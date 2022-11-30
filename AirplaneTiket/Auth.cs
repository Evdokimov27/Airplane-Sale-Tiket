using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;


namespace AirplaneTiket
{
    public partial class Auth : Form
    {
        public static Authz autho = new Authz();
        bool register=false;
        int reg;
        bool hide = true;
        Tiket tiket = new Tiket();
        Settings sets = new Settings();
        Profile prof = new Profile();
        Authz authz = new Authz();
        Reg regis = new Reg();
        BuyTiket buy = new BuyTiket();
        MySqlConnection conn = new MySqlConnection("server=127.0.0.1;uid=root;port=3306;pwd=;database=airs;");

        public Auth()
        {
            InitializeComponent();
            Reg reg = new Reg();
        }

        public void addUserController(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            controlPanel.Controls.Clear();
            controlPanel.Controls.Add(uc);
            uc.BringToFront();
        }
        private void Auth_Load(object sender, EventArgs e)
        {
            addUserController(authz);
        }
        private void label3_Click_1(object sender, EventArgs e)
        {
            if(register == false)
            {
                addUserController(regis);
                label3.Text = "Уже есть аккаунт";
                register = true;
            }
            else
            {
                addUserController(authz);
                label3.Text = "Еще нет аккаунта?";
                register = false;
            }
        }

        private void Auth_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
