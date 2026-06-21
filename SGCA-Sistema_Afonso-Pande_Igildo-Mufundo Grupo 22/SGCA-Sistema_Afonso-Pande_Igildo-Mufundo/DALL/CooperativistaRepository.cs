using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Exceptions;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.DALL
{
   public class CooperativistaRepository
    { // ── INSERT ──────────────────────────────────────────────────────────
        public void Inserir(Cooperativista c)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = @"
                INSERT INTO cooperativistas
                    (nome, numero_socio, bilhete_id, telefone, email,
                     quota_percent, data_adesao, activo)
                VALUES
                    (@Nome, @NumeroSocio, @BilheteId, @Telefone, @Email,
                     @Quota, @DataAdesao, 1)";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Nome", c.Nome);
            cmd.Parameters.AddWithValue("@NumeroSocio", c.NumeroSocio);
            cmd.Parameters.AddWithValue("@BilheteId", c.BilheteId);
            cmd.Parameters.AddWithValue("@Telefone", (object?)c.Telefone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", (object?)c.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Quota", c.QuotaPercent);
            cmd.Parameters.AddWithValue("@DataAdesao", c.DataAdesao.ToString("yyyy-MM-dd"));
            cmd.ExecuteNonQuery();
        }

        // ── SELECT por ID ────────────────────────────────────────────────────
        public Cooperativista? ObterPorId(int id)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "SELECT * FROM cooperativistas WHERE id = @Id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            using var reader = cmd.ExecuteReader();
            if (!reader.Read())
                throw new CooperativistaNaoEncontradaException(
                    $"Cooperativista com ID {id} não encontrado.");
            return MapearLinha(reader);
        }

        // ── SELECT todos ─────────────────────────────────────────────────────
        public IEnumerable<Cooperativista> ObterTodos()
        {
            var lista = new List<Cooperativista>();
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "SELECT * FROM cooperativistas ORDER BY nome";
            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) lista.Add(MapearLinha(reader));
            return lista;
        }

        // ── SELECT só activos ─────────────────────────────────────────────────
        public IEnumerable<Cooperativista> ObterActivos()
        {
            var lista = new List<Cooperativista>();
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "SELECT * FROM cooperativistas WHERE activo = 1 ORDER BY nome";
            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) lista.Add(MapearLinha(reader));
            return lista;
        }

        // ── UPDATE ───────────────────────────────────────────────────────────
        public void Actualizar(Cooperativista c)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = @"
                UPDATE cooperativistas SET
                    nome          = @Nome,
                    numero_socio  = @NumeroSocio,
                    bilhete_id    = @BilheteId,
                    telefone      = @Telefone,
                    email         = @Email,
                    quota_percent = @Quota,
                    data_adesao   = @DataAdesao,
                    activo        = @Activo
                WHERE id = @Id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", c.Id);
            cmd.Parameters.AddWithValue("@Nome", c.Nome);
            cmd.Parameters.AddWithValue("@NumeroSocio", c.NumeroSocio);
            cmd.Parameters.AddWithValue("@BilheteId", c.BilheteId);
            cmd.Parameters.AddWithValue("@Telefone", (object?)c.Telefone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", (object?)c.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Quota", c.QuotaPercent);
            cmd.Parameters.AddWithValue("@DataAdesao", c.DataAdesao.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Activo", c.Activo ? 1 : 0);
            cmd.ExecuteNonQuery();
        }

        // ── DELETE (soft delete) ──────────────────────────────────────────────
        public void Eliminar(int id)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "UPDATE cooperativistas SET activo = 0 WHERE id = @Id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }

        // ── Verificar número de sócio duplicado ──────────────────────────────
        public bool NumeroSocioExiste(string numeroSocio, int excluirId = 0)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "SELECT COUNT(*) FROM cooperativistas WHERE numero_socio = @N AND id <> @Id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@N", numeroSocio);
            cmd.Parameters.AddWithValue("@Id", excluirId);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        // ── Soma das quotas dos activos ───────────────────────────────────────
        public decimal SomaQuotasActivas(int excluirId = 0)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();
            const string sql = "SELECT COALESCE(SUM(quota_percent),0) FROM cooperativistas WHERE activo=1 AND id<>@Id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", excluirId);
            return Convert.ToDecimal(cmd.ExecuteScalar());
        }

        // ── MAPEAMENTO ────────────────────────────────────────────────────────
        private static Cooperativista MapearLinha(MySqlDataReader r) => new()
        {
            Id = r.GetInt32("id"),
            Nome = r.GetString("nome"),
            NumeroSocio = r.GetString("numero_socio"),
            BilheteId = r.GetString("bilhete_id"),
            Telefone = r.IsDBNull(r.GetOrdinal("telefone")) ? null : r.GetString("telefone"),
            Email = r.IsDBNull(r.GetOrdinal("email")) ? null : r.GetString("email"),
            QuotaPercent = r.GetDecimal("quota_percent"),
            DataAdesao = r.GetDateTime("data_adesao"),
            Activo = r.GetBoolean("activo"),
        };
    }
}
