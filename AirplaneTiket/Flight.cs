using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirplaneTiket
{
    public partial class Flight : Form
    {
        public CultureInfo culture = new CultureInfo("ru-ru");
        bd bd = new bd();
        public Flight()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            bd.openBD();

            string query = "SELECT airplane.model, time_departure, departure, arrival FROM `airplane`,`flight` WHERE airplane.id_airplane = flight.id_airplane";

            MySqlCommand command = new MySqlCommand(query, bd.conn);
            command.Parameters.Add("@userid", MySqlDbType.Int32, 11);
            command.Parameters["@userid"].Value = Tiket.sets.id;
            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[6]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = Convert.ToDateTime(reader[1]).ToString("dd.MM.yyyy", culture);
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
            }

            reader.Close();

            bd.closeBD();

            foreach (string[] s in data)
                guna2DataGridView1.Rows.Add(s);
        }
        private void Flight_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
