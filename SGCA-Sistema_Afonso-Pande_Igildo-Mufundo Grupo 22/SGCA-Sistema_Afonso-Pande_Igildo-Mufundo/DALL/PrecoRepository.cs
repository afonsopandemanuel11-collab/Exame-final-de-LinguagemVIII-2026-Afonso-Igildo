using MySql.Data.MySqlClient;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Interfaces;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.DALL
{
    public class PrecoRepository : IRepositorio<PrecoComercializacao>
    {
        public void Inserir(PrecoComercializacao p)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = @"
                INSERT INTO precos_comercializacao (produto_id, epoca_id, preco_unitario, data_definicao)
                VALUES (@ProdId, @EpocaId, @Preco, @Data)
                ON DUPLICATE KEY UPDATE preco_unitario=@Preco, data_definicao=@Data";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ProdId", p.ProdutoId);
            cmd.Parameters.AddWithValue("@EpocaId", p.EpocaId);
            cmd.Parameters.AddWithValue("@Preco", p.PrecoUnitario);
            cmd.Parameters.AddWithValue("@Data", p.DataDefinicao.ToString("yyyy-MM-dd"));
            cmd.ExecuteNonQuery();
        }

        public PrecoComercializacao? ObterPorId(int id)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "SELECT * FROM precos_comercializacao WHERE id=@Id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            using var reader = cmd.ExecuteReader();
            return reader.Read() ? MapearLinha(reader) : null;
        }

        /// <summary>Obtém o preço de um produto para uma época específica.</summary>
        public PrecoComercializacao? ObterPreco(int produtoId, int epocaId)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = @"
                SELECT * FROM precos_comercializacao
                WHERE produto_id=@ProdId AND epoca_id=@EpocaId";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ProdId", produtoId);
            cmd.Parameters.AddWithValue("@EpocaId", epocaId);
            using var reader = cmd.ExecuteReader();
            return reader.Read() ? MapearLinha(reader) : null;
        }

        public IEnumerable<PrecoComercializacao> ObterTodos()
        {
            var lista = new List<PrecoComercializacao>();
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "SELECT * FROM precos_comercializacao ORDER BY epoca_id, produto_id";
            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) lista.Add(MapearLinha(reader));
            return lista;
        }

        public IEnumerable<PrecoComercializacao> ObterPorEpoca(int epocaId)
        {
            var lista = new List<PrecoComercializacao>();
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "SELECT * FROM precos_comercializacao WHERE epoca_id=@EId ORDER BY produto_id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@EId", epocaId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) lista.Add(MapearLinha(reader));
            return lista;
        }

        public void Actualizar(PrecoComercializacao p)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = @"
                UPDATE precos_comercializacao SET
                    preco_unitario = @Preco,
                    data_definicao = @Data
                WHERE produto_id=@ProdId AND epoca_id=@EpocaId";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Preco", p.PrecoUnitario);
            cmd.Parameters.AddWithValue("@Data", p.DataDefinicao.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@ProdId", p.ProdutoId);
            cmd.Parameters.AddWithValue("@EpocaId", p.EpocaId);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "DELETE FROM precos_comercializacao WHERE id=@Id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }

        private static PrecoComercializacao MapearLinha(MySqlDataReader r) => new()
        {
            Id = r.GetInt32("id"),
            ProdutoId = r.GetInt32("produto_id"),
            EpocaId = r.GetInt32("epoca_id"),
            PrecoUnitario = r.GetDecimal("preco_unitario"),
            DataDefinicao = r.GetDateTime("data_definicao"),
        };
    }
}
