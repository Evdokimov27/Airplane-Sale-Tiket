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
    public partial class ArrayAirs : UserControl
    {
        int row;
        public ArrayAirs()
        {
            InitializeComponent();
        }

        private void LoadData()
        {

            bd bd = new bd();

            bd.openBD();

            string query = "SELECT id_airplane,model, firm, amount_places FROM `airplane` where id_airplane > 0";
            MySqlCommand command = new MySqlCommand(query, bd.conn);
            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[5]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
            }
            reader.Close();

            bd.closeBD();

            foreach (string[] s in data)
                guna2DataGridView1.Rows.Add(s);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DialogResult resualt = MessageBox.Show("Подтвердить удаление?", "Удалить", MessageBoxButtons.YesNo);
            if (resualt == DialogResult.Yes)
            {
                bd bd = new bd();
                bd.openBD();
                string query = "DELETE FROM `evdokCvc`.`airplane` where id_airplane = " + guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                MySqlCommand command = new MySqlCommand(query, bd.conn);
                command.ExecuteNonQuery();
                bd.closeBD();
                guna2DataGridView1.Rows.Clear();
                LoadData();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            InsertAirs insertAirs = new InsertAirs();
            insertAirs.ShowDialog();
            guna2DataGridView1.Rows.Clear();
            LoadData();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            bd bd = new bd();

            bd.openBD();

            string query = "UPDATE `evdokCvc`.`airplane` SET `model` = @model, `firm` = @firm , `amount_places` = @amount_places where `id_airplane` = " + guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            MySqlCommand command = new MySqlCommand(query, bd.conn);

            command.Parameters.Add("@model", MySqlDbType.VarChar, 45);
            command.Parameters["@model"].Value = guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            command.Parameters.Add("@firm", MySqlDbType.VarChar, 45);
            command.Parameters["@firm"].Value = guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            command.Parameters.Add("@amount_places", MySqlDbType.Int64, 5);
            command.Parameters["@amount_places"].Value = guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[3].Value.ToString();

            command.ExecuteNonQuery();
            bd.closeBD();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex + 1;
            label1.Text = "Выбрана строка: " + row.ToString();
        }

        private void ArrayAirs_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
