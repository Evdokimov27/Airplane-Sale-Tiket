﻿using Microsoft.Win32;
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
using static System.Data.Entity.Infrastructure.Design.Executor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

namespace AirplaneTiket
{
    public partial class ArrayWork : UserControl
    {
        public int row;
        public ArrayWork()
        {
            InitializeComponent();
        }

        private void LoadData()
        {

            bd bd = new bd();

            bd.openBD();

            string query = "SELECT id_worker, FIO, login, gender, phone_nomber, specialisation_id_specialisation FROM `worker`";
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
            }
            reader.Close();

            bd.closeBD();

            foreach (string[] s in data)
                guna2DataGridView1.Rows.Add(s);
        }

        private void ArrayWork_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            bd bd = new bd();

            bd.openBD();

            string query = "UPDATE `evdokCvc`.`worker` SET `FIO` = @fio, `login` = @login , `gender` = @gender, `phone_nomber` = @phone, `specialisation_id_specialisation` = @spec where id_worker = " + guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            MySqlCommand command = new MySqlCommand(query, bd.conn);

            command.Parameters.Add("@login", MySqlDbType.VarChar, 45);
            command.Parameters["@login"].Value = guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            command.Parameters.Add("@fio", MySqlDbType.VarChar, 45);
            command.Parameters["@fio"].Value = guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            command.Parameters.Add("@gender", MySqlDbType.VarChar, 5);
            command.Parameters["@gender"].Value = guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            command.Parameters.Add("@phone", MySqlDbType.Int64, 11);
            command.Parameters["@phone"].Value = guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
            command.Parameters.Add("@spec", MySqlDbType.Int64, 11);
            command.Parameters["@spec"].Value = guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[5].Value.ToString();

            command.ExecuteNonQuery();
            bd.closeBD();       

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            InsertWorker insertWorker = new InsertWorker();         
            insertWorker.ShowDialog();
            guna2DataGridView1.Rows.Clear();
            LoadData();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
                DialogResult resualt = MessageBox.Show("Подтвердить удаление?", "Удалить", MessageBoxButtons.YesNo);
            if (resualt == DialogResult.Yes)
            {
                bd bd = new bd();
                bd.openBD();
                string query = "DELETE FROM `evdokCvc`.`worker` where id_worker = " + guna2DataGridView1.Rows[guna2DataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                MySqlCommand command = new MySqlCommand(query, bd.conn);
                command.ExecuteNonQuery();
                bd.closeBD();
                guna2DataGridView1.Rows.Clear();
                LoadData();
            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex + 1;
            label1.Text = "Выбрана строка: " + row.ToString();
        }
    }
}
