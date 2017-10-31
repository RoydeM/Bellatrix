using Bellatrix.Core;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Bellatrix.Infrastructure.AdoNetRepository
{
    public class AdoNetRepository : IRepository
    {
        public IDbDataParameter CreateParameter(string name, object value)
        {
            return new SqlParameter(name, value);
        }

        public void Execute(string sql, params IDbDataParameter[] para)
        {
            string server = ConfigurationManager.AppSettings["DbLoggerServer"];
            string path = ConfigurationManager.AppSettings["DbLoggerPath"];
            string cnnString = "Data Source=" + server + ";AttachDbFilename=" + path + ";Integrated Security=True;Connect Timeout=30;User Instance=True";
            SqlConnection cnn = null;
            SqlCommand cmd;
            try
            {
                cnn = new SqlConnection(cnnString);
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);
                foreach (IDbDataParameter p in para)
                {
                    cmd.Parameters.Add(p);
                }
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (cnn != null)
                {
                    if (cnn.State != ConnectionState.Closed)
                    {
                        cnn.Close();
                    }
                    cnn = null;
                }
            }
        }
    }
}