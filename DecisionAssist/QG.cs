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
    public partial class QG : Form
    {
        int pro_id,ss;
        public QG(int pro)
        {
            InitializeComponent();
            pro_id = pro;
        }

        private void QG_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rDSADDDataSet.QualityAttribute' table. You can move, or remove it, as needed.
            // this.qualityAttributeTableAdapter.Fill(this.rDSADDDataSet.QualityAttribute);
            // TODO: This line of code loads data into the 'rDSADDDataSet.QualityAttribute' table. You can move, or remove it, as needed.
            // this.qualityAttributeTableAdapter.Fill(this.rDSADDDataSet.QualityAttribute);
           

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            /*  SqlConnection con = new SqlConnection();
              var x = 4;
              con.ConnectionString = "data source= IMRAN;database=RDSADD;integrated security= SSPI";

              foreach (ListViewItem item in listView1.Items)
              {
                  SqlCommand cmd = new SqlCommand("insert into QualityGoal(QG_id,QG_name,PDC_id) values ('" + (x = x + 1) + "','" + item.Text + "','"+1 +"')", con);
                  con.Open();
                  cmd.ExecuteReader();
                  con.Close();
              }
              */
            this.Close();

        }
        
        private void QG_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qualityAttributeDataSet.QualityAttribute' table. You can move, or remove it, as needed.
            // this.qualityAttributeTableAdapter.Fill(this.qualityAttributeDataSet.QualityAttribute);
            using (DAssistEntities de = new DAssistEntities())
            {

                var s = (from f in de.QualityAttributes select f.QA_name);
               //id = Convert.ToInt32(from f in de.QualityAttributes select f.QA_id);
                Console.WriteLine(s.ToString());
                listBox2.Items.AddRange(s.ToArray());
               
            }
        }
        List<string> q = new List<string>();
        private void button4_Click_1(object sender, EventArgs e)
        {
            if (this.listBox2.Text != "")

            {
                if(q.Contains(this.listBox2.Text)==false)
                {
                    listView2.Items.Add(this.listBox2.Text);
                    q.Add(this.listBox2.Text);
                }
                
            }
            else
            {
                MessageBox.Show("select QA");
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            
            string s = listView2.SelectedItems[0].SubItems[0].Text;
            listView2.Items.RemoveAt(listView2.SelectedIndices[0]);
            Console.WriteLine(s);
            if (q.Contains(s))
            {

                q.Remove(s);
                Console.WriteLine("removed");
            }
            //if(q!=null)
            //{
            //    foreach (string a in q)
            //    {
            //        Console.WriteLine(a);
            //    }
            //}
            
        }
       
        private void button6_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();            
            con.ConnectionString = "data source= IMRAN;database=DAssist;integrated security= SSPI";
            foreach (ListViewItem item in listView2.Items)
            {
                SqlCommand cmd = new SqlCommand("select QA_id from QualityAttribute where QA_name='" + item.Text + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ss = Convert.ToInt32(dr["QA_id"]);
                }
                dr.Close();
                con.Close();

                Console.WriteLine(ss);

                SqlCommand cmd1 = new SqlCommand("insert into QualityGoal(QA_id,Project_id) values ('" + ss + "' ,'" + pro_id + "')", con);
                // SqlCommand cmd1 = new SqlCommand("insert into QualityGoal (QA_id,Project_id) select QA_id,'" + pro_id + "' from QualityAttribute where QA_name='" + item + "'", con);
                con.Open();
                cmd1.ExecuteReader();
                con.Close();
            }


            //foreach (string a in q)
            //{
            //    //string s =Convert.ToString(item);

            //    SqlCommand cmd = new SqlCommand("select QA_id from QualityAttribute where QA_name='" + a + "'", con);
            //    con.Open();
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        ss = Convert.ToInt32(dr["QA_id"]);
            //    }
            //    dr.Close();
            //    con.Close();

            //    Console.WriteLine(ss);


            //    SqlCommand cmd1 = new SqlCommand("insert into QualityGoal(QA_id,Project_id) values ('" + ss + "' ,'" + pro_id + "')", con);
            //    // SqlCommand cmd1 = new SqlCommand("insert into QualityGoal (QA_id,Project_id) select QA_id,'"+pro_id+"' from QualityAttribute where QA_name='" + item + "'", con);
            //    con.Open();
            //    cmd1.ExecuteReader();
            //    con.Close();
            //}


            //using (DAssistEntities de = new DAssistEntities())
            //{
            //    QualityGoal qg = new QualityGoal();
            //    QualityAttribute qa = new QualityAttribute();
            //    foreach (ListViewItem item in listView2.Items)
            //    {
            //        var s =(from f in de.QualityAttributes.Where(a=>a.QA_name.Equals(item)) select f.QA_id);
            //        //a = Convert.ToInt32(s);
            //      //  Console.WriteLine(s.ToString());
            //        //   a = int.Parse(s);
            //        if (s != null)
            //        {
            //            qg.QA_id = qa.QA_id;
            //            qg.Project_id = pro_id;
            //            de.QualityGoals.Add(qg);
            //            de.SaveChanges();

            //        }

            //    }
            //}
            this.Close();
        }
    }
}
