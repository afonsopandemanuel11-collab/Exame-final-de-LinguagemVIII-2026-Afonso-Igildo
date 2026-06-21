using MySql.Data.MySqlClient;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Interfaces;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Models;
using System;
using System.Collections.Generic;
using System.Text;
namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.DALL
{
    public class ComercializacaoRepository : IRepositorio<Comercializacao>
    {
        public void Inserir(Comercializacao c)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = @"
                INSERT INTO comercializacoes (epoca_id, data_venda, descricao)
                VALUES (@EpocaId, @Data, @Desc);
                SELECT LAST_INSERT_ID();";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@EpocaId", c.EpocaId);
            cmd.Parameters.AddWithValue("@Data", c.DataVenda.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Desc", (object?)c.Descricao ?? DBNull.Value);
            var newId = Convert.ToInt32(cmd.ExecuteScalar());
            c.Id = newId;
        }

        public Comercializacao? ObterPorId(int id)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "SELECT * FROM comercializacoes WHERE id=@Id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            using var reader = cmd.ExecuteReader();
            return reader.Read() ? MapearLinha(reader) : null;
        }

        public IEnumerable<Comercializacao> ObterTodos()
        {
            var lista = new List<Comercializacao>();
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "SELECT * FROM comercializacoes ORDER BY data_venda DESC";
            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) lista.Add(MapearLinha(reader));
            return lista;
        }

        public void AssociarEntrega(int comercializacaoId, int entregaId)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = @"
                INSERT IGNORE INTO comercializacao_entregas (comercializacao_id, entrega_id)
                VALUES (@CId, @EId)";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@CId", comercializacaoId);
            cmd.Parameters.AddWithValue("@EId", entregaId);
            cmd.ExecuteNonQuery();
        }

        public void Actualizar(Comercializacao c)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = @"
                UPDATE comercializacoes SET
                    epoca_id   = @EpocaId,
                    data_venda = @Data,
                    descricao  = @Desc
                WHERE id = @Id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", c.Id);
            cmd.Parameters.AddWithValue("@EpocaId", c.EpocaId);
            cmd.Parameters.AddWithValue("@Data", c.DataVenda.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Desc", (object?)c.Descricao ?? DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "DELETE FROM comercializacoes WHERE id=@Id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }

        private static Comercializacao MapearLinha(MySqlDataReader r) => new()
        {
            Id = r.GetInt32("id"),
            EpocaId = r.GetInt32("epoca_id"),
            DataVenda = r.GetDateTime("data_venda"),
            Descricao = r.IsDBNull(r.GetOrdinal("descricao")) ? null : r.GetString("descricao"),
        };
    }
}
