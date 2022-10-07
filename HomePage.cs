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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }
        
        MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=datapet;charset=utf8;");
        public static string SetValueForText1 = "";
        
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RegisterUser().Show();
        }

        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminLogin().Show();
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT COUNT(*) FROM login WHERE username='" + TextUsername.Text + "' AND password='" + TextPassword.Text + "'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                SetValueForText1 = TextUsername.Text;

                UserEditData frm2 = new UserEditData();
                this.Hide();
                new P_PetShop().Show();
            }

            else { 
                MessageBox.Show("Invalid username or password");
                }
        }
    }
}
