using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Crud1.Infra
{
    public static class Database
    {
        public static DataSet ExecutarComandoSql(string comando)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet dataSet = new DataSet();

            try
            {
                using (SqlConnection cnn = new SqlConnection(WebConfigurationManager.AppSettings["ConexaoBD"].ToString()))
                {
                    cmd.Connection = cnn;
                    cmd.CommandText = @"" + comando;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection.Open();
                    var adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dataSet);
                    SqlDataReader reader = cmd.ExecuteReader();
                }

                return dataSet;
            }
            catch (SqlException ex)
            {
                cmd.Connection.Close();
                throw new Exception("Ocorreu um erro no banco de dados: " + ex.Message);
            }
            finally
            {
                cmd.Connection.Close();0
            }
        }
    }
}