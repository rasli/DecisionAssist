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
    public partial class Recommandation : Form
    {
        SqlConnection con = new SqlConnection("data source= IMRAN;database=DAssist;integrated security= SSPI");
        List<string> qg = new List<string>();
        int pro_id;
        string current;
        bool fr=false, dc=false;
        DataTable dt = new DataTable();
        public Recommandation(int x)
        {
           
            InitializeComponent();
            pro_id = x;
           /* RDSADDEntities1 r = new RDSADDEntities1();
            var gr = from d in r.QualityGoals
                     select d.QG_name;
            checkedListBox1.Items.AddRange(gr.ToArray());*/
            SqlCommand cmd = new SqlCommand("select QA_name from QualityGoal as q inner join QualityAttribute as qa on q.QA_id=qa.QA_id where Project_id='"+pro_id+"'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();                   
            while (dr.Read())
            {               
                qg.Add(dr["QA_name"].ToString());
                /*ListViewItem item = new ListViewItem(dr["QG_name"].ToString());
                 listView1.Items.Add(item);*/
               // Console.WriteLine(dr["QG_name"]);
            }
            dr.Close();                   

            SqlCommand cmd6 = new SqlCommand("select QA_name from QualityGoal as q inner join QualityAttribute as qa on q.QA_id=qa.QA_id where Project_id='" + pro_id + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd6);
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                checkedListBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            con.Close();        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Recommandation_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rDSADDDataSet.QualityAttribute' table. You can move, or remove it, as needed.
        

        }

        private void Recommandation_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rDSADDDataSet1.DesignDecision' table. You can move, or remove it, as needed.
           

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "A_d")
            {
                dataGridView3.Rows.Clear();
                String iddd = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["DR_name"].Value.ToString());
                Console.WriteLine(iddd);
                
                if (MessageBox.Show("Are you sure to add this as design decision", "save decision", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int n = dataGridView3.Rows.Add();
                    dataGridView3.Rows[n].Cells[0].Value = iddd;
                    con.Open();
                    SqlCommand cmd4 = new SqlCommand("insert into DesignDecision (DD_name,DD_des,Project_id) select DR_name,DR_des,'" + pro_id + "' from DecisionRepo  where  DR_name='" + iddd + "'", con);
                    cmd4.ExecuteReader();
                    con.Close();
                    MessageBox.Show("Decision saved under current project");
                }

            }

            /*  con.Open();
             dataGridView3.DataSource = iddd;    
            Console.WriteLine(iddd);
            SqlCommand cmd4 = new SqlCommand("insert into DesignDecision (DD_id,Decision_name,Decision_description,Project_id) select '" + a + "',DR_name,DR_des,1 from DecisionRepo  where  DR_name='" + iddd + "'", con);
            a++;
            SqlDataReader dr4 = cmd4.ExecuteReader();
            current = iddd;
            Console.WriteLine(current);
            con.Close();
            dr4.Close();*/


            else
            {
                con.Open();
                String idd = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["DR_name"].Value.ToString());
                SqlCommand cmd3 = new SqlCommand("select QA_name, Impact from DecisionRepo as dr inner join DecisionQAimpact as i on dr.DR_id = i.DR_id inner join QualityAttribute as qa on i.QA_id = qa.QA_id where DR_name='" + idd + "'", con);
                SqlDataReader dr3 = cmd3.ExecuteReader();
                BindingSource bs3 = new BindingSource();
                bs3.DataSource = dr3;
                dataGridView2.DataSource = bs3;
                dr3.Close();
                con.Close();
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (dataGridView2.Rows[i].Cells[1].Value.ToString() == "negative")
                    {
                        dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        { 
           
        }
        List<string>[] DD = new List<string>[6];

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> DL = new List<string>();
            
            if (DL.Count!=0)
            {
                
                foreach (string s in DL)
                {
                    SqlCommand cmd8 = new SqlCommand("select DR_name,DR_des,DR_type from DecisionRepo where DR_name = '" + s + "'", con);
                    con.Open();
                    SqlDataReader dr8 = cmd8.ExecuteReader();
                    SqlDataAdapter ad = new SqlDataAdapter();
                    ad.SelectCommand = cmd8;

                    // int m = dataGridView4.Rows.Add();
                    //dataGridView4.Rows[m].Cells[0].Value = s;

                    while (dr8.Read())
                    {
                        //dataGridView4.Rows[m].Cells[1].Value = dr8["DR_des"];
                        //dataGridView4.Rows[m].Cells[2].Value = dr8["DR_type"];
                        if (!comboBox1.Items.Contains(dr8["DR_type"]))
                        {
                            comboBox1.Items.Add(dr8["DR_type"]);
                        }


                    }
                    con.Close();
                    dr8.Close();
                   
                    ad.Fill(dt);
                    dataGridView4.DataSource = dt;
                    dt.Rows.Clear();
                }
            }
            else
            {
                for (int i = 0; i < qg.Count; i++)
                {

                    SqlCommand cmd7 = new SqlCommand("select Distinct DR_name from DecisionRepo as dr inner join DecisionQAimpact as i on dr.DR_id = i.DR_id inner join QualityAttribute as qa on i.QA_id = qa.QA_id where(Impact = 'positive' OR Impact = 'neutral') AND(QA_name = '" + qg[i] + "')", con);
                    con.Open();
                    SqlDataReader dr7 = cmd7.ExecuteReader();

                    while (dr7.Read())
                    {

                        if (!DL.Contains(dr7["DR_name"]))
                        {
                            DL.Add(dr7["DR_name"].ToString());
                        }

                    }
                    dr7.Close();
                    con.Close();
                }
                List<string> conflict = new List<string>();
                for (int i = 0; i < DL.Count; i++)
                {
                    //   int m = dataGridView4.Rows.Add();
                    // Console.WriteLine(DL[i]);

                    // dataGridView4.Rows[m].Cells[0].Value=s;
                    foreach (string q in qg)
                    {
                        SqlCommand cmd = new SqlCommand("select Impact from DecisionRepo as dr inner join DecisionQAimpact as i on dr.DR_id = i.DR_id inner join QualityAttribute as qa on i.QA_id = qa.QA_id where DR_name = '" + DL[i] + "' AND QA_name='" + q + "'", con);
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {

                            if (dr["Impact"].ToString() == "negative")
                            {
                                if (!conflict.Contains(DL[i]))
                                {
                                    conflict.Add(DL[i]);
                                }
                            }

                        }
                        dr.Close();
                        con.Close();
                    }


                }

                for (int i = 0; i < conflict.Count; i++)
                {
                    if (DL.Contains(conflict[i].ToString()))
                    {

                        DL.Remove(conflict[i]);

                    }

                }
                dt.Rows.Clear();
                foreach (string s in DL)
                {
                    SqlCommand cmd8 = new SqlCommand("select DR_name,DR_des,DR_type from DecisionRepo where DR_name = '" + s + "'", con);
                    con.Open();
                    SqlDataReader dr8 = cmd8.ExecuteReader();
                    SqlDataAdapter ad = new SqlDataAdapter();
                    ad.SelectCommand = cmd8;

                    // int m = dataGridView4.Rows.Add();
                    //dataGridView4.Rows[m].Cells[0].Value = s;

                    while (dr8.Read())
                    {
                        //dataGridView4.Rows[m].Cells[1].Value = dr8["DR_des"];
                        //dataGridView4.Rows[m].Cells[2].Value = dr8["DR_type"];
                        if (!comboBox1.Items.Contains(dr8["DR_type"]))
                        {
                            comboBox1.Items.Add(dr8["DR_type"]);
                        }


                    }
                    con.Close();
                    dr8.Close();
                    ad.Fill(dt);
                    dataGridView4.DataSource = dt;
                  
                }
               

            }
            //  SqlCommand cmd7 = new SqlCommand("select Distinct DR_name from DecisionRepo as dr inner join DR_QA_impact as i on dr.DR_id = i.DR_id inner join QualityAttribute as qa on i.QA_id = qa.QA_id where(Impact = 'positive' OR Impact = 'neutral') AND(QA_name like'"+(checkedListBox1.SelectedItem.ToString())+ "' OR description like'" + textBox1.Text + "' OR DR_name like'" + textBox1.Text + "' )", con);
            // int j = 7;





            //for (int i=0; i< qg.Count;i++)
            //{
            //    DD[i] = new List<string>();
            //    SqlCommand cmd7 = new SqlCommand("select Distinct DR_name from DecisionRepo as dr inner join DR_QA_impact as i on dr.DR_id = i.DR_id inner join QualityAttribute as qa on i.QA_id = qa.QA_id where(Impact = 'positive' OR Impact = 'neutral') AND(QA_name = '" + qg[i] + "')", con);
            //    con.Open();
            //    SqlDataReader dr7 = cmd7.ExecuteReader();

            //    while (dr7.Read())
            //    {

            //        DD[i].Add(dr7["DR_name"].ToString());

            //    }

            //   // DD.Add("end");
            //    // DataTable dt = new DataTable();
            //    //SqlDataAdapter sd = new SqlDataAdapter(cmd7);
            //    //sd.Fill(dt);
            //    //dataGridView4.DataSource = dt;
            //    dr7.Close();
            //    con.Close();
            //}
            //List<string> sa = new List<string>();
            // for (int j = 0; j < DD[0].Count; j++)
            //  {
            //    int c=1;
            //    //foreach (String x in DD[j])
            //    //{
            //    //  Console.WriteLine(x);
            //    //  Console.WriteLine(DD[0][p]);
            //    for (int k = 1; k < qg.Count; k++)
            //    {

            //       // Console.WriteLine(DD[0][j]);
            //        if (DD[k].Contains(DD[0][j].ToString()))
            //        {
            //           // Console.WriteLine(DD[0][j]);
            //            c++;
            //        }

            //    }
            //    if (c == qg.Count)
            //    {
            //        sa.Add(DD[0][j] );

            //    }

            //    //}
            //  }

            //foreach (string s in sa)
            //{
            //    int m = dataGridView4.Rows.Add();
            //    // Console.WriteLine(s);

            //    dataGridView4.Rows[m].Cells[0].Value=s;
            //}


            /* SqlDataReader dr8;
             for (int i = 0; i < sa.Count; i++)
             {
                 SqlCommand cmd8 = new SqlCommand("select Distinct DR_name from DecisionRepo as dr inner join DR_QA_impact as i on dr.DR_id = i.DR_id inner join QualityAttribute as qa on i.QA_id = qa.QA_id where(Impact = 'positive' OR Impact = 'neutral') AND(DR_name = '" + sa[i] + "')", con);
                 con.Open();
                 dr8 = cmd8.ExecuteReader();
                 while (dr8.Read())
                 {
                     ListViewItem item = new ListViewItem(dr8["DR_name"].ToString());
                     listView1.Items.Add(item);
                 }
                 //BindingSource bs8 = new BindingSource();
                 //bs8.DataSource = dr8;
                 //dataGridView4.DataSource = bs8;
                 dr8.Close();
                 con.Close();
             }*/

        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dataGridView4.Columns[e.ColumnIndex].Name == "AddDecision")
            //{ 
            //    dataGridView3.Rows.Clear();
            //    String iddd = Convert.ToString(dataGridView4.Rows[e.RowIndex].Cells["ADD_D"].Value.ToString());
                
            //    if (MessageBox.Show("Are you sure to add this as design decision", "save decision", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        int m = dataGridView3.Rows.Add();
            //        dataGridView3.Rows[m].Cells[0].Value = iddd;
            //        con.Open();
            //        SqlCommand cmd4 = new SqlCommand("insert into DesignDecision (DD_name,DD_des,Project_id) select DR_name,DR_des,'" + pro_id + "' from DecisionRepo  where  DR_name='" + iddd + "'", con);
            //        cmd4.ExecuteReader();
            //        con.Close();
            //        MessageBox.Show("Decision saved under current project");
            //    }
               
            //}
            //else {

            //    con.Open();
            //    String idd = Convert.ToString(dataGridView4.Rows[e.RowIndex].Cells["ADD_D"].Value.ToString());
            //    SqlCommand cmd8 = new SqlCommand("select QA_name, Impact from DecisionRepo as dr inner join DecisionQAimpact as i on dr.DR_id = i.DR_id inner join QualityAttribute as qa on i.QA_id = qa.QA_id where DR_name='" + idd + "'", con);
            //    SqlDataReader dr8 = cmd8.ExecuteReader();
            //    BindingSource bs8 = new BindingSource();
            //    bs8.DataSource = dr8;
            //    dataGridView2.DataSource = bs8;
            //    dr8.Close();
            //    con.Close();
            //    for (int i = 0; i < dataGridView2.Rows.Count; i++)
            //    {
            //        if (dataGridView2.Rows[i].Cells[1].Value.ToString() == "negative")
            //        {
            //            dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Red;
            //        }
            //    }
            //}
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            List<string> sr = new List<string>();
            if (sr.Count != 0)
            {
                foreach (string s in sr)
                {
                    SqlCommand cmd8 = new SqlCommand("select DR_name,DR_des,DR_type from DecisionRepo where DR_name = '" + s + "'", con);
                    con.Open();
                    SqlDataReader dr8 = cmd8.ExecuteReader();
                    SqlDataAdapter ad = new SqlDataAdapter();
                    ad.SelectCommand = cmd8;
                    //int m = dataGridView1.Rows.Add();                
                    //dataGridView1.Rows[m].Cells[0].Value = s;
                    while (dr8.Read())
                    {
                        // dataGridView1.Rows[m].Cells[1].Value = dr8["DR_des"];

                        if (!comboBox2.Items.Contains(dr8["DR_type"]))
                        {
                            comboBox2.Items.Add(dr8["DR_type"]);
                        }
                    }
                    con.Close();
                    dr8.Close();
                    ad.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dt.Rows.Clear();
                }
            }
            else
            {

                foreach (string z in checkedListBox1.CheckedItems)
                {
                    SqlCommand cmd2 = new SqlCommand("select Distinct DR_name from DecisionRepo as dr inner join DecisionQAimpact as i on dr.DR_id = i.DR_id inner join QualityAttribute as qa on i.QA_id = qa.QA_id where(Impact = 'positive' OR Impact = 'neutral') AND(qa.QA_name = '" + z + "')", con);
                    con.Open();
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    while (dr2.Read())
                    {
                        if (sr.Contains(dr2["DR_name"]) == false)
                        {
                            sr.Add(dr2["DR_name"].ToString());
                        }
                    }
                    dr2.Close();
                    con.Close();

                }
                SqlCommand cmd9 = new SqlCommand("select Distinct DR_name from DecisionRepo as dr inner join DecisionQAimpact as i on dr.DR_id = i.DR_id inner join QualityAttribute as qa on i.QA_id = qa.QA_id where(Impact = 'positive' OR Impact = 'neutral') AND(DR_name = '" + textBox1.Text + "'OR QA_name = '" + textBox1.Text + "'OR DR_type = '" + textBox1.Text + "')", con);
                con.Open();
                SqlDataReader dr9 = cmd9.ExecuteReader();
                while (dr9.Read())
                {
                    if (sr.Contains(dr9["DR_name"]) == false)
                    {
                        sr.Add(dr9["DR_name"].ToString());
                    }
                }
                dr9.Close();
                con.Close();
                dt.Rows.Clear();
                foreach (string s in sr)
                {
                    SqlCommand cmd8 = new SqlCommand("select DR_name,DR_des,DR_type from DecisionRepo where DR_name = '" + s + "'", con);
                    con.Open();
                    SqlDataReader dr8 = cmd8.ExecuteReader();
                    SqlDataAdapter ad = new SqlDataAdapter();
                    ad.SelectCommand = cmd8;
                    //int m = dataGridView1.Rows.Add();                
                    //dataGridView1.Rows[m].Cells[0].Value = s;
                    while (dr8.Read())
                    {
                        // dataGridView1.Rows[m].Cells[1].Value = dr8["DR_des"];

                        if (!comboBox2.Items.Contains(dr8["DR_type"]))
                        {
                            comboBox2.Items.Add(dr8["DR_type"]);
                        }
                    }
                    con.Close();
                    dr8.Close();
                    ad.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
              
         }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4.Columns[e.ColumnIndex].Name == "AddDecision")
            {
                dataGridView3.Rows.Clear();
                String iddd = Convert.ToString(dataGridView4.Rows[e.RowIndex].Cells["DR_name"].Value.ToString());

                if (MessageBox.Show("Are you sure to add this as design decision", "save decision", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int m = dataGridView3.Rows.Add();
                    dataGridView3.Rows[m].Cells[0].Value = iddd;
                    con.Open();
                    SqlCommand cmd4 = new SqlCommand("insert into DesignDecision (DD_name,DD_des,Project_id) select DR_name,DR_des,'" + pro_id + "' from DecisionRepo  where  DR_name='" + iddd + "'", con);
                    cmd4.ExecuteReader();
                    con.Close();
                    MessageBox.Show("Decision saved under current project");
                }

            }
            else {

                con.Open();
                String idd = Convert.ToString(dataGridView4.Rows[e.RowIndex].Cells["DR_name"].Value.ToString());
                SqlCommand cmd8 = new SqlCommand("select QA_name, Impact from DecisionRepo as dr inner join DecisionQAimpact as i on dr.DR_id = i.DR_id inner join QualityAttribute as qa on i.QA_id = qa.QA_id where DR_name='" + idd + "'", con);
                SqlDataReader dr8 = cmd8.ExecuteReader();
                BindingSource bs8 = new BindingSource();
                bs8.DataSource = dr8;
                dataGridView2.DataSource = bs8;
                dr8.Close();
                con.Close();
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (dataGridView2.Rows[i].Cells[1].Value.ToString() == "negative")
                    {
                        dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.Columns[e.ColumnIndex].Name == "Add_Fr")
            {
                dataGridView5.Rows.Clear();
                String iddd = Convert.ToString(dataGridView3.Rows[e.RowIndex].Cells["Decision"].Value.ToString());
                current = iddd;
               // Console.WriteLine(current);
                fr = true;
                dc = false;
                SqlCommand cmd12 = new SqlCommand("select FR_name from FunctReq where Project_id='"+pro_id+"' ", con);
                con.Open();
                SqlDataReader dr12 = cmd12.ExecuteReader();
                BindingSource bs12 = new BindingSource();
                bs12.DataSource = dr12;
                dataGridView5.DataSource = bs12;
                dr12.Close();
                con.Close();

            }
            else if (dataGridView3.Columns[e.ColumnIndex].Name == "AddDc")
            {
                dataGridView5.Rows.Clear();
                String iddd = Convert.ToString(dataGridView3.Rows[e.RowIndex].Cells["Decision"].Value.ToString());
                current = iddd;
                dc = true;
                fr = false;
                SqlCommand cmd13 = new SqlCommand("select Dc_name from Dconst where Project_id='"+pro_id+"' ", con);
                con.Open();
                SqlDataReader dr13 = cmd13.ExecuteReader();
                BindingSource bs13 = new BindingSource();
                bs13.DataSource = dr13;
                dataGridView5.DataSource = bs13;
                dr13.Close();
                con.Close();

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("DR_type Like '%{0}%'", comboBox1.SelectedItem.ToString());
            dataGridView4.DataSource = dv;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("DR_type Like '%{0}%'", comboBox2.SelectedItem.ToString());
            dataGridView1.DataSource = dv;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rDSADDDataSet2BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void decisionRepoBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void decisionRepoBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = dataGridView5.RowCount - 1; i >= 0; i--)
            {
                DataGridViewRow row = dataGridView5.Rows[i];
                if (Convert.ToBoolean(row.Cells["Select"].Value))
                {
                    if (fr)
                    {
                        String idd = Convert.ToString(dataGridView5.Rows[i].Cells["FR_name"].Value.ToString());
                        SqlCommand cmd10 = new SqlCommand("insert into Trace(DD_it,FR_id) select DD_id,FR_id from DesignDecision as dd inner join Project as p on dd.Project_id=p.Project_id inner join FunctReq as f on p.Project_id=f.Project_id   where p.Project_id='" + pro_id + "' and dd.DD_name='" + current + "' and f.FR_name='" + idd + "'", con);
                        con.Open();
                        SqlDataReader dr10 = cmd10.ExecuteReader();
                        dr10.Close();
                        con.Close();
                        fr = false;
                        Console.WriteLine(idd + "  " + current);
                        MessageBox.Show("trace successfull");
                    }
                    else if (dc)
                    {
                        String idd = Convert.ToString(dataGridView5.Rows[i].Cells["Dc_name"].Value.ToString());
                        SqlCommand cmd11 = new SqlCommand("insert into Trace(DD_it,Dc_id) select DD_id,Dc_id from DesignDecision as dd inner join Project as p on dd.Project_id=p.Project_Id inner join DConst as dc on p.Project_id=dc.Project_id   where p.Project_id='" + pro_id + "' and dd.DD_name='" + current + "' and dc.Dc_name='" + idd + "'", con);
                        con.Open();
                        SqlDataReader dr11 = cmd11.ExecuteReader();
                        dr11.Close();
                        con.Close();
                        dc = false;
                        MessageBox.Show("trace successfull");
                    }
                    
                    
                }
            }
        }
    }
}
