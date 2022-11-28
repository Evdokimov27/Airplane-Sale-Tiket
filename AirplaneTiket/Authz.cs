using System;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace AirplaneTiket
{
    public partial class Authz : UserControl
    {
        bool hide = true;
        Tiket tiket = new Tiket();
        BuyTiket buy = new BuyTiket();
        Admin admin = new Admin();
        bool enter;
        MySqlConnection conn = new MySqlConnection("server=triniti.ru-hoster.com; uid=evdokCvc;port=3306;pwd=993eq1RmAc;database=evdokCvc;");

        public Authz()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                {
                    conn.Open();
                    string admin = "SELECT * FROM `worker` WHERE `password`= @upass and `login` = @ulogin or phone_nomber = @nomber";
                    MySqlCommand adm_command = new MySqlCommand(admin, conn);

                    adm_command.Parameters.Add("@ulogin", MySqlDbType.VarChar, 25);
                    adm_command.Parameters.Add("@upass", MySqlDbType.VarChar, 25);
                    adm_command.Parameters.Add("@nomber", MySqlDbType.VarChar, 11);
                    adm_command.Parameters["@ulogin"].Value = textBox1.Text;
                    adm_command.Parameters["@nomber"].Value = textBox1.Text;
                    adm_command.Parameters["@upass"].Value = GetHashMD5(textBox2.Text);

                    MySqlDataReader adm = adm_command.ExecuteReader();

                    if (adm.HasRows)
                    {
                        enter = true;
                        adm.Close();
                        AdminP();
                    }


                    conn.Close();
                }
                {
                    conn.Open();
                    string sql = "SELECT * FROM `user` WHERE `pass`= @upass and `login` = @ulogin or phone_nomber = @nomber";
                    MySqlCommand command = new MySqlCommand(sql, conn);


                    command.Parameters.Add("@ulogin", MySqlDbType.VarChar, 25);
                    command.Parameters.Add("@upass", MySqlDbType.VarChar, 25);
                    command.Parameters.Add("@nomber", MySqlDbType.VarChar, 11);
                    command.Parameters["@ulogin"].Value = textBox1.Text;
                    command.Parameters["@nomber"].Value = textBox1.Text;
                    command.Parameters["@upass"].Value = GetHashMD5(textBox2.Text);


                    MySqlDataReader user = command.ExecuteReader();




                    if (user.HasRows)
                    {
                        user.Close();
                        User();
                        enter = true;
                    }
                    else if(enter == false)MessageBox.Show("Неверный логин или пароль!");
                    conn.Close();
                }
                    

            }
            else MessageBox.Show("Введите логин и пароль");
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
                Tiket.sets.id = reader[1].ToString();
                Tiket.sets.name = reader[0].ToString();
            }
            reader.Close();
            Auth.ActiveForm.Hide();
            tiket.Show();
            conn.Close();
            reader.Close();
        }
        public void AdminP()
        {
            string sql = "SELECT FIO, specialisation.name_specialisation FROM `worker` JOIN specialisation on worker.specialisation_id_specialisation = specialisation.name_specialisation WHERE `login` = @ulogin or `phone_nomber` = @nomber";
            MySqlCommand name = new MySqlCommand(sql, conn);
            name.Parameters.Add("@ulogin", MySqlDbType.VarChar, 25);
            name.Parameters["@ulogin"].Value = textBox1.Text;
            name.Parameters.Add("@nomber", MySqlDbType.VarChar, 25);
            name.Parameters["@nomber"].Value = textBox1.Text;
            MySqlDataReader reader = name.ExecuteReader();
            while (reader.Read())
            {
                admin.fio = reader[0].ToString();
                admin.spec = reader[1].ToString();

                
            }
            reader.Close();
            Auth.ActiveForm.Hide();
            admin.Show();
            conn.Close();
            reader.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            new RecoverPass().ShowDialog();
        }


        private void label3_Click(object sender, EventArgs e)
        {
            Auth auth = new Auth();
            Reg reg = new Reg();
            auth.addUserController(reg);
        }

        private void Authz_Load(object sender, EventArgs e)
        {

        }
    }
}
