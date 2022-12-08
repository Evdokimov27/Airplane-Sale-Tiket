using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirplaneTiket
{
    public partial class PrintTiket : Form
    {
        public int id;
        public CultureInfo culture = new CultureInfo("ru-ru");
        public PrintTiket()
        {
            InitializeComponent();
            LoadData();
        }
        private void Print()
        {
            Bitmap bmp = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, this.ClientRectangle);
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "Билет.jpg";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                    bmp.Save(savefile.FileName);
            }
            
        }
        private void LoadData()
        {
            
            bd bd = new bd();

            bd.openBD();

            string query = "SELECT user.FIO, flight.departure, flight.arrival, DATE(flight.time_departure), TIME(flight.time_departure), TIME(ADDTIME(flight.time_departure, '-00:35:00')), TIME(ADDTIME(flight.time_departure, '00:15:00')),  airplane.model FROM `tiket` , `user` , `flight` , `airplane` WHERE tiket.id_flight = flight.id_flight AND tiket.user_id = user.id_user AND flight.id_airplane = airplane.id_airplane and tiket.id_tiket =" + id;
            MySqlCommand command = new MySqlCommand(query, bd.conn);
            MySqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                // пассажир
                label15.Text = reader[0].ToString();
                label21.Text = reader[0].ToString();
                // вылет
                label11.Text = reader[1].ToString();
                label30.Text = reader[1].ToString();
                // прилет
                label12.Text = reader[2].ToString();
                label29.Text = reader[2].ToString();
                // дата
                label18.Text = Convert.ToDateTime(reader[3]).ToString("dd.MM.yyyy", culture);
                label26.Text = Convert.ToDateTime(reader[3]).ToString("dd.MM.yyyy", culture);
                // время
                label17.Text = reader[4].ToString();
                label25.Text = reader[4].ToString();
                // начало посадки
                label9.Text = reader[5].ToString();
                // конец посадки
                label10.Text = reader[6].ToString();
                // самолет
                label14.Text = reader[7].ToString();
                label24.Text = reader[7].ToString();

            }

            reader.Close();
            bd.closeBD();

        }
        private void PrintTiket_Load(object sender, EventArgs e)
        {
            LoadData();
            Print();
            this.Close();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }
    }
}
