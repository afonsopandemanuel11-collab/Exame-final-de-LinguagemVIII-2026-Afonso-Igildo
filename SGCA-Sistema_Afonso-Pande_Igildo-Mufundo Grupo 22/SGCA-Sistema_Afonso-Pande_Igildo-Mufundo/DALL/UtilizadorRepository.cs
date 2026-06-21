
using MySql.Data.MySqlClient;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Modelos;




namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.DALL
{
    public class UtilizadorRepository
    {
        public Utilizador? Autenticar(string username, string password)
        {
            using var conn = ConexaoBD.ObterConexao();
            conn.Open();

            const string sql = @"
                SELECT id, nome, username, perfil
                FROM utilizadores
                WHERE username = @user
                  AND password = @pass
                  AND ativo   = 1";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@user", username);
            cmd.Parameters.AddWithValue("@pass", password);

            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;

            return new Utilizador
            {
                Id = reader.GetInt32("id"),
                Nome = reader.GetString("nome"),
                Username = reader.GetString("username"),
                Perfil = reader.GetString("perfil"),
            };
        }
    }
}
