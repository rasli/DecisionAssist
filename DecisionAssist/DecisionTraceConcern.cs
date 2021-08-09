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
    public partial class DecisionTraceConcern : Form
    {
        SqlConnection con = new SqlConnection("data source= IMRAN;database=DAssist;integrated security= SSPI");
        int pro_id;
        string dname;
        bool fr = false, dc = false;
       
        string[] impact = new string[7];
       
       // int count = 0;
        public DecisionTraceConcern(int x, string dn)
        {
            InitializeComponent();
            pro_id = x;
            dname = dn;

        }

        private void DecisionTraceConcern_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            SqlCommand cmd12 = new SqlCommand("select FR_name from FunctReq where Project_id='" + pro_id + "' ", con);
            con.Open();
            SqlDataReader dr12 = cmd12.ExecuteReader();
            BindingSource bs12 = new BindingSource();
            bs12.DataSource = dr12;
            dataGridView1.DataSource = bs12;
            dr12.Close();
            con.Close();
            fr = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            SqlCommand cmd12 = new SqlCommand("select Dc_name from DConst where Project_id='" + pro_id + "' ", con);
            con.Open();
            SqlDataReader dr12 = cmd12.ExecuteReader();
            BindingSource bs12 = new BindingSource();
            bs12.DataSource = dr12;
            dataGridView1.DataSource = bs12;
            dr12.Close();
            con.Close();
            dc = true;
        }

       

        private void button5_Click(object sender, EventArgs e)
        {
            
                SqlCommand cmd10 = new SqlCommand("insert into DecisionQAimpact(DD_id,QA_id,Impact) select DD_id,1,'" + impact[1] + "' from DesignDecision as dd inner join Project as p on dd.Project_id=p.Project_Id    where p.Project_id='" + pro_id + "' AND dd.DD_name='"+dname+"' ", con);
                con.Open();
                cmd10.ExecuteReader();
                con.Close();

            
           
                SqlCommand cmd = new SqlCommand("insert into DecisionQAimpact(DD_id,QA_id,Impact) select DD_id,2,'" + impact[2] + "' from DesignDecision as dd inner join Project as p on dd.Project_id=p.Project_Id    where p.Project_id='" + pro_id + "' AND dd.DD_name='" + dname + "' ", con);
                con.Open();
                cmd.ExecuteReader();
                con.Close();

            SqlCommand cmd1 = new SqlCommand("insert into DecisionQAimpact(DD_id,QA_id,Impact) select DD_id,3,'" + impact[3] + "' from DesignDecision as dd inner join Project as p on dd.Project_id=p.Project_Id    where p.Project_id='" + pro_id + "' AND dd.DD_name='" + dname + "' ", con);
            con.Open();
            cmd1.ExecuteReader();
            con.Close();

            SqlCommand cmd2 = new SqlCommand("insert into DecisionQAimpact(DD_id,QA_id,Impact) select DD_id,4,'" + impact[4] + "' from DesignDecision as dd inner join Project as p on dd.Project_id=p.Project_Id    where p.Project_id='" + pro_id + "' AND dd.DD_name='" + dname + "' ", con);
            con.Open();
            cmd2.ExecuteReader();
            con.Close();

            SqlCommand cmd3 = new SqlCommand("insert into DecisionQAimpact(DD_id,QA_id,Impact) select DD_id,5,'" + impact[5] + "' from DesignDecision as dd inner join Project as p on dd.Project_id=p.Project_Id    where p.Project_id='" + pro_id + "' AND dd.DD_name='" + dname + "' ", con);
            con.Open();
            cmd3.ExecuteReader();
            con.Close();

            SqlCommand cmd4 = new SqlCommand("insert into DecisionQAimpact(DD_id,QA_id,Impact) select DD_id,6,'" + impact[6] + "' from DesignDecision as dd inner join Project as p on dd.Project_id=p.Project_Id    where p.Project_id='" + pro_id + "' AND dd.DD_name='" + dname + "' ", con);
            con.Open();
            cmd4.ExecuteReader();
            con.Close();



            MessageBox.Show("successful");
        }

        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {
            
            impact[1] = "positive";
           
        }

        private void radioButton26_CheckedChanged(object sender, EventArgs e)
        {
          
            impact[2] = "positive";
           
        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
            impact[1] = "negative";
        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            impact[1] = "neutral";
        }

        private void radioButton25_CheckedChanged(object sender, EventArgs e)
        {
            impact[2] = "negative";
        }

        private void radioButton27_CheckedChanged(object sender, EventArgs e)
        {
            impact[2] = "neutral";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            impact[3] = "positive";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            impact[3] = "negative";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            impact[3] = "neutral";
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            impact[4] = "positive";
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            impact[4] = "negative";
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            impact[4] = "neutral";
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            impact[5] = "positive";
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            impact[5] = "negative";
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            impact[5] = "neutral";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            impact[6] = "positive";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            impact[6] = "negative";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            impact[6] = "neutral";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = dataGridView1.RowCount - 1; i >= 0; i--)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                if (Convert.ToBoolean(row.Cells["t_dc"].Value))
                {
                    if (fr)
                    {
                        String idd = Convert.ToString(dataGridView1.Rows[i].Cells["FR_name"].Value.ToString());
                        SqlCommand cmd10 = new SqlCommand("insert into Trace(DD_it,FR_id) select DD_id,FR_id from DesignDecision as dd inner join Project as p on dd.Project_id=p.Project_Id inner join FunctReq as f on p.Project_id=f.Project_id   where p.Project_id='" + pro_id + "' and dd.DD_name='" + dname + "' and f.FR_name='" + idd + "'", con);
                        con.Open();
                        SqlDataReader dr10 = cmd10.ExecuteReader();
                        dr10.Close();
                        con.Close();
                        fr = false;
                        MessageBox.Show("Trace successful");
                        
                    }
                    else if (dc)
                    {
                        String idd = Convert.ToString(dataGridView1.Rows[i].Cells["Dc_name"].Value.ToString());
                        SqlCommand cmd11 = new SqlCommand("insert into Trace(DD_it,Dc_id) select DD_id,Dc_id from DesignDecision as dd inner join Project as p on dd.Project_id=p.Project_Id inner join DConst as dc on p.Project_id=dc.Project_id   where p.Project_id='" + pro_id + "' and dd.DD_name='" + dname + "' and dc.Dc_name='" + idd + "'", con);
                        con.Open();
                        SqlDataReader dr11 = cmd11.ExecuteReader();
                        dr11.Close();
                        con.Close();
                        dc = false;
                        MessageBox.Show("Trace successful");
                    }

                }
            }
        }
    }
}
