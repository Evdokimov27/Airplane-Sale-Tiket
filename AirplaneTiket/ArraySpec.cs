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
    public partial class ArraySpec : UserControl
    {
        int row;
        public ArraySpec()
        {
            InitializeComponent();
        }
        private void LoadData()
        {

            bd bd = new bd();

            bd.openBD();

            string query = "SELECT id_specialisation, name_specialisation FROM `specialisation`";
            MySqlCommand command = new MySqlCommand(query, bd.conn);
            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[7]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
            }
            reader.Close();

            bd.closeBD();

            foreach (string[] s in data)
                guna2DataGridView1.Rows.Add(s);
        }
        private void ArraySpec_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text != "")
            {
                bd bd = new bd();

                bd.openBD();
                string query = "INSERT INTO `evdokCvc`.`specialisation` (`id_specialisation` ,`name_specialisation`) VALUES(NULL, @spec)";
                MySqlCommand command = new MySqlCommand(query, bd.conn);

                command.Parameters.Add("@spec", MySqlDbType.VarChar, 45);
                command.Parameters["@spec"].Value = guna2TextBox1.Text;

                command.ExecuteNonQuery();
                bd.closeBD();
                guna2DataGridView1.Rows.Clear();
                LoadData();
            }
            else MessageBox.Show("Введите название специальности!");
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            bd bd = new bd();

            bd.openBD();

            string query = "UPDATE `evdokCvc`.`specialisation` SET `name_specialisation` = @spec where id_specialisation = " + guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            MySqlCommand command = new MySqlCommand(query, bd.conn);

            command.Parameters.Add("@spec", MySqlDbType.VarChar, 45);
            command.Parameters["@spec"].Value = guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[1].Value.ToString();

            command.ExecuteNonQuery();
            bd.closeBD();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DialogResult resualt = MessageBox.Show("Подтвердить удаление?", "Удалить", MessageBoxButtons.YesNo);
            if (resualt == DialogResult.Yes)
            {
                bd bd = new bd();
                bd.openBD();
                string query = "DELETE FROM `evdokCvc`.`specialisation` where id_specialisation = " + guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                MySqlCommand command = new MySqlCommand(query, bd.conn);
                command.ExecuteNonQuery();
                bd.closeBD();
                guna2DataGridView1.Rows.Clear();
                LoadData();
            }
        }
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex + 1;
            label1.Text = "Выбрана строка: " + row.ToString();
        }

    }
}
