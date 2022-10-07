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
    public partial class UserEditData : Form
    {
        public UserEditData()
        {
            InitializeComponent();
        }
        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";
        public static string SetValueForText3 = "";
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
            cmd.CommandText = "SELECT * FROM login where username ='" + HomePage.SetValueForText1 + "'";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();

            dataGridView1.DataSource = ds.Tables[0].DefaultView;

        }
        private void btnShop_Click(object sender, EventArgs e)
        {
            this.Hide();
            SetValueForText1 = textBox1.Text;
            SetValueForText2 = textBox2.Text;
            SetValueForText3 = textBox3.Text;

            P_PetShop frm2 = new P_PetShop();
            frm2.Show();
        }

        private void UserEditData_Load(object sender, EventArgs e)
        {
            showEquipment();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].FormattedValue.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["surname"].FormattedValue.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["tell"].FormattedValue.ToString();
            TextID.Text = dataGridView1.Rows[e.RowIndex].Cells["id_number"].FormattedValue.ToString();
            TextLine.Text = dataGridView1.Rows[e.RowIndex].Cells["line_id"].FormattedValue.ToString();
            TextHome.Text = dataGridView1.Rows[e.RowIndex].Cells["address"].FormattedValue.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["username"].FormattedValue.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["password"].FormattedValue.ToString();
        }

        private void btnAddData_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("กรุณากรอกชื่อ");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("กรุณากรอกนามสกุล");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("กรุณากรอกเบอร์โทร");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("กรุณากรอกUserName");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("กรุณากรอกPassword");
            }
            else if (TextHome.Text == "")
            {
                MessageBox.Show("กรุณากรอกที่อยู่");
            }
            else if (TextLine.Text == "")
            {
                MessageBox.Show("กรุณากรอกID Line");
            }
            else if (TextID.Text == "")
            {
                MessageBox.Show("กรุณากรอกบัตรประชาชน");
            }
            else
            {
                if (textBox5.Text == TextVerify.Text)
                {
                    int selectedRow = dataGridView1.CurrentCell.RowIndex;
                    int editId = Convert.ToInt32(dataGridView1.Rows[selectedRow].Cells["id"].Value);
                    MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=datapet;charset=utf8;");
                    String sql = "UPDATE login SET name = '" + textBox1.Text + "',surname = '" + textBox2.Text + "',tell = '" + textBox3.Text + "',id_number = '" + TextID.Text + "',line_id = '" + TextLine.Text + "',address = '" + TextHome.Text + "',username = '" + textBox4.Text + "',password = '" + textBox5.Text + "' WHERE id = '" + editId + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    con.Open();

                    int rows = cmd.ExecuteNonQuery();

                    con.Close();

                    if (rows > 0)
                    {
                        MessageBox.Show("เพิ่มข้อมูลสำเร็จ");
                        showEquipment();
                        SetValueForText1 = textBox1.Text;
                        SetValueForText2 = textBox2.Text;
                        SetValueForText3 = textBox3.Text;

                    }
                }
                else
                {
                    MessageBox.Show("รหัสผ่านไม่ตรงกัน");
                }
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = (e.KeyChar == (char)Keys.Space))
            {
                MessageBox.Show("Space Is Not Allowed ..");
            }
            else
            {
                e.Handled = false;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = (e.KeyChar == (char)Keys.Space))
            {
                MessageBox.Show("Space Is Not Allowed ..");
            }
            else
            {
                e.Handled = false;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = (e.KeyChar == (char)Keys.Space))
            {
                MessageBox.Show("Space Is Not Allowed ..");
            }
            else
            {
                e.Handled = false;
            }
        }

        private void TextLine_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = (e.KeyChar == (char)Keys.Space))
            {
                MessageBox.Show("Space Is Not Allowed ..");
            }
            else
            {
                e.Handled = false;
            }
        }

        private void TextID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = (e.KeyChar == (char)Keys.Space))
            {
                MessageBox.Show("Space Is Not Allowed ..");
            }
            else
            {
                e.Handled = false;
            }
        }

        private void TextHome_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = (e.KeyChar == (char)Keys.Space))
            {
                MessageBox.Show("Space Is Not Allowed ..");
            }
            else
            {
                e.Handled = false;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = (e.KeyChar == (char)Keys.Space))
            {
                MessageBox.Show("Space Is Not Allowed ..");
            }
            else
            {
                e.Handled = false;
            }
        }

        private void TextVerify_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = (e.KeyChar == (char)Keys.Space))
            {
                MessageBox.Show("Space Is Not Allowed ..");
            }
            else
            {
                e.Handled = false;
            }
        }
    }
}
