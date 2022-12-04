using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirplaneTiket
{
    public partial class InsertUser : Form
    {
        public string fio;
        public InsertUser()
        {
            InitializeComponent();
            CustomFormat();
        }
        public string GetHashMD5(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
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
            string sql = "INSERT INTO `evdokCvc`.`user` (`id_user`, `login`, `pass`, `FIO`, `gender`, `phone_nomber`, `mail`, `date_birth`, `serial_pasport`, `nomber_pasport`) VALUES (NULL, @login, @pass, @fio, @gender, @nomber, @mail, @date, '0', '0')";


            MySqlCommand command = new MySqlCommand(sql, bd.conn);
            command.Parameters.Add("@login", MySqlDbType.VarChar, 25);
            command.Parameters.Add("@pass", MySqlDbType.VarChar, 25);
            command.Parameters.Add("@nomber", MySqlDbType.Int64, 11);
            command.Parameters.Add("@fio", MySqlDbType.VarChar, 25);
            command.Parameters.Add("@gender", MySqlDbType.VarChar, 25);
            command.Parameters.Add("@mail", MySqlDbType.Int64, 25);
            command.Parameters.Add("@date", MySqlDbType.Date, 25);


            command.Parameters["@login"].Value = guna2TextBox1.Text;
            command.Parameters["@pass"].Value = GetHashMD5(guna2TextBox2.Text);
            command.Parameters["@fio"].Value = guna2TextBox3.Text;
            command.Parameters["@gender"].Value = guna2TextBox4.Text;
            command.Parameters["@nomber"].Value = guna2TextBox5.Text;
            command.Parameters["@mail"].Value = guna2TextBox6.Text;
            command.Parameters["@date"].Value = dateTimePicker1.Value;

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
