using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.DALL
{
    static  class ConexaoBD
    {
       
             private const string obterdados =
            "server=localhost;" +
            "port=3306;" +
            "database=cooperativa_agricola;" +
            "uid=root;" +
             "password=;";
        public static MySqlConnection ObterConexao()
        => new MySqlConnection(obterdados);

        public static bool TestarConexao() {

            try
            {using var conn= ObterConexao();
                conn.Open();
                return true;
            }
            catch {
                return false;
            
            
            }

                }

    }
}
