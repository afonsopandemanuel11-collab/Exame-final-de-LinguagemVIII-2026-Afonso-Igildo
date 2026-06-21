# AUDITORIA TÉCNICA + PLANO DE IMPLEMENTAÇÃO — SGCA

## Contexto

Sistema de Gestão de Cooperativa Agrícola (SGCA) — C# .NET 10 Windows Forms + MySQL + ADO.NET.

---

## FASE 1 — RELATÓRIO DE AUDITORIA TÉCNICA

### ✅ Funcionalidades Concluídas e Funcionais

| Módulo | Estado |
|---|---|
| Login e autenticação | ✅ Funcional |
| Ecrã de ligação (splash) com teste de BD | ✅ Funcional |
| Dashboard com 4 indicadores (Coops, Produtos, Entregas, Épocas) | ✅ Funcional |
| Gestão de Cooperativistas (Inserir, Editar, Desactivar, Pesquisar, Exportar CSV/PDF) | ✅ Funcional |
| Gestão de Produtos (Inserir, Editar, Inactivar, Pesquisar, Exportar CSV/PDF) | ✅ Funcional |
| Gestão de Épocas (Inserir, Editar, Encerrar, Pesquisar, Exportar CSV/PDF) | ✅ Funcional |
| Gestão de Preços (Definir, Eliminar, Pesquisa por época, Exportar CSV/PDF) | ✅ Funcional |
| Gestão de Entregas (Inserir, Eliminar, Filtros avançados, Exportar CSV/PDF) | ✅ Funcional |
| Comercialização e Distribuição de Lucros (Calcular, Distribuir, Exportar) | ✅ Funcional |
| Relatório de Distribuição (por época, com totais, Exportar CSV/PDF) | ✅ Funcional |
| Sistema de estilos unificado (classe `Estilo`) | ✅ Funcional |
| Exportação CSV com metadados de instituição | ✅ Funcional |
| Exportação PDF básica (gerador próprio, sem bibliotecas externas) | ✅ Funcional mas **limitado** |
| Permissões por perfil de utilizador | ✅ Funcional |
| Sistema de sessão (Sessao.cs) | ✅ Funcional |
| Navegação MDI corrigida (dashboard oculta ao abrir formulários filhos) | ✅ Funcional (corrigido) |
| Menus (Cadastros, Operações, Relatórios, Sistema) todos associados | ✅ Funcional |

---

### ⚠️ Funcionalidades Incompletas ou Ausentes

| Problema | Prioridade |
|---|---|
| **Dashboard** — faltam indicadores: Total Comercializações, Total Lucros Distribuídos | ALTA |
| **Dashboard** — falta secção de "Últimas atividades" ou "Resumo recente" | MÉDIA |
| **Dashboard** — o modelo `EstatisticasDashboard` não tem campos para Comercializações nem Lucros | ALTA |
| **EstatisticasRepository** — não consulta tabela `comercializacoes` nem `distribuicoes_lucro` | ALTA |
| **FrmEntregas** — sem botão "Editar entrega" (só Inserir e Eliminar) | ALTA |
| **Exportação PDF** — gerador manual com posicionamento fixo: sem paginação, sem rodapé com nº página, fontes limitadas a Helvetica | ALTA |
| **Exportação PDF** — cabeçalho sem formatação visual, sem separadores gráficos, linha de dados pode sair da página | ALTA |
| **GestorCooperativa.cs** — importação duplicada: `using System.Collections.Generic;` aparece 2 vezes | BAIXA |
| **Categorias de Produto** — sem formulário de gestão de categorias (CRUD ausente) | MÉDIA |
| **FrmProdutos** — categoria gravada com id=1 se `cmbCategoria.SelectedItem` for nulo (fallback pouco robusto) | MÉDIA |
| **FrmCadCooperativista / FrmCadEntrega** — não analisados nesta auditoria (ficheiros de cadastro individual) | PENDENTE |

---

### 🐛 Bugs e Problemas Técnicos

