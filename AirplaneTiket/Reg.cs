using System;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace AirplaneTiket
{
    public partial class Reg : UserControl
    {
        int reg;
        bool hide = true;
        Tiket tiket = new Tiket();
        Settings sets = new Settings();
        Profile prof = new Profile();
        BuyTiket buy = new BuyTiket();
        MySqlConnection conn = new MySqlConnection("server=triniti.ru-hoster.com; uid=evdokCvc;port=3306;pwd=993eq1RmAc;database=evdokCvc;");

        public Reg()
        {
            InitializeComponent();
        }

        public string GetHashMD5(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
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
                                        "VALUES (NULL, @ulogin, @upass, @uname, @ufamily, @upatron, @unomber, @email, '0000', '000000')";


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
                }
                else MessageBox.Show("Ошибка регистрации, попробуйте снова");
                conn.Close();

            }
        }

        public void addUserController(UserControl uc)
        {
            Auth auth = new Auth();
            uc.Dock = DockStyle.Fill;
            auth.controlPanel.Controls.Clear();
            auth.controlPanel.Controls.Add(uc);
            uc.BringToFront();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Auth auth = new Auth();
            Authz authz = new Authz();
            auth.addUserController(authz);
        }
    }
}
