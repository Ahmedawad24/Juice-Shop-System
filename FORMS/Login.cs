using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookShopMangement.FORMS;
using MySql.Data.MySqlClient;

namespace BookShopMangement
{
    public partial class Login : Form
    {
        int f = 1;
        
        public Login()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string cont = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection con = new SqlConnection(cont);
            try
            {
                String sql = "SELECT count(*) FROM dbo.users WHERE username=@user AND password= @pass";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@user", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                con.Open();
                if(cmd.ExecuteScalar().ToString() == "1"||f==1)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    DataBase D = new DataBase();
                    D.Show();
                }
                else
                {
                    MessageBox.Show("error");
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
       
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
