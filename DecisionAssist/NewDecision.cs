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
    public partial class NewDecision : Form
    {
        SqlConnection con = new SqlConnection("data source= IMRAN;database=DAssist;integrated security= SSPI");

        int pro_id;
        public NewDecision(int x)
        {
            InitializeComponent();
            pro_id = x;
        }
        DecisionTraceConcern dtc;
        private void button1_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure to add this as design decision","save decision", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("insert into DesignDecision(DD_name,DD_des,DD_type,Project_id) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + pro_id + "') ", con);
                con.Open();
                cmd.ExecuteReader();
                con.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                dtc = new DecisionTraceConcern(pro_id,textBox1.Text);
                dtc.Show();
            }
            
        }

        private void NewDecision_Load(object sender, EventArgs e)
        {

        }
    }
}
