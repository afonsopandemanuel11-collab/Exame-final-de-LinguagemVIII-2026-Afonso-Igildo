using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Models;
using MySql.Data.MySqlClient;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.DALL
{
    public class CategoriaProdutoRepository
    {
        public IEnumerable<CategoriaProduto> ObterTodos()
        {
            var lista = new List<CategoriaProduto>();
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "SELECT * FROM categorias_produto ORDER BY nome";
            using var cmd = new MySqlCommand(sql, conn);
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
                lista.Add(Mapear(rd));
            return lista;
        }

        public CategoriaProduto? ObterPorId(int id)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "SELECT * FROM categorias_produto WHERE id = @id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var rd = cmd.ExecuteReader();
            return rd.Read() ? Mapear(rd) : null;
        }

        public void Inserir(CategoriaProduto categoria)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "INSERT INTO categorias_produto (nome, descricao) VALUES (@nome, @descricao)";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nome",      categoria.Nome);
            cmd.Parameters.AddWithValue("@descricao", (object?)categoria.Descricao ?? DBNull.Value);
            cmd.ExecuteNonQuery();
            categoria.Id = (int)cmd.LastInsertedId;
        }

        public void Actualizar(CategoriaProduto categoria)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "UPDATE categorias_produto SET nome = @nome, descricao = @descricao WHERE id = @id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nome",      categoria.Nome);
            cmd.Parameters.AddWithValue("@descricao", (object?)categoria.Descricao ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@id",        categoria.Id);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "DELETE FROM categorias_produto WHERE id = @id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        private static CategoriaProduto Mapear(MySqlDataReader rd) => new()
        {
            Id        = rd.GetInt32("id"),
            Nome      = rd.GetString("nome"),
            Descricao = rd.IsDBNull(rd.GetOrdinal("descricao")) ? null : rd.GetString("descricao"),
        };
    }
}