| Bug | Localização |
|---|---|
| `pnlDashboard` com `Dock=Fill` encobria a área MDI → filhos invisíveis | Corrigido |
| `GestorCooperativa.cs` linha 9: `using System.Collections.Generic;` duplicado | `GestorCooperativa.cs` |
| `FrmEntregas.cs` linha 48: `cmbFiltroCooperativista.SelectedValue!` com `!` — pode lançar `NullReferenceException` se combo vazio | `FrmEntregas.cs:48` |
| `ExportadorPdf` — `y < 60 break` abandona registos sem paginação — dados truncados em relatórios longos | `ExportadorPdf.cs:34` |
| `ExportadorPdf` — encoding ASCII perde caracteres PT (ã, ç, é, etc.) | `ExportadorPdf.cs:71` |
| `Sessao.cs` importa namespace `Modelos` (com "o") que não existe como pasta — deverá ser `Models` | `Sessao.cs:1` |

---

### 📋 Divergências com Requisitos Típicos de TCC/Projeto Final

| Requisito | Estado |
|---|---|
| CRUD completo de Categorias de Produto | ❌ Não implementado |
| Dashboard com ≥ 6 indicadores operacionais | ⚠️ Só 4 (faltam Comercializações e Lucros) |
| PDF profissional com cabeçalho, rodapé e paginação | ⚠️ PDF básico sem paginação |
| Histórico/listagem de Comercializações | ⚠️ Parcial (apenas no Relatório) |
| Edição de Entregas | ❌ Ausente |

---

## FASE 2 — PLANO DE IMPLEMENTAÇÃO

### Itens a Implementar

---

### Módulo 1 — Model + Repository (Dashboard)

#### [MODIFY] [EstatisticasDashboard.cs](file:///c:/Users/Afonso%20Manuel/3D%20Objects/00/SGCA-Sistema_Afonso-Pande_Igildo-Mufundo/SGCA-Sistema_Afonso-Pande_Igildo-Mufundo/Models/EstatisticasDashboard.cs)
- Adicionar `TotalComercializacoes` e `TotalLucrosDistribuidos`

#### [MODIFY] [EstatisticasRepository.cs](file:///c:/Users/Afonso%20Manuel/3D%20Objects/00/SGCA-Sistema_Afonso-Pande_Igildo-Mufundo/SGCA-Sistema_Afonso-Pande_Igildo-Mufundo/DALL/EstatisticasRepository.cs)
- Adicionar consultas para `comercializacoes` e `distribuicoes_lucro`

---

### Módulo 2 — Dashboard (FrmPrincipal)

#### [MODIFY] [FrmPrincipal.cs](file:///c:/Users/Afonso%20Manuel/3D%20Objects/00/SGCA-Sistema_Afonso-Pande_Igildo-Mufundo/SGCA-Sistema_Afonso-Pande_Igildo-Mufundo/Forms/FrmPrincipal.cs) + Designer
- Adicionar 2 cards: Comercializações e Lucros Distribuídos
- Adicionar labels `lblValorCom` e `lblValorLucros` no Dashboard
- Ajustar método `ActualizarDashboard()` para preencher novos campos

> [!IMPORTANT]
> Os novos controles serão adicionados ao Designer.cs (não por código dinâmico).

---

### Módulo 3 — Edição de Entregas

#### [MODIFY] [FrmEntregas.cs](file:///c:/Users/Afonso%20Manuel/3D%20Objects/00/SGCA-Sistema_Afonso-Pande_Igildo-Mufundo/SGCA-Sistema_Afonso-Pande_Igildo-Mufundo/Forms/FrmEntregas.cs)
- Adicionar botão "Editar" associado a evento que abre `FrmCadEntrega` com dados

#### [MODIFY] [FrmEntregas.Designer.cs](file:///c:/Users/Afonso%20Manuel/3D%20Objects/00/SGCA-Sistema_Afonso-Pande_Igildo-Mufundo/SGCA-Sistema_Afonso-Pande_Igildo-Mufundo/Forms/FrmEntregas.Designer.cs)
- Inserir botão `btnEditarEntrega` na barra de ações

