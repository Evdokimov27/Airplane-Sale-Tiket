using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirplaneTiket
{
    public partial class Admin : Form
    {
        public string fio, spec;
        public static AdminPanel adminPanel = new AdminPanel();
        Worker worker = new Worker();
        public Admin()
        {
            InitializeComponent();
            
        }
        
        private void addUserController(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            guna2Panel1.Controls.Clear();
            guna2Panel1.Controls.Add(uc);
            uc.BringToFront();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            label1.Text = fio;
            label2.Text = spec;
            if (spec == "Администратор")
            {
                addUserController(adminPanel);
            }
            if (spec == "Работник")
            {
                addUserController(worker);
            }
        }

        private void Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
