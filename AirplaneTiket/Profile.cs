using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Data.Entity.Infrastructure.Design.Executor;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Application = System.Windows.Forms.Application;
using Image = System.Drawing.Image;

namespace AirplaneTiket
{
    public partial class Profile : UserControl
    {
        bd bd = new bd();
        public string name = "qwe";
        public int id = 0;
        public CultureInfo culture = new CultureInfo("ru-ru");

        public Profile()
        {
            InitializeComponent();
            CustomFormat();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            bd.openBD();
            string sql = "SELECT fio, gender, date_birth, serial_pasport, nomber_pasport FROM `user` WHERE `id_user` = " + id;
            MySqlCommand command = new MySqlCommand(sql, bd.conn);


            MySqlDataReader user = command.ExecuteReader();


            if (user.Read())
            {
                label1.Text = user[0].ToString();
                label7.Text = user[1].ToString();
                label5.Text = Convert.ToDateTime(user[2]).ToString("dd.MM.yyyy", culture);
                label9.Text = user[3].ToString();
                label8.Text = user[4].ToString();
                user.Close();
            }
           
            bd.closeBD();
            if (label9.Text == "0" || label8.Text == "0")
            {
                guna2Panel1.Visible = true;
            }
            else guna2Panel1.Visible = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
        }

        public void CustomFormat()
        {
            // Set the Format type and the CustomFormat string.
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
            string pass = "UPDATE user SET date_birth =  '" + dateTimePicker1.Text + "' , serial_pasport = '" + guna2TextBox1.Text + "' , nomber_pasport = '" + guna2TextBox2.Text + "' WHERE id_user = " + id;
            bd.openBD();
            MySqlCommand recover_pass = new MySqlCommand(pass, bd.conn);

            if (guna2TextBox1.Text != null || guna2TextBox2.Text != null)
            {
                Profile prof = new Profile();
                recover_pass.ExecuteNonQuery();
                DialogResult rsl = MessageBox.Show("Данные успешно сохранены! После перезагрузки программы, они будут отображаться в данном разделе!", "", MessageBoxButtons.OK);
                if (rsl == DialogResult.OK)
                {
                    Process.Start(Assembly.GetEntryAssembly().Location);
                    Process.GetCurrentProcess().Kill();
                }
            }
            else MessageBox.Show("Введите данные!");
        }

        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }
        private void guna2TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }
    }
}
