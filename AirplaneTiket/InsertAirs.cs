using MySql.Data.MySqlClient;
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
    public partial class InsertAirs : Form
    {
        public InsertAirs()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            int reg;
            bd bd = new bd();
            bd.openBD();
            string sql = "INSERT INTO `evdokCvc`.`airplane` (`id_airplane`, `model`, `firm`, `amount_places`) VALUES (NULL, @model, @firm, @amount_places)";


            MySqlCommand command = new MySqlCommand(sql, bd.conn);
            command.Parameters.Add("@model", MySqlDbType.VarChar, 25);
            command.Parameters.Add("@firm", MySqlDbType.VarChar, 25);
            command.Parameters.Add("@amount_places", MySqlDbType.Int64, 11);

            command.Parameters["@model"].Value = guna2TextBox1.Text;
            command.Parameters["@firm"].Value = guna2TextBox2.Text;
            command.Parameters["@amount_places"].Value = guna2TextBox3.Text;
           

            reg = command.ExecuteNonQuery();
            if (reg == 1)
            {
                MessageBox.Show("Добавленно!");
            }
            else MessageBox.Show("Ошибка добавления, попробуйте снова");
            bd.closeBD();
            this.Close();
        }
    }
}
