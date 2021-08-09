using DecisionAssist.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Data.SqlClient;


namespace DecisionAssist
{
    public partial class DConcern : Form
    {
        SqlConnection con = new SqlConnection("data source= IMRAN;database=DAssist;integrated security= SSPI");
        int pro_id;
        int fr = 0;
        public DConcern(int pro, int b)
        {
            InitializeComponent();
            if (b == 1)
            {
                comboBox2.Visible = false;
                label6.Visible = false;
                label5.Visible = false;
                comboBox1.Visible = false;
                button5.Hide();
                button4.Hide();
                fr = b;
            }
            else
            {
                label5.Visible = false;
                comboBox1.Visible = false;
                button6.Hide();
                button3.Hide();
            }
            pro_id = pro;
            Console.WriteLine(pro_id.ToString());


        }
        private string filename = "";
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Title = "Please select a XML file";
            o.Filter = "XML File|*.xml";
            DialogResult d = o.ShowDialog();
            if (d == System.Windows.Forms.DialogResult.OK)
            {
                this.filename = o.FileName;
                XDocument x = XDocument.Load(filename);
                //XmlReader xr = XmlReader.Create(filename);

                //while (xr.Read())
                //{if ((xr.NodeType == XmlNodeType.Element) && (xr.Name == "FunctionaRequirement"))
                //    {
                //        if (xr.HasAttributes)
                //        {
                //            Console.WriteLine(xr.GetAttribute("id") + " " + xr.GetAttribute("FR_name") + " " + xr.GetAttribute("id"));
                //        }
                //    }
                //    else
                //    {
                //        Console.WriteLine("not reading");
                //    }
                //}
                List<FunctReq> FRlist = x.Descendants("FunctionalRequirement").Select
                    (FunctionalRequirement =>
                        new FunctReq
                        {

                            FR_name = FunctionalRequirement.Element("FR_name").Value,
                            FR_desc = FunctionalRequirement.Element("FR_description").Value,
                            Project_id = pro_id

                        }).ToList();

                using (DAssistDesignConcernEntities fre = new DAssistDesignConcernEntities())
                {
                    foreach (var i in FRlist)
                    {
                        Console.WriteLine(i.FR_name + i.FR_desc);
                        var v = fre.FunctReqs.Where(f => f.FR_id.Equals(i.FR_id)).FirstOrDefault();
                        if (v != null)
                        {

                            v.FR_name = i.FR_name;
                            v.FR_desc = i.FR_desc;
                            v.Project_id = pro_id;
                        }
                        else
                        {
                            fre.FunctReqs.Add(i);
                        }

                    }
                    fre.SaveChanges();
                    this.dataGridView1.DataSource = fre.FunctReqs.Where(f => f.Project_id.Equals(1)).ToList();

                }

            }
            else
            {
                this.Close();
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Title = "Please select a XML file";
            o.Filter = "XML File|*.xml";
            DialogResult d = o.ShowDialog();
            if (d == System.Windows.Forms.DialogResult.OK)
            {
                this.filename = o.FileName;
                XDocument x = XDocument.Load(filename);
                List<DConst> FRlist = x.Descendants("Constraint").Select
                    (FunctionalRequirement =>
                        new DConst
                        {//Dc_id = Convert.ToInt32(FunctionalRequirement.Element("id").Value),
                            Dc_name = FunctionalRequirement.Element("Dc_name").Value,
                            Dc_des = FunctionalRequirement.Element("Dc_description").Value,
                            Project_id = pro_id
                        }).ToList();

                using (DAssistDesignConcernEntities fre = new DAssistDesignConcernEntities())
                {
                    foreach (var i in FRlist)
                    {
                        var v = fre.DConsts.Where(f => f.Dc_id.Equals(i.Dc_id)).FirstOrDefault();
                        if (v != null)
                        {
                            v.Dc_name = i.Dc_name;
                            v.Dc_des = i.Dc_des;
                            v.Project_id = pro_id;
                        }
                        else
                        {
                            fre.DConsts.Add(i);
                        }
                    }
                    fre.SaveChanges();
                    this.dataGridView1.DataSource = fre.DConsts.Where(f => f.Project_id.Equals(1)).ToList();
                }

            }
            else
            {

                this.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void DConcern_Load(object sender, EventArgs e)
        {
            fillcombo();
        }

        private void fillcombo()
        {

            SqlCommand cmd8 = new SqlCommand("select QA_name from QualityGoal as q inner join QualityAttribute as qa on q.QA_id=qa.QA_id where Project_id='" + pro_id + "'", con);
            con.Open();
            SqlDataReader dr8 = cmd8.ExecuteReader();
            while (dr8.Read())
            {
                if (!comboBox1.Items.Contains(dr8["QA_name"]))
                {
                    comboBox1.Items.Add(dr8["QA_name"]);
                }
            }
            con.Close();
            dr8.Close();

            if (fr == 1)
            {
                SqlCommand cmd = new SqlCommand("select Dc_name from DConst where Project_id='" + pro_id + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (!comboBox2.Items.Contains(dr["Dc_name"]))
                    {
                        comboBox2.Items.Add(dr["Dc_name"]);
                    }
                }
                con.Close();
                dr.Close();

            }


        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            DAssistDesignConcernEntities fre = new DAssistDesignConcernEntities();
            DConst dc = new DConst();
            dc.Dc_name = textBox1.Text;
            dc.Dc_des = textBox2.Text;
            dc.Project_id = pro_id;
            fre.DConsts.Add(dc);
            fre.SaveChanges();
            this.dataGridView1.DataSource = fre.DConsts.Where(f => f.Project_id.Equals(1)).ToList();

            int x = 0, z = 0;
            SqlCommand cmd8 = new SqlCommand("select Dc_id from Dconst where Dc_name='" + textBox1.Text + "'", con);
            con.Open();
            SqlDataReader dr8 = cmd8.ExecuteReader();
            while (dr8.Read())
            {
                x = Convert.ToInt32(dr8["Dc_id"]);
            }
            con.Close();
            dr8.Close();
            if (comboBox1.SelectedItem != null)
            {
                SqlCommand cmd9 = new SqlCommand("select QG_id from QualityGoal as qg inner join QualityAttribute as qa on qg.QA_id=qa.QA_id where QA_name='" + comboBox1.SelectedItem.ToString() + "'", con);
                con.Open();
                SqlDataReader dr9 = cmd9.ExecuteReader();
                while (dr9.Read())
                {
                    z = Convert.ToInt32(dr9["QG_id"]);
                }
                con.Close();
                dr9.Close();
                RelateQA(x, z, 2);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DAssistDesignConcernEntities fre = new DAssistDesignConcernEntities();
            FunctReq fr = new FunctReq();
            fr.FR_name = textBox1.Text;
            fr.FR_desc = textBox2.Text;
            fr.Project_id = pro_id;
            fre.FunctReqs.Add(fr);
            fre.SaveChanges();
            this.dataGridView1.DataSource = fre.FunctReqs.Where(f => f.Project_id.Equals(1)).ToList();
            int x = 0, z = 0, y = 0;
            SqlCommand cmd8 = new SqlCommand("select FR_id from FunctReq where FR_name='" + textBox1.Text + "'", con);
            con.Open();
            SqlDataReader dr8 = cmd8.ExecuteReader();
            while (dr8.Read())
            {
                x = Convert.ToInt32(dr8["FR_id"]);
            }
            con.Close();
            dr8.Close();
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                SqlCommand cmd9 = new SqlCommand("select QG_id from QualityGoal as qg inner join QualityAttribute as qa on qg.QA_id=qa.QA_id where QA_name='" + comboBox1.SelectedItem.ToString() + "'", con);
                con.Open();
                SqlDataReader dr9 = cmd9.ExecuteReader();
                while (dr9.Read())
                {
                    z = Convert.ToInt32(dr9["QG_id"]);
                }
                con.Close();
                dr9.Close();

                SqlCommand cmd = new SqlCommand("select Dc_id from DConst where Dc_name='" + comboBox2.SelectedItem.ToString() + "' And Project_id='" + pro_id + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    y = Convert.ToInt32(dr["Dc_id"]);
                }
                con.Close();
                dr.Close();

                RelateQADc(x, z, y, 1);
            }
            else if (comboBox1.SelectedItem != null)
            {
                SqlCommand cmd9 = new SqlCommand("select QG_id from QualityGoal as qg inner join QualityAttribute as qa on qg.QA_id=qa.QA_id where QA_name='" + comboBox1.SelectedItem.ToString() + "'", con);
                con.Open();
                SqlDataReader dr9 = cmd9.ExecuteReader();
                while (dr9.Read())
                {
                    z = Convert.ToInt32(dr9["QG_id"]);
                }
                con.Close();
                dr9.Close();

                RelateQA(x, z, 1);
            }
            else if (comboBox2.SelectedItem != null)
            {
                SqlCommand cmd9 = new SqlCommand("select Dc_id from DConst where Dc_name='" + comboBox2.SelectedItem.ToString() + "' And Project_id='" + pro_id + "'", con);
                con.Open();
                SqlDataReader dr9 = cmd9.ExecuteReader();
                while (dr9.Read())
                {
                    y = Convert.ToInt32(dr9["Dc_id"]);
                }
                con.Close();
                dr9.Close();

                RelateDc(x, y, 1);
            }

        }
        private void RelateQA(int s, int ss, int check)
        {
            if (check == 1)
            {
                con.Open();
                SqlCommand cmd4 = new SqlCommand("insert into DC_Relation (FR_id,QG_id,Project_id) values ('" + s + "','" + ss + "','" + pro_id + "')", con);
                cmd4.ExecuteReader();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand cmd4 = new SqlCommand("insert into DC_Relation (Dc_id,QG_id,Project_id) values ('" + s + "','" + ss + "','" + pro_id + "')", con);
                cmd4.ExecuteReader();
                con.Close();
            }
        }
        private void RelateDc(int s, int ss, int check)
        {
            if (check == 1)
            {
                con.Open();
                SqlCommand cmd4 = new SqlCommand("insert into DC_Relation (FR_id,Dc_id,Project_id) values ('" + s + "','" + ss + "','" + pro_id + "')", con);
                cmd4.ExecuteReader();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand cmd4 = new SqlCommand("insert into DC_Relation (Dc_id,QG_id,Project_id) values ('" + s + "','" + ss + "','" + pro_id + "')", con);
                cmd4.ExecuteReader();
                con.Close();
            }
        }
        private void RelateQADc(int s, int ss, int sss, int check)
        {
            if (check == 1)
            {
                con.Open();
                SqlCommand cmd4 = new SqlCommand("insert into DC_Relation (FR_id,QG_id,Dc_id,Project_id) values ('" + s + "','" + ss + "','" + sss + "','" + pro_id + "')", con);
                cmd4.ExecuteReader();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand cmd4 = new SqlCommand("insert into DC_Relation (Dc_id,QG_id,Project_id) values ('" + s + "','" + ss + "','" + pro_id + "')", con);
                cmd4.ExecuteReader();
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}

