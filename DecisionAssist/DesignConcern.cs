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
    public partial class DesignConcern : UserControl
    {
        private static DesignConcern _instance;
        public static DesignConcern Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DesignConcern();
                return _instance;
            } 

        }
        private string pp;
        public string p
        {
            get { return pp; }
            set { pp = value; }
        }
        private int ii;
        public int i    
        {
            get { return ii; }
            set { ii= value; }
        }
        public DesignConcern()
        {
            InitializeComponent();
            //Form2 f2 = new Form2("de");
            //panel10.Visible = false;
          
        }

        private void DesignConcern_Load(object sender, EventArgs e)
        {

        }
        QG q;

        private void button2_Click(object sender, EventArgs e)
        {
            q = new QG(ii);
            q.Show();
        }
       DConcern f;
        private void button1_Click(object sender, EventArgs e)
        {
            //panel10.Visible = true;
            //if (!panel10.Controls.Contains(DesignConcernFRDc.Instance))
            //{
            //    panel10.Controls.Add(DesignConcernFRDc.Instance);
            //    DesignConcernFRDc.Instance.Dock = DockStyle.Fill;
            //    DesignConcernFRDc.Instance.BringToFront();
            //    DesignConcernFRDc.Instance.bb = 1;
            //    DesignConcernFRDc.Instance.i =ii ;
            //    //MessageBox.Show("Use the tool to input Design Concerns" + Environment.NewLine + "For Functional Requirement Click FR" + Environment.NewLine + "For Design Constraints Click Constaints and For Quality Goal Click QG", "Design Concerns");
            //}
            //else {
            //    DesignConcernFRDc.Instance.BringToFront();
            //    //  MessageBox.Show("Use the tool to input Design Concerns"+Environment.NewLine+ " For Functional Requirement Click FR, For Design Constraints Click DConst and For Quality Goal Click QG", "Design Concerns");
            //}
            f = new DConcern(ii,1);
            f.Show();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            
        }

       

        private void button4_Click_1(object sender, EventArgs e)
        {
           // string s = label3.Text;
            Console.WriteLine(pp.ToString());
            Console.WriteLine(ii);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source= IMRAN;database=DAssist;integrated security= SSPI";
            SqlCommand cmd = new SqlCommand("select FR_name, FR_desc from FunctReq where Project_id="+ii+"", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            // BindingSource bs = new BindingSource();
            //bs.DataSource = dr;
            //dataGridView1.DataSource = bs;
            while (dr.Read())
            {
                int m = dataGridView1.Rows.Add();
                dataGridView1.Rows[m].Cells[0].Value = "Functional Requirement";
                dataGridView1.Rows[m].Cells[1].Value = dr["FR_name"];
                dataGridView1.Rows[m].Cells[2].Value = dr["FR_desc"];
            }
            dr.Close();
            con.Close();

            SqlCommand cmd1 = new SqlCommand("select QA_name, QA_des from QualityGoal as qg inner join QualityAttribute as qa on qg.QA_id=qa.QA_id  where Project_id=" + ii + "", con);
            con.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            
            while (dr1.Read())
            {
                int m = dataGridView1.Rows.Add();
                dataGridView1.Rows[m].Cells[0].Value = "Quality Goal";
                dataGridView1.Rows[m].Cells[1].Value = dr1["QA_name"];
                dataGridView1.Rows[m].Cells[2].Value = dr1["QA_des"];
            }
            dr1.Close();
            con.Close();

            SqlCommand cmd2 = new SqlCommand("select Dc_name, Dc_des from DConst where Project_id=" + ii + "", con);
            con.Open();
            SqlDataReader dr2 = cmd2.ExecuteReader();
          
            while (dr2.Read())
            {
                int m = dataGridView1.Rows.Add();
                dataGridView1.Rows[m].Cells[0].Value = "Design Constraints";
                dataGridView1.Rows[m].Cells[1].Value = dr2["Dc_name"];
                dataGridView1.Rows[m].Cells[2].Value = dr2["Dc_des"];
            }
            dr2.Close();
            con.Close();
        }
        RelateConcerns rc;
        private void button5_Click(object sender, EventArgs e)
        {
            rc = new RelateConcerns(ii);
            rc.Show();
        }
    }
}
