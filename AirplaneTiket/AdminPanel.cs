using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AirplaneTiket
{
    public partial class AdminPanel : UserControl
    {
        bd bd = new bd();
        ArrayWork worker = new ArrayWork();
        public AdminPanel()
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

        private void AdminPanel_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            addUserController(worker);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }
    }
}
