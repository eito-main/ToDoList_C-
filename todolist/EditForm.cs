using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace todolist
{
    public partial class EditForm : Form
    {

        MySqlConnection conn = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();

        string selfId = "";

        public EditForm(string id,string todo, string date_time, string place, string category)
        {
            InitializeComponent();
            selfId = id;
            todoTb.Text = todo;
            placeTb.Text = place;
            categoryTb.Text = category;
            string date_time_return = date_time.Replace("-", "/");
            dtp.Value = DateTime.Parse(date_time_return);
   
        }

        private void editB_Click(object sender, EventArgs e)
        {
            string id = "任意";
            string password = "任意";
            string database = "任意";
            string table = "任意";

            if (todoTb.Text == "" || placeTb.Text == "" || categoryTb.Text == "")
            {
                MessageBox.Show("未入力欄があります");
                return;
            };
            conn.ConnectionString = $"Data Source=localhost;Database={database};User ID={id};password={password}";
            conn.Open();

            string todo = todoTb.Text;
            string date_time = dtp.Value.ToShortDateString().Replace("/", "-");
            string place = placeTb.Text;
            string category = categoryTb.Text;

            cmd.CommandText = $"update {table} set todo = \"{todo}\",date_time = \"{date_time}\",place = \"{place}\",category =\"{category}\" where id = \"{selfId}\";";
            cmd.Connection = conn;
            using (MySqlDataReader reader = cmd.ExecuteReader());
            conn.Close();
            this.Dispose();
            this.Close();
        }
    }
}
