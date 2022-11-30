using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace AirplaneTiket
{
    public partial class MyTiket : UserControl
    {
        bd bd = new bd();

        public MyTiket()
        {
            InitializeComponent();
            
        }

        private void MyTiket_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            bd.openBD();

            string query = "SELECT departure, arrival, time_departure, tiket_price, confirm FROM `tiket`,`flight` WHERE `tiket`.`id_flight` = `flight`.`id_flight` and `tiket`.`user_id` = @userid";

            MySqlCommand command = new MySqlCommand(query, bd.conn);
            command.Parameters.Add("@userid", MySqlDbType.Int32, 11);
            command.Parameters["@userid"].Value = Tiket.sets.id;
            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[5]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = Convert.ToBoolean(reader[4]).ToString();

            }

            reader.Close();

            bd.closeBD();

            foreach (string[] s in data)
                guna2DataGridView1.Rows.Add(s);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Clear();
            LoadData();
        }
    }
}
