using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Guna.UI2.WinForms;

namespace AirplaneTiket
{
    public partial class Auth : Form
    {
        
        int reg;
        bool hide = true;
        Tiket tiket = new Tiket();
        Settings sets = new Settings();
        Profile prof = new Profile();
        BuyTiket buy = new BuyTiket();
        MySqlConnection conn = new MySqlConnection("server=127.0.0.1;uid=root;port=3306;pwd=;database=airs;");

        public Auth()
        {
            InitializeComponent();
        }

        public string GetHashMD5(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }

        public void User()
        {
            string sql = "SELECT name, id_user FROM `user` WHERE `login` = @ulogin or `phone_nomber` = @nomber";
            MySqlCommand name = new MySqlCommand(sql, conn);
            name.Parameters.Add("@ulogin", MySqlDbType.VarChar, 25);
            name.Parameters["@ulogin"].Value = textBox1.Text;
            name.Parameters.Add("@nomber", MySqlDbType.VarChar, 25);
            name.Parameters["@nomber"].Value = textBox1.Text;
            MySqlDataReader reader = name.ExecuteReader();
            while (reader.Read())
            {
                sets.name = reader[0].ToString();
                buy.user_id = Convert.ToInt32(reader[1]);
                MessageBox.Show(buy.user_id.ToString());
            }


            MySqlCommand command = new MySqlCommand(sql, conn);


            reader.Close();
            this.Hide();
            tiket.Show();
            conn.Close();
            reader.Close();
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
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string sql = "SELECT * FROM `user` WHERE `pass`= @upass and `login` = @ulogin or phone_nomber = @nomber";


                MySqlCommand command = new MySqlCommand(sql, conn);
                command.Parameters.Add("@ulogin", MySqlDbType.VarChar, 25);
                command.Parameters.Add("@upass", MySqlDbType.VarChar, 25);
                command.Parameters.Add("@nomber", MySqlDbType.VarChar, 11);


                command.Parameters["@ulogin"].Value = textBox1.Text;
                command.Parameters["@nomber"].Value = textBox1.Text;
                command.Parameters["@upass"].Value = GetHashMD5(textBox2.Text);
                MySqlDataReader read = command.ExecuteReader();

                if (read.HasRows)
                {
                    read.Close();
                    User();
                }
                else MessageBox.Show("Неверный логин или пароль");
            }
            else MessageBox.Show("Введите логин и пароль");
            conn.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

            new RecoverPass().ShowDialog();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            guna2Panel1.Visible = false;
            guna2Panel2.Visible = true;
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            guna2Panel1.Visible = true;
            guna2Panel2.Visible = false;
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            

            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "" || guna2TextBox3.Text == "" || guna2TextBox7.Text == "" || guna2TextBox6.Text == "" || guna2TextBox5.Text == "" || guna2TextBox4.Text == "")
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                conn.Open();
                string sql = "INSERT INTO `user` (`id_user`, `login`, `pass`, `name`, `family`, `patronymic`, `phone_nomber`, `mail`, `serial_pasport`, `nomber_pasport`) " +
                                        "VALUES (NULL, @ulogin, @upass, @uname, @ufamily, @upatron, @unomber, @email, '', '')";


                MySqlCommand command = new MySqlCommand(sql, conn);
                command.Parameters.Add("@ulogin", MySqlDbType.VarChar, 25);
                command.Parameters.Add("@upass", MySqlDbType.VarChar, 25);
                command.Parameters.Add("@unomber", MySqlDbType.VarChar, 11);
                command.Parameters.Add("@uname", MySqlDbType.VarChar, 25);
                command.Parameters.Add("@ufamily", MySqlDbType.VarChar, 25);
                command.Parameters.Add("@upatron", MySqlDbType.VarChar, 25);
                command.Parameters.Add("@email", MySqlDbType.VarChar, 25);


                command.Parameters["@ulogin"].Value = guna2TextBox1.Text;
                command.Parameters["@upass"].Value = GetHashMD5(guna2TextBox2.Text);
                command.Parameters["@unomber"].Value = guna2TextBox3.Text;
                command.Parameters["@uname"].Value = guna2TextBox7.Text;
                command.Parameters["@ufamily"].Value = guna2TextBox6.Text;
                command.Parameters["@upatron"].Value = guna2TextBox5.Text;
                command.Parameters["@email"].Value = guna2TextBox4.Text;

                reg = command.ExecuteNonQuery();
                if (reg == 1)
                {
                    MessageBox.Show("Вы успешно зарегестрировались!");
                    guna2Panel2.Visible = false;
                    guna2Panel1.Visible = true;
                }
                else MessageBox.Show("Ошибка регистрации, попробуйте снова");
                conn.Close();

            }

                
           
                
        }
    }
}
