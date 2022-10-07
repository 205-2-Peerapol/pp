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
    public partial class RegisterUser : Form
    {
        public RegisterUser()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=datapet;charset=utf8;");
                    String sql = "INSERT INTO login (name,surname,tell,id_number,line_id,address,username,password) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + TextID.Text + "','" + TextLine.Text + "','" + TextHome.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    con.Open();

                    int rows = cmd.ExecuteNonQuery();

                    con.Close();

                    if (rows > 0)
                    {
                        MessageBox.Show("เพิ่มข้อมูลสำเร็จ");
                        this.Hide();
                        new HomePage().Show();
                    }
                    else
                    {
                        MessageBox.Show("รหัสผ่านไม่ตรงกัน");
                    }
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

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

        private void textBox4_TextChanged(object sender, EventArgs e)
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

        private void TextVerify_TextChanged(object sender, EventArgs e)
        {

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

        private void TextHome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
