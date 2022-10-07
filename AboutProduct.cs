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

namespace Project03
{
    public partial class AboutProduct : Form
    {
        public AboutProduct()
        {
            InitializeComponent();
        }
        private MySqlConnection databaseConnection()
        {
            //Connection String สำหรับใช้เชื่อมต่อฐานข้อมูล โดยระบุชื่อ Host,Port,Username,Password และชื่อ database
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=datapet;charset=utf8;";

            //สร้างตัวแปลชื่อ conn เพื่อใช้เก็บการเชื่อมต่อฐานข้อมูล โดยใส่ค่า conncetionstring เข้าไป
            MySqlConnection conn = new MySqlConnection(connectionString);

            //ส่งค่าการเชื่อมต่อฐานข้อมูลกลับไปยังที่ที่เรียกใช้งาน Method
            return conn;
        }
        private void showEquipment()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM product";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();

            dataGridView1.DataSource = ds.Tables[0].DefaultView;

        }
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AboutAdmin().Show();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            this.Hide();
            new OrderList().Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutProduct_Load(object sender, EventArgs e)
        {
            showEquipment();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();

            String sql = "INSERT INTO product (id,type,price) VALUES('" + TextID.Text + "','" + TextType.Text + "','" + TextPrice.Text + "')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();

            int rows = cmd.ExecuteNonQuery();

            conn.Close();

            if (rows > 0)
            {
                MessageBox.Show("เพิ่มข้อมูลสำเร็จ");
                showEquipment();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridView1.CurrentCell.RowIndex;
            int editId = Convert.ToInt32(dataGridView1.Rows[selectedRow].Cells["id"].Value);

            MySqlConnection conn = databaseConnection();
            String sql = "UPDATE product SET type ='" + TextType.Text + "',price = '" + TextPrice.Text + "'WHERE id = '" + editId + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();

            int rows = cmd.ExecuteNonQuery();

            conn.Close();

            if (rows > 0)
            {
                MessageBox.Show("แก้ไขข้อมูลสำเร็จ");
                showEquipment();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridView1.CurrentCell.RowIndex;
            int deleteId = Convert.ToInt32(dataGridView1.Rows[selectedRow].Cells["id"].Value);
            if (MessageBox.Show("ต้องการยืนยันการลบหรือไม่ ?", "confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                    MySqlConnection conn = databaseConnection();

                    String sql = "DELETE FROM product WHERE id = '" + deleteId + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    conn.Open();

                    int rows = cmd.ExecuteNonQuery();

                    conn.Close();

                    if (rows > 0)
                    {
                        MessageBox.Show("ลบข้อมูลสำเร็จ");
                        showEquipment();
                    }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            TextID.Text = dataGridView1.Rows[e.RowIndex].Cells["id"].FormattedValue.ToString();
        }
    }
}
