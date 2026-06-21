using System.Text;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Utils
{
    /// <summary>
    /// Gerador de PDF profissional com cabeçalho institucional, paginação e rodapé.
    /// Utiliza o formato PDF 1.4 com fontes Type1 (Helvetica / Helvetica-Bold).
    /// Os caracteres acentuados são transliterados para compatibilidade com ISO-8859-1.
    /// </summary>
    internal static class ExportadorPdf
    {
        private const float LarguraPagina  = 842f;  // A4 landscape
        private const float AlturaPagina   = 595f;
        private const float MargemEsquerda = 36f;
        private const float MargemDireita  = 36f;
        private const float MargemSuperior = 36f;
        private const float MargemInferior = 36f;

        private const float TamFonteTitulo  = 13f;
        private const float TamFonteSubtit  = 9f;
        private const float TamFonteCorp    = 8f;
        private const float TamFonteRodape  = 7f;
        private const float AlturaLinhaHead = 16f;
        private const float AlturaLinhaCorp = 11f;
        private const float AlturaRodape    = 18f;

        // ──────────────────────────────────────────────────────────────────────
        public static void Gerar(
            string       caminho,
            IList<string> linhasCabecalho,
            string[]     colunas,
            IList<string[]> linhas)
        {
            // Calcular largura de cada coluna
            float areaUtil   = LarguraPagina - MargemEsquerda - MargemDireita;
            float largCol    = colunas.Length > 0 ? areaUtil / colunas.Length : areaUtil;

            // Dividir linhas em páginas
            float yInicio    = AlturaPagina - MargemSuperior;
            float alturaHead = AlturaLinhaHead * (linhasCabecalho.Count + 2); // título + subtítulo + espaço
            float areaCorpo  = yInicio - alturaHead - AlturaRodape - MargemInferior;
            int linhasPorPag = Math.Max(1, (int)(areaCorpo / AlturaLinhaCorp));

            int totalPags = Math.Max(1, (int)Math.Ceiling((double)linhas.Count / linhasPorPag));

            // ── Construir objectos PDF ─────────────────────────────────────────
            var sb = new StringBuilder();
            sb.AppendLine("%PDF-1.4");
            // Marca de binário (compatibilidade)
            sb.AppendLine("%\xe2\xe3\xcf\xd3");

            var objectOffsets = new List<int>();

            // Referências das páginas serão resolvidas depois
            var pageRefs = new List<string>();
            for (int p = 0; p < totalPags; p++)
                pageRefs.Add($"{4 + p * 2} 0 R");   // obj 4,6,8...

            // ── Obj 1: Catalog ────────────────────────────────────────────────
            objectOffsets.Add(sb.Length);
            sb.AppendLine("1 0 obj");
            sb.AppendLine("<< /Type /Catalog /Pages 2 0 R >>");
            sb.AppendLine("endobj");

            // ── Obj 2: Pages (Kids preenchidos depois) ────────────────────────
            // Guardar posição para reescrever depois — usamos marcador substituível
            objectOffsets.Add(sb.Length);
            sb.AppendLine("2 0 obj");
            sb.AppendLine($"<< /Type /Pages /Kids [{string.Join(" ", pageRefs)}] /Count {totalPags} >>");
            sb.AppendLine("endobj");

            // ── Obj 3: Font F1 (Helvetica) ────────────────────────────────────
            objectOffsets.Add(sb.Length);
            sb.AppendLine("3 0 obj");
            sb.AppendLine("<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica /Encoding /WinAnsiEncoding >>");
            sb.AppendLine("endobj");

            // ── Obj 4: Font F2 (Helvetica-Bold) ──────────────────────────────
            objectOffsets.Add(sb.Length);
            sb.AppendLine("4 0 obj");
            sb.AppendLine("<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica-Bold /Encoding /WinAnsiEncoding >>");
            sb.AppendLine("endobj");

            int proximoObj = 5; // próximo objecto livre (páginas e streams)

            var pageObjNums   = new List<int>();
            var streamObjNums = new List<int>();

            for (int pagina = 0; pagina < totalPags; pagina++)
            {
                int numStream = proximoObj;
                streamObjNums.Add(numStream);
                proximoObj++;

                int numPage = proximoObj;
                pageObjNums.Add(numPage);
                proximoObj++;

                // Slice de linhas desta página
                int inicio = pagina * linhasPorPag;
                int fim    = Math.Min(inicio + linhasPorPag, linhas.Count);
                var linhasPag = new List<string[]>();
                for (int i = inicio; i < fim; i++)
                    linhasPag.Add(linhas[i]);

                string conteudo = MontarConteudo(
                    linhasCabecalho, colunas, linhasPag,
                    pagina + 1, totalPags,
                    largCol, areaUtil);

                // Stream
                objectOffsets.Add(sb.Length);
                sb.AppendLine($"{numStream} 0 obj");
                sb.AppendLine($"<< /Length {conteudo.Length} >>");
                sb.AppendLine("stream");
                sb.Append(conteudo);
                sb.AppendLine("endstream");
                sb.AppendLine("endobj");

                // Page
                objectOffsets.Add(sb.Length);
                sb.AppendLine($"{numPage} 0 obj");
                sb.AppendLine($"<< /Type /Page /Parent 2 0 R " +
                              $"/MediaBox [0 0 {LarguraPagina} {AlturaPagina}] " +
                              $"/Contents {numStream} 0 R " +
                              $"/Resources << /Font << /F1 3 0 R /F2 4 0 R >> >> >>");
                sb.AppendLine("endobj");
            }

            // ── Cross-reference table ─────────────────────────────────────────
            int xrefPos = sb.Length;
            sb.AppendLine("xref");
            sb.AppendLine($"0 {objectOffsets.Count + 1}");
            sb.AppendLine("0000000000 65535 f ");
            foreach (var off in objectOffsets)
                sb.AppendLine($"{off:D10} 00000 n ");

            sb.AppendLine("trailer");
            sb.AppendLine($"<< /Size {objectOffsets.Count + 1} /Root 1 0 R >>");
            sb.AppendLine("startxref");
            sb.AppendLine(xrefPos.ToString());
            sb.AppendLine("%%EOF");

            // Escrever usando Latin-1 (Windows-1252) para suportar acentos
            File.WriteAllText(caminho, sb.ToString(), Encoding.Latin1);
        }

        // ──────────────────────────────────────────────────────────────────────
        private static string MontarConteudo(
            IList<string> cabecalho,
            string[]      colunas,
            IList<string[]> linhas,
            int pagina, int totalPags,
            float largCol, float areaUtil)
        {
            var s   = new StringBuilder();
            float y = AlturaPagina - MargemSuperior;

            // ── Linha verde de topo ────────────────────────────────────────────
            s.AppendLine("q");
            s.AppendLine($"0.106 0.227 0.176 rg");   // #1B3A2D
            s.AppendLine($"{MargemEsquerda} {y - 26} {areaUtil} 26 re f");
            s.AppendLine("Q");

            // Título principal (branco sobre verde)
            s.AppendLine("q");
            s.AppendLine("1 1 1 rg");
            if (cabecalho.Count > 0)
                EscreverTexto(s, Limpar(cabecalho[0]), "F2", TamFonteTitulo, MargemEsquerda + 6, y - 18);
            // Data + Utilizador à direita
            string dataHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            string utilizador = Sessao.UtilizadorActual?.Nome ?? "-";
            string infoDir = $"{dataHora}  |  {Limpar(utilizador)}";
            float xDir = LarguraPagina - MargemDireita - (infoDir.Length * 4.5f);
            EscreverTexto(s, infoDir, "F1", TamFonteRodape + 1, xDir, y - 18);
            s.AppendLine("Q");

            y -= 30;

            // ── Subtítulo e linhas do cabeçalho ───────────────────────────────
            s.AppendLine("0.271 0.271 0.271 rg");  // cinzento escuro
            for (int i = 1; i < cabecalho.Count; i++)
            {
                EscreverTexto(s, Limpar(cabecalho[i]), "F1", TamFonteSubtit, MargemEsquerda, y);
                y -= AlturaLinhaHead - 4;
            }

            y -= 6;

            // ── Linha separadora ──────────────────────────────────────────────
            s.AppendLine("q");
            s.AppendLine("0.106 0.227 0.176 rg");
            s.AppendLine($"{MargemEsquerda} {y} {areaUtil} 1.5 re f");
            s.AppendLine("Q");
            y -= 8;

            // ── Cabeçalho das colunas ─────────────────────────────────────────
            s.AppendLine("q");
            s.AppendLine("0.929 0.972 0.933 rg");   // verde muito suave
            s.AppendLine($"{MargemEsquerda} {y - AlturaLinhaCorp + 2} {areaUtil} {AlturaLinhaCorp + 2} re f");
            s.AppendLine("Q");

            s.AppendLine("0.106 0.227 0.176 rg");
            for (int c = 0; c < colunas.Length; c++)
            {
                float xCol = MargemEsquerda + c * largCol;
                string txt = Truncar(Limpar(colunas[c]), largCol - 4, TamFonteCorp);
                EscreverTexto(s, txt, "F2", TamFonteCorp, xCol + 2, y);
            }
            y -= AlturaLinhaCorp + 4;

            // ── Linhas de dados ───────────────────────────────────────────────
            bool alternar = false;
            s.AppendLine("0.071 0.071 0.071 rg");

            foreach (var linha in linhas)
            {
                if (alternar)
                {
                    s.AppendLine("q");
                    s.AppendLine("0.957 0.980 0.965 rg");
                    s.AppendLine($"{MargemEsquerda} {y - AlturaLinhaCorp + 2} {areaUtil} {AlturaLinhaCorp} re f");
                    s.AppendLine("Q");
                    s.AppendLine("0.071 0.071 0.071 rg");
                }
                alternar = !alternar;

                for (int c = 0; c < colunas.Length && c < linha.Length; c++)
                {
                    float xCol = MargemEsquerda + c * largCol;
                    string txt = Truncar(Limpar(linha[c] ?? ""), largCol - 4, TamFonteCorp);
                    EscreverTexto(s, txt, "F1", TamFonteCorp, xCol + 2, y);
                }
                y -= AlturaLinhaCorp;
            }

            // ── Linha inferior ────────────────────────────────────────────────
            s.AppendLine("q");
            s.AppendLine("0.627 0.824 0.667 rg");   // #A0D2AA
            s.AppendLine($"{MargemEsquerda} {MargemInferior + AlturaRodape} {areaUtil} 1 re f");
            s.AppendLine("Q");

            // ── Rodapé ────────────────────────────────────────────────────────
            s.AppendLine("0.549 0.549 0.549 rg");
            string rodapeEsq = $"SGCA - Sistema de Gestao de Cooperativa Agricola  |  IPUKV 2025/2026";
            string rodapeDir = $"Pagina {pagina} de {totalPags}";
            EscreverTexto(s, rodapeEsq, "F1", TamFonteRodape, MargemEsquerda, MargemInferior + 6);

            float xRodapeDir = LarguraPagina - MargemDireita - (rodapeDir.Length * 4.0f);
            EscreverTexto(s, rodapeDir, "F1", TamFonteRodape, xRodapeDir, MargemInferior + 6);

            return s.ToString();
        }

        private static void EscreverTexto(StringBuilder s, string texto, string fonte, float tam, float x, float y)
        {
            s.AppendLine("BT");
            s.AppendLine($"/{fonte} {tam} Tf");
            s.AppendLine($"{x:F1} {y:F1} Td");
            s.AppendLine($"({EscaparPdf(texto)}) Tj");
            s.AppendLine("ET");
        }

        private static string EscaparPdf(string texto)
        {
            return texto
                .Replace("\\", "\\\\")
                .Replace("(", "\\(")
                .Replace(")", "\\)")
                .Replace("\r", "")
                .Replace("\n", " ");
        }

        // Transliteração de caracteres acentuados para Windows-1252
        private static string Limpar(string? texto)
        {
            if (string.IsNullOrEmpty(texto)) return "";
            var sb = new StringBuilder(texto.Length);
            foreach (char c in texto)
            {
                // Windows-1252 suporta directamente os acentos portugueses
                // basta garantir que o char é representável
                if (c < 256)
                    sb.Append(c);
                else
                    sb.Append('?');
            }
            return sb.ToString();
        }

        // Trunca texto para caber na coluna (estimativa: ~5px por char em 8pt)
        private static string Truncar(string texto, float largMaxima, float tamFonte)
        {
            float charWidth = tamFonte * 0.55f;
            int maxChars = (int)(largMaxima / charWidth);
            if (maxChars <= 0) return "";
            if (texto.Length <= maxChars) return texto;
            return texto[..(maxChars - 1)] + "~";
        }
    }
}
