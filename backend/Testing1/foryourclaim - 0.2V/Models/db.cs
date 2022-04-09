using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Extensions.Configuration;
namespace foryourclaim___0._2V.Models
{
    public class db
    {
        //create an instance for connection string
        SqlConnection con;
        //create constractur for making database connection
        public db()
        {
            var configuration = GetConfiguration();
            con = new SqlConnection(configuration.GetSection("Data").GetSection("ConnectionString").Value);
            con.Open();
        }
        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
        public int logincheck(WebMaster ad)
        {
            SqlCommand com = new SqlCommand("webmasterLogin",con);
            com.CommandType = CommandType.StoredProcedure ;
            com.Parameters.AddWithValue("@Username",ad.username);
            com.Parameters.AddWithValue("@Password", ad.password);
            SqlParameter oblogin = new SqlParameter();
            oblogin.ParameterName ="@Isvalid";
            oblogin.SqlDbType = SqlDbType.Bit;
            oblogin.Direction = ParameterDirection.Output;
            com.Parameters.Add(oblogin);
            com.ExecuteNonQuery();
            int res = Convert.ToInt32(oblogin.Value);
            con.Close();
            return res;

        }
        
    }
}
