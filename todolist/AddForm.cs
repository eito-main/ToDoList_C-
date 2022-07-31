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

namespace todolist
{
    public partial class AddForm : Form
    {

        MySqlConnection conn = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();

        public AddForm()
        {
            InitializeComponent();
        }
        private void registerB_Click(object sender, EventArgs e)
        {
            string id = "任意";
            string password = "任意";
            string database = "任意";
            string table = "任意";


            if (todoTb.Text == "" || placeTb.Text == "" || categoryTB.Text == "") {
                MessageBox.Show("未入力欄があります");
                return;
            };
            conn.ConnectionString = $"Data Source=localhost;Database={database};User ID={id};password={password}";
            conn.Open();

            string todo = todoTb.Text;
            string date_time = dtp.Value.ToShortDateString().Replace("/", "-");
            string place = placeTb.Text;
            string category = categoryTB.Text;

            cmd.CommandText = $"insert into {table}(todo,date_time,place,category)value(\"{todo}\",\"{date_time}\",\"{place}\",\"{category}\");";
            cmd.Connection = conn;
            using (MySqlDataReader reader = cmd.ExecuteReader());
            
            conn.Close();
            this.Dispose();
            this.Close();  
        }
    }
}



