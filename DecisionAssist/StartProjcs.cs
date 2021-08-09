using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DecisionAssist
{
    public partial class StartProjcs : UserControl
    {
        private static StartProjcs _instance;
        public static StartProjcs Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new StartProjcs();
                return _instance;
            }

        }
        public StartProjcs()
        {
            InitializeComponent();
        }
        //SqlConnection con = new SqlConnection("data source= IMRAN;database=DAssist;integrated security= SSPI");
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DAssist.mdf;Initial Catalog=DAssist;Integrated Security=True;Connect Timeout=30");

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text != "")
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("insert into Project(Project_name,Project_des) values ('" + textBox1.Text + "','" + textBox2.Text + "')", con);
                cmd1.ExecuteReader();
                con.Close();
                // ProjectFrom pf = new ProjectFrom();
                //this.Visible = false;
                // Form1 f1 = new Form1();
                // f1.Visible = false;
                // pf.Show();


                //int project_count = 0;
                SqlCommand cmd = new SqlCommand("select Project_id from Project where Project_name='" + textBox1.Text + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    //ss= Convert.ToInt32(dr["Project_id"]);
                }
                con.Close();
                //Form2 f2 = new Form2(textBox1.Text);
                //f2.Show();
            }
            else
            {
                MessageBox.Show("Enter Project Name");
            }
            
        }
    }
}
