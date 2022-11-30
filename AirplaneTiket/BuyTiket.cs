using GeoCoordinatePortable;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GMap.NET.Entity.OpenStreetMapGraphHopperRouteEntity;

namespace AirplaneTiket
{
    public partial class BuyTiket : UserControl
    {
        bd bd = new bd();
        MyTiket mytkt = new MyTiket();
        double x1, y1, x2, y2, distanceBetween, km, km1, km2;
        private void gmap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
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
                km1 = km - km % 0.1;
                km2 = Math.Round(km1/100);
                label5.Text = km1 + " км".ToString();
            }
        }

        private void calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime start = calendar.SelectionRange.Start;
            string formattedStart = start.ToString("yyyy-MM-dd");
            button3.Text = formattedStart + " ";
        }

        private void BuyTiket_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (button1.Text != "Откуда" && button2.Text != "Куда" && button3.Text != "Дата")
            {
                int id_flight = 0;
                bd.openBD();
                string time = "SELECT id_flight, time_departure FROM flight WHERE time_departure > '" + button3.Text + "' AND departure = '" + button1.Text + "' AND arrival = '" + button2.Text + "' ORDER BY time_departure ASC LIMIT 1";

                MySqlCommand time_check = new MySqlCommand(time, bd.conn);
                MySqlDataReader _time = time_check.ExecuteReader();


                while (_time.Read())
                {
                   if (_time.HasRows)
                   {
                        id_flight = Convert.ToInt32(_time[0]);
                   }
                   
                }
                _time.Close();
                if(id_flight != 0)
                {
                    string sql = "INSERT INTO `evdokCvc`.`tiket` (`id_tiket`, `id_flight`, `user_id`, `tiket_price`, `confirm`)" 
                        + "VALUES (NULL, '"+ id_flight + "', @userid, '"+ km2 * 500 +"', '0');";
                    MySqlCommand id = new MySqlCommand(sql, bd.conn);

                    id.Parameters.Add("@userid", MySqlDbType.Int32, 11);
                    id.Parameters["@userid"].Value = Tiket.sets.id;
                    MySqlDataReader tik = id.ExecuteReader();
                    tik.Close();

                    MessageBox.Show("Билет заказан!");
                    Guna2Panel someForm = (Guna2Panel)this.Parent;
                    someForm.Controls.Clear();
                    someForm.Controls.Add(mytkt);
                    mytkt.BringToFront();
                }
                else MessageBox.Show("Похожих рейсов не найдено!");

                bd.closeBD();
            }
            else if (button1.Text == "Откуда") MessageBox.Show("Выберите место отправления");
            else if (button2.Text == "Куда") MessageBox.Show("Выберите место прибытия");
            else if (button3.Text == "Дата") MessageBox.Show("Выберите время отправления");
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

        int check = 0;
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

        public BuyTiket()
        {
            InitializeComponent();
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
            gmap.Overlays.Add(markersOverlay);

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
    }
}
