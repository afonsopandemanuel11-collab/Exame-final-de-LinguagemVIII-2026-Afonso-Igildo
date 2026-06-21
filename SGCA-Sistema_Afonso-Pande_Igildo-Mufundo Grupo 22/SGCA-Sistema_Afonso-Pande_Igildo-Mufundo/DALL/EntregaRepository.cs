using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Interfaces;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Models;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Text;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.DALL
{
    public class EntregaRepository : IRepositorio<Entrega>
    {
        public void Inserir(Entrega e)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = @"
                INSERT INTO entregas
                    (cooperativista_id, produto_id, epoca_id, data_entrega, quantidade, observacoes)
                VALUES (@CoopId, @ProdId, @EpocaId, @Data, @Qtd, @Obs)";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@CoopId", e.CooperativistaId);
            cmd.Parameters.AddWithValue("@ProdId", e.ProdutoId);
            cmd.Parameters.AddWithValue("@EpocaId", e.EpocaId);
            cmd.Parameters.AddWithValue("@Data", e.DataEntrega.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Qtd", e.Quantidade);
            cmd.Parameters.AddWithValue("@Obs", (object?)e.Observacoes ?? DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        public Entrega? ObterPorId(int id)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "SELECT * FROM entregas WHERE id=@Id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            using var reader = cmd.ExecuteReader();
            return reader.Read() ? MapearLinha(reader) : null;
        }

        public IEnumerable<Entrega> ObterTodos()
        {
            var lista = new List<Entrega>();
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "SELECT * FROM entregas ORDER BY data_entrega DESC";
            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) lista.Add(MapearLinha(reader));
            return lista;
        }

        public IEnumerable<Entrega> ObterPorEpoca(int epocaId)
        {
            var lista = new List<Entrega>();
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "SELECT * FROM entregas WHERE epoca_id=@EId ORDER BY data_entrega";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@EId", epocaId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) lista.Add(MapearLinha(reader));
            return lista;
        }

        public IEnumerable<Entrega> ObterPorCooperativistaEEpoca(int coopId, int epocaId)
        {
            var lista = new List<Entrega>();
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = @"
                SELECT * FROM entregas
                WHERE cooperativista_id=@CId AND epoca_id=@EId
                ORDER BY data_entrega";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@CId", coopId);
            cmd.Parameters.AddWithValue("@EId", epocaId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) lista.Add(MapearLinha(reader));
            return lista;
        }

        public void Actualizar(Entrega e)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = @"
                UPDATE entregas SET
                    cooperativista_id = @CoopId,
                    produto_id        = @ProdId,
                    epoca_id          = @EpocaId,
                    data_entrega      = @Data,
                    quantidade        = @Qtd,
                    observacoes       = @Obs
                WHERE id = @Id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", e.Id);
            cmd.Parameters.AddWithValue("@CoopId", e.CooperativistaId);
            cmd.Parameters.AddWithValue("@ProdId", e.ProdutoId);
            cmd.Parameters.AddWithValue("@EpocaId", e.EpocaId);
            cmd.Parameters.AddWithValue("@Data", e.DataEntrega.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Qtd", e.Quantidade);
            cmd.Parameters.AddWithValue("@Obs", (object?)e.Observacoes ?? DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "DELETE FROM entregas WHERE id=@Id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }

        private static Entrega MapearLinha(MySqlDataReader r) => new()
        {
            Id = r.GetInt32("id"),
            CooperativistaId = r.GetInt32("cooperativista_id"),
            ProdutoId = r.GetInt32("produto_id"),
            EpocaId = r.GetInt32("epoca_id"),
            DataEntrega = r.GetDateTime("data_entrega"),
            Quantidade = r.GetDecimal("quantidade"),
            Observacoes = r.IsDBNull(r.GetOrdinal("observacoes")) ? null : r.GetString("observacoes"),
        };
    }
}
