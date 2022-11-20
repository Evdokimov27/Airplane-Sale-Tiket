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

namespace AirplaneTiket
{
    public partial class RecoverPass : Form
    {
        string send_mail;
        string randomer;
        bool send = false;
        Random rnd = new Random();

        MySqlConnection conn = new MySqlConnection("server=127.0.0.1;uid=root;port=3306;pwd=;database=airs;");
        public RecoverPass()
        {
            InitializeComponent();
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (randomer == null)
            {
                for (int i = 0; i < 6; i++)
                {
                    randomer += (char)rnd.Next(0x0410, 0x44F);
                }
            }


            if (textBox1.PlaceholderText != "Номер телефона" || textBox1.Text != "")
            {
                conn.Open();
                string sql = "SELECT mail FROM `user` WHERE `phone_nomber` = @nomber";
                MySqlCommand name = new MySqlCommand(sql, conn);
                name.Parameters.Add("@nomber", MySqlDbType.Int64, 11);
                name.Parameters["@nomber"].Value = textBox1.Text;
                MySqlDataReader email = name.ExecuteReader();
                while (email.Read())
                {
                    send_mail = email[0].ToString();
                    label1.Visible = true;
                    textBox2.Visible = true;
                }
                conn.Close();
                if (send_mail != null)
                {
                    if (textBox2.Text == randomer)
                    {
                        string pass = "UPDATE user SET pass = '"+ textBox3.Text +"' WHERE mail = '" + send_mail + "'";

                        conn.Open();
                        MySqlCommand recover_pass = new MySqlCommand(pass, conn);
                        
                        if(recover_pass.ExecuteNonQuery() == 1)
                        {
                            DialogResult rsl = MessageBox.Show("Пароль успешно изменен!", "", MessageBoxButtons.OK);
                            if (rsl == DialogResult.OK)
                            {
                                this.Close();
                            }
                        }


                        MailMessage mail = new MailMessage();
                       mail.From = new MailAddress("airport_kursovoy@mail.ru"); // Адрес отправителя
                       mail.To.Add(new MailAddress(send_mail)); // Адрес получателя
                       mail.Subject = "Пароль успешно изменен";
                       mail.Body = "Ваш новый пароль:" + textBox3.Text;
                       SmtpClient client = new SmtpClient();
                       client.Host = "smtp.mail.ru";
                       client.Port = 587;
                       client.EnableSsl = true;
                       client.Credentials = new NetworkCredential("airport_kursovoy@mail.ru", "M0K61YA1zvZQQpRk9Dzn");
                       client.Send(mail);
                       conn.Close();
                    }
                    else if (send == true) MessageBox.Show("Код подтверждения неверный!");

                    if (send == false)
                    {
                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress("airport_kursovoy@mail.ru"); // Адрес отправителя
                        mail.To.Add(new MailAddress(send_mail)); // Адрес получателя
                        mail.Subject = "Восстановление пароля";
                        mail.Body = "Ключ для восстановления пароля: " + randomer;

                        SmtpClient client = new SmtpClient();
                        client.Host = "smtp.mail.ru";
                        client.Port = 587;
                        client.EnableSsl = true;
                        client.Credentials = new NetworkCredential("airport_kursovoy@mail.ru", "M0K61YA1zvZQQpRk9Dzn");
                        client.Send(mail);
                        MessageBox.Show("Введите код подтверждения отправленный вам на почту");
                        send = true;
                    }
                }
                else if (send_mail == null) MessageBox.Show("Данный пользователь не зарегестрирован");


                conn.Close();
            }
            else MessageBox.Show("Введите номер телефона");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }
    }
}
