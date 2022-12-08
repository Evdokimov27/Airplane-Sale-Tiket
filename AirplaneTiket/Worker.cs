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
    public partial class Worker : UserControl
    {
        bd bd = new bd();
        PrintTiket print = new PrintTiket();
        public Worker()
        {
            InitializeComponent();
            LoadData();
        }


        private void LoadData()
        {

            bd bd = new bd();

            bd.openBD();

            string query = "SELECT id_tiket, FIO , departure, arrival, time_departure, `flight`.id_flight, confirm FROM `tiket` , `user` , `flight` WHERE `flight`.`id_flight` = `tiket`.`id_flight` AND `user`.`id_user` = `tiket`.`user_id` GROUP BY id_tiket";
            MySqlCommand command = new MySqlCommand(query, bd.conn);
            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[7]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = Convert.ToBoolean(reader[6]).ToString();

            }
            reader.Close();

            bd.closeBD();

            foreach (string[] s in data)
            guna2DataGridView1.Rows.Add(s);
        }
        private void Print()
        {
            
            var ctrl = print;
            Bitmap bmp = new Bitmap(ctrl.Width, ctrl.Height);
            ctrl.DrawToBitmap(bmp, new Rectangle(Point.Empty, bmp.Size));
            bmp.Save(@"C:\form.png");
        }
        private void deleteTiket()
        {
            bd.openBD();
            string query = "DELETE FROM `tiket` WHERE id_tiket = " + guna2DataGridView1[0, guna2DataGridView1.CurrentRow.Index].Value.ToString();
            MySqlCommand command = new MySqlCommand(query, bd.conn);
            command.ExecuteNonQuery();
        }
        private void getCheckBox()
        {
            DataGridViewCheckBoxCell ch3 = new DataGridViewCheckBoxCell();
            ch3 = (DataGridViewCheckBoxCell)guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[6];
            if (ch3.Value == null)
                ch3.Value = false;

            switch (ch3.Value.ToString())
            {
                case "True":
                    ch3.Value = false;
                    break;
                case "False":
                    ch3.Value = true;
                    break;
            }
            bd.openBD();
            string query = "UPDATE `tiket` SET `confirm` = " + Convert.ToInt32(ch3.Value) + " WHERE `tiket`.`id_tiket` = " + guna2DataGridView1[0, guna2DataGridView1.CurrentRow.Index].Value.ToString();
            MySqlCommand command = new MySqlCommand(query, bd.conn);
            command.ExecuteNonQuery();
            guna2DataGridView1.Rows.Clear();
            LoadData();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Clear();
            LoadData();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Action dialog = new Action();
            dialog.ShowDialog();
            switch (dialog.click)
            {
                case 1:
                    getCheckBox();
                    break;
                case 2:
                    deleteTiket();
                    break;                
                case 3:
                    print.id = Convert.ToInt32(guna2DataGridView1[0, guna2DataGridView1.CurrentRow.Index].Value.ToString());
                    print.ShowDialog();
                    break;
            }
            guna2DataGridView1.Rows.Clear();
            LoadData();
        }

        private void Worker_Load(object sender, EventArgs e)
        {

        }
    }
}
