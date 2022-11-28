using System;
using System.Windows.Forms;

namespace AirplaneTiket
{
    public partial class Settings : UserControl
    {
        public string name;
        public string id;
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            label1.Text = name;
            label2.Text = id;
        }
    }
}
