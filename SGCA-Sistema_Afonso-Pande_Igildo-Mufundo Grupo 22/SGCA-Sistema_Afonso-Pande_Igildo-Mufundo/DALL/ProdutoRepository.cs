using MySql.Data.MySqlClient;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Interfaces;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Models;
using System;
using System.Collections.Generic;
using System.Text;
namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.DALL
{
    public class ProdutoRepository :IRepositorio<ProdutoAgricola>
    {
        public void Inserir(ProdutoAgricola p)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = @"
                INSERT INTO produtos_agricolas (codigo, nome, unidade_medida, categoria_id, activo)
                VALUES (@Codigo, @Nome, @Unidade, @CatId, 1)";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Codigo", p.Codigo);
            cmd.Parameters.AddWithValue("@Nome", p.Nome);
            cmd.Parameters.AddWithValue("@Unidade", p.UnidadeMedida);
            cmd.Parameters.AddWithValue("@CatId", p.CategoriaId);
            cmd.ExecuteNonQuery();
        }

        public ProdutoAgricola? ObterPorId(int id)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "SELECT * FROM produtos_agricolas WHERE id = @Id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            using var reader = cmd.ExecuteReader();
            return reader.Read() ? MapearLinha(reader) : null;
        }

        public IEnumerable<ProdutoAgricola> ObterTodos()
        {
            var lista = new List<ProdutoAgricola>();
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "SELECT * FROM produtos_agricolas ORDER BY nome";
            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) lista.Add(MapearLinha(reader));
            return lista;
        }

        public IEnumerable<ProdutoAgricola> ObterActivos()
        {
            var lista = new List<ProdutoAgricola>();
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "SELECT * FROM produtos_agricolas WHERE activo=1 ORDER BY nome";
            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) lista.Add(MapearLinha(reader));
            return lista;
        }

        public void Actualizar(ProdutoAgricola p)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = @"
                UPDATE produtos_agricolas SET
                    codigo        = @Codigo,
                    nome          = @Nome,
                    unidade_medida= @Unidade,
                    categoria_id  = @CatId,
                    activo        = @Activo
                WHERE id = @Id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", p.Id);
            cmd.Parameters.AddWithValue("@Codigo", p.Codigo);
            cmd.Parameters.AddWithValue("@Nome", p.Nome);
            cmd.Parameters.AddWithValue("@Unidade", p.UnidadeMedida);
            cmd.Parameters.AddWithValue("@CatId", p.CategoriaId);
            cmd.Parameters.AddWithValue("@Activo", p.Activo ? 1 : 0);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "UPDATE produtos_agricolas SET activo=0 WHERE id=@Id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }

        private static ProdutoAgricola MapearLinha(MySqlDataReader r) => new()
        {
            Id = r.GetInt32("id"),
            Codigo = r.GetString("codigo"),
            Nome = r.GetString("nome"),
            UnidadeMedida = r.GetString("unidade_medida"),
            CategoriaId = r.GetInt32("categoria_id"),
            Activo = r.GetBoolean("activo"),
        };
    }
}
