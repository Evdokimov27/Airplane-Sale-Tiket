using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace AirplaneTiket
{
    public partial class Settings : UserControl
    {
        public string name;
        public string id;
        bd bd = new bd();
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            label1.Text = name;
            label2.Text = id;
        }

        public string GetHashMD5(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            


            string pass = "UPDATE user SET pass = '" + GetHashMD5(guna2TextBox1.Text) + "' WHERE id_user = " + id;

            bd.openBD();
            MySqlCommand recover_pass = new MySqlCommand(pass, bd.conn);

            if (guna2TextBox1.Text == guna2TextBox2.Text)
            {
                recover_pass.ExecuteNonQuery();
                DialogResult rsl = MessageBox.Show("Пароль успешно изменен!", "", MessageBoxButtons.OK);
            }
            else MessageBox.Show("Пароли не совпадают!");
        }

    }
}
