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
    public partial class Form2 : Form
    {
        //private string a;
        //public string x
        //{
        //    get { return a; }
        //    set { a = value; }

        //}
        SqlConnection con = new SqlConnection("data source= IMRAN;database=DAssist;integrated security= SSPI");
        private int ss;
        
        public Form2(string s)
        {
            InitializeComponent();

            this.Text = "Decision-Assist:" + s;
            label2.Text=s;
           
            SqlCommand cmd = new SqlCommand("select Project_id from Project as p where p.Project_name ='"+s+"'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ss =Convert.ToInt32(dr["Project_id"]);
            }
            Console.WriteLine(ss);
            dr.Close();
            con.Close();

            
        }

       
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
       
       
        private void button1_Click(object sender, EventArgs e)
        {
            if (!panel.Controls.Contains(DesignConcern.Instance))
            {
                panel.Controls.Add(DesignConcern.Instance);
                DesignConcern.Instance.Dock = DockStyle.Fill;
                DesignConcern.Instance.BringToFront();
                DesignConcern.Instance.p = label2.Text;
                DesignConcern.Instance.i = ss;
                MessageBox.Show("Use the tool to input Design Concerns" + Environment.NewLine + "For Functional Requirement Click FR" + Environment.NewLine + "For Design Constraints Click Constaints and For Quality Goal Click QG","Design Concerns");
            }
            else { 
                DesignConcern.Instance.BringToFront();
              //  MessageBox.Show("Use the tool to input Design Concerns"+Environment.NewLine+ " For Functional Requirement Click FR, For Design Constraints Click DConst and For Quality Goal Click QG", "Design Concerns");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (!panel.Controls.Contains(DesignDecisions.Instance))
            {
                panel.Controls.Add(DesignDecisions.Instance);
                DesignDecisions.Instance.Dock = DockStyle.Fill;
                DesignDecisions.Instance.BringToFront();
                // DesignDecisions.Instance.p = label2.Text;
                DesignDecisions.Instance.x = ss;
            }
            else
                DesignDecisions.Instance.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (!panel.Controls.Contains(DecisionTrace.Instance))
            {
                panel.Controls.Add(DecisionTrace.Instance);
                DecisionTrace.Instance.Dock = DockStyle.Fill;
                DecisionTrace.Instance.BringToFront();
                // DecisionTrace.Instance.p = label2.Text;
                DecisionTrace.Instance.p = ss;
            }
            else
                DecisionTrace.Instance.BringToFront();
        }

     

        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            panel.Controls.Clear();
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            //DialogResult dialogOpen = MessageBox.Show("Use the navigation menu to get started.", "Welcome!",MessageBoxButtons.OKCancel);
            if (MessageBox.Show("Use the navigation menu to get started.", "Welcome!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (MessageBox.Show("First Lets Click Design Concern Button to input Design Concerns", "First Step!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (MessageBox.Show("Next Click Design Decision Button to insert Design Decisions", "Second Step!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        MessageBox.Show("Finally Click Traceability button for Design Concern to Decision to Impact Trace","Final Step");
                    }
                }
            }
          //  MessageBox.Show("First Lets Click Design Concern Button to input Design Concerns");
        }
    }
}
