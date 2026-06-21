using MySql.Data.MySqlClient;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Models;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.DALL
{
    public class EstatisticasRepository
    {
        public EstatisticasDashboard ObterEstatisticas()
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();

            var stats = new EstatisticasDashboard
            {
                TotalCooperativistasActivos = ExecutarContagem(conn,
                    "SELECT COUNT(*) FROM cooperativistas WHERE activo = 1"),
                TotalProdutosActivos = ExecutarContagem(conn,
                    "SELECT COUNT(*) FROM produtos_agricolas WHERE activo = 1"),
                TotalEntregas = ExecutarContagem(conn,
                    "SELECT COUNT(*) FROM entregas"),
                EpocasAbertas = ExecutarContagem(conn,
                    "SELECT COUNT(*) FROM epocas_agricolas WHERE encerrada = 0"),
                TotalEpocas = ExecutarContagem(conn,
                    "SELECT COUNT(*) FROM epocas_agricolas"),
                TotalComercializacoes = ExecutarContagem(conn,
                    "SELECT COUNT(*) FROM comercializacoes"),
                EntregasMesActual = ExecutarContagem(conn,
                    "SELECT COUNT(*) FROM entregas WHERE MONTH(data_entrega) = MONTH(CURDATE()) AND YEAR(data_entrega) = YEAR(CURDATE())"),
            };

            stats.SomaQuotasActivas = ExecutarDecimal(conn,
                "SELECT COALESCE(SUM(quota_percent), 0) FROM cooperativistas WHERE activo = 1");

            stats.TotalLucrosDistribuidos = ExecutarDecimal(conn,
                "SELECT COALESCE(SUM(valor_lucro), 0) FROM distribuicoes_lucro");

            stats.EpocaActual = ExecutarTexto(conn,
                "SELECT nome FROM epocas_agricolas WHERE encerrada = 0 ORDER BY ano DESC, data_inicio DESC LIMIT 1");

            stats.ActividadesRecentes = ObterActividadesRecentes(conn);

            return stats;
        }

        private static List<ActividadeRecente> ObterActividadesRecentes(MySqlConnection conn)
        {
            var lista = new List<ActividadeRecente>();
            string sql = @"
                (SELECT 'Entrega' AS tipo, e.data_entrega AS data, CONCAT(c.nome, ' entregou ', e.quantidade, ' de ', p.nome) AS descricao
                 FROM entregas e
                 JOIN cooperativistas c ON e.cooperativista_id = c.id
                 JOIN produtos_agricolas p ON e.produto_id = p.id)
                UNION ALL
                (SELECT 'Distribuição' AS tipo, d.data_distribuicao AS data, CONCAT(c.nome, ' recebeu ', d.valor_lucro, ' AOA (', d.quota_aplicada, '%)') AS descricao
                 FROM distribuicoes_lucro d
                 JOIN cooperativistas c ON d.cooperativista_id = c.id)
                ORDER BY data DESC
                LIMIT 5";

            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new ActividadeRecente
                {
                    Tipo = reader.GetString("tipo"),
                    Data = reader.GetDateTime("data"),
                    Descricao = reader.GetString("descricao")
                });
            }
            return lista;
        }

        private static int ExecutarContagem(MySqlConnection conn, string sql)
        {
            using var cmd = new MySqlCommand(sql, conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private static decimal ExecutarDecimal(MySqlConnection conn, string sql)
        {
            using var cmd = new MySqlCommand(sql, conn);
            return Convert.ToDecimal(cmd.ExecuteScalar());
        }

        private static string? ExecutarTexto(MySqlConnection conn, string sql)
        {
            using var cmd = new MySqlCommand(sql, conn);
            return cmd.ExecuteScalar()?.ToString();
        }
    }
}
