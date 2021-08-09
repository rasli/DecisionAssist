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
    public partial class RelateConcerns : Form
    {
        SqlConnection con = new SqlConnection("data source= IMRAN;database=DAssist;integrated security= SSPI");
        int pro_id;
        bool fr = false,qg=false;  
        DataTable dt = new DataTable();
        public RelateConcerns(int p)
        {
            InitializeComponent();
            pro_id = p;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fr = true;
            qg = false;
            button3.Visible = true;
            dataGridView1.Rows.Clear();

            SqlCommand cmd8 = new SqlCommand("select FR_name,FR_desc from FunctReq where Project_id = '" + pro_id + "'", con);
            con.Open();
            //SqlDataAdapter ad = new SqlDataAdapter();
            //ad.SelectCommand = cmd8;
            SqlDataReader dr = cmd8.ExecuteReader();
            
            BindingSource bs = new BindingSource();
            bs.DataSource = dr;
            dataGridView1.DataSource = bs;
            dr.Close();
            //ad.Fill(dt);
            //dataGridView1.DataSource = dt;
            con.Close();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            qg = true;
            fr = false;
            panel1.Visible = false;
            button3.Visible = false;
            dataGridView1.Rows.Clear();
            SqlCommand cmd = new SqlCommand("select QA_name,QA_des from QualityGoal as q inner join QualityAttribute as qa on q.QA_id=qa.QA_id where q.Project_id = '" + pro_id + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            BindingSource bs = new BindingSource();
            bs.DataSource = dr;
            dataGridView1.DataSource = bs;
            dr.Close();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            panel2.Visible = false;
            panel1.Visible = true;
            panel1.BringToFront();
            SqlCommand cmd = new SqlCommand("select QA_name from QualityGoal as q inner join QualityAttribute as qa on q.QA_id=qa.QA_id where q.Project_id = '" + pro_id + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["QA_name"]);
            }
            dr.Close();
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel2.BringToFront();
            SqlCommand cmd = new SqlCommand("select Dc_name from DConst where Project_id='" + pro_id + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            BindingSource bs = new BindingSource();
            bs.DataSource = dr;
            dataGridView2.DataSource = bs;
            dr.Close();
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = dataGridView1.RowCount - 1; i >= 0; i--)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                if (Convert.ToBoolean(row.Cells["Column2"].Value))
                {
                    String idd = Convert.ToString(dataGridView1.Rows[i].Cells["FR_name"].Value.ToString());
                    SqlCommand cmd10 = new SqlCommand("insert into DC_Relation(FR_id,QG_id,Project_id) select FR_id,QG_id,dd.Project_id from FunctReq as dd inner join Project as p on dd.Project_id=p.Project_id inner join QualityGoal as f on p.Project_id=f.Project_id inner join QualityAttribute as q on f.QA_id=q.QA_id   where p.Project_id='" + pro_id + "' and q.QA_name='" + comboBox1.SelectedItem.ToString() + "' and dd.FR_name='" + idd + "'", con);
                    con.Open();
                    cmd10.ExecuteReader();
                    con.Close();                                                          
                }
            }
            MessageBox.Show("Relation successfull");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (fr)
            {
                for (int i = dataGridView1.RowCount - 1; i >= 0; i--)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    if (Convert.ToBoolean(row.Cells["Column2"].Value))
                    {
                        for (int j = dataGridView2.RowCount - 1; j >= 0; j--)
                        {

                            DataGridViewRow roww = dataGridView2.Rows[j];
                            if (Convert.ToBoolean(roww.Cells["sc"].Value))
                            {
                                String idd = Convert.ToString(dataGridView1.Rows[i].Cells["FR_name"].Value.ToString());
                                String iddd = Convert.ToString(dataGridView2.Rows[j].Cells["Dc_name"].Value.ToString());
                                SqlCommand cmd10 = new SqlCommand("insert into DC_Relation(FR_id,Dc_id,Project_id) select FR_id,Dc_id,dd.Project_id from FunctReq as dd inner join Project as p on dd.Project_id=p.Project_id inner join DConst as f on p.Project_id=f.Project_id where p.Project_id='" + pro_id + "' and f.Dc_name='" + iddd + "' and dd.FR_name='" + idd + "'", con);
                                con.Open();
                                cmd10.ExecuteReader();
                                con.Close();

                                //Console.WriteLine(idd + "  " + current);

                            }
                        }
                    }
                }
                MessageBox.Show("Relation successfull");
            }
            else if (qg)
            {
                for (int i = dataGridView1.RowCount - 1; i >= 0; i--)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    if (Convert.ToBoolean(row.Cells["Column2"].Value))
                    {
                        for (int j = dataGridView2.RowCount - 1; j >= 0; j--)
                        {

                            DataGridViewRow roww = dataGridView2.Rows[j];
                            if (Convert.ToBoolean(roww.Cells["sc"].Value))
                            {
                                String idd = Convert.ToString(dataGridView1.Rows[i].Cells["QA_name"].Value.ToString());
                                String iddd = Convert.ToString(dataGridView2.Rows[j].Cells["Dc_name"].Value.ToString());
                                SqlCommand cmd10 = new SqlCommand("insert into DC_Relation(QG_id,Dc_id,Project_id) select QG_id,Dc_id,dd.Project_id from QualityGoal as dd inner join Project as p on dd.Project_id=p.Project_id inner join QualityAttribute as q on dd.QA_id=q.QA_id inner join DConst as f on p.Project_id=f.Project_id where p.Project_id='" + pro_id + "' and f.Dc_name='" + iddd + "' and q.QA_name='" + idd + "'", con);
                                con.Open();
                                cmd10.ExecuteReader();
                                con.Close();

                                //Console.WriteLine(idd + "  " + current);

                            }
                        }
                    }
                }
                MessageBox.Show("Relation successfull");
            }
        }
    }
}
