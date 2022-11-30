using System;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using Guna.UI2.WinForms;

namespace AirplaneTiket
{
    public partial class Reg : UserControl
    {
        int reg;
        int noreg = 0;
        Authz authz = new Authz();
        bd bd = new bd();

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
                    bd.openBD();
                    string regist = "SELECT * FROM `user`,`worker` WHERE `user`.`login` = @ulogin or `user`.`login` = @ulogin  or `user`.`phone_nomber` = @nomber or `worker`.`phone_nomber` = @nomber";
                    MySqlCommand register = new MySqlCommand(regist, bd.conn);

                    register.Parameters.Add("@ulogin", MySqlDbType.VarChar, 25);
                    register.Parameters.Add("@nomber", MySqlDbType.VarChar, 11);
                    register.Parameters["@ulogin"].Value = guna2TextBox1.Text;
                    register.Parameters["@nomber"].Value = guna2TextBox3.Text;

                    MySqlDataReader regis = register.ExecuteReader();

                if (regis.HasRows)
                {
                    noreg = 0;
                }
                else noreg = 1;
                bd.closeBD();

                if (noreg == 1)
                {
                    bd.openBD();
                    string sql = "INSERT INTO `user` (`id_user`, `login`, `pass`, `name`, `family`, `patronymic`, `gender`, `phone_nomber`, `mail`, `serial_pasport`, `nomber_pasport`) " +
                                            "VALUES (NULL, @ulogin, @upass, @uname, @ufamily, @upatron, @gender, @unomber, @email, '0000', '000000')";


                    MySqlCommand command = new MySqlCommand(sql, bd.conn);
                    command.Parameters.Add("@ulogin", MySqlDbType.VarChar, 25);
                    command.Parameters.Add("@upass", MySqlDbType.VarChar, 25);
                    command.Parameters.Add("@unomber", MySqlDbType.VarChar, 11);
                    command.Parameters.Add("@uname", MySqlDbType.VarChar, 25);
                    command.Parameters.Add("@ufamily", MySqlDbType.VarChar, 25);
                    command.Parameters.Add("@upatron", MySqlDbType.VarChar, 25);
                    command.Parameters.Add("@email", MySqlDbType.VarChar, 25);
                    command.Parameters.Add("@gender", MySqlDbType.VarChar, 25);


                    command.Parameters["@gender"].Value = guna2ComboBox1.Text;
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
                        Guna2Panel someForm = (Guna2Panel)this.Parent;
                        someForm.Controls.Clear();
                        someForm.Controls.Add(authz);
                        authz.BringToFront();
                    }
                    else MessageBox.Show("Ошибка регистрации, попробуйте снова");
                    bd.closeBD();
                }
                else MessageBox.Show("Данный логин или номер уже зарегистрирован!");
            }
        }


        private void label6_Click(object sender, EventArgs e)
        {
            Auth auth = new Auth();
            Authz authz = new Authz();
            auth.addUserController(authz);
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
