using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AirplaneTiket
{
    public partial class Auth : Form
    {
        bool hide = true;
        Tiket tiket = new Tiket();
        MySqlConnection conn = new MySqlConnection("server=127.0.0.1;uid=root;port=3306;pwd=;database=airs;");

        public Auth()
        {
            InitializeComponent();
        }

        public void User()
        {
            string sql = "SELECT name FROM `user` WHERE `login` = @ulogin or `phone_nomber` = @nomber";
            MySqlCommand name = new MySqlCommand(sql, conn);
            name.Parameters.Add("@ulogin", MySqlDbType.VarChar, 25);
            name.Parameters["@ulogin"].Value = textBox1.Text;
            name.Parameters.Add("@nomber", MySqlDbType.VarChar, 25);
            name.Parameters["@nomber"].Value = textBox1.Text;
            MySqlDataReader reader = name.ExecuteReader();
            while (reader.Read())
            {
                tiket.name = reader[0].ToString();
            }
            reader.Close();
            this.Hide();
            tiket.Show();
            conn.Close();
            reader.Close();
        }




        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Логин")
                textBox1.Text = "";
        }
        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "Пароль")
                textBox2.Text = "";
        }

        private void imageButton1_Click(object sender, EventArgs e)
        {
            if (hide == true)
            {
                imageButton1.Image = AirplaneTiket.Properties.Resources.hide_pass;
                textBox2.PasswordChar = '\0';
                hide = false;
            }
            else
            {
                imageButton1.Image = AirplaneTiket.Properties.Resources.show_pass;
                textBox2.PasswordChar = '•';
                hide = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            conn.Open();
            string sql = "SELECT * FROM `user` WHERE `pass`= @upass and `login` = @ulogin or phone_nomber = @nomber";


            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@ulogin", MySqlDbType.VarChar, 25);
            command.Parameters.Add("@upass", MySqlDbType.VarChar, 25);
            command.Parameters.Add("@nomber", MySqlDbType.VarChar, 11);


            command.Parameters["@ulogin"].Value = textBox1.Text;
            command.Parameters["@nomber"].Value = textBox1.Text;
            command.Parameters["@upass"].Value = textBox2.Text;
            MySqlDataReader read = command.ExecuteReader();

            if (read.HasRows)
            {
                read.Close();
                User();

            }
            else MessageBox.Show("Неверный логин или пароль");

            conn.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

            new RecoverPass().ShowDialog();

        }
    }
}
