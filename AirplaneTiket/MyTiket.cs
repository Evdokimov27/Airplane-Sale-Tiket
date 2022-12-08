using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace AirplaneTiket
{
    public partial class MyTiket : UserControl
    {
        public CultureInfo culture = new CultureInfo("ru-ru");
        bd bd = new bd();
        public int id;
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

            string query = "SELECT id_tiket, departure, arrival, time_departure, tiket_price, confirm FROM `tiket`,`flight` WHERE `tiket`.`id_flight` = `flight`.`id_flight` and `tiket`.`user_id` = @userid";

            MySqlCommand command = new MySqlCommand(query, bd.conn);
            command.Parameters.Add("@userid", MySqlDbType.Int32, 11);
            command.Parameters["@userid"].Value = Tiket.sets.id;
            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[6]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = Convert.ToDateTime(reader[3]).ToString("dd.MM.yyyy HH:mm", culture);
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = Convert.ToBoolean(reader[5]).ToString();

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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            bd bd = new bd();

            bd.openBD();
            DialogResult resualt = MessageBox.Show("Вы точно хотите отменить билет?", "Отмена билета", MessageBoxButtons.YesNo);
            if (resualt == DialogResult.Yes)
            {
                string query = "DELETE FROM `tiket` WHERE id_tiket = " + guna2DataGridView1[0, guna2DataGridView1.CurrentRow.Index].Value.ToString() + " and user_id = " + id;
                MySqlCommand command = new MySqlCommand(query, bd.conn);
                command.ExecuteNonQuery();
                guna2DataGridView1.Rows.Clear();
                LoadData();
            }
            
            bd.closeBD();
        }
    }
}
