using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DecisionAssist
{
    public partial class StartPJ : Form
    {
        public StartPJ()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("data source= IMRAN;database=RDSADD;integrated security= SSPI");
        
        private void StartPJ_Load(object sender, EventArgs e)
        {
          
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // con.Open();
            //SqlCommand cmd = new SqlCommand("select Project_id from Project", con);
            // var x=cmd.ExecuteReader();
           
           // con.Close();
            //con.Open();
          // SqlCommand cmd = new SqlCommand("insert into Project(Project_Id,Project_name,Project_description) values ('"+3+"','"+ textBox1.Text+ "','" + textBox2.Text + "')", con);
            //Console.WriteLine(x);
//cmd.ExecuteReader();
  //          con.Close();
            Form2 f2 = new Form2(textBox1.Text);
            f2.Show();
        }
    }
}
