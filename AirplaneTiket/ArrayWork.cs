using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirplaneTiket
{
    public partial class ArrayWork : UserControl
    {
        public ArrayWork()
        {
            InitializeComponent();
        }

        private void LoadData()
        {

            bd bd = new bd();

            bd.openBD();

            string query = "SELECT id_worker, FIO, login, gender, phone_nomber, name_specialisation FROM `worker`,`specialisation` WHERE worker.specialisation_id_specialisation = specialisation.id_specialisation";
            MySqlCommand command = new MySqlCommand(query, bd.conn);
            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[7]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
            }
            reader.Close();

            bd.closeBD();

            foreach (string[] s in data)
                guna2DataGridView1.Rows.Add(s);
        }

        private void ArrayWork_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
