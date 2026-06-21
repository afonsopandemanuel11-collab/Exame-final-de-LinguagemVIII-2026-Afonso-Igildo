using MySql.Data.MySqlClient;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Interfaces;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Models;
using System;
using System.Collections.Generic;
using System.Text;
namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.DALL
{
    public class DistribuicaoRepository : IRepositorio<DistribuicaoLucro>
    {
        public void Inserir(DistribuicaoLucro d)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = @"
                INSERT INTO distribuicoes_lucro
                    (cooperativista_id, comercializacao_id, valor_apurado,
                     valor_lucro, quota_aplicada, data_distribuicao)
                VALUES (@CoopId, @ComId, @Apurado, @Lucro, @Quota, @Data)
                ON DUPLICATE KEY UPDATE
                    valor_apurado  = @Apurado,
                    valor_lucro    = @Lucro,
                    quota_aplicada = @Quota";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@CoopId", d.CooperativistaId);
            cmd.Parameters.AddWithValue("@ComId", d.ComercializacaoId);
            cmd.Parameters.AddWithValue("@Apurado", d.ValorApurado);
            cmd.Parameters.AddWithValue("@Lucro", d.ValorLucro);
            cmd.Parameters.AddWithValue("@Quota", d.QuotaAplicada);
            cmd.Parameters.AddWithValue("@Data", d.DataDistribuicao.ToString("yyyy-MM-dd"));
            cmd.ExecuteNonQuery();
        }

        public DistribuicaoLucro? ObterPorId(int id)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "SELECT * FROM distribuicoes_lucro WHERE id=@Id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            using var reader = cmd.ExecuteReader();
            return reader.Read() ? MapearLinha(reader) : null;
        }

        public IEnumerable<DistribuicaoLucro> ObterTodos()
        {
            var lista = new List<DistribuicaoLucro>();
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "SELECT * FROM distribuicoes_lucro ORDER BY data_distribuicao DESC";
            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) lista.Add(MapearLinha(reader));
            return lista;
        }

        public IEnumerable<DistribuicaoLucro> ObterPorComercializacao(int comercializacaoId)
        {
            var lista = new List<DistribuicaoLucro>();
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = @"
                SELECT dl.*, c.nome AS nome_coop
                FROM distribuicoes_lucro dl
                JOIN cooperativistas c ON c.id = dl.cooperativista_id
                WHERE dl.comercializacao_id = @ComId
                ORDER BY dl.valor_lucro DESC";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ComId", comercializacaoId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var d = MapearLinha(reader);
                d.Cooperativista = new Models.Cooperativista
                {
                    Id = d.CooperativistaId,
                    Nome = reader.GetString("nome_coop"),
                };
                lista.Add(d);
            }
            return lista;
        }

        public void Actualizar(DistribuicaoLucro d)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = @"
                UPDATE distribuicoes_lucro SET
                    valor_apurado  = @Apurado,
                    valor_lucro    = @Lucro,
                    quota_aplicada = @Quota
                WHERE id = @Id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", d.Id);
            cmd.Parameters.AddWithValue("@Apurado", d.ValorApurado);
            cmd.Parameters.AddWithValue("@Lucro", d.ValorLucro);
            cmd.Parameters.AddWithValue("@Quota", d.QuotaAplicada);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "DELETE FROM distribuicoes_lucro WHERE id=@Id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }

        private static DistribuicaoLucro MapearLinha(MySqlDataReader r) => new()
        {
            Id = r.GetInt32("id"),
            CooperativistaId = r.GetInt32("cooperativista_id"),
            ComercializacaoId = r.GetInt32("comercializacao_id"),
            ValorApurado = r.GetDecimal("valor_apurado"),
            ValorLucro = r.GetDecimal("valor_lucro"),
            QuotaAplicada = r.GetDecimal("quota_aplicada"),
            DataDistribuicao = r.GetDateTime("data_distribuicao"),
        };
    }
}
