using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class KetNoi
    {
        protected SqlConnection conn = null;

        public void OpenConn()
        {
            try
            {
                if (conn == null)
                    conn = new SqlConnection(ConfigurationManager.ConnectionStrings["KetNoi"].ToString());
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }

        public void CloseConn()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
    }
}
