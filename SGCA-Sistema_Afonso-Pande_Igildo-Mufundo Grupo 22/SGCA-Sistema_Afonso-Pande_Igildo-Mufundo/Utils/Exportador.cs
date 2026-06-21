using System.Text;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Utils
{
    public static class Exportador
    {
        public const string Instituicao = "SGCA — Sistema de Gestão de Cooperativa Agrícola";
        public const string SubtituloInstituicao = "IPUKV 2025/2026";

        public static bool ExportarCsv(DataGridView grid, string nomeFicheiroSugerido)
        {
            if (grid.Rows.Count == 0)
            {
                MessageBox.Show("Não existem dados para exportar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            using var sfd = new SaveFileDialog
            {
                Filter = "Ficheiro CSV (*.csv)|*.csv",
                FileName = nomeFicheiroSugerido
            };

            if (sfd.ShowDialog() != DialogResult.OK) return false;

            var sb = new StringBuilder();
            sb.AppendLine($"{Instituicao};{SubtituloInstituicao}");
            sb.AppendLine($"Data;{DateTime.Now:dd/MM/yyyy HH:mm}");
            sb.AppendLine($"Utilizador;{Sessao.UtilizadorActual?.Nome ?? "—"}");
            sb.AppendLine();

            var headers = grid.Columns.Cast<DataGridViewColumn>()
                .Where(c => c.Visible)
                .Select(c => c.HeaderText);
            sb.AppendLine(string.Join(";", headers));

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.IsNewRow) continue;
                var cells = row.Cells.Cast<DataGridViewCell>()
                    .Where(c => c.OwningColumn.Visible)
                    .Select(c => EscaparCsv(c.Value?.ToString()));
                sb.AppendLine(string.Join(";", cells));
            }

            File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));
            MessageBox.Show("Dados exportados com sucesso.", "Exportação CSV",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        public static bool ExportarPdf(DataGridView grid, string titulo, string nomeFicheiroSugerido,
            IEnumerable<string>? linhasResumo = null)
        {
            if (grid.Rows.Count == 0)
            {
                MessageBox.Show("Não existem dados para exportar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            using var sfd = new SaveFileDialog
            {
                Filter = "Ficheiro PDF (*.pdf)|*.pdf",
                FileName = nomeFicheiroSugerido
            };

            if (sfd.ShowDialog() != DialogResult.OK) return false;

            var colunas = grid.Columns.Cast<DataGridViewColumn>().Where(c => c.Visible).ToList();
            var linhas = new List<string[]>();

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.IsNewRow) continue;
                linhas.Add(colunas.Select(c => row.Cells[c.Index].Value?.ToString() ?? "").ToArray());
            }

            var cabecalho = new List<string>
            {
                Instituicao,
                SubtituloInstituicao,
                titulo,
                $"Data: {DateTime.Now:dd/MM/yyyy HH:mm}",
                $"Utilizador: {Sessao.UtilizadorActual?.Nome ?? "—"}"
            };

            if (linhasResumo != null)
                cabecalho.AddRange(linhasResumo);

            ExportadorPdf.Gerar(sfd.FileName, cabecalho, colunas.Select(c => c.HeaderText).ToArray(), linhas);

            MessageBox.Show("Relatório PDF gerado com sucesso.", "Exportação PDF",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        private static string EscaparCsv(string? valor)
        {
            if (string.IsNullOrEmpty(valor)) return "";
            return valor.Replace(";", ",").Replace("\r", " ").Replace("\n", " ");
        }
    }
}
