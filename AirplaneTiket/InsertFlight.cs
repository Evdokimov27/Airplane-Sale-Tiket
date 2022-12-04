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
    public partial class InsertFlight : Form
    {
        public InsertFlight()
        {
            InitializeComponent();
            CustomFormat();
        }
        public void CustomFormat()
        {
            // Set the Format type and the CustomFormat string.
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {

            int reg;
            bd bd = new bd();
            bd.openBD();
            string sql = "INSERT INTO `evdokCvc`.`flight` (`id_flight`, `id_airplane`, `time_departure`, `departure`, `arrival`) VALUES (NULL, '4', '2022-12-05 00:00:00', 'Лондон', 'Иркутск')";


            MySqlCommand command = new MySqlCommand(sql, bd.conn);
            command.Parameters.Add("@id_airplane", MySqlDbType.VarChar, 25);
            command.Parameters.Add("@time_departure", MySqlDbType.Date, 25);
            command.Parameters.Add("@departure", MySqlDbType.Int64, 11);
            command.Parameters.Add("@arrival", MySqlDbType.VarChar, 25);


            command.Parameters["@id_airplane"].Value = guna2TextBox1.Text;
            command.Parameters["@time_departure"].Value = dateTimePicker1.Text; 
            command.Parameters["@departure"].Value = guna2TextBox2.Text;
            command.Parameters["@arrival"].Value = guna2TextBox3.Text;

            reg = command.ExecuteNonQuery();
            if (reg == 1)
            {
                MessageBox.Show("Добавленно!");
            }
            else MessageBox.Show("Ошибка добавления, попробуйте снова");
            bd.closeBD();
            this.Close();
        }
    }
}