#### [MODIFY] [FrmCadEntrega.cs](file:///c:/Users/Afonso%20Manuel/3D%20Objects/00/SGCA-Sistema_Afonso-Pande_Igildo-Mufundo/SGCA-Sistema_Afonso-Pande_Igildo-Mufundo/Forms/FrmCadEntrega.cs)
- Verificar e adicionar construtor com parâmetro `Entrega` para modo edição

#### [MODIFY] [EntregaRepository.cs](file:///c:/Users/Afonso%20Manuel/3D%20Objects/00/SGCA-Sistema_Afonso-Pande_Igildo-Mufundo/SGCA-Sistema_Afonso-Pande_Igildo-Mufundo/DALL/EntregaRepository.cs)
- Verificar existência de método `Actualizar()` e adicionar se ausente

---

### Módulo 4 — Exportação PDF Profissional

#### [MODIFY] [ExportadorPdf.cs](file:///c:/Users/Afonso%20Manuel/3D%20Objects/00/SGCA-Sistema_Afonso-Pande_Igildo-Mufundo/SGCA-Sistema_Afonso-Pande_Igildo-Mufundo/Utils/ExportadorPdf.cs)
Reestruturar completamente o gerador PDF para incluir:
- **Cabeçalho**: Nome da instituição, nome do sistema, data, hora, utilizador
- **Separador visual** (linha horizontal)
- **Tabela com colunas alinhadas** (cálculo dinâmico de larguras)
- **Rodapé por página**: número de página / total de páginas, data de geração
- **Paginação automática**: nova página quando `y < margem_inferior`
- **Encoding Latin-1** para suportar caracteres portugueses (ã, ç, é)
- **Linha de totais/resumo** ao fundo do relatório

---

### Módulo 5 — Correção de Bugs

#### [MODIFY] [GestorCooperativa.cs](file:///c:/Users/Afonso%20Manuel/3D%20Objects/00/SGCA-Sistema_Afonso-Pande_Igildo-Mufundo/SGCA-Sistema_Afonso-Pande_Igildo-Mufundo/Services/GestorCooperativa.cs)
- Remover `using System.Collections.Generic;` duplicado

#### [MODIFY] [Sessao.cs](file:///c:/Users/Afonso Manuel\3D Objects\00\SGCA-Sistema_Afonso-Pande_Igildo-Mufundo\SGCA-Sistema_Afonso-Pande_Igildo-Mufundo\Utils\Sessao.cs)
- Verificar namespace correto da classe `Utilizador` (deve ser `Services` ou `Models`)

---

## Questões em Aberto

> [!IMPORTANT]
> **CRUD de Categorias**: Deve ser adicionado um formulário de gestão de categorias de produto (`FrmCategorias`)? Ou as categorias são geridas diretamente dentro do `FrmProdutos` (combobox de categorias existentes)?

> [!IMPORTANT]
> **Edição de Entregas**: O `FrmCadEntrega` existe mas ainda não foi analisado. Antes de implementar o botão de editar, confirmar se o construtor com parâmetro já existe ou se precisa ser criado.

> [!NOTE]
> **PDF sem bibliotecas externas**: O sistema gera PDFs manualmente (sem iTextSharp, FastReport, etc.) para evitar dependências. Esta abordagem será mantida com melhorias no gerador existente.

---

## Plano de Verificação

### Testes automatizados
```
dotnet build
```

### Verificação manual por módulo
1. Dashboard: confirmar 6 indicadores visíveis e correctos
2. Entregas: confirmar botão Editar funcional
3. PDF: gerar PDF de Cooperativistas, Entregas e Relatório — verificar cabeçalho, rodapé, paginação e caracteres PT
4. Menus: testar todos os itens do menu principal
5. Atalhos Dashboard: testar todos os botões de atalho rápido
