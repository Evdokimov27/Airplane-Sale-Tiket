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
    public partial class Action : Form
    {
        public int click;
        public Action()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            click = 1;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            click = 2;
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
