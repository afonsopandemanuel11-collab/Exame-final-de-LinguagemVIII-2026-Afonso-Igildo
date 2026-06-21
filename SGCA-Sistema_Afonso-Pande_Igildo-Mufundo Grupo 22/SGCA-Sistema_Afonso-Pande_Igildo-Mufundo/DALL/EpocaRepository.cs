using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Interfaces;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Models;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Enums;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.DALL
{
    public class EpocaRepository : IRepositorio<EpocaAgricola>
    {
        public void Inserir(EpocaAgricola e)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = @"
                INSERT INTO epocas_agricolas (nome, tipo, ano, data_inicio, data_fim, encerrada)
                VALUES (@Nome, @Tipo, @Ano, @Inicio, @Fim, 0)";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Nome", e.Nome);
            cmd.Parameters.AddWithValue("@Tipo", (int)e.Tipo);
            cmd.Parameters.AddWithValue("@Ano", e.Ano);
            cmd.Parameters.AddWithValue("@Inicio", e.DataInicio.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Fim", e.DataFim.ToString("yyyy-MM-dd"));
            cmd.ExecuteNonQuery();
        }

        public EpocaAgricola? ObterPorId(int id)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "SELECT * FROM epocas_agricolas WHERE id = @Id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            using var reader = cmd.ExecuteReader();
            return reader.Read() ? MapearLinha(reader) : null;
        }

        public IEnumerable<EpocaAgricola> ObterTodos()
        {
            var lista = new List<EpocaAgricola>();
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "SELECT * FROM epocas_agricolas ORDER BY ano DESC, data_inicio DESC";
            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) lista.Add(MapearLinha(reader));
            return lista;
        }

        public IEnumerable<EpocaAgricola> ObterAbertas()
        {
            var lista = new List<EpocaAgricola>();
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "SELECT * FROM epocas_agricolas WHERE encerrada=0 ORDER BY ano DESC";
            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) lista.Add(MapearLinha(reader));
            return lista;
        }

        public void Actualizar(EpocaAgricola e)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = @"
                UPDATE epocas_agricolas SET
                    nome       = @Nome,
                    tipo       = @Tipo,
                    ano        = @Ano,
                    data_inicio= @Inicio,
                    data_fim   = @Fim,
                    encerrada  = @Enc
                WHERE id = @Id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", e.Id);
            cmd.Parameters.AddWithValue("@Nome", e.Nome);
            cmd.Parameters.AddWithValue("@Tipo", (int)e.Tipo);
            cmd.Parameters.AddWithValue("@Ano", e.Ano);
            cmd.Parameters.AddWithValue("@Inicio", e.DataInicio.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Fim", e.DataFim.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Enc", e.Encerrada ? 1 : 0);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "DELETE FROM epocas_agricolas WHERE id=@Id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }

        public void EncerrarEpoca(int id)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "UPDATE epocas_agricolas SET encerrada=1 WHERE id=@Id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }

        private static EpocaAgricola MapearLinha(MySqlDataReader r)
        {
            var tipoValor = r["tipo"];
            TipoEpoca tipo = tipoValor switch
            {
                int i => (TipoEpoca)i,
                string s when Enum.TryParse<TipoEpoca>(s, true, out var parsed) => parsed,
                _ => TipoEpoca.Chuvas
            };

            return new EpocaAgricola
            {
                Id = r.GetInt32("id"),
                Nome = r.GetString("nome"),
                Tipo = tipo,
                Ano = r.GetInt32("ano"),
                DataInicio = r.GetDateTime("data_inicio"),
                DataFim = r.GetDateTime("data_fim"),
                Encerrada = r.GetBoolean("encerrada"),
            };
        }
    }
}
