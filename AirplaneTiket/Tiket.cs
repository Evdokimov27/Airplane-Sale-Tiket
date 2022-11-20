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
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AirplaneTiket
{
    public partial class Tiket : Form
    {
        double x1,y1,x2,y2,distanceBetween,km,km1;
        bool slide = false;
        int check = 0;
        public string name = "qwe";
        public Tiket()
        {
            InitializeComponent();
            gmap2.Visible = false;
            calendar.Visible = false;

        }

        private void gmap_Load(object sender, EventArgs e)
        {
            // Настройки для компонента GMap
            gmap.GrayScaleMode = true;
            gmap.MarkersEnabled = true;
            gmap.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
            gmap.NegativeMode = false;
            gmap.PolygonsEnabled = true;
            gmap.RoutesEnabled = true;
            gmap.ShowTileGridLines = false;
            gmap.Bearing = 0;
            gmap.CanDragMap = true;
            gmap.DragButton = MouseButtons.Left;
            gmap.ShowCenter = false;

            // Максимальное приближение
            gmap.MaxZoom = 16;
            // Минимальное приближение
            gmap.MinZoom = 2;
            // Стартовое приближение
            gmap.Zoom = 8;

            // Чья карта используется
            gmap.MapProvider = GMapProviders.GoogleMap;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            // Начальная точка карты
            gmap.Position = new PointLatLng(52.283363330010474, 104.2810983606102);


            // Иконка маркера
            //Bitmap flag = new Bitmap(@"Icon/Cemetery.png");

            // Список Меток
            GMapOverlay markersOverlay = new GMapOverlay("markers");

            // 1 метка
            // Создание метки
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(52.26863267179805, 104.38335806422812), GMarkerGoogleType.red_big_stop);
            marker.ToolTip = new GMapRoundedToolTip(marker);
            marker.ToolTipText = "Иркутск";

            // Добавление метки в список
            markersOverlay.Markers.Add(marker);
            gmap2.Overlays.Add(markersOverlay);

            // 2 метка
            GMarkerGoogle marker2 = new GMarkerGoogle(new PointLatLng(55.97296962437368, 37.411794741111066), GMarkerGoogleType.red_big_stop);
            marker2.ToolTip = new GMapRoundedToolTip(marker2);
            marker2.ToolTipText = "Москва";

            markersOverlay.Markers.Add(marker2);
            gmap.Overlays.Add(markersOverlay);


            // 3 метка
            GMarkerGoogle marker3 = new GMarkerGoogle(new PointLatLng(51.87687394687733, -0.37332423183367514), GMarkerGoogleType.red_big_stop);
            marker3.ToolTip = new GMapRoundedToolTip(marker2);
            marker3.ToolTipText = "Лондон";

            markersOverlay.Markers.Add(marker3);
            gmap.Overlays.Add(markersOverlay);

            // 4 метка
            GMarkerGoogle marker4 = new GMarkerGoogle(new PointLatLng(27.33387568400841, -99.58011807644885), GMarkerGoogleType.red_big_stop);
            marker4.ToolTip = new GMapRoundedToolTip(marker4);
            marker4.ToolTipText = "Мексика";

            markersOverlay.Markers.Add(marker4);
            gmap.Overlays.Add(markersOverlay);
        }
        
        

        private void button1_Click(object sender, EventArgs e)
        {
            check = 0;
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            gmap.Visible = true;
            gmap.Enabled = true;
            calendar.Visible = false;
            calendar.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            check = 1;
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = true;
            gmap.Visible = true;
            gmap.Enabled = true;
            calendar.Visible = false;
            calendar.Enabled = false;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;
            gmap.Visible = false;
            gmap.Enabled = false;
            calendar.Visible = true;
            calendar.Enabled = true;
        }

        private void gmap_OnMarkerClick_1(GMapMarker item, MouseEventArgs e)
        {
            if (check == 0)
            {
                button1.Text = item.ToolTipText.ToString();
                x1 = item.Position.Lat;
                y1 = item.Position.Lng;
            }
            if (check == 1)
            {
                button2.Text = item.ToolTipText.ToString();
                x2 = item.Position.Lat;
                y2 = item.Position.Lng;
            }

            if (x2 != 0 && y2 != 0)
            {
                GeoCoordinate pin1 = new GeoCoordinate(x1, y1);
                GeoCoordinate pin2 = new GeoCoordinate(x2, y2);

                distanceBetween = pin1.GetDistanceTo(pin2);
                km = (distanceBetween / 1000);
                km1 = km - km % 0.01;
                label5.Text =  km1 + " км".ToString();
            }
        }

        private void calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime start = calendar.SelectionRange.Start;
            string formattedStart = start.ToString("yyyy-MM-dd");
            button3.Text = formattedStart + " ";
        }

        private void Tiket_Load(object sender, EventArgs e)
        {
            label1.Text = name;
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            slide = !slide;
            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
        }

        public void Authorize()
        {
            Auth auth = new Auth();            
        }

        private void Tiket_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button1.Text != "Откуда" && button2.Text != "Куда" && button3.Text != "Дата")
            {
                MySqlConnection conn = new MySqlConnection("server=127.0.0.1;uid=root;port=3306;pwd=;database=airs;");
                conn.Open();
                string sql = "INSERT INTO `tiket` (`id_tiket`, `departure`, `arrival`, `time_departure`, `time_arrival`, `tiket_price`, `confirm`, `airplane_id_airplane`) " +
                    "VALUES (NULL, '"+ button1.Text +"', '"+ button2.Text + "', '"+ button3.Text + "', '2022-11-08 11:03:39.000000', '"+ km1*5 +"', '', '');";


                MySqlCommand command = new MySqlCommand(sql, conn);


                MySqlDataReader read = command.ExecuteReader();
                conn.Close();
            }
            else if (button1.Text == "Откуда") MessageBox.Show("Выберите место отправления");
            else if (button2.Text == "Куда") MessageBox.Show("Выберите место прибытия");
            else if (button3.Text == "Дата") MessageBox.Show("Выберите время отправления");
        }

 
        private void timer1_Tick(object sender, EventArgs e)
        {

            if(flowLayoutPanel1.Width < 240 && slide == true)
            {
                flowLayoutPanel1.Width += 10;
            }
            if (flowLayoutPanel1.Width > 90 && slide == false)
            {
                flowLayoutPanel1.Width -= 10;
            }
        }
    }
}
