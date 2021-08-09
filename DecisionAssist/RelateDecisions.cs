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
    public partial class RelateDecisions : Form
    {
        SqlConnection con = new SqlConnection("data source= IMRAN;database=DAssist;integrated security= SSPI");

        string[] impact = new string[8];
        private int pro_id;
        public RelateDecisions(int p)
        {
            InitializeComponent();
            pro_id = p;
        }
        DataTable decisiondt=new DataTable();
        DataTable decisiondt1 = new DataTable();
        private void loadDRbutton_Click(object sender, EventArgs e)
        {
            decisiondt.Rows.Clear();
            decisiondt.Columns.Clear();
            SqlCommand cmd8 = new SqlCommand("select DD_name,DD_des,catagoryName from DesignDecision as d inner join DCatagory as c on d.catagory_id=c.catagory_id where d.Project_id='"+pro_id+"'", con);
            con.Open();
            SqlDataReader dr8 = cmd8.ExecuteReader();
            while (dr8.Read())
            {
                if (!comboBox2.Items.Contains(dr8["catagoryName"]))
                {
                    comboBox2.Items.Add(dr8["catagoryName"]);
                }
                if (!comboBox3.Items.Contains(dr8["catagoryName"]))
                {
                    comboBox3.Items.Add(dr8["catagoryName"]);
                }
            }
            SqlDataAdapter addd = new SqlDataAdapter();
            addd.SelectCommand = cmd8;
            
            con.Close();
            dr8.Close();
            addd.Fill(decisiondt);
            addd.Fill(decisiondt1);
            // DataView dv = new DataView(ds.Tables[0]);
            dataGridView1.DataSource = decisiondt;
            dataGridView18.DataSource = decisiondt1;

        }

        private void DtoDrelationbutton_Click(object sender, EventArgs e)
        {
            int dr1 = 0, dr2 = 0;
            for (int i = dataGridView18.RowCount - 1; i >= 0; i--)
            {
                DataGridViewRow row = dataGridView18.Rows[i];
                if (Convert.ToBoolean(row.Cells["dg18select"].Value))
                {
                    for (int j = dataGridView1.RowCount - 1; j >= 0; j--)
                    {
                        DataGridViewRow roww = dataGridView1.Rows[j];
                        if (Convert.ToBoolean(roww.Cells["dg1select"].Value))
                        {
                            String idd = Convert.ToString(dataGridView18.Rows[i].Cells["DD_name"].Value.ToString());
                            String iddd = Convert.ToString(dataGridView1.Rows[j].Cells["DD_name"].Value.ToString());
                            //SqlCommand cmd10 = new SqlCommand("insert into DecisionDecImpact(dr1_id,dr2_id,impact) select dd.DR_id,dr.DR_id,'"+impact[7]+"' from DecisionRepo as dd inner join DecisionDecImpact di on dd.DR_id=di.dr1_id inner join DecisionRepo as dr on dr.DR_id=di.dr2_id  where  dd.DR_name='" + iddd + "' and dr.DR_name='" + idd + "'", con);
                            SqlCommand cmd10 = new SqlCommand("select DD_id from DesignDecision where DD_name='" + idd + "' and Project_id='"+pro_id+"'", con);
                            con.Open();
                            SqlDataReader dr = cmd10.ExecuteReader();
                            while (dr.Read())
                            {
                                dr1 = Convert.ToInt32(dr["DD_id"]);
                            }
                            con.Close();
                            dr.Close();
                            SqlCommand cmd11 = new SqlCommand("select DD_id from DesignDecision where DD_name='" + iddd + "' and Project_id='"+pro_id+"'", con);
                            con.Open();
                            SqlDataReader dr3 = cmd11.ExecuteReader();
                            while (dr3.Read())
                            {
                                dr2 = Convert.ToInt32(dr3["DD_id"]);
                            }
                            con.Close();
                            dr3.Close();

                            SqlCommand cmd12 = new SqlCommand("insert into DecisionDecImpact(dd1_id,dd2_id,impact) select '" + dr1 + "','" + dr2 + "','" + impact[1] + "'", con);
                            con.Open();
                            cmd12.ExecuteReader();
                            con.Close();
                        }
                    }
                }
            }
            MessageBox.Show("Relation successfull");
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            impact[1] = "positive";
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            impact[1] = "negative";
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            impact[1] = "neutral";
        }
    }
}
