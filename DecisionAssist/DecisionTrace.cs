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
    public partial class DecisionTrace : UserControl
    {
        private static DecisionTrace _instance;
        public static DecisionTrace Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DecisionTrace();
                return _instance;
            }

        }
        private int pp;
        public int p
        {
            get { return pp; }
            set { pp = value; }
        }
        SqlConnection con = new SqlConnection("data source= IMRAN;database=DAssist;integrated security= SSPI");
        List<string> qg = new List<string>();
        public DecisionTrace()
        {
            InitializeComponent();
            

            //SqlConnection con = new SqlConnection("data source= IMRAN;database=RDSADD;integrated security= SSPI");
            //SqlCommand cmd3 = new SqlCommand("select  FR_name from Trace as t inner join DesignDecision as dd on t.DD_id=dd.DD_id inner join FunctReq as f on t.DC_id=f.FR_id where dd.Decision_name='layer'", con);
            //con.Open();
            //SqlDataReader dr3 = cmd3.ExecuteReader();
            ////// BindingSource bs3 = new BindingSource();
            //////bs3.DataSource = dr3;
            //////dataGridView1.DataSource = bs3;
            ////// dataGridView2.ColumnCount = 2;
            ////dataGridView2.Columns.Add("Decision_name", "Decision name");
            ////dataGridView2.Columns.Add("FR_name","FR name");
            //while (dr3.Read())
            //{
            //    //dataGridView2.Columns[x].Name = "Decision_name";
            //    //dataGridView2.Columns[1].Name = "FR_name";

            //    int m = dataGridView3.Rows.Add();
            //   // dataGridView3.Rows[m].Cells[0].Value = dr3["Decision_name"];
            //    dataGridView3.Rows[m].Cells[1].Value = dr3["FR_name"];
            //}
            //dr3.Close();
            //con.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand cmd3 = new SqlCommand("select DD_name from DesignDecision where Project_id='" + pp + "'", con);
            con.Open();
            SqlDataReader dr3 = cmd3.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (dr3.Read())
            {

                int m = dataGridView1.Rows.Add();
                //  dataGridView3.Rows[m].Cells[0].Value = dr3["Decision_name"];
                dataGridView1.Rows[m].Cells[0].Value = dr3["DD_name"];
            }
            dr3.Close();
            con.Close();
           
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView3.Rows.Clear();
            String iddd = (dataGridView1.Rows[e.RowIndex].Cells["DDecision"].Value.ToString());
            Console.WriteLine(iddd.ToString()+" "+pp);
            SqlCommand cmd3 = new SqlCommand("select FR_name from Trace as t inner join DesignDecision as dd on t.DD_it=dd.DD_id inner join FunctReq as f on t.FR_id=f.FR_id where dd.DD_name='" + iddd + "'", con);
           // SqlCommand cmd3 = new SqlCommand("select FR_name from FunctReq as f where f.PDC_id=" + p + " ", con);
            con.Open();
            SqlDataReader dr3 = cmd3.ExecuteReader();
            dataGridView3.Rows.Clear();
            while (dr3.Read())
            {
                
                int m = dataGridView3.Rows.Add();
              //  dataGridView3.Rows[m].Cells[0].Value = dr3["Decision_name"];
                dataGridView3.Rows[m].Cells[0].Value = dr3["FR_name"];

            }
            dr3.Close();
            con.Close();
            SqlCommand cmd = new SqlCommand("select  Dc_name from Trace as t inner join DesignDecision as dd on t.DD_it=dd.DD_id inner join DConst as dc on t.DC_id=dc.Dc_id where dc.Project_id=" + p + " and dd.DD_name='" + iddd + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int n = dataGridView3.Rows.Add();
                dataGridView3.Rows[n].Cells[0].Value = dr["Dc_name"];
            }

            dr.Close();
            con.Close();

            SqlCommand cmd1 = new SqlCommand("select QA_name, Impact from DecisionQAimpact as t inner join DecisionRepo as dr on t.DR_id = dr.DR_id inner join QualityAttribute as f on t.QA_id = f.QA_id where dr.DR_name = '"+iddd+"'", con);
            con.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                int n = dataGridView3.Rows.Add();
                dataGridView3.Rows[n].Cells[0].Value = dr1["QA_name"];
                dataGridView3.Rows[n].Cells[1].Value = dr1["Impact"];
                if (dataGridView3.Rows[n].Cells[1].Value.ToString() == "negative")
                {
                    dataGridView3.Rows[n].DefaultCellStyle.BackColor = Color.Red;
                }
            }

            dr1.Close();
            con.Close();

            SqlCommand cmd10 = new SqlCommand("select QA_name, Impact from DecisionQAimpact as t inner join DesignDecision as dr on t.DD_id = dr.DD_id inner join QualityAttribute as f on t.QA_id = f.QA_id where dr.DD_name = '" + iddd + "'", con);
            con.Open();
            SqlDataReader dr10 = cmd10.ExecuteReader();

            while (dr10.Read())
            {
                int n = dataGridView3.Rows.Add();
                dataGridView3.Rows[n].Cells[0].Value = dr10["QA_name"];
                dataGridView3.Rows[n].Cells[1].Value = dr10["Impact"];
                if (dataGridView3.Rows[n].Cells[1].Value.ToString() == "negative")
                {
                    dataGridView3.Rows[n].DefaultCellStyle.BackColor = Color.Red;
                }
            }

            dr10.Close();
            con.Close();



        }

        private void button2_Click(object sender, EventArgs e)
        { List<string> fr = new List<string>();
            SqlCommand cmd1 = new SqlCommand("select FR_name from Trace as t inner join DesignDecision as dd on t.DD_it=dd.DD_id inner join FunctReq as f on t.FR_id=f.FR_id where f.Project_id='"+pp+"'", con);
            con.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                fr.Add(dr1["FR_name"].ToString());
            }
            dr1.Close();
            con.Close();
            List<string> frr = new List<string>();
            SqlCommand cmd2 = new SqlCommand("select FR_name from FunctReq as f where f.Project_id='" + pp + "'", con);
            con.Open();
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                frr.Add(dr2["FR_name"].ToString());
            }
            dr2.Close();  
            con.Close();
            dataGridView2.Rows.Clear();
            foreach (string s in frr)
            {
                //Console.WriteLine(s);
                if (fr.Contains(s)==false)
                {
                    int n = dataGridView2.Rows.Add();
                    dataGridView2.Rows[n].Cells[0].Value =s;
                   
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select QA_name from QualityGoal as q inner join QualityAttribute as qa on q.QA_id=qa.QA_id where Project_id='" + pp + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                qg.Add(dr["QA_name"].ToString());
                /*ListViewItem item = new ListViewItem(dr["QG_name"].ToString());
                 listView1.Items.Add(item);*/
               // Console.WriteLine(dr["QA_name"]);
            }
            dr.Close();
            con.Close();
            dataGridView4.Rows.Clear();
            for (int i = 0; i < qg.Count; i++)
            {
                SqlCommand cmd2 = new SqlCommand("select DD_name,DD_des from DecisionQAimpact as i inner join DesignDecision as dd on i.DD_id = dd.DD_id inner join QualityAttribute as q on i.QA_id=q.QA_id Where dd.Project_id='" + pp + "' and i.Impact = 'negative' and q.QA_name='"+qg[i]+"' ", con);
                con.Open();
                SqlDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    int n = dataGridView4.Rows.Add();
                    dataGridView4.Rows[n].Cells[0].Value = dr2["DD_name"];
                    dataGridView4.Rows[n].Cells[1].Value = dr2["DD_des"];
                    Console.WriteLine(dr2["DD_name"]);
                    dataGridView4.Rows[n].DefaultCellStyle.BackColor = Color.Red;
                }

                dr2.Close();
                con.Close();
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView3.Rows.Clear();
            String iddd = (dataGridView4.Rows[e.RowIndex].Cells["Conflicted_decison"].Value.ToString());
            SqlCommand cmd1 = new SqlCommand("select QA_name, Impact from DecisionQAimpact as t inner join DesignDecision as dr on t.DD_id = dr.DD_id inner join QualityAttribute as f on t.QA_id = f.QA_id where dr.DD_name = '" + iddd + "'", con);
            con.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                int n = dataGridView3.Rows.Add();
                dataGridView3.Rows[n].Cells[0].Value = dr1["QA_name"];
                dataGridView3.Rows[n].Cells[1].Value = dr1["Impact"];
                if (dataGridView3.Rows[n].Cells[1].Value.ToString() == "negative")
                {
                    dataGridView3.Rows[n].DefaultCellStyle.BackColor = Color.Red;
                }
            }

            dr1.Close();
            con.Close();
        }

        private void DecisionTrace_Load(object sender, EventArgs e)
        {
            
        }
    }
}
