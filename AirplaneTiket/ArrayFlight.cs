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
    public partial class ArrayFlight : UserControl
    {
        int row;
        public ArrayFlight()
        {
            InitializeComponent();
        }

        private void LoadData()
        {

            bd bd = new bd();

            bd.openBD();

            string query = "SELECT id_flight,id_airplane, time_departure, departure, arrival FROM `flight`";
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
            }
            reader.Close();

            bd.closeBD();

            foreach (string[] s in data)
                guna2DataGridView1.Rows.Add(s);
        }

        private void ArrayFlight_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex + 1;
            label1.Text = "Выбрана строка: " + row.ToString();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            InsertFlight insertFlight = new InsertFlight();
            insertFlight.ShowDialog();
            guna2DataGridView1.Rows.Clear();
            LoadData();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            bd bd = new bd();

            bd.openBD();

            string query = "UPDATE `evdokCvc`.`flight` SET `id_airplane` = @id_airplane, `time_departure` = @time_departure , `departure` = @departure, `arrival` = @arrival where `id_flight` = " + guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            MySqlCommand command = new MySqlCommand(query, bd.conn);

            command.Parameters.Add("@id_airplane", MySqlDbType.Int64, 45);
            command.Parameters["@id_airplane"].Value = guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            command.Parameters.Add("@time_departure", MySqlDbType.Date, 45);
            command.Parameters["@time_departure"].Value = guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            command.Parameters.Add("@departure", MySqlDbType.VarChar, 45);
            command.Parameters["@departure"].Value = guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            command.Parameters.Add("@arrival", MySqlDbType.VarChar, 45);
            command.Parameters["@arrival"].Value = guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[4].Value.ToString();

            command.ExecuteNonQuery();
            bd.closeBD();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(guna2DataGridView1.CurrentRow.Index.ToString());
            DialogResult resualt = MessageBox.Show("Подтвердить удаление?", "Удалить", MessageBoxButtons.YesNo);
            if (resualt == DialogResult.Yes)
            {
                bd bd = new bd();
                bd.openBD();
                string query = "DELETE FROM `evdokCvc`.`flight` where id_flight = " + guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                MySqlCommand command = new MySqlCommand(query, bd.conn);
                command.ExecuteNonQuery();
                bd.closeBD();
                guna2DataGridView1.Rows.Clear();
                LoadData();
            }
        }
    }
}
