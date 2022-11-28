using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AirplaneTiket
{
    public partial class Worker : UserControl
    {
        public Worker()
        {
            InitializeComponent();
            LoadData();
        }

        private void Worker_Load(object sender, EventArgs e)
        {
        }
        private void LoadData()
        {

            MySqlConnection conn = new MySqlConnection("server=triniti.ru-hoster.com; uid=evdokCvc;port=3306;pwd=993eq1RmAc;database=evdokCvc;");

            conn.Open();

            string query = "SELECT id_tiket, CONCAT(name,' ', family,' ', patronymic), departure, arrival, time_departure, time_arrival, tiket_price, confirm FROM `tiket`,`user` where `id_user` = `user_id`";
            MySqlCommand command = new MySqlCommand(query, conn);
            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[8]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6]= reader[6].ToString();
                data[data.Count - 1][7] = Convert.ToBoolean(reader[7]).ToString();

            }

            reader.Close();

            conn.Close();

            foreach (string[] s in data)
            guna2DataGridView1.Rows.Add(s);
        }
        private void getCheckBox()
        {
            DataGridViewCheckBoxCell ch3 = new DataGridViewCheckBoxCell();
            ch3 = (DataGridViewCheckBoxCell)guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[7];
            if (ch3.Value == null)
                ch3.Value = false;

            switch (ch3.Value.ToString())
            {
                case "True":
                    ch3.Value = false;
                    break;
                case "False":
                    ch3.Value = true;
                    break;
            }


           MySqlConnection conn = new MySqlConnection("server=triniti.ru-hoster.com; uid=evdokCvc;port=3306;pwd=993eq1RmAc;database=evdokCvc;");
       
           conn.Open();
       
           string query = "UPDATE `tiket` SET `confirm` = " + Convert.ToInt32(ch3.Value) + " WHERE `tiket`.`id_tiket` = " + guna2DataGridView1[0, guna2DataGridView1.CurrentRow.Index].Value.ToString();
           MySqlCommand command = new MySqlCommand(query, conn);
            //command.ExecuteNonQuery();
            MessageBox.Show(Convert.ToInt32(ch3.Value).ToString());

        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            getCheckBox();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
