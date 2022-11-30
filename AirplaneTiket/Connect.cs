using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneTiket
{
    internal class bd
    {
        public static MySqlConnection conn = new MySqlConnection("server=triniti.ru-hoster.com; uid=evdokCvc;port=3306;pwd=993eq1RmAc;database=evdokCvc;");

        public void openBD()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
        }
        public void closeBD()
        {
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();    
        }
    }
}
