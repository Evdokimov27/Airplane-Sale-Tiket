using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeoCoordinatePortable;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AirplaneTiket
{
    public partial class Tiket : Form
    {
        public static Settings sets = new Settings();
        bool slide = false;

        
        public Tiket()
        {
            InitializeComponent();

        }

        private void addUserController(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            ControlPanel.Controls.Clear();
            ControlPanel.Controls.Add(uc);
            uc.BringToFront();
        }
        

        private void Tiket_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if(flowLayoutPanel1.Width < 260 && slide == true)
            {
                flowLayoutPanel1.Width += 10;
            }
            if (flowLayoutPanel1.Width > 90 && slide == false)
            {
                flowLayoutPanel1.Width -= 10;
            }
        }



        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void settings_Click(object sender, EventArgs e)
        {
            addUserController(sets);
        }

        private void myTiket_Click(object sender, EventArgs e)
        {
            MyTiket myTkt = new MyTiket();
            addUserController(myTkt);
        }

        private void buyTiket_Click(object sender, EventArgs e)
        {
            BuyTiket buyTkt = new BuyTiket();
            addUserController(buyTkt);
        }

        private void profile_Click(object sender, EventArgs e)
        {
            Profile prof = new Profile();
            addUserController(prof);
        }

        private void menu_Click(object sender, EventArgs e)
        {
            slide = !slide;
            timer1.Start();
        }

        private void Tiket_Load(object sender, EventArgs e)
        {

        }

        private void ControlPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
