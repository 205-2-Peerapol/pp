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
    public partial class P_PetShop : Form
    {
        public P_PetShop()
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

            dataEquipment.DataSource = ds.Tables[0].DefaultView;

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminLogin().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Text += "******************************************************************************\n";
            richTextBox1.Text += "************************     Fees Receiot System     ************************\n";
            richTextBox1.Text += "******************************************************************************\n";
            richTextBox1.Text += "Date :" + DateTime.Now + "\n\n";
            richTextBox1.Text += "******************************************************************************\n";
            richTextBox1.Text += "ชื่อ : " + label5.Text + "  นามสกุล : " + label6.Text + "\nเบอร์โทรศัพท์ : " + label7.Text + "\n\n";
            richTextBox1.Text += "******************************************************************************\n";

            richTextBox1.Text += "ท่านได้ทำการสั่งจองสัตว์เลี้ยง ID ที่ : " + textBox1.Text + "\n\n";
            richTextBox1.Text += "ประเภท : " + textBox2.Text + "\n\n";
            richTextBox1.Text += "\n\nคิดเป็นเงิน : " + textBox3.Text + " บาท\n\nขอให้ลูกค้าบันทึกใบเสร็จ แล้วนำมาแสดงในวันที่มารับสัตว์เลี้ยง";

            richTextBox1.Text += "\n**************************************************************************** ";
            richTextBox1.Text += "\nพร้อมเพย์ : 0952610342 ";
            richTextBox1.Text += "\nหลังจากที่ลูกค้าได้ทำการจองแล้ว ให้ลูกค้ามารับสัตว์เลี้ยงที่ร้าน P-PetShop \nถนน คนกันเอง อ.เมือง จ.อะไรสักอย่าง ภายในเวลา 30 วัน";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการยืนยันคำสั่งซื้อ\nและปริ้นใบเสร็จหรือไม่ ?", "confirm order", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
                MySqlConnection conn = databaseConnection();

                String sql = "INSERT INTO order_list (id,type,price,time,name,surname,tell) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + DateTime.Now + "','"+label5.Text+"','"+label6.Text+"','"+label7.Text+"')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                conn.Close();

                if (rows > 0)
                {
                    MessageBox.Show("ท่านได้ยืนยันออเดอร์แล้ว");
                }
            }
        }

        private void P_PetShop_Load(object sender, EventArgs e)
        {
            showEquipment();
            label5.Text = UserEditData.SetValueForText1;
            label6.Text = UserEditData.SetValueForText2;
            label7.Text = UserEditData.SetValueForText3;
        }

        private void dataEquipment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataEquipment.CurrentRow.Selected = true;
            textBox1.Text = dataEquipment.Rows[e.RowIndex].Cells["id"].FormattedValue.ToString();
            textBox2.Text = dataEquipment.Rows[e.RowIndex].Cells["type"].FormattedValue.ToString();
            textBox3.Text = dataEquipment.Rows[e.RowIndex].Cells["price"].FormattedValue.ToString();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, new Font("Microsoft Scans Serif", 18, FontStyle.Bold), Brushes.Black, new Point(10, 10));
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            MySqlDataAdapter adapt;
            DataTable dt;
            conn.Open();
            adapt = new MySqlDataAdapter("select * from product where type like '" + textBox4.Text + "%'", conn);
            dt = new DataTable();
            adapt.Fill(dt);
            dataEquipment.DataSource = dt;
            conn.Close();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void dtnUserEdit_Click(object sender, EventArgs e)
        {
            this.Close();
            new UserEditData().Show();
        }

        private void btnShop_Click(object sender, EventArgs e)
        {

        }
    }

}
