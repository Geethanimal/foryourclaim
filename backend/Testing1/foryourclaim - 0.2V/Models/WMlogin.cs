using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace foryourclaim___0._2V.Models
{
    public class WMlogin:db
    {
        public int logincheck(WebMaster ad)
        {
            SqlCommand com = new SqlCommand("webmasterLogin", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Username", ad.username);
            com.Parameters.AddWithValue("@Password", ad.password);
            SqlParameter oblogin = new SqlParameter();
            oblogin.ParameterName = "@Isvalid";
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
