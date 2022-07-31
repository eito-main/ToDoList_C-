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
    public partial class TopForm : Form
    {
        //SQL接続に使うオブジェクト
        MySqlConnection conn = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();

        //DGVに列を追加するためのオブジェクト
        DataGridViewCheckBoxColumn chkDeleteDgvColumn = new DataGridViewCheckBoxColumn();
        DataGridViewTextBoxColumn idDgvColumn = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn todoDgvColumn = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn datetimeDgvColumn = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn placeDgvColumn = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn categoryDgvColumn = new DataGridViewTextBoxColumn();
        DataGridViewButtonColumn btnUpdateDgvColumn = new DataGridViewButtonColumn();
        DataGridViewTextBoxColumn overtimeDgvColumn = new DataGridViewTextBoxColumn();

        public TopForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームロード時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///
        private void update_dgv()
        {
            string id = "任意";
            string password = "任意";
            string database = "任意";
            string table = "任意";

            dgv.Rows.Clear();
            conn.ConnectionString = $"Data Source=localhost;Database={database};User ID={id}; password={password}";
            try
            {
                conn.Open();
                cmd.CommandText = $"SELECT * FROM {table};";
                cmd.Connection = conn;

                // クエリを発行
                // readerの中にはデータ(テーブルの値が入ります)
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    //DB内のテーブルにレコードがあった場合にそれを取得する
                    if (reader.HasRows)
                    {
                        int rowNo = 0;
                        int overtimes = 0;

                        String now = DateTime.Now.ToString("yyyy/MM/dd");
                        DateTime useNow = DateTime.Parse(now);

                        //1行ずつ繰り返し情報を取得する
                        while (reader.Read())
                        {
                            //DGVに行を追加する
                            dgv.Rows.Add(new DataGridViewRow());

                            //rows => 行、cells => 列
                            dgv.Rows[rowNo].Cells[0].Value = false;
                            dgv.Rows[rowNo].Cells[1].Value = reader[0];
                            dgv.Rows[rowNo].Cells[2].Value = reader[1];
                            dgv.Rows[rowNo].Cells[3].Value = reader[2];
                            dgv.Rows[rowNo].Cells[5].Value = reader[3];
                            dgv.Rows[rowNo].Cells[6].Value = reader[4];

                            string rowDateTime = dgv.Rows[rowNo].Cells[3].Value as string;
                            DateTime useRowDateTime = DateTime.Parse(rowDateTime.Replace("/", "-"));
                            TimeSpan ts = useNow - useRowDateTime;
                            dgv.Rows[rowNo].Cells[4].Value = $"{ts.Days}";

                            if (ts.Days > 0)
                            {
                                dgv.Rows[rowNo].Cells[4].Value = $"超過：{ts.Days}日";
                                overtimes += 1;
                            }
                            else if (ts.Days == 0)
                            {
                                dgv.Rows[rowNo].Cells[4].Value = $"本日";
                            }
                            else
                            {
                                dgv.Rows[rowNo].Cells[4].Value = $"残り：{-(ts.Days)}日";
                            }

                            rowNo++;
                        }
                    }
                }
            }
            catch (Exception example)
            {
                //接続失敗の時の処理
                MessageBox.Show(example.Message);
            }
            finally
            {
                //切断
                conn.Close();
            }
        }
        public void Form1_Load(object sender, EventArgs e)
        {
            string id = "任意";
            string password = "任意";
            string database = "任意";
            string table = "任意";

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false; 

            //DGVの各ヘッダーおよびボタンの表示名設定
            chkDeleteDgvColumn.HeaderText = "チェック";
            idDgvColumn.HeaderText = "番号";
            todoDgvColumn.HeaderText = "予定";
            datetimeDgvColumn.HeaderText = "日時";
            placeDgvColumn.HeaderText = "場所";
            categoryDgvColumn.HeaderText = "カテゴリ";
            btnUpdateDgvColumn.Text = "編集";

            overtimeDgvColumn.HeaderText = "超過時間";
            int overtimes = 0;

            //DGV内ボタンの設定と名前
            btnUpdateDgvColumn.UseColumnTextForButtonValue = true;
            btnUpdateDgvColumn.Name = "編集";

            //DGVにヘッダーとそれに対応する列を作成する（上で宣言した名前を使う）
            dgv.Columns.Add(chkDeleteDgvColumn);
            dgv.Columns.Add(idDgvColumn);
            dgv.Columns.Add(todoDgvColumn);
            dgv.Columns.Add(datetimeDgvColumn);
            dgv.Columns.Add(overtimeDgvColumn);
            dgv.Columns.Add(placeDgvColumn);
            dgv.Columns.Add(categoryDgvColumn);
            dgv.Columns.Add(btnUpdateDgvColumn);

            conn.ConnectionString = $"Data Source=localhost;Database={database};User ID={id};password={password}";
            try
            {
                //接続
                conn.Open();
                cmd.CommandText = $"SELECT * FROM {table};";
                cmd.Connection = conn;

                // クエリを発行
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    //DB内のテーブルにレコードがあった場合にそれを取得する
                    if (reader.HasRows)
                    {
                        // 行数の値として使う
                        int rowNo = 0;
                        
                        String now = DateTime.Now.ToString("yyyy/MM/dd");
                        DateTime useNow = DateTime.Parse(now);
                        
                        //1行ずつ繰り返し情報を取得する
                        //テーブル内の行がなくなった時点でループから脱出
                        while (reader.Read())
                        {
                            //DGVに行を追加する
                            dgv.Rows.Add(new DataGridViewRow());

                            //rows => 行、cells => 列
                            dgv.Rows[rowNo].Cells[0].Value = false;
                            dgv.Rows[rowNo].Cells[1].Value = reader[0];
                            dgv.Rows[rowNo].Cells[2].Value = reader[1];
                            dgv.Rows[rowNo].Cells[3].Value = reader[2];
                            dgv.Rows[rowNo].Cells[5].Value = reader[3];
                            dgv.Rows[rowNo].Cells[6].Value = reader[4];
                            
                            string rowDateTime = dgv.Rows[rowNo].Cells[3].Value as string;
                            DateTime useRowDateTime = DateTime.Parse(rowDateTime.Replace("/", "-"));
                            TimeSpan ts = useNow - useRowDateTime;
                            dgv.Rows[rowNo].Cells[4].Value = $"{ts.Days}";

                            if (ts.Days > 0)
                            {
                                dgv.Rows[rowNo].Cells[4].Value = $"超過：{ts.Days}日";
                                overtimes += 1;
                            }
                            else if (ts.Days == 0)
                            {
                                dgv.Rows[rowNo].Cells[4].Value = $"本日";
                            }
                            else
                            {
                                dgv.Rows[rowNo].Cells[4].Value = $"残り：{-(ts.Days)}日";
                            }

                            rowNo++;

                        }
                    }
                }
            }
            catch (Exception example)
            {
                //接続失敗の時の処理
                MessageBox.Show(example.Message);
            }
            finally
            {
                //切断
                conn.Close();
            }

            if (overtimes > 0)
            {
                MessageBox.Show($"超過が{overtimes}件あります");
            }
        }

        private void registerTransitionBT_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddForm addform = new AddForm();
            addform.ShowDialog();
            this.update_dgv();
            this.Show();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; } //列ヘッダーをクリックした場合などにキャンセルする。			
            DataGridView dgv = (DataGridView)sender; //クリックした列が対象列かチェックする。

            if (dgv.Columns[e.ColumnIndex].Name != "編集")
            {
                return;
            }

            string take_id = dgv.CurrentRow.Cells[1].Value.ToString();
            string take_todo = dgv.CurrentRow.Cells[2].Value.ToString();
            string take_date_time = dgv.CurrentRow.Cells[3].Value.ToString();
            string take_place = dgv.CurrentRow.Cells[5].Value.ToString();
            string take_category = dgv.CurrentRow.Cells[6].Value.ToString();

            this.Hide();
            EditForm editForm = new EditForm(take_id, take_todo, take_date_time, take_place, take_category);
            editForm.ShowDialog();
            this.update_dgv();
            this.Show();

        }

        private void removeBT_Click(object sender, EventArgs e)
        {
            string id = "任意";
            string password = "任意";
            string database = "任意";


            int remove_item = 0;
            int?[] remove_item_box = new int?[0];

            for (int i = 0; i < dgv.RowCount; i++)
            {
                if (dgv.Rows[i].Cells[0].Value as bool? == true)
                {
                    remove_item += 1;
                    Array.Resize(ref remove_item_box, remove_item_box.Length + 1);
                    remove_item_box[remove_item_box.Length - 1] =
                        dgv.Rows[i].Cells[1].Value as int?;
                }
            }

            if (remove_item == 0)
            {
                MessageBox.Show("選択されていません");
                return;
            }

            DialogResult result = MessageBox.Show($"{remove_item}件削除しますか？",
                "質問",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                //「はい」が選択された時
                conn.ConnectionString = $"Data Source=localhost;Database={database};User ID={id};password={password}";
                for (int i = 0; i != remove_item_box.Length; i++)
                {
                conn.Open();

                cmd.CommandText = $"delete from todolist where id = \"{remove_item_box[i]}\";";
                cmd.Connection = conn;
                using (MySqlDataReader reader = cmd.ExecuteReader()) ;

                conn.Close();
                }
                this.update_dgv();
            }
            
        }
    }

}
