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
    public partial class ArrayUser : UserControl
    {
        public int row;
        public CultureInfo culture = new CultureInfo("ru-ru");
        public ArrayUser()
        {
            InitializeComponent();
        }

        private void LoadData()
        {

            bd bd = new bd();

            bd.openBD();

            string query = "SELECT id_user, login, FIO, gender ,phone_nomber,mail, date_birth FROM `user` WHERE 1";
            MySqlCommand command = new MySqlCommand(query, bd.conn);
            MySqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
;
            while (reader.Read())
            {
                data.Add(new string[7]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = Convert.ToDateTime(reader[6]).ToString("dd.MM.yyyy", culture);
            }
            reader.Close();

            bd.closeBD();

            foreach (string[] s in data)
                guna2DataGridView1.Rows.Add(s);
        }
        private void ArrayUser_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            bd bd = new bd();

            bd.openBD();
            
            string query = "UPDATE `evdokCvc`.`user` SET `FIO` = @fio, `login` = @login , `gender` = @gender, `phone_nomber` = @phone, `mail` = @mail, `date_birth` = '"+ Convert.ToDateTime(guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[6].Value).ToString("yyyy.MM.dd", culture) + "' where `id_user` = " + guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            MySqlCommand command = new MySqlCommand(query, bd.conn);

            command.Parameters.Add("@login", MySqlDbType.VarChar, 45);
            command.Parameters["@login"].Value = guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            command.Parameters.Add("@fio", MySqlDbType.VarChar, 45);
            command.Parameters["@fio"].Value = guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            command.Parameters.Add("@gender", MySqlDbType.VarChar, 5);
            command.Parameters["@gender"].Value = guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            command.Parameters.Add("@phone", MySqlDbType.UInt64, 11);
            command.Parameters["@phone"].Value = guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
            command.Parameters.Add("@mail", MySqlDbType.VarChar, 11);
            command.Parameters["@mail"].Value = guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[5].Value.ToString();

            command.ExecuteNonQuery();
            bd.closeBD();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex + 1;
            label1.Text = "Выбрана строка: " + row.ToString();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            InsertUser insertUser = new InsertUser();
            insertUser.ShowDialog();
            guna2DataGridView1.Rows.Clear();
            LoadData();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DialogResult resualt = MessageBox.Show("Подтвердить удаление?", "Удалить", MessageBoxButtons.YesNo);
            if (resualt == DialogResult.Yes)
            {
                bd bd = new bd();
                bd.openBD();
                string query = "DELETE FROM `evdokCvc`.`user` where id_user = " + guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                MySqlCommand command = new MySqlCommand(query, bd.conn);
                command.ExecuteNonQuery();
                bd.closeBD();
                guna2DataGridView1.Rows.Clear();
                LoadData();
            }
        }

    }
}
