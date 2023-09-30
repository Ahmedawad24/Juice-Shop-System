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
using Tulpep.NotificationWindow;

namespace BookShopMangement.FORMS
{
    public partial class DataBase : Form
    {
        int slide = 0;
        int PanelWidth;
        bool isCollapsed;
        Timer tt = new Timer();
        List<PopupNotifier> p = new List<PopupNotifier>();
        int i = 0;
        DateTime d=new DateTime();
        public DataBase()
        {
            InitializeComponent();
            PanelWidth = panelleft.Width;
          
            tt.Tick += Tt_Tick;
            tt.Start();
            tt.Interval= 4000;
            isCollapsed = false;
            this.KeyDown += DataBase_KeyDown;
          
        }

        private void DataBase_KeyDown(object sender, KeyEventArgs e)
        {
            
          
            if (e.KeyCode == Keys.F10)
            {
                view v = new view("");
                v.Show();
            }
        }

       
      

        public void checkQ()
        {
            string cont = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection con = new SqlConnection(cont);
            try
            {
                String sql = "SELECT ProductName FROM dbo.wharehouse WHERE quantity < 2 ";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                con.Open();
                DataSet thisDataSet = new DataSet();

                adt.Fill(thisDataSet, "wharehouse");

                foreach (DataRow row in thisDataSet.Tables["wharehouse"].Rows)
                {
                    PopupNotifier pop = new PopupNotifier();
                    pop.Image = Properties.Resources._1;
                    pop.BodyColor = System.Drawing.Color.OldLace;
                    pop.BorderColor = System.Drawing.Color.Goldenrod;
                    pop.HeaderColor= System.Drawing.Color.Goldenrod;
                    pop.ImagePadding = new Padding(10, 20, 10, 10);
                    pop.TitlePadding = new Padding(10, 25, 0, 0);
                    pop.ContentPadding = new Padding(10, 0, 0, 0);
                    pop.TitleColor = Color.Red;
                    pop.Click += Pop_Click;
                    pop.TitleText = row["ProductName"].ToString();
                    pop.ContentText = "Run out of your " + row["ProductName"];
                   
                    p.Add(pop);

                }
               
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Pop_Click(object sender, EventArgs e)
        {
            view v = new view("");
            v.Show();
        }
        private void Tt_Tick(object sender, EventArgs e)
        {
            if (i < p.Count)
            {
                p[i].Popup();
                i++;
            }
            label1.Text = DateTime.Now.ToString("T");

        }

        private void DataBase_Load(object sender, EventArgs e)
        {
            checkQ();
            label1.Text = DateTime.Now.ToString("T");
            label2.Text = DateTime.Now.ToString("dddd");

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btnSaloon);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (isCollapsed)
            {
                panelleft.Width = panelleft.Width + 100;
                if (panelleft.Width >= PanelWidth)
                {
                    panelleft.Width = panelleft.Width - 80;
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();
                  
                }
                
            }
            else
            {
                    panelleft.Width = panelleft.Width - 100;

                    if (panelleft.Width <= 0)
                    {
                        timer1.Stop();
                        isCollapsed = true;
                        this.Refresh();

                    }
                
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void MoveSidePanel (Control btn)
        {
            panelside.Top = btn.Top;
            panelside.Height = btn.Height;
        }

        private void btnEmpolyees_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btnEmpolyees);
            view v = new view("");
            v.Show();

        }

        private void btnUpdateStorage_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btnUpdateStorage);
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btnAddOrder);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            storage s = new storage();
            s.Show();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
