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
using System.Xml.Linq;
using System.IO;

namespace DecisionAssist
{
    public partial class ProjectFrom : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DAssist.mdf;Initial Catalog=DAssist;Integrated Security=True;Connect Timeout=30");

        //SqlConnection con = new SqlConnection("data source= IMRAN;database=DAssist;integrated security= SSPI");
        //static string path = Path.GetFullPath(Environment.CurrentDirectory);
        //static string databaseName = "DAssist.mdf";
        //SqlConnection con = new SqlConnection(@"data source=(localdb)\v11.0;AttachDbFilename="+path+@"\"+databaseName+";integrated security= true");
        private int ss;
        public ProjectFrom()
        {
            InitializeComponent();
            FinalDecisionTab.Enabled = false;

            // this.Text = "Decision-Assist:" + s;
            // label2.Text = s;
            panel7.Enabled = false;
            panel8.Enabled = true;

            try
            {
                SqlCommand cmd = new SqlCommand("select Project_name,Project_des from Project", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int n = dataGridView24.Rows.Add();
                    dataGridView24.Rows[n].Cells[1].Value = dr["Project_name"];
                    dataGridView24.Rows[n].Cells[2].Value = dr["Project_des"];
                }

                dr.Close();
                con.Close();
            }
            catch (SqlException sq) { MessageBox.Show(sq.Message); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { if (con != null) con.Close(); }
            tabControl1.TabPages.Remove(tabPage19);
            tabControl4.TabPages.Remove(tabPage17);
            tabControl2.TabPages.Remove(tabPage8);
            tabControl2.TabPages.Remove(tabPage7);
        }

        private void ProjectFrom_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSetReport.DataTable1' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'DataSetReport.DataTable1' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'DataSetReport.Project' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'DataSetReport.DataTable1' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'DataSetReport.FunctReq' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'DataSetReport.DataTable1' table. You can move, or remove it, as needed.
            //this.DataTable1TableAdapter.Fill(this.DataSetReport.DataTable1);
            // TODO: This line of code loads data into the 'DataSetReport.DataTable2' table. You can move, or remove it, as needed.
            //this.DataTable2TableAdapter.Fill(this.DataSetReport.DataTable2);
            // TODO: This line of code loads data into the 'DataSetReport.DataTable3' table. You can move, or remove it, as needed.
            //this.DataTable3TableAdapter.Fill(this.DataSetReport.DataTable3);
            // TODO: This line of code loads data into the 'DataSetReport.DataTable1' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'DataSetReport.DataTable1' table. You can move, or remove it, as needed.

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FRAddbutton_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure to add the requirement in current project", "Save Requirement", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Enter a Concern Name");
                }
                else
                {
                    List<string> check = new List<string>();
                    try
                    {
                        con.Open();
                        SqlCommand cmd2 = new SqlCommand("select FR_name from FunctReq where FR_name='" + textBox1.Text + "' and Project_id='" + ss + "'", con);
                        SqlDataReader dr2 = cmd2.ExecuteReader();
                        while (dr2.Read())
                        {
                            check.Add(dr2["FR_name"].ToString());
                        }
                        con.Close();
                        dr2.Close();

                    }
                    catch (SqlException sq) { MessageBox.Show(sq.Message); }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally { if (con != null) con.Close(); }
                    if (check.Count > 0)
                    {
                        MessageBox.Show("Requirement Already Exist");
                    }
                    else
                    {
                        //DAssistDesignConcernEntities fre = new DAssistDesignConcernEntities();
                        //FunctReq fr = new FunctReq();
                        //fr.FR_name = textBox1.Text;
                        //fr.FR_desc = textBox2.Text;
                        //fr.Project_id = ss;
                        //fre.FunctReqs.Add(fr);
                        //fre.SaveChanges();
                        //this.dataGridView1.DataSource = fre.FunctReqs.Where(f => f.Project_id.Equals(ss)).ToList();
                        if (comboBox9.SelectedIndex > -1)
                        {
                            try
                            {
                                SqlCommand cmd10 = new SqlCommand("insert into FunctReq(FR_name,FR_desc,Project_id,concategory_id) values( '" + textBox1.Text + "','" + textBox2.Text + "','" + ss + "',(select concerncategory.cc_id from concerncategory where concerncategory.concategory_name='" + comboBox9.SelectedItem.ToString() + "'))", con);
                                con.Open();
                                cmd10.ExecuteReader();
                                con.Close();
                                SqlCommand cmd = new SqlCommand("select FR_name as 'Requirement Name',FR_desc as 'Description',concerncategory.concategory_name from FunctReq,concerncategory where FunctReq.concategory_id=concerncategory.cc_id and FunctReq.Project_id = '" + ss + "'", con);
                                con.Open();
                                SqlDataReader dr = cmd.ExecuteReader();
                                BindingSource bs = new BindingSource();
                                bs.DataSource = dr;
                                dataGridView1.DataSource = bs;
                                dr.Close();

                            }
                            catch (SqlException sq) { MessageBox.Show(sq.Message); }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally { if (con != null) con.Close(); }
                            textBox1.Clear();
                            textBox2.Clear();

                            MessageBox.Show("successfully saved");
                        }
                        else
                        {
                            MessageBox.Show("select one concern type");
                        }
                    }
                }

            }

        }
        private string filename = "";
        private void frxmlbutton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog o = new OpenFileDialog();
                o.Title = "Please select a XML file";
                o.Filter = "XML File|*.xml";
                DialogResult d = o.ShowDialog();
                if (d == System.Windows.Forms.DialogResult.OK)
                {
                    this.filename = o.FileName;
                    XDocument x = XDocument.Load(filename);
                    Console.WriteLine("reading file");
                    //  List<FunctReq> FRlist = 
                    x.Descendants("FunctionalRequirement").Select
                    (FunctionalRequirement =>
                        new
                        {
                            FR_name = FunctionalRequirement.Element("FR_name").Value,
                            FR_desc = FunctionalRequirement.Element("FR_description").Value,
                            c_type = FunctionalRequirement.Element("concategory_type").Value,
                            Project_id = ss

                        }).ToList().ForEach(FunctionalRequirement =>
                        {
                            if (MessageBox.Show("Are you sure to add the requirement in current project", "Save Requirement", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                List<string> check = new List<string>();
                                try
                                {
                                    con.Open();
                                    SqlCommand cmd2 = new SqlCommand("select FR_name from FunctReq where FR_name='" + FunctionalRequirement.FR_name + "' and Project_id='" + ss + "'", con);
                                    SqlDataReader dr2 = cmd2.ExecuteReader();
                                    while (dr2.Read())
                                    {
                                        check.Add(dr2["FR_name"].ToString());
                                    }
                                    con.Close();
                                    dr2.Close();
                                }
                                catch (SqlException sq) { MessageBox.Show(sq.Message); }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                finally { if (con != null) con.Close(); }
                                if (check.Count > 0)
                                {
                                    MessageBox.Show("Requirement Already Exist");

                                }

                                else
                                {
                                    try
                                    {
                                        SqlCommand cmd10 = new SqlCommand("insert into FunctReq(FR_name,FR_desc,Project_id,concategory_id) values( '" + FunctionalRequirement.FR_name + "','" + FunctionalRequirement.FR_desc + "','" + ss + "',(select concerncategory.cc_id from concerncategory where concerncategory.concategory_name='" + FunctionalRequirement.c_type + "'))", con);
                                        con.Open();
                                        cmd10.ExecuteReader();
                                        con.Close();
                                    }
                                    catch (SqlException sq) { MessageBox.Show(sq.Message); }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                    finally { if (con != null) con.Close(); }
                                }


                            }
                        }

                        );
                    MessageBox.Show("Succesfully Added requirements");
                    try
                    {
                        SqlCommand cmd = new SqlCommand("select FR_name as 'Requirement Name',FR_desc as 'Description',concerncategory.concategory_name from FunctReq,concerncategory where FunctReq.concategory_id=concerncategory.cc_id and FunctReq.Project_id = '" + ss + "'", con);
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        BindingSource bs = new BindingSource();
                        bs.DataSource = dr;
                        dataGridView1.DataSource = bs;
                        dr.Close();
                        con.Close();
                    }
                    catch (SqlException sq) { MessageBox.Show(sq.Message); }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally { if (con != null) con.Close(); }
                    //using (DAssistDesignConcernEntities fre = new DAssistDesignConcernEntities())
                    //{
                    //    foreach (var i in FRlist)
                    //    {
                    //        Console.WriteLine(i.FR_name + i.FR_desc);
                    //        var v = fre.FunctReqs.Where(f => f.FR_id.Equals(i.FR_id)).FirstOrDefault();
                    //        if (v != null)
                    //        {
                    //            v.FR_name = i.FR_name;
                    //            v.FR_desc = i.FR_desc;
                    //            v.Project_id = ss;
                    //        }
                    //        else
                    //        {
                    //            fre.FunctReqs.Add(i);
                    //        }

                    //    }
                    //    fre.SaveChanges();
                    //    this.dataGridView1.DataSource = fre.FunctReqs.Where(f => f.Project_id.Equals(ss)).ToList();

                    //}

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void Dcxmlbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Title = "Please select a XML file";
            o.Filter = "XML File|*.xml";
            DialogResult d = o.ShowDialog();
            if (d == System.Windows.Forms.DialogResult.OK)
            {
                this.filename = o.FileName;
                XDocument x = XDocument.Load(filename);
                //List<DConst> FRlist = 
                x.Descendants("Constraint").Select
                (FunctionalRequirement =>
                    new
                    {//Dc_id = Convert.ToInt32(FunctionalRequirement.Element("id").Value),
                        Dc_name = FunctionalRequirement.Element("Dc_name").Value,
                        Dc_des = FunctionalRequirement.Element("Dc_description").Value,
                        Project_id = ss
                    }).ToList().ForEach(FunctionalRequirement =>
                    {
                        SqlCommand cmd10 = new SqlCommand("insert into DConst(Dc_name,Dc_des,Project_id) values( '" + FunctionalRequirement.Dc_name + "','" + FunctionalRequirement.Dc_des + "','" + ss + "')", con);
                        con.Open();
                        cmd10.ExecuteReader();
                        con.Close();
                    });
                MessageBox.Show("Succesfully Added constraints");
                SqlCommand cmd = new SqlCommand("select Dc_name as 'Constraints Name',Dc_des as 'Description' from DConst where Project_id = '" + ss + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                BindingSource bs = new BindingSource();
                bs.DataSource = dr;
                dataGridView2.DataSource = bs;
                dr.Close();
                con.Close();

                //using (DAssistDesignConcernEntities fre = new DAssistDesignConcernEntities())
                //{
                //    foreach (var i in FRlist)
                //    {
                //        var v = fre.DConsts.Where(f => f.Dc_id.Equals(i.Dc_id)).FirstOrDefault();
                //        if (v != null)
                //        {
                //            v.Dc_name = i.Dc_name;
                //            v.Dc_des = i.Dc_des;
                //            v.Project_id = ss;
                //        }
                //        else
                //        {
                //            fre.DConsts.Add(i);
                //        }
                //    }
                //    fre.SaveChanges();
                //    this.dataGridView2.DataSource = fre.DConsts.Where(f => f.Project_id.Equals(ss)).ToList();
                //}
            }

        }

        private void Dcmanualbutton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to add the requirement in current project", "Save Requirement", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<string> check = new List<string>();
                con.Open();
                SqlCommand cmd2 = new SqlCommand("select Dc_name from DConst where Dc_name='" + textBox4.Text + "' and Project_id='" + ss + "'", con);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    check.Add(dr2["Dc_name"].ToString());
                }
                con.Close();
                dr2.Close();
                if (check.Count > 0)
                {
                    MessageBox.Show("Constraints Already Exist");
                }
                else
                {
                    //DAssistDesignConcernEntities fre = new DAssistDesignConcernEntities();
                    //DConst dc = new DConst();
                    //dc.Dc_name = textBox4.Text;
                    //dc.Dc_des = textBox3.Text;
                    //dc.Project_id = ss;
                    //fre.DConsts.Add(dc);
                    //fre.SaveChanges();
                    //this.dataGridView2.DataSource = fre.DConsts.Where(f => f.Project_id.Equals(ss)).ToList();
                    SqlCommand cmd10 = new SqlCommand("insert into DConst(Dc_name,Dc_des,Project_id) values( '" + textBox4.Text + "','" + textBox3.Text + "','" + ss + "')", con);
                    con.Open();
                    cmd10.ExecuteReader();
                    con.Close();
                    MessageBox.Show("Succesfully Added Constraints");
                    SqlCommand cmd = new SqlCommand("select Dc_name as 'Constraints Name',Dc_des as 'Description' from DConst where Project_id = '" + ss + "'", con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dr;
                    dataGridView2.DataSource = bs;
                    dr.Close();
                    con.Close();
                    textBox3.Clear();
                    textBox4.Clear();
                }
            }
        }
        bool fr = false, qg = false, cat = false, qaa = false;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        private void LoadQGbutton_Click(object sender, EventArgs e)
        {
            qg = true;
            fr = false;
            panel3.Visible = false;
            RelateQG.Visible = false;
            CatagoryButton.Visible = false;
            // dataGridView1.Rows.Clear();
            try
            {
                SqlCommand cmd = new SqlCommand("select QA_name as 'QG Name',QA_des 'Description' from QualityGoal as q inner join QualityAttribute as qa on q.QA_id=qa.QA_id where q.Project_id = '" + ss + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                BindingSource bs = new BindingSource();
                bs.DataSource = dr;
                dataGridView4.DataSource = bs;
                dr.Close();
            }
            catch (SqlException sq) { MessageBox.Show(sq.Message); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { if (con != null) con.Close(); }

            con.Close();
        }

        private void RelateQG_Click(object sender, EventArgs e)
        {
            qaa = true;
            cat = false;
            comboBox5.Items.Clear();
            panel2.Visible = false;
            panel3.Visible = true;
            panel3.BringToFront();
            try
            {
                SqlCommand cmd = new SqlCommand("select QA_name from QualityGoal as q inner join QualityAttribute as qa on q.QA_id=qa.QA_id where q.Project_id = '" + ss + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox5.Items.Add(dr["QA_name"]);
                }
                dr.Close();
            }
            catch (SqlException sq) { MessageBox.Show(sq.Message); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { if (con != null) con.Close(); }

            con.Close();
        }

        private void RelateConstraintsButton_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel2.Visible = true;
            panel2.BringToFront();
            SqlCommand cmd = new SqlCommand("select Dc_name as 'Constraints Name',Dc_des as 'Description' from DConst where Project_id='" + ss + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            BindingSource bs = new BindingSource();
            bs.DataSource = dr;
            dataGridView3.DataSource = bs;
            dr.Close();
            con.Close();
        }

        private void QGConfirmButton_Click(object sender, EventArgs e)
        {
            if (qaa)
            {
                for (int i = dataGridView4.RowCount - 1; i >= 0; i--)
                {
                    DataGridViewRow row = dataGridView4.Rows[i];
                    if (Convert.ToBoolean(row.Cells["Column2"].Value))
                    {
                        String idd = Convert.ToString(dataGridView4.Rows[i].Cells["Requirement Name"].Value.ToString());

                        //duplication
                        List<string> check = new List<string>();
                        try
                        {
                            con.Open();
                            SqlCommand cmd2 = new SqlCommand("select d.FR_id as fr from DC_Relation as d inner join FunctReq as f on d.FR_id=f.FR_id inner join QualityGoal as q on d.QG_id=q.QG_id inner join QualityAttribute as qa on q.QA_id=qa.QA_id where f.FR_name='" + idd + "' and qa.QA_name='" + comboBox5.SelectedItem.ToString() + "' and d.Project_id='" + ss + "'", con);
                            SqlDataReader dr2 = cmd2.ExecuteReader();
                            while (dr2.Read())
                            {
                                //Console.WriteLine(dr2["DD_name"].ToString());
                                check.Add(dr2["fr"].ToString());
                            }
                            con.Close();
                            dr2.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally { if (con != null) con.Close(); }

                        if (check.Count > 0)
                        {
                            MessageBox.Show("Impact Already Exist");
                        }
                        else
                        {
                            try
                            {
                                SqlCommand cmd10 = new SqlCommand("insert into DC_Relation(FR_id,QG_id,Project_id) select FR_id,QG_id,dd.Project_id from FunctReq as dd inner join Project as p on dd.Project_id=p.Project_id inner join QualityGoal as f on p.Project_id=f.Project_id inner join QualityAttribute as q on f.QA_id=q.QA_id   where p.Project_id='" + ss + "' and q.QA_name='" + comboBox5.SelectedItem.ToString() + "' and dd.FR_name='" + idd + "'", con);
                                con.Open();
                                cmd10.ExecuteReader();
                                con.Close();
                                MessageBox.Show("Impact successfull");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally { if (con != null) con.Close(); }

                        }

                    }
                }

            }
            else if (cat)
            {
                for (int i = dataGridView4.RowCount - 1; i >= 0; i--)
                {
                    DataGridViewRow row = dataGridView4.Rows[i];
                    if (Convert.ToBoolean(row.Cells["Column2"].Value))
                    {
                        try
                        {
                            String idd = Convert.ToString(dataGridView4.Rows[i].Cells["FR_name"].Value.ToString());
                            SqlCommand cmd10 = new SqlCommand("insert into DDFRCatagory(FR_id,catagory_id) select FR_id,catagory_id from FunctReq as dd inner join DCatagory as c on dd.Project_id=c.project_id   where dd.Project_id='" + ss + "' and c.catagoryName='" + comboBox5.SelectedItem.ToString() + "' and dd.FR_name='" + idd + "'", con);
                            con.Open();
                            cmd10.ExecuteReader();
                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally { if (con != null) con.Close(); }

                    }
                }
                MessageBox.Show("Relation successfull");
            }
        }
        List<string> q = new List<string>();
        private void Addbutton_Click(object sender, EventArgs e)
        {

            if (this.listBox2.Text != "")
            {
                if (q.Contains(this.listBox2.Text) == false)
                {
                    List<string> check = new List<string>();
                    try
                    {
                        con.Open();
                        SqlCommand cmd2 = new SqlCommand("select QA_name from QualityAttribute as qa inner join QualityGoal as q on qa.QA_id=q.QA_id where QA_name='" + this.listBox2.Text + "' and q.Project_id='" + ss + "'", con);
                        SqlDataReader dr2 = cmd2.ExecuteReader();
                        while (dr2.Read())
                        {
                            check.Add(dr2["QA_name"].ToString());
                        }
                        con.Close();
                        dr2.Close();
                    }
                    catch (SqlException sq) { MessageBox.Show(sq.Message); }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally { if (con != null) con.Close(); }
                    if (check.Count > 0)
                    {
                        MessageBox.Show("Quality Goal Already Exist");
                    }
                    else
                    {
                        listView2.Items.Add(this.listBox2.Text);
                        q.Add(this.listBox2.Text);
                    }
                }

            }
            else
            {
                MessageBox.Show("No Quality Attribute Selected");
            }
        }

        private void Removebutton_Click(object sender, EventArgs e)
        {
            if (listView2.Items.Count != 0)
            {
                string s = listView2.SelectedItems[0].SubItems[0].Text;
                listView2.Items.RemoveAt(listView2.SelectedIndices[0]);
                Console.WriteLine(s);
                if (q.Contains(s))
                {
                    q.Remove(s);
                    Console.WriteLine("removed");
                }
            }
            else
            {
                MessageBox.Show("No Quality Found ");
            }
            
        }
        int qaid;
        private void Donebutton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView2.Items)
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("select QA_id from QualityAttribute where QA_name='" + item.Text + "'", con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        qaid = Convert.ToInt32(dr["QA_id"]);
                    }
                    dr.Close();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { if (con != null) con.Close(); }
                try
                {

                    SqlCommand cmd1 = new SqlCommand("insert into QualityGoal(QA_id,Project_id,concateg) values ('" + qaid + "' ,'" + ss + "','" + 10 + "')", con);
                    con.Open();
                    cmd1.ExecuteReader();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { if (con != null) con.Close(); }


            }
            dtt.Rows.Clear();
            dtt.Columns.Clear();
            // frOrDcorQG = 3;
            try
            {
                SqlCommand cmd11 = new SqlCommand("select QA_name as 'Name',QA_des as 'Description' from QualityGoal as q inner join QualityAttribute as qa on q.QA_id=qa.QA_id where q.Project_id = '" + ss + "'", con);
                con.Open();
                cmd11.ExecuteReader();
                addd = new SqlDataAdapter();
                addd.SelectCommand = cmd11;
                con.Close();
                addd.Fill(dtt);
                dataGridView21.DataSource = dtt;
                listView2.Items.Clear();
                MessageBox.Show("successfully Added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { if (con != null) con.Close(); }
            // DataView dv = new DataView(ds.Tables[0]);

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            using (DAssistEntities de = new DAssistEntities())
            {
                listBox2.Items.Clear();
                var s = (from f in de.QualityAttributes select f.QA_name);
                //id = Convert.ToInt32(from f in de.QualityAttributes select f.QA_id);
                Console.WriteLine(s.ToString());
                listBox2.Items.AddRange(s.ToArray());
            }
            listView2.Items.Clear();
        }
        byte[] img_byte = null;
        String igloc = "";
        private void uploadartifactbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Choose Image";
            ofd.Filter = "Images (*.JPEG;*.BMP;*.JPG;*.GIF;*.PNG;*.)|*.JPEG;*.BMP;*.JPG;*.GIF;*.PNG";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // igloc = ofd.FileName.ToString();
                //FileStream fs = new FileStream(igloc, FileMode.Open, FileAccess.Read);
                //BinaryReader br = new BinaryReader(fs);
                //img = br.ReadBytes((int)fs.Length);
                //img = Image.FromFile(ofd.FileName);
                //MemoryStream ms = new MemoryStream();
                //img.Save(ms, img.RawFormat);
                //using (ArtiEntity af = new ArtiEntity())
                //{
                //    af.Artifacts.Add(new Artifact() { artifacts = ms.ToArray() });
                //    af.SaveChanges();
                //}

                //MessageBox.Show("succesfully added");
                Image img = new Bitmap(ofd.FileName);
                pictureBox2.Image = img;// resizeImage(img);

                img_byte = ImageToByteArray(pictureBox2.Image, pictureBox2);
            }
        }

        public static byte[] ImageToByteArray(Image img, PictureBox pictureBox2)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            if (pictureBox2.Image != null)
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            return ms.ToArray();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            try
            {
                SqlCommand cmd = new SqlCommand("select catagoryName from DCatagory", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["catagoryName"]);
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { if (con != null) con.Close(); }
        }

        private void FindRecbutton_Click(object sender, EventArgs e)
        {
            dataGridView6.DataSource = null;
            List<string> qg = new List<string>();
            List<string> DL = new List<string>();
            try
            {
                SqlCommand cmd = new SqlCommand("select QA_name from QualityGoal as q inner join QualityAttribute as qa on q.QA_id=qa.QA_id where Project_id='" + ss + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    qg.Add(dr["QA_name"].ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { if (con != null) con.Close(); }
            if (DL.Count != 0)
            {
                foreach (string s in DL)
                {
                    try
                    {
                        SqlCommand cmd8 = new SqlCommand("select DR_name as 'Decision Name',DR_Des as 'Description',catagoryName as 'CatagoryName' from DecisionRepo as dr inner join DCatagory as c on dr.catagory_id=c.catagory_id where dr.DR_name = '" + s + "'", con);
                        con.Open();
                        SqlDataReader dr8 = cmd8.ExecuteReader();
                        SqlDataAdapter ad = new SqlDataAdapter();
                        ad.SelectCommand = cmd8;
                        while (dr8.Read())
                        {
                            if (!catagorycombobox.Items.Contains(dr8["CatagoryName"]))
                            {
                                catagorycombobox.Items.Add(dr8["CatagoryName"]);
                            }
                        }
                        con.Close();
                        dr8.Close();
                        ad.Fill(dt);
                        dataGridView5.DataSource = dt;
                        dt.Rows.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally { if (con != null) con.Close(); }

                }

            }
            else
            {
                for (int i = 0; i < qg.Count; i++)
                {

                    try
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
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally { if (con != null) con.Close(); }
                }
                List<string> conflict = new List<string>();
                for (int i = 0; i < DL.Count; i++)
                {
                    foreach (string q in qg)
                    {
                        try
                        {
                            SqlCommand cmd1 = new SqlCommand("select Impact from DecisionRepo as dr inner join DecisionQAimpact as i on dr.DR_id = i.DR_id inner join QualityAttribute as qa on i.QA_id = qa.QA_id where DR_name = '" + DL[i] + "' AND QA_name='" + q + "'", con);
                            con.Open();
                            SqlDataReader dr1 = cmd1.ExecuteReader();
                            while (dr1.Read())
                            {
                                if (dr1["Impact"].ToString() == "negative")
                                {
                                    if (!conflict.Contains(DL[i]))
                                    {
                                        conflict.Add(DL[i]);
                                    }
                                }
                            }
                            dr1.Close();
                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally { if (con != null) con.Close(); }
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
                    try
                    {
                        SqlCommand cmd8 = new SqlCommand("select DR_name as 'Decision Name',DR_des as 'Description',catagoryName as 'CatagoryName' from DecisionRepo as dr inner join DCatagory as c on dr.catagory_id=c.catagory_id where dr.DR_name = '" + s + "'", con);
                        con.Open();
                        SqlDataReader dr8 = cmd8.ExecuteReader();
                        SqlDataAdapter ad = new SqlDataAdapter();
                        ad.SelectCommand = cmd8;

                        while (dr8.Read())
                        {
                            if (!catagorycombobox.Items.Contains(dr8["CatagoryName"]))
                            {
                                catagorycombobox.Items.Add(dr8["CatagoryName"]);
                            }
                        }
                        con.Close();
                        dr8.Close();
                        ad.Fill(dt);
                        dataGridView5.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally { if (con != null) con.Close(); }
                }
            }


            //SqlCommand cmd18 = new SqlCommand("select DR_name,DR_des,DR_type from DecisionRepo where DR_type = '" + catagorycombobox.SelectedItem.ToString() + "'", con);
            //con.Open();
            //SqlDataReader dr18 = cmd18.ExecuteReader();

            //con.Close();
            //dr18.Close();

        }

        private void catagorycombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("CatagoryName Like '%{0}%'", catagorycombobox.SelectedItem.ToString());
            dataGridView5.DataSource = dv;
            dataGridView6.DataSource = null;
        }
        string[] impact = new string[8];
        private void qaimpactbutton_Click(object sender, EventArgs e)
        {
            int a = 0;
            List<string> x = new List<string>();
            if (MessageBox.Show("Are you sure to add this as architecture decision", "save decision", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<string> check = new List<string>();
                try
                {
                    con.Open();
                    SqlCommand cmd2 = new SqlCommand("select DD_name from DesignDecision where DD_name='" + textBox7.Text + "' and Project_id='" + ss + "'", con);
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    while (dr2.Read())
                    {
                        check.Add(dr2["DD_name"].ToString());
                    }
                    con.Close();
                    dr2.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { if (con != null) con.Close(); }
                if (check.Count > 0)
                {
                    MessageBox.Show("Decision Already Exist; View decision in Decision Editor");
                }
                else {
                    if (comboBox1.SelectedIndex > -1)
                    {
                        try
                        {
                            SqlCommand cmd1 = new SqlCommand("select catagory_id from DCatagory as c where c.catagoryName='" + comboBox1.SelectedItem.ToString() + "'", con);
                            con.Open();
                            SqlDataReader dr = cmd1.ExecuteReader();
                            while (dr.Read())
                            {
                                x.Add(dr["catagory_id"].ToString());
                            }
                            a = Convert.ToInt32(x[0]);
                            con.Close();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally { if (con != null) con.Close(); }
                        //Console.WriteLine(a.ToString());


                        // MessageBox.Show("successfully saved");

                        if (impact[1] == null || impact[2] == null || impact[3] == null || impact[4] == null || impact[5] == null || impact[6] == null)
                        {
                            MessageBox.Show("Please Check whether any quality relation is unselected");
                        }
                        else {
                            if (textBox7.Text == "") { MessageBox.Show("Please add a Decision Name. Decision without a name can not be added"); }
                            else
                            {
                                try
                                {

                                    SqlCommand cmd = new SqlCommand("insert into DesignDecision(DD_name,DD_des,Project_id,catagory_id,dd_image) values('" + textBox7.Text + "','" + textBox6.Text + "','" + ss + "','" + a + "','" + img_byte + "') ", con);
                                    con.Open();
                                    cmd.ExecuteReader();
                                    con.Close();

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                finally { if (con != null) con.Close(); }

                                try
                                {
                                    SqlCommand cmd10 = new SqlCommand("insert into DecisionQAimpact(DD_id,QA_id,Impact) select DD_id,1,'" + impact[1] + "' from DesignDecision as dd where dd.DD_name='" + textBox7.Text + "' ", con);
                                    con.Open();
                                    cmd10.ExecuteReader();
                                    con.Close();

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                finally { if (con != null) con.Close(); }


                                try
                                {
                                    SqlCommand cmd100 = new SqlCommand("insert into DecisionQAimpact(DD_id,QA_id,Impact) select DD_id,2,'" + impact[2] + "' from DesignDecision as dd where dd.DD_name='" + textBox7.Text + "' ", con);
                                    con.Open();
                                    cmd100.ExecuteReader();
                                    con.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                finally { if (con != null) con.Close(); }

                                try
                                {

                                    SqlCommand cmd111 = new SqlCommand("insert into DecisionQAimpact(DD_id,QA_id,Impact) select DD_id,3,'" + impact[3] + "' from DesignDecision as dd where dd.DD_name='" + textBox7.Text + "' ", con);
                                    con.Open();
                                    cmd111.ExecuteReader();
                                    con.Close();

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                finally { if (con != null) con.Close(); }

                                try
                                {
                                    SqlCommand cmd21 = new SqlCommand("insert into DecisionQAimpact(DD_id,QA_id,Impact) select DD_id,4,'" + impact[4] + "' from DesignDecision as dd where dd.DD_name='" + textBox7.Text + "' ", con);
                                    con.Open();
                                    cmd21.ExecuteReader();
                                    con.Close();

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                finally { if (con != null) con.Close(); }

                                try
                                {
                                    SqlCommand cmd3 = new SqlCommand("insert into DecisionQAimpact(DD_id,QA_id,Impact) select DD_id,5,'" + impact[5] + "' from DesignDecision as dd where dd.DD_name='" + textBox7.Text + "' ", con);
                                    con.Open();
                                    cmd3.ExecuteReader();
                                    con.Close();

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                finally { if (con != null) con.Close(); }

                                try
                                {
                                    SqlCommand cmd4 = new SqlCommand("insert into DecisionQAimpact(DD_id,QA_id,Impact) select DD_id,6,'" + impact[6] + "' from DesignDecision as dd where dd.DD_name='" + textBox7.Text + "' ", con);
                                    con.Open();
                                    cmd4.ExecuteReader();
                                    con.Close();

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                finally { if (con != null) con.Close(); }

                                MessageBox.Show("successfull");

                                textBox7.Clear();
                                textBox6.Clear();
                                radioButton1.Checked = false;
                                radioButton2.Checked = false;
                                radioButton3.Checked = false;
                                radioButton4.Checked = false;
                                radioButton5.Checked = false;
                                radioButton6.Checked = false;
                                radioButton7.Checked = false;
                                radioButton8.Checked = false;
                                radioButton9.Checked = false;
                                radioButton10.Checked = false;
                                radioButton11.Checked = false;
                                radioButton12.Checked = false;
                                radioButton18.Checked = false;
                                radioButton17.Checked = false;
                                radioButton16.Checked = false;
                                radioButton26.Checked = false;
                                radioButton27.Checked = false;
                                radioButton25.Checked = false;
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("select one decision type");
                    }
                }

            }



        }

        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {
            impact[1] = "positive";
        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
            impact[1] = "negative";
        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            impact[1] = "neutral";
        }

        private void radioButton26_CheckedChanged(object sender, EventArgs e)
        {
            impact[2] = "positive";
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
        DataTable dtretrieve = new DataTable();
        private void Retrievebutton_Click(object sender, EventArgs e)
        {
            dataGridView8.DataSource = null;
            List<string> sr = new List<string>();
            if (sr.Count != 0)
            {
                foreach (string s in sr)
                {
                    try
                    {
                        SqlCommand cmd8 = new SqlCommand("select DR_name as 'Decision Name',DR_des as 'Description',catagoryName as 'CatagoryName' from DecisionRepo as d inner join DCatagory as c on d.catagory_id=c.catagory_id where DR_name = '" + s + "'", con);
                        con.Open();
                        SqlDataReader dr8 = cmd8.ExecuteReader();
                        SqlDataAdapter ad_r = new SqlDataAdapter();
                        ad_r.SelectCommand = cmd8;
                        while (dr8.Read())
                        {
                            if (!comboBox2.Items.Contains(dr8["CatagoryName"]))
                            {
                                comboBox2.Items.Add(dr8["CatagoryName"]);
                            }
                        }
                        con.Close();
                        dr8.Close();
                        ad_r.Fill(dtretrieve);
                        dataGridView7.DataSource = dtretrieve;
                        dtretrieve.Rows.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally { if (con != null) con.Close(); }

                }
            }
            else
            {

                foreach (string z in checkedListBox1.CheckedItems)
                {
                    try
                    {
                        SqlCommand cmd2 = new SqlCommand("select Distinct DR_name as 'Decision Name' from DecisionRepo as dr inner join DecisionQAimpact as i on dr.DR_id = i.DR_id inner join QualityAttribute as qa on i.QA_id = qa.QA_id where(Impact = 'positive' OR Impact = 'neutral') AND(qa.QA_name = '" + z + "')", con);
                        con.Open();
                        SqlDataReader dr2 = cmd2.ExecuteReader();
                        while (dr2.Read())
                        {
                            if (sr.Contains(dr2["Decision Name"]) == false)
                            {
                                sr.Add(dr2["Decision Name"].ToString());
                            }
                        }
                        dr2.Close();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally { if (con != null) con.Close(); }


                }
                try
                {
                    SqlCommand cmd9 = new SqlCommand("select Distinct DR_name as 'Decision Name' from DecisionRepo as dr inner join DecisionQAimpact as i on dr.DR_id = i.DR_id inner join QualityAttribute as qa on i.QA_id = qa.QA_id where(Impact = 'positive' OR Impact = 'neutral') AND(DR_name = '" + textBox5.Text + "'OR QA_name = '" + textBox5.Text + "')", con);
                    con.Open();
                    SqlDataReader dr9 = cmd9.ExecuteReader();
                    while (dr9.Read())
                    {
                        if (sr.Contains(dr9["Decision Name"]) == false)
                        {
                            sr.Add(dr9["Decision Name"].ToString());
                        }
                    }
                    dr9.Close();
                    con.Close();
                    dtretrieve.Rows.Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { if (con != null) con.Close(); }

                foreach (string s in sr)
                {
                    try
                    {
                        SqlCommand cmd8 = new SqlCommand("select DR_name as 'Decision Name',DR_des as 'Description',catagoryName as 'CatagoryName' from DecisionRepo as d inner join DCatagory as c on d.catagory_id=c.catagory_id where DR_name = '" + s + "'", con);
                        con.Open();
                        SqlDataReader dr8 = cmd8.ExecuteReader();
                        SqlDataAdapter ad = new SqlDataAdapter();
                        ad.SelectCommand = cmd8;
                        //int m = dataGridView1.Rows.Add();                
                        //dataGridView1.Rows[m].Cells[0].Value = s;
                        while (dr8.Read())
                        {
                            // dataGridView1.Rows[m].Cells[1].Value = dr8["DR_des"];

                            if (!comboBox2.Items.Contains(dr8["CatagoryName"]))
                            {
                                comboBox2.Items.Add(dr8["CatagoryName"]);
                            }
                        }
                        con.Close();
                        dr8.Close();
                        ad.Fill(dtretrieve);
                        dataGridView7.DataSource = dtretrieve;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally { if (con != null) con.Close(); }

                }
            }
        }

        private void tabControl3_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.Items.Count == 0)
            {
                try
                {
                    SqlCommand cmd6 = new SqlCommand("select QA_name from QualityGoal as q inner join QualityAttribute as qa on q.QA_id=qa.QA_id where Project_id='" + ss + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd6);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        checkedListBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { if (con != null) con.Close(); }

            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtretrieve);
            dv.RowFilter = string.Format("CatagoryName Like '%{0}%'", comboBox2.SelectedItem.ToString());
            dataGridView7.DataSource = dv;
            dataGridView8.DataSource = null;
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView5.Columns[e.ColumnIndex].Name == "AddDecision")
            {
                // dataGridView3.Rows.Clear();
                String iddd = Convert.ToString(dataGridView5.Rows[e.RowIndex].Cells["Decision Name"].Value.ToString());
                if (MessageBox.Show("Are you sure to add this as Architectural Decision", "Add Decision", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    List<string> check = new List<string>();
                    try
                    {
                        con.Open();
                        SqlCommand cmd2 = new SqlCommand("select DD_name from DesignDecision where DD_name='" + iddd + "' and Project_id='" + ss + "'", con);
                        SqlDataReader dr2 = cmd2.ExecuteReader();
                        while (dr2.Read())
                        {
                            check.Add(dr2["DD_name"].ToString());
                        }
                        con.Close();
                        dr2.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally { if (con != null) con.Close(); }

                    if (check.Count > 0)
                    {
                        MessageBox.Show("Decision Already Exist");
                    }
                    else
                    {
                        try
                        {
                            con.Open();
                            SqlCommand cmd4 = new SqlCommand("insert into DesignDecision (DD_name,DD_des,Project_id,catagory_id) select DR_name,DR_des,'" + ss + "',catagory_id from DecisionRepo  where  DR_name='" + iddd + "'", con);
                            cmd4.ExecuteReader();
                            con.Close();
                            con.Open();
                            SqlCommand cmd15 = new SqlCommand("select Impact from DecisionQAimpact as d inner join DecisionRepo as dr on d.DR_id=dr.DR_id where dr.DR_name ='" + iddd + "'", con);
                            SqlDataReader dr = cmd15.ExecuteReader();
                            List<string> ls = new List<string>();
                            while (dr.Read())
                            {
                                ls.Add(dr["Impact"].ToString());
                            }
                            con.Close();
                            dr.Close();
                            for (int i = 1; i < 7; i++)
                            {
                                con.Open();
                                SqlCommand cmd14 = new SqlCommand("insert into DecisionQAimpact(DD_id, QA_id, Impact) select DD_id,'" + i + "','" + ls[i - 1] + "' from DesignDecision as d where d.DD_name ='" + iddd + "'", con);
                                cmd14.ExecuteReader();
                                con.Close();
                                Console.WriteLine(ls[i - 1].ToString());
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally { if (con != null) con.Close(); }



                        MessageBox.Show("Decision saved under current project");
                    }
                }
            }
            else if (dataGridView5.Columns[e.ColumnIndex].Name == "viewQimpact")
            {
                try
                {
                    con.Open();
                    String idd = Convert.ToString(dataGridView5.Rows[e.RowIndex].Cells["Decision Name"].Value.ToString());
                    SqlCommand cmd8 = new SqlCommand("select QA_name as 'Quality Name', Impact from DecisionRepo as dr inner join DecisionQAimpact as i on dr.DR_id = i.DR_id inner join QualityAttribute as qa on i.QA_id = qa.QA_id where DR_name='" + idd + "'", con);
                    SqlDataReader dr8 = cmd8.ExecuteReader();
                    BindingSource bs8 = new BindingSource();
                    bs8.DataSource = dr8;
                    dataGridView6.DataSource = bs8;
                    dr8.Close();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }
                for (int i = 0; i < dataGridView6.Rows.Count; i++)
                {
                    if (dataGridView6.Rows[i].Cells[1].Value.ToString() == "negative")
                    {
                        dataGridView6.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                    if (dataGridView6.Rows[i].Cells[1].Value.ToString() == "positive")
                    {
                        dataGridView6.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    }
                }

            }
            else if (dataGridView5.Columns[e.ColumnIndex].Name == "viewdrdetail")
            {
                try
                {
                    // int id = Convert.ToInt32(dataGridView9.Rows[e.RowIndex].Cells["DR_id"].Value.ToString());
                    String name = Convert.ToString(dataGridView5.Rows[e.RowIndex].Cells["Decision Name"].Value.ToString());
                    String des = Convert.ToString(dataGridView5.Rows[e.RowIndex].Cells["Description"].Value.ToString());
                    ViewDetails v = new ViewDetails(name, des, ss, 0, 4);
                    v.ShowDialog();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView7.Columns[e.ColumnIndex].Name == "A_d")
            {
                //  dataGridView3.Rows.Clear();
                String iddd = Convert.ToString(dataGridView7.Rows[e.RowIndex].Cells["Decision Name"].Value.ToString());
                Console.WriteLine(iddd);

                if (MessageBox.Show("Are you sure to add this as architectural decision", "Add Decision", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    List<string> check = new List<string>();
                    try
                    {
                        con.Open();
                        SqlCommand cmd2 = new SqlCommand("select DD_name from DesignDecision as d where d.DD_name='" + iddd + "' and d.Project_id='" + ss + "'", con);
                        SqlDataReader dr2 = cmd2.ExecuteReader();
                        while (dr2.Read())
                        {
                            //Console.WriteLine(dr2["DD_name"].ToString());
                            check.Add(dr2["DD_name"].ToString());
                        }
                        con.Close();
                        dr2.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        if (con != null)
                        {
                            con.Close();
                        }
                    }
                    if (check.Count > 0)
                    {
                        MessageBox.Show("Decision Already Exist");
                    }
                    else
                    {
                        try
                        {
                            con.Open();
                            SqlCommand cmd4 = new SqlCommand("insert into DesignDecision (DD_name,DD_des,Project_id,catagory_id) select DR_name,DR_des,'" + ss + "',catagory_id from DecisionRepo  where  DR_name='" + iddd + "'", con);
                            cmd4.ExecuteReader();
                            con.Close();
                            con.Open();
                            SqlCommand cmd15 = new SqlCommand("select Impact from DecisionQAimpact as d inner join DecisionRepo as dr on d.DR_id=dr.DR_id where dr.DR_name ='" + iddd + "'", con);
                            SqlDataReader dr = cmd15.ExecuteReader();
                            List<string> ls = new List<string>();
                            while (dr.Read())
                            {
                                ls.Add(dr["Impact"].ToString());
                            }
                            con.Close();
                            dr.Close();
                            for (int i = 1; i < 7; i++)
                            {
                                con.Open();
                                SqlCommand cmd14 = new SqlCommand("insert into DecisionQAimpact(DD_id, QA_id, Impact) select DD_id,'" + i + "','" + ls[i - 1] + "' from DesignDecision as d where d.DD_name ='" + iddd + "'", con);
                                cmd14.ExecuteReader();
                                con.Close();
                                Console.WriteLine(ls[i - 1].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            if (con != null)
                            {
                                con.Close();
                            }
                        }
                        MessageBox.Show("Decision saved under current project");
                    }
                }
            }
            else if (dataGridView7.Columns[e.ColumnIndex].Name == "ViewQAimpact")
            {
                try
                {
                    con.Open();
                    String idd = Convert.ToString(dataGridView7.Rows[e.RowIndex].Cells["Decision Name"].Value.ToString());
                    SqlCommand cmd3 = new SqlCommand("select QA_name as 'Quality Name', Impact from DecisionRepo as dr inner join DecisionQAimpact as i on dr.DR_id = i.DR_id inner join QualityAttribute as qa on i.QA_id = qa.QA_id where DR_name='" + idd + "'", con);
                    SqlDataReader dr3 = cmd3.ExecuteReader();
                    BindingSource bs3 = new BindingSource();
                    bs3.DataSource = dr3;
                    dataGridView8.DataSource = bs3;
                    dr3.Close();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }
                for (int i = 0; i < dataGridView8.Rows.Count; i++)
                {
                    if (dataGridView8.Rows[i].Cells[1].Value.ToString() == "negative")
                    {
                        dataGridView8.Rows[i].DefaultCellStyle.BackColor = Color.Red;

                    }
                    if (dataGridView8.Rows[i].Cells[1].Value.ToString() == "positive")
                    {
                        dataGridView8.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    }
                }
            }
            else if (dataGridView7.Columns[e.ColumnIndex].Name == "ViewretDetails")
            {
                try
                {
                    // int id = Convert.ToInt32(dataGridView9.Rows[e.RowIndex].Cells["DR_id"].Value.ToString());
                    String name = Convert.ToString(dataGridView7.Rows[e.RowIndex].Cells["Decision Name"].Value.ToString());
                    String des = Convert.ToString(dataGridView7.Rows[e.RowIndex].Cells["Description"].Value.ToString());
                    ViewDetails v = new ViewDetails(name, des, ss, 0, 5);
                    v.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }
        DataTable candidatedecisiondt = new DataTable();
        DataSet candidset = new DataSet();
        private void LoadDecisionbutton_Click(object sender, EventArgs e)
        {
            dataGridView11.DataSource = null;
            dataGridView22.DataSource = null;
            candidset.Clear();
            List<string> dd = new List<string>();
            List<string> rj = new List<string>();
            //List<string> app = new List<string>();

            try
            {
                SqlCommand cmd = new SqlCommand("select DD_name from DesignDecision as d inner join AlternateDecision as a on d.DD_id=a.dd_id where a.Project_id = '" + ss + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    rj.Add(dr["DD_name"].ToString());
                }
                con.Close();
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

            try
            {
                SqlCommand cmd1 = new SqlCommand("select DD_name from DesignDecision as d inner join FinalDecision as a on d.DD_id=a.dd_id where a.Project_id = '" + ss + "'", con);
                con.Open();
                SqlDataReader dr1 = cmd1.ExecuteReader();
                while (dr1.Read())
                {
                    rj.Add(dr1["DD_name"].ToString());
                }
                con.Close();
                dr1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

            try
            {
                SqlCommand cmd2 = new SqlCommand("select DD_name from DesignDecision where Project_id='" + ss + "'", con);
                con.Open();
                SqlDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    if (!rj.Contains(dr2["DD_name"].ToString()))
                    {
                        dd.Add(dr2["DD_name"].ToString());
                    }

                }
                con.Close();
                dr2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            //ds.Clear();
            //if (candidatedecisiondt.Rows.Count > 0)
            //{
            //    dataGridView10.DataSource = candidatedecisiondt;
            //}
            //else
            //{
            //  candidatedecisiondt.Rows.Clear();
            //candidatedecisiondt.Columns.Clear();
            foreach (string s in dd)
            {

                try
                {
                    SqlCommand cmd8 = new SqlCommand("select DD_name as 'Decision Name' ,DD_des as 'Description',catagoryName from DesignDecision as d inner join DCatagory as c on d.catagory_id=c.catagory_id where d.DD_name='" + s + "' and d.Project_id = '" + ss + "'", con);
                    con.Open();
                    SqlDataReader dr8 = cmd8.ExecuteReader();
                    SqlDataAdapter add = new SqlDataAdapter();
                    add.SelectCommand = cmd8;
                    while (dr8.Read())
                    {
                        if (!comboBox3.Items.Contains(dr8["catagoryName"]))
                        {
                            comboBox3.Items.Add(dr8["catagoryName"]);
                        }
                    }
                    con.Close();
                    dr8.Close();
                    add.Fill(candidset);
                    //add.Fill(dt);
                    DataView canditview = new DataView(candidset.Tables[0]);
                    if (canditview.Count > 0)
                    { dataGridView10.DataSource = canditview; }
                    else
                    { MessageBox.Show("No Candidate Decisions Found"); }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }


            }



            //dt.Rows.Clear();
        }
        DataTable decisionrelationdt = new DataTable();
        private void dataGridView10_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView10.Columns[e.ColumnIndex].Name == "ApproveDecision")
                {
                    //  dataGridView3.Rows.Clear();
                    String iddd = Convert.ToString(dataGridView10.Rows[e.RowIndex].Cells["Decision Name"].Value.ToString());
                    //Console.WriteLine(iddd);

                    if (MessageBox.Show("Are you sure to approve this as design decision", "save decision", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        List<string> check = new List<string>();
                        try
                        {
                            con.Open();
                            SqlCommand cmd2 = new SqlCommand("select DD_name from DesignDecision as d inner join FinalDecision as f on d.DD_id=f.dd_id where DD_name='" + iddd + "' and f.project_id='" + ss + "'", con);
                            SqlDataReader dr2 = cmd2.ExecuteReader();
                            while (dr2.Read())
                            {
                                check.Add(dr2["DD_name"].ToString());
                            }
                            con.Close();
                            dr2.Close();
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                        string rejected = null;
                        try
                        {
                            con.Open();
                            SqlCommand cmd3 = new SqlCommand("select DD_name from DesignDecision as d inner join AlternateDecision as f on d.DD_id=f.dd_id where DD_name='" + iddd + "' and f.project_id='" + ss + "'", con);
                            SqlDataReader dr3 = cmd3.ExecuteReader();
                            while (dr3.Read())
                            {
                                rejected = Convert.ToString(dr3["DD_name"].ToString());
                            }
                            con.Close();
                            dr3.Close();
                            if (rejected != null)
                            {
                                SqlCommand cmd9 = new SqlCommand("delete from AlternateDecicion where dd_name='" + iddd + "' and project_id='" + ss + "' ", con);
                                con.Open();
                                cmd9.ExecuteReader();
                                con.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            if (con != null)
                            {
                                con.Close();
                            }
                        }
                        if (check.Count > 0)
                        {
                            MessageBox.Show("Decision Already Approved");
                        }
                        else
                        {
                            try
                            {
                                con.Open();
                                SqlCommand cmd4 = new SqlCommand("insert into FinalDecision (DD_id,project_id) select DD_id,'" + ss + "' from DesignDecision  where  DD_name='" + iddd + "' and Project_id='" + ss + "'", con);
                                cmd4.ExecuteReader();
                                con.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                if (con != null)
                                {
                                    con.Close();
                                }
                            }
                            MessageBox.Show("Decision Approved under current project");
                        }
                    }
                }
                else if (dataGridView10.Columns[e.ColumnIndex].Name == "RejectDecision")
                {
                    String iddd = Convert.ToString(dataGridView10.Rows[e.RowIndex].Cells["Decision Name"].Value.ToString());

                    if (MessageBox.Show("Are you sure to Reject this as design decision", "Rejct decision", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        List<string> check = new List<string>();
                        try
                        {
                            con.Open();
                            SqlCommand cmd2 = new SqlCommand("select DD_name from DesignDecision as d inner join AlternateDecision as f on d.DD_id=f.dd_id where DD_name='" + iddd + "' and f.project_id='" + ss + "'", con);
                            SqlDataReader dr2 = cmd2.ExecuteReader();
                            while (dr2.Read())
                            {
                                check.Add(dr2["DD_name"].ToString());
                            }
                            con.Close();
                            dr2.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            if (con != null)
                            {
                                con.Close();
                            }
                        }
                        if (check.Count > 0)
                        {
                            MessageBox.Show("Decision Already Rejected");
                        }
                        else
                        {
                            try
                            {
                                con.Open();
                                SqlCommand cmd4 = new SqlCommand("insert into AlternateDecision (DD_id,project_id) select DD_id,'" + ss + "' from DesignDecision  where  DD_name='" + iddd + "' and Project_id='" + ss + "'", con);
                                cmd4.ExecuteReader();
                                con.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                if (con != null)
                                {
                                    con.Close();
                                }
                            }
                            MessageBox.Show("Decision rejected under current project");
                        }
                    }
                }
                else if (dataGridView10.Columns[e.ColumnIndex].Name == "Dimpact")
                {
                    
                    String idd = Convert.ToString(dataGridView10.Rows[e.RowIndex].Cells["Decision Name"].Value.ToString());
                    try
                    {
                        con.Open();
                        SqlCommand cmd3 = new SqlCommand("select QA_name as 'Quality Name', Impact from DesignDecision as dr inner join DecisionQAimpact as i on dr.DD_id = i.DD_id inner join QualityAttribute as qa on i.QA_id = qa.QA_id where DD_name='" + idd + "' and dr.Project_id='" + ss + "'", con);
                        SqlDataReader dr3 = cmd3.ExecuteReader();
                        BindingSource bs3 = new BindingSource();
                        bs3.DataSource = dr3;
                        if (dr3.HasRows)
                        { dataGridView11.DataSource = bs3; }
                        else
                        { MessageBox.Show("No Quality Impact Found"); }
                        dr3.Close();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        if (con != null)
                        {
                            con.Close();
                        }
                    }
                    for (int i = 0; i < dataGridView11.Rows.Count; i++)
                    {
                        if (dataGridView11.Rows[i].Cells[1].Value.ToString() == "negative")
                        {
                            dataGridView11.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        }
                        if (dataGridView11.Rows[i].Cells[1].Value.ToString() == "positive")
                        {
                            dataGridView11.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                        }
                    }
                    try
                    {
                        decisionrelationdt.Rows.Clear();
                        decisionrelationdt.Columns.Clear();
                        //string check = null;
                        SqlCommand cmd = new SqlCommand("select di.impact as 'Impact',d.DD_name as 'Selected Decision',dd.DD_name as 'Mapped Decision' from DecisionDecImpact as di inner join DesignDecision as d on di.dd1_id = d.DD_id inner join DesignDecision as dd on dd.DD_id = di.dd2_id where d.DD_name = '" + idd + "' OR dd.DD_name = '" + idd + "' and d.Project_id='" + ss + "'", con);
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        //while (dr.Read())
                        //{
                        //    check = Convert.ToString(dr["d.DD_name"].ToString());
                        //}
                        //if (check == null)
                        //{
                        //    MessageBox.Show("no relation with other decision");
                        //}
                        //else
                        //{
                        //    BindingSource bs = new BindingSource();
                        //    bs.DataSource = dr;
                        //    dataGridView22.DataSource = bs;
                        //}

                        SqlDataAdapter addd = new SqlDataAdapter();
                        addd.SelectCommand = cmd;
                        con.Close();
                        dr.Close();
                        addd.Fill(decisionrelationdt);
                        if (decisionrelationdt.Rows.Count > 0)
                        {
                            dataGridView22.DataSource = decisionrelationdt;
                        }
                        else
                        {
                            MessageBox.Show("No Decision-Decision Impact Found");
                        }

                        // DataView dv = new DataView(ds.Tables[0]);
                        for (int i = 0; i < dataGridView22.Rows.Count; i++)
                        {
                            if (dataGridView22.Rows[i].Cells[0].Value.ToString() == "negative")
                            {
                                dataGridView22.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            }
                            if (dataGridView22.Rows[i].Cells[0].Value.ToString() == "positive")
                            {
                                dataGridView22.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        if (con != null)
                        {
                            con.Close();
                        }
                    }


                }
                else if (dataGridView10.Columns[e.ColumnIndex].Name == "ViewDecisionDetails")
                {
                    String name = Convert.ToString(dataGridView10.Rows[e.RowIndex].Cells["Decision Name"].Value.ToString());
                    String des = Convert.ToString(dataGridView10.Rows[e.RowIndex].Cells["Description"].Value.ToString());
                    ViewDetails v = new ViewDetails(name, des, ss, 0, 7);
                    v.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dvv = new DataView(candidset.Tables[0]);
            dvv.RowFilter = string.Format("catagoryName Like '%{0}%'", comboBox3.SelectedItem.ToString());
            dataGridView10.DataSource = dvv;
            dataGridView11.DataSource = null;
            dataGridView22.DataSource = null;
        }
        DataTable finaldecisiondt = new DataTable();
        SqlDataAdapter fadd;
        DataSet finaldset = new DataSet();
        private void LoadFinalDecisionbutton_Click(object sender, EventArgs e)
        {
            dataGridView13.DataSource = null;
            dataGridView14.DataSource = null;
            finaldset.Clear();
            //if (finaldecisiondt.Rows.Count > 0)
            //{
            //    dataGridView12.DataSource = finaldecisiondt;
            //}
            //else
            //{
            try
            {
                // finaldecisiondt.Rows.Clear();
                //finaldecisiondt.Columns.Clear();
                SqlCommand cmd8 = new SqlCommand("select DD_name as 'Decision Name',DD_des as 'Description',catagoryName from FinalDecision as f inner join DesignDecision as d  on f.dd_id=d.DD_id inner join DCatagory as c on d.catagory_id=c.catagory_id where f.Project_id='" + ss + "'", con);
                con.Open();
                SqlDataReader dr8 = cmd8.ExecuteReader();
                while (dr8.Read())
                {
                    if (!comboBox4.Items.Contains(dr8["catagoryName"]))
                    {
                        comboBox4.Items.Add(dr8["catagoryName"]);
                    }
                }
                fadd = new SqlDataAdapter();
                fadd.SelectCommand = cmd8;
                con.Close();
                dr8.Close();
                fadd.Fill(finaldset);
                DataView finaldview = new DataView(finaldset.Tables[0]);
                if (finaldview.Count > 0)
                { dataGridView12.DataSource = finaldview; }
                else { MessageBox.Show("No Approved Decision Found"); }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            //}// finaldecisiondt.Rows.Clear();
        }
        DataTable alternatedecisiondt = new DataTable();
        private void dataGridView12_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView12.Columns[e.ColumnIndex].Name == "MapRationale")
            {

                try
                {
                    String idd = Convert.ToString(dataGridView12.Rows[e.RowIndex].Cells["Decision Name"].Value.ToString());
                    con.Open();
                    SqlCommand cmd3 = new SqlCommand("select QA_name as 'Quality Name',Impact from DesignDecision as dr inner join DecisionQAimpact as i on dr.DD_id = i.DD_id inner join QualityAttribute as qa on i.QA_id = qa.QA_id where dr.DD_name='" + idd + "' and dr.Project_id='" + ss + "'", con);
                    SqlDataReader dr3 = cmd3.ExecuteReader();
                    BindingSource bs3 = new BindingSource();
                    bs3.Clear();
                    bs3.DataSource = dr3;
                    if (dr3.HasRows)
                    {
                        dataGridView13.DataSource = bs3;
                    }
                    else
                    {
                        MessageBox.Show("No Quality Impact Found");
                    }

                    con.Close();
                    dr3.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }

                alternatedecisiondt.Rows.Clear();
                alternatedecisiondt.Columns.Clear();
                String iddd = Convert.ToString(dataGridView12.Rows[e.RowIndex].Cells["catagoryName"].Value.ToString());
                Console.WriteLine(iddd.ToString());
                try
                {
                    con.Open();
                    SqlCommand cmd4 = new SqlCommand("select DD_name as 'Decision Name',DD_des as 'Description',catagoryName from AlternateDecision as f inner join DesignDecision as d  on f.dd_id=d.DD_id inner join DCatagory as c on d.catagory_id=c.catagory_id where f.Project_id='" + ss + "' and c.catagoryName='" + iddd + "'", con);
                    //SqlDataReader dr4 = cmd4.ExecuteReader();
                    //while (dr4.Read())
                    //{
                    //    int n = dataGridView14.Rows.Add();
                    //    dataGridView14.Rows[n].Cells[0].Value = dr4["DD_name"];
                    //    dataGridView14.Rows[n].Cells[1].Value = dr4["DD_des"];
                    //    dataGridView14.Rows[n].Cells[2].Value = dr4["catagoryName"];
                    //    //Console.WriteLine(dr4["DD_name"].ToString());
                    //}
                    // dr4.Close();
                    SqlDataReader dr8 = cmd4.ExecuteReader();
                    SqlDataAdapter f = new SqlDataAdapter();
                    dr8.Close();
                    f.SelectCommand = cmd4;
                    con.Close();
                    f.Fill(alternatedecisiondt);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }
                if (alternatedecisiondt.Rows.Count > 0)
                {
                    dataGridView14.DataSource = alternatedecisiondt;
                }
                else
                { MessageBox.Show("No Alternative Decision Found for this Decision"); }
                for (int i = 0; i < dataGridView13.Rows.Count; i++)
                {
                    if (dataGridView13.Rows[i].Cells[1].Value.ToString() == "negative")
                    {
                        dataGridView13.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                    if (dataGridView13.Rows[i].Cells[1].Value.ToString() == "positive")
                    {
                        dataGridView13.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    }
                }

            }
            else if (dataGridView12.Columns[e.ColumnIndex].Name == "Disapprove")
            {
                int di = 0;
                String idd = Convert.ToString(dataGridView12.Rows[e.RowIndex].Cells["Decision Name"].Value.ToString());
                if (MessageBox.Show("Are you sure to disapprove this as design decision", "Finalize decision", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("select DD_id from DesignDecision where DD_name='" + idd + "' and Project_id='" + ss + "'", con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            di = Convert.ToInt32(dr["DD_id"].ToString());
                        }
                        dr.Close();
                        con.Close();

                        SqlCommand cmd3 = new SqlCommand("Delete from FinalDecision where dd_id='" + di + "' and project_id='" + ss + "'", con);
                        con.Open();
                        cmd3.ExecuteReader();
                        con.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        if (con != null)
                        {
                            con.Close();
                        }
                    }

                }
            }




            //SqlDataAdapter add = new SqlDataAdapter();
            //add.SelectCommand = cmd3;
            //con.Close();
            //dr3.Close();
            //add.Fill(ds);
            //DataView dv = new DataView(ds.Tables[0]);
            //dataGridView13.DataSource = dv;
            //}


            //BindingSource bs3 = new BindingSource();
            //bs3.DataSource = dr3;
            //dataGridView13.DataSource = bs3;
            //dr3.Close();
            //con.Close();
            //for (int i = 0; i < dataGridView13.Rows.Count; i++)
            //{
            //    if (dataGridView13.Rows[i].Cells[1].Value.ToString() == "negative")
            //    {
            //        dataGridView13.Rows[i].DefaultCellStyle.BackColor = Color.Red;
            //    }
            //}


            //}
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView fd = new DataView(finaldset.Tables[0]);
            fd.RowFilter = string.Format("catagoryName Like '%{0}%'", comboBox4.SelectedItem.ToString());
            dataGridView12.DataSource = fd;
            dataGridView13.DataSource = null;
            dataGridView14.DataSource = null;
        }
        DataTable conflictdt = new DataTable();
        private void LoadConflicteddecisionbutton_Click(object sender, EventArgs e)
        {
            dataGridView16.DataSource = null;
            List<string> qg = new List<string>();
            try
            {
                SqlCommand cmd = new SqlCommand("select QA_name from QualityGoal as q inner join QualityAttribute as qa on q.QA_id=qa.QA_id where Project_id='" + ss + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    qg.Add(dr["QA_name"].ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            ds.Clear();
            //dataGridView15.Rows.Clear();
            List<string> decision = new List<string>();
            for (int i = 0; i < qg.Count; i++)
            {
                try
                {
                    SqlCommand cmd2 = new SqlCommand("select Distinct DD_name from FinalDecision as f inner join DesignDecision as d on f.dd_id=d.DD_id inner join DecisionQAimpact as i on i.DD_id = d.DD_id inner join QualityAttribute as q on i.QA_id=q.QA_id where f.Project_id='" + ss + "' and i.Impact = 'negative' and q.QA_name='" + qg[i] + "' ", con);
                    con.Open();
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    while (dr2.Read())
                    {
                        if (!decision.Contains(dr2["DD_name"]))
                        {
                            decision.Add(dr2["DD_name"].ToString());
                        }
                    }
                    con.Close();
                    dr2.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }
            }


            //while (dr2.Read())
            //{
            //    int n = dataGridView4.Rows.Add();
            //    dataGridView15.Rows[n].Cells[0].Value = dr2["DD_name"];
            //    dataGridView15.Rows[n].Cells[1].Value = dr2["DD_des"];
            //   // Console.WriteLine(dr2["DD_name"]);
            //    dataGridView15.Rows[n].DefaultCellStyle.BackColor = Color.Red;
            //}
            conflictdt.Clear();
            if (decision.Count == 0)
            {
                MessageBox.Show("No conflicting final decisions with Quality Concern is Found");
            }
            else {
                foreach (string d in decision)
                {
                    try
                    {
                        SqlCommand cmd3 = new SqlCommand("select DD_name as 'Decision Name',DD_des as 'Description' from DesignDecision as f Where f.Project_id='" + ss + "' and f.DD_name='" + d + "' ", con);
                        con.Open();
                        cmd3.ExecuteReader();
                        SqlDataAdapter ad = new SqlDataAdapter();
                        ad.SelectCommand = cmd3;
                        con.Close();
                        ad.Fill(conflictdt);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        if (con != null)
                        {
                            con.Close();
                        }
                    }
                    if (conflictdt.Rows.Count > 0)
                    { dataGridView15.DataSource = conflictdt; }

                    //DataView dv = new DataView(ds.Tables[0]);


                    //Console.WriteLine(d.ToString());
                }
            }


        }

        private void LoadFDbutton_Click(object sender, EventArgs e)
        {
            ds.Clear();
            try
            {
                SqlCommand cmd8 = new SqlCommand("select DD_name,DD_des,catagoryName from FinalDecision as f inner join DesignDecision as d  on f.dd_id=d.DD_id inner join DCatagory as c on d.catagory_id=c.catagory_id where f.Project_id='" + ss + "'", con);
                con.Open();
                SqlDataReader dr8 = cmd8.ExecuteReader();
                SqlDataAdapter add = new SqlDataAdapter();
                add.SelectCommand = cmd8;
                con.Close();
                dr8.Close();
                add.Fill(ds);
                DataView dv = new DataView(ds.Tables[0]);
                dataGridView18.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void QGloadbutton_Click(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            panel4.Visible = false;
            panel5.Visible = true;
            panel4.BringToFront();
            try
            {
                SqlCommand cmd = new SqlCommand("select QA_name from QualityGoal as q inner join QualityAttribute as qa on q.QA_id=qa.QA_id where q.Project_id = '" + ss + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox6.Items.Add(dr["QA_name"]);
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void LoadReqbutton_Click(object sender, EventArgs e)
        {
            try
            {
                panel4.Visible = true;
                panel5.Visible = false;
                panel4.BringToFront();
                dataGridView17.Rows.Clear();
                SqlCommand cmd8 = new SqlCommand("select FR_name,FR_desc from FunctReq where Project_id = '" + ss + "'", con);
                con.Open();
                SqlDataReader dr = cmd8.ExecuteReader();
                BindingSource bs = new BindingSource();
                bs.DataSource = dr;
                dataGridView17.DataSource = bs;
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void decisionReqconfirmbutton_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = dataGridView18.RowCount - 1; i >= 0; i--)
                {
                    DataGridViewRow row = dataGridView18.Rows[i];
                    if (Convert.ToBoolean(row.Cells["Column2"].Value))
                    {
                        for (int j = dataGridView17.RowCount - 1; j >= 0; j--)
                        {
                            DataGridViewRow roww = dataGridView17.Rows[j];
                            if (Convert.ToBoolean(roww.Cells["ssc"].Value))
                            {
                                String idd = Convert.ToString(dataGridView18.Rows[i].Cells["DD_name"].Value.ToString());
                                String iddd = Convert.ToString(dataGridView17.Rows[j].Cells["FR_name"].Value.ToString());
                                SqlCommand cmd10 = new SqlCommand("insert into DC_Relation(FR_id,Dc_id,Project_id) select FR_id,Dc_id,dd.Project_id from FunctReq as dd inner join Project as p on dd.Project_id=p.Project_id inner join DConst as f on p.Project_id=f.Project_id where p.Project_id='" + ss + "' and f.Dc_name='" + iddd + "' and dd.FR_name='" + idd + "'", con);
                                con.Open();
                                cmd10.ExecuteReader();
                                con.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            MessageBox.Show("Relation successfull");
        }
        SqlDataAdapter addd;
        DataTable dtt = new DataTable();
        DataTable dtt_c = new DataTable();
        private void FRLoadbutton_Click(object sender, EventArgs e)
        {
            try
            {
                frOrDcorQG = 1;
                dtt_c.Rows.Clear();
                dtt_c.Columns.Clear();
                //this.dataGridView9.AutoSizeColumnsMode=DataGridViewAutoSizeColumnMode.Fill;
                //DAssistDesignConcernEntities fre = new DAssistDesignConcernEntities();           
                //this.dataGridView9.DataSource = fre.FunctReqs.Where(f => f.Project_id.Equals(ss)).ToList();

                SqlCommand cmd8 = new SqlCommand("select FunctReq.FR_id as 'ID',FunctReq.FR_name as 'Requirement Name',FunctReq.FR_desc as 'Description',concerncategory.concategory_name as Category from FunctReq,concerncategory  where FunctReq.concategory_id=concerncategory.cc_id AND FunctReq.Project_id='" + ss + "'", con);
                con.Open();
                SqlDataReader dr8 = cmd8.ExecuteReader();
                addd = new SqlDataAdapter();
                addd.SelectCommand = cmd8;
                con.Close();
                dr8.Close();
                addd.Fill(dtt_c);
                // DataView dv = new DataView(ds.Tables[0]);
                if (dtt_c.Rows.Count == 0)
                { MessageBox.Show("No Other Architectural Concners exists"); }
                else {
                    dataGridView9.DataSource = dtt_c;
                    //dt.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

        }

        private void DcLoadbutton_Click(object sender, EventArgs e)
        {
            try
            {
                frOrDcorQG = 2;
                dtt.Rows.Clear();
                dtt.Columns.Clear();
                //DAssistDesignConcernEntities fre = new DAssistDesignConcernEntities();
                //this.dataGridView9.DataSource = fre.DConsts.Where(f => f.Project_id.Equals(ss)).ToList();

                SqlCommand cmd8 = new SqlCommand("select Dc_id as 'ID',Dc_name as 'Constraints Name',Dc_des as 'Description' from DConst as f where f.Project_id='" + ss + "'", con);
                con.Open();
                SqlDataReader dr8 = cmd8.ExecuteReader();
                addd = new SqlDataAdapter();
                addd.SelectCommand = cmd8;
                con.Close();
                dr8.Close();
                addd.Fill(dtt);
                // DataView dv = new DataView(ds.Tables[0]);
                dataGridView9.DataSource = dtt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

        }
        SqlCommandBuilder scom;//update datatable with this

        int frOrDcorQG;
        private void dataGridView9_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (frOrDcorQG == 1)
                {
                    if (dataGridView9.Columns[e.ColumnIndex].Name == "DelConcern")
                    {
                        if (MessageBox.Show("Are you sure to delete the requirements", "Delete Requirements", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            String frr = Convert.ToString(dataGridView9.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                            SqlCommand cmd8 = new SqlCommand("delete from DC_Relation where Project_id='" + ss + "' and FR_id='" + Convert.ToInt32(frr) + "'", con);
                            con.Open();
                            SqlDataReader dr = cmd8.ExecuteReader();
                            dr.Close();
                            con.Close();
                            dataGridView9.Rows.RemoveAt(dataGridView9.CurrentCell.RowIndex);
                            SqlCommand cmd9 = new SqlCommand("delete from FunctReq where Project_id='" + ss + "' and FR_id='" + Convert.ToInt32(frr) + "'", con);
                            con.Open();
                            cmd9.ExecuteReader();
                            con.Close();

                            scom = new SqlCommandBuilder(addd);
                            addd.Update(dtt);

                        }

                    }
                    else if (dataGridView9.Columns[e.ColumnIndex].Name == "ViewRDetails")
                    {
                        int fid = Convert.ToInt32(dataGridView9.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                        String fname = Convert.ToString(dataGridView9.Rows[e.RowIndex].Cells["Requirement Name"].Value.ToString());
                        String fdes = Convert.ToString(dataGridView9.Rows[e.RowIndex].Cells["Description"].Value.ToString());
                        ViewDetails v = new ViewDetails(fname, fdes, ss, fid, 1);
                        v.ShowDialog();
                    }

                }
                else if (frOrDcorQG == 2)
                {
                    if (dataGridView9.Columns[e.ColumnIndex].Name == "DelConcern")
                    {
                        if (MessageBox.Show("Are you sure to delete the requirements", "Delete Requirements", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            String frr = Convert.ToString(dataGridView9.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                            SqlCommand cmd8 = new SqlCommand("delete from DC_Relation where Project_id='" + ss + "' and Dc_id='" + Convert.ToInt32(frr) + "'", con);
                            con.Open();
                            SqlDataReader dr = cmd8.ExecuteReader();
                            dr.Close();
                            con.Close();
                            dataGridView9.Rows.RemoveAt(dataGridView9.CurrentCell.RowIndex);
                            scom = new SqlCommandBuilder(addd);
                            addd.Update(dtt);
                        }

                    }
                    else if (dataGridView9.Columns[e.ColumnIndex].Name == "ViewRDetails")
                    {
                        int fid = Convert.ToInt32(dataGridView9.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                        String fname = Convert.ToString(dataGridView9.Rows[e.RowIndex].Cells["Constraints Name"].Value.ToString());
                        String fdes = Convert.ToString(dataGridView9.Rows[e.RowIndex].Cells["Description"].Value.ToString());
                        ViewDetails v = new ViewDetails(fname, fdes, ss, fid, 2);
                        v.ShowDialog();
                    }

                }
                else
                {
                    if (dataGridView9.Columns[e.ColumnIndex].Name == "DelConcern")
                    {
                        if (MessageBox.Show("Are you sure to delete the requirements", "Delete Requirements", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            String frr = Convert.ToString(dataGridView9.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                            SqlCommand cmd8 = new SqlCommand("delete from DC_Relation where Project_id='" + ss + "' and QG_id='" + Convert.ToInt32(frr) + "'", con);
                            con.Open();
                            SqlDataReader dr = cmd8.ExecuteReader();
                            dr.Close();
                            con.Close();
                            dataGridView9.Rows.RemoveAt(dataGridView9.CurrentCell.RowIndex);
                            SqlCommand cmd9 = new SqlCommand("delete from QualityGoal where Project_id='" + ss + "' and QG_id='" + Convert.ToInt32(frr) + "'", con);
                            con.Open();
                            cmd9.ExecuteReader();
                            con.Close();
                        }
                    }
                    else if (dataGridView9.Columns[e.ColumnIndex].Name == "ViewRDetails")
                    {
                        int fid = Convert.ToInt32(dataGridView9.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                        String fname = Convert.ToString(dataGridView9.Rows[e.RowIndex].Cells["Quality Goal Name"].Value.ToString());
                        String fdes = Convert.ToString(dataGridView9.Rows[e.RowIndex].Cells["Description"].Value.ToString());
                        ViewDetails v = new ViewDetails(fname, fdes, ss, fid, 3);
                        v.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void DCDeletebutton_Click(object sender, EventArgs e)
        {
            //dataGridView9.Rows.RemoveAt(dataGridView9.CurrentCell.RowIndex);
            //String idd = Convert.ToString(dataGridView9.Rows[e.RowIndex].Cells["DR_name"].Value.ToString());
        }

        private void DecisionEditordataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DecisionEditordataGridView.Columns[e.ColumnIndex].Name == "DelDecision")
                {
                    String frr = Convert.ToString(DecisionEditordataGridView.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    if (MessageBox.Show("Are you sure to approve this as design decision", "save decision", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            SqlCommand cmd8 = new SqlCommand("delete from DecisionQAimpact where DD_id='" + Convert.ToInt32(frr) + "'", con);
                            con.Open();
                            SqlDataReader dr = cmd8.ExecuteReader();
                            dr.Close();
                            con.Close();
                            SqlCommand cmd9 = new SqlCommand("delete from DecisionDecImpact where dd1_id='" + Convert.ToInt32(frr) + "' OR dd2_id='" + Convert.ToInt32(frr) + "'", con);
                            con.Open();
                            cmd9.ExecuteReader();
                            con.Close();
                            DecisionEditordataGridView.Rows.RemoveAt(DecisionEditordataGridView.CurrentCell.RowIndex);
                            scom = new SqlCommandBuilder(addd);
                            addd.Update(dtt);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            if (con != null)
                            {
                                con.Close();
                            }
                        }
                    }

                }
                else if (DecisionEditordataGridView.Columns[e.ColumnIndex].Name == "ViewDdetails")
                {
                    int id = Convert.ToInt32(DecisionEditordataGridView.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    String name = Convert.ToString(DecisionEditordataGridView.Rows[e.RowIndex].Cells["Decision Name"].Value.ToString());
                    String des = Convert.ToString(DecisionEditordataGridView.Rows[e.RowIndex].Cells["Description"].Value.ToString());
                    ViewDetails v = new ViewDetails(name, des, ss, id, 6);
                    v.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void CDlaodbutton_Click(object sender, EventArgs e)
        {
            try
            {
                dtt.Rows.Clear();
                dtt.Columns.Clear();
                SqlCommand cmd8 = new SqlCommand("select DD_id as 'ID',DD_name as 'Decision Name',DD_des as 'Description' from DesignDecision as f where f.Project_id='" + ss + "'", con);
                con.Open();
                SqlDataReader dr8 = cmd8.ExecuteReader();
                addd = new SqlDataAdapter();
                addd.SelectCommand = cmd8;
                con.Close();
                dr8.Close();
                addd.Fill(dtt);
                // DataView dv = new DataView(ds.Tables[0]);
                DecisionEditordataGridView.DataSource = dtt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void decisionUpdatebutton_Click(object sender, EventArgs e)
        {
            scom = new SqlCommandBuilder(addd);
            addd.Update(dtt);
        }

        private void dataGridView15_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView15.Columns[e.ColumnIndex].Name == "traceqg")
                {
                    con.Open();
                    String idd = Convert.ToString(dataGridView15.Rows[e.RowIndex].Cells["Decision Name"].Value.ToString());
                    SqlCommand cmd3 = new SqlCommand("select QA_name as 'Quality Goal', Impact from DesignDecision as dr inner join DecisionQAimpact as i on dr.DD_id = i.DD_id inner join QualityAttribute as qa on i.QA_id = qa.QA_id where DD_name='" + idd + "' and dr.Project_id='" + ss + "' and i.impact='negative'", con);
                    SqlDataReader dr3 = cmd3.ExecuteReader();
                    //while (dr3.Read())
                    //{
                    //    string s = Convert.ToString(dr3["Quality Goal"].ToString());
                    //    Console.WriteLine(s);
                    //}
                    BindingSource bs3 = new BindingSource();
                    bs3.DataSource = dr3;
                    dataGridView16.DataSource = bs3;
                    dr3.Close();
                    con.Close();
                    for (int i = 0; i < dataGridView16.Rows.Count; i++)
                    {
                        if (dataGridView16.Rows[i].Cells[1].Value.ToString() == "negative")
                        {
                            dataGridView16.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

        }

        private void ReqeditorQALoadbutton_Click(object sender, EventArgs e)
        {
            try
            {
                dtt_c.Rows.Clear();
                dtt_c.Columns.Clear();
                frOrDcorQG = 3;
                SqlCommand cmd = new SqlCommand("select QG_id as 'ID',QA_name as 'Quality Goal Name',QA_des as 'Description' from QualityGoal as q inner join QualityAttribute as qa on q.QA_id=qa.QA_id where q.Project_id = '" + ss + "'", con);
                con.Open();
                cmd.ExecuteReader();
                addd = new SqlDataAdapter();
                addd.SelectCommand = cmd;
                con.Close();
                addd.Fill(dtt_c);
                // DataView dv = new DataView(ds.Tables[0]);
                if (dtt_c.Rows.Count == 0)
                { MessageBox.Show("No Quality Concners exists"); }
                else {
                    dataGridView9.DataSource = dtt_c;
                    //dt.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        DataSet asr = new DataSet();
        private void SReqLoadbutton_Click(object sender, EventArgs e)
        {
            try
            {
                asr.Clear();
                SqlCommand cmd = new SqlCommand("select FR_name as 'Requirement Name',FR_desc as 'Description' from FunctReq where Project_id = '" + ss + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                //BindingSource bs = new BindingSource();
                //bs.DataSource = dr;
                addd = new SqlDataAdapter();
                addd.SelectCommand = cmd;
                con.Close();
                dr.Close();
                addd.Fill(asr);
                DataView asrview = new DataView(asr.Tables[0]);
                if (asrview.Count == 0)
                { MessageBox.Show("No Other Architectural Concners exists"); }
                else
                {
                    dataGridView1.DataSource = asrview;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        DataSet cons = new DataSet();
        private void ConstraintsLoadbutton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select Dc_name as 'Constraints Name',Dc_des as 'Description' from DConst where Project_id = '" + ss + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                // BindingSource bs = new BindingSource();
                //bs.DataSource = dr;
                addd = new SqlDataAdapter();
                addd.SelectCommand = cmd;
                con.Close();
                dr.Close();
                addd.Fill(cons);
                DataView consview = new DataView(cons.Tables[0]);
                dataGridView2.DataSource = consview;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //RelateDecisions r = new RelateDecisions(ss);
            //r.Show();
        }
        DataTable dtracedt = new DataTable();
        private void LoadDtoDbutton_Click(object sender, EventArgs e)
        {
            try
            {
                dtracedt.Rows.Clear();
                dtracedt.Columns.Clear();
                SqlCommand cmd = new SqlCommand("select di.impact as 'Impact',d.DD_name as 'Decision Name',dd.DD_name as 'Conflicting Decision' from DecisionDecImpact as di inner join DesignDecision as d on di.dd1_id = d.DD_id inner join DesignDecision as dd on dd.DD_id = di.dd2_id inner join FinalDecision as f on f.dd_id = d.DD_id inner join FinalDecision as ff on ff.dd_id=dd.DD_id where f.project_id ='" + ss + "' and di.impact = 'negative' and di.project_id='" + ss + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                SqlDataAdapter da = new SqlDataAdapter();
                dr.Close();
                da.SelectCommand = cmd;
                da.Fill(dtracedt);
                if (dtracedt.Rows.Count == 0)
                {
                    MessageBox.Show("no conflict found among final decisions");
                }
                else {
                    dataGridView20.DataSource = dtracedt;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

            for (int i = 0; i < dataGridView20.Rows.Count; i++)
            {
                if (dataGridView20.Rows[i].Cells[0].Value.ToString() == "negative")
                {
                    dataGridView20.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }

            }
        }

        private void dataGridView20_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView20.Columns[e.ColumnIndex].Name == "DD_name")
            {

                String name = Convert.ToString(dataGridView20.Rows[e.RowIndex].Cells["DD_name"].Value.ToString());

                ViewDetails v = new ViewDetails(name, "a", ss, 0, 8);
                v.ShowDialog();
            }
            else if (dataGridView20.Columns[e.ColumnIndex].Name == "DD_name1")
            {
                String name = Convert.ToString(dataGridView20.Rows[e.RowIndex].Cells["DD_name1"].Value.ToString());

                ViewDetails v = new ViewDetails(name, "a", ss, 0, 8);
                v.ShowDialog();
            }
        }
        DataTable decisiondt = new DataTable();
        DataTable decisiondt1 = new DataTable();
        DataSet dedt = new DataSet();
        DataSet dedt1 = new DataSet();
        private void loadDRbutton_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            dedt.Clear();
            dedt1.Clear();
            decisiondt.Rows.Clear();
            decisiondt.Columns.Clear();
            decisiondt1.Rows.Clear();
            decisiondt1.Columns.Clear();



            try
            {
                SqlCommand cmd8 = new SqlCommand("select DD_name as 'Decision Name',catagoryName from DesignDecision as d inner join DCatagory as c on d.catagory_id=c.catagory_id where d.Project_id='" + ss + "'", con);
                con.Open();
                SqlDataReader dr8 = cmd8.ExecuteReader();
                while (dr8.Read())
                {
                    if (!comboBox7.Items.Contains(dr8["catagoryName"]))
                    {
                        comboBox7.Items.Add(dr8["catagoryName"]);
                    }
                    if (!comboBox8.Items.Contains(dr8["catagoryName"]))
                    {
                        comboBox8.Items.Add(dr8["catagoryName"]);
                    }
                }
                SqlDataAdapter addd = new SqlDataAdapter();
                addd.SelectCommand = cmd8;
                //BindingSource bs = new BindingSource();
                //bs.DataSource = dr8;
                //dataGridView18.DataSource = bs;

                con.Close();
                dr8.Close();
                addd.Fill(dedt);
                addd.Fill(dedt1);
                DataView dedtview = new DataView(dedt.Tables[0]);
                DataView dedt1view = new DataView(dedt1.Tables[0]);
                dataGridView19.DataSource = dedtview;
                dataGridView23.DataSource = dedt1view;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dedt.Tables[0]);
            dv.RowFilter = string.Format("catagoryName Like '%{0}%'", comboBox7.SelectedItem.ToString());
            dataGridView19.DataSource = dv;
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dedt1.Tables[0]);
            dv.RowFilter = string.Format("catagoryName Like '%{0}%'", comboBox8.SelectedItem.ToString());
            dataGridView23.DataSource = dv;
        }
        int count = 0, cnt = 0;
        private void DtoDrelationbutton_Click(object sender, EventArgs e)
        {
            if (newOrOld)
            {
                int dr11 = 0, dr22 = 0;
                for (int i = dataGridView23.RowCount - 1; i >= 0; i--)
                {
                    DataGridViewRow row = dataGridView23.Rows[i];
                    if (Convert.ToBoolean(row.Cells["dg18select"].Value))
                    {
                        for (int j = dataGridView19.RowCount - 1; j >= 0; j--)
                        {
                            DataGridViewRow roww = dataGridView19.Rows[j];
                            if (Convert.ToBoolean(roww.Cells["dg1select"].Value))
                            {
                                String idd = Convert.ToString(dataGridView23.Rows[i].Cells["Decision Name"].Value.ToString());
                                String iddd = Convert.ToString(dataGridView19.Rows[j].Cells["Decision Name"].Value.ToString());
                                //SqlCommand cmd10 = new SqlCommand("insert into DecisionDecImpact(dr1_id,dr2_id,impact) select dd.DR_id,dr.DR_id,'"+impact[7]+"' from DecisionRepo as dd inner join DecisionDecImpact di on dd.DR_id=di.dr1_id inner join DecisionRepo as dr on dr.DR_id=di.dr2_id  where  dd.DR_name='" + iddd + "' and dr.DR_name='" + idd + "'", con);
                                try
                                {
                                    SqlCommand cmd10 = new SqlCommand("select DD_id from DesignDecision where DD_name='" + idd + "' and Project_id='" + ss + "'", con);
                                    con.Open();
                                    SqlDataReader dr = cmd10.ExecuteReader();
                                    while (dr.Read())
                                    {
                                        dr11 = Convert.ToInt32(dr["DD_id"]);
                                    }
                                    con.Close();
                                    dr.Close();
                                    SqlCommand cmd11 = new SqlCommand("select DD_id from DesignDecision where DD_name='" + iddd + "' and Project_id='" + ss + "'", con);
                                    con.Open();
                                    SqlDataReader dr3 = cmd11.ExecuteReader();
                                    while (dr3.Read())
                                    {
                                        dr22 = Convert.ToInt32(dr3["DD_id"]);
                                    }
                                    con.Close();
                                    dr3.Close();

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                finally
                                {
                                    if (con != null)
                                    {
                                        con.Close();
                                    }
                                }
                                //checking duplicate insertion

                                List<string> check = new List<string>();
                                try
                                {
                                    con.Open();
                                    SqlCommand cmd2 = new SqlCommand("select dd1_id from DecisionDecImpact as d where d.dd1_id='" + dr11 + "' and d.dd2_id='" + dr22 + "' and d.project_id='" + ss + "'", con);
                                    SqlDataReader dr2 = cmd2.ExecuteReader();
                                    while (dr2.Read())
                                    {
                                        //Console.WriteLine(dr2["DD_name"].ToString());
                                        check.Add(dr2["dd1_id"].ToString());
                                    }
                                    con.Close();
                                    dr2.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                finally
                                {
                                    if (con != null)
                                    {
                                        con.Close();
                                    }
                                }
                                if (check.Count > 0)
                                {
                                    cnt += 1;
                                    count = count - 1;
                                }
                                else
                                {
                                    if (radioButton13.Checked || radioButton14.Checked || radioButton15.Checked)
                                    {
                                        SqlCommand cmd12 = new SqlCommand("insert into DecisionDecImpact(dd1_id,dd2_id,impact,project_id) select '" + dr11 + "','" + dr22 + "','" + impact[7] + "','" + ss + "'", con);
                                        con.Open();
                                        cmd12.ExecuteReader();
                                        con.Close();
                                        count += 1;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Quality Relationship Impact Unselected.");
                                    }

                                }
                            }
                        }
                    }
                }
                if (count > 0)
                {
                    MessageBox.Show("Impact successfuly added");
                }
                if (cnt > 0)
                { MessageBox.Show("Impact Already Exist"); }
                foreach (DataGridViewRow item in dataGridView19.Rows)
                {
                    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)item.Cells[0];

                    cell.Value = false;
                }
                foreach (DataGridViewRow item in dataGridView23.Rows)
                {
                    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)item.Cells[0];

                    cell.Value = false;
                }

            }
            else
            {
                int dr1 = 0, dr2 = 0, dd1 = 0, dd2 = 0;
                for (int i = dataGridView23.RowCount - 1; i >= 0; i--)
                {
                    DataGridViewRow row = dataGridView23.Rows[i];
                    if (Convert.ToBoolean(row.Cells["dg18select"].Value))
                    {
                        for (int j = dataGridView19.RowCount - 1; j >= 0; j--)
                        {
                            DataGridViewRow roww = dataGridView19.Rows[j];
                            if (Convert.ToBoolean(roww.Cells["dg1select"].Value))
                            {
                                String idd = Convert.ToString(dataGridView23.Rows[i].Cells["Decision Name"].Value.ToString());
                                String iddd = Convert.ToString(dataGridView19.Rows[j].Cells["Decision Name"].Value.ToString());
                                //SqlCommand cmd10 = new SqlCommand("insert into DecisionDecImpact(dr1_id,dr2_id,impact) select dd.DR_id,dr.DR_id,'"+impact[7]+"' from DecisionRepo as dd inner join DecisionDecImpact di on dd.DR_id=di.dr1_id inner join DecisionRepo as dr on dr.DR_id=di.dr2_id  where  dd.DR_name='" + iddd + "' and dr.DR_name='" + idd + "'", con);
                                //Console.WriteLine(iddd.ToString());
                                try
                                {
                                    SqlCommand cmd10 = new SqlCommand("select DD_id from DesignDecision where DD_name='" + idd + "' and Project_id='" + ss + "'", con);
                                    con.Open();
                                    SqlDataReader dr = cmd10.ExecuteReader();
                                    while (dr.Read())
                                    {
                                        dd1 = Convert.ToInt32(dr["DD_id"]);
                                        //Console.WriteLine("1st dd" + dd1.ToString());
                                    }
                                    con.Close();
                                    dr.Close();

                                    SqlCommand cmd11 = new SqlCommand("select DR_id from DecisionRepo where DR_name='" + idd + "'", con);
                                    con.Open();
                                    SqlDataReader dr3 = cmd11.ExecuteReader();
                                    while (dr3.Read())
                                    {
                                        dr1 = Convert.ToInt32(dr3["DR_id"]);
                                        Console.WriteLine("1st dr" + dr1.ToString());
                                    }
                                    con.Close();
                                    dr3.Close();

                                    SqlCommand cmd12 = new SqlCommand("select DD_id from DesignDecision where DD_name='" + iddd + "' and Project_id='" + ss + "'", con);
                                    con.Open();
                                    SqlDataReader dr4 = cmd12.ExecuteReader();
                                    while (dr4.Read())
                                    {
                                        dd2 = Convert.ToInt32(dr4["DD_id"]);

                                        Console.WriteLine("second dd" + dd2.ToString());
                                    }
                                    con.Close();
                                    dr4.Close();

                                    SqlCommand cmd14 = new SqlCommand("select DR_id from DecisionRepo where DR_name='" + iddd + "'", con);
                                    con.Open();
                                    SqlDataReader dr5 = cmd14.ExecuteReader();
                                    while (dr5.Read())
                                    {
                                        dr2 = Convert.ToInt32(dr5["DR_id"]);
                                        Console.WriteLine("second dr" + dr2.ToString());
                                    }
                                    con.Close();
                                    dr5.Close();


                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                finally
                                {
                                    if (con != null)
                                    {
                                        con.Close();
                                    }
                                }
                                List<string> check = new List<string>();
                                try
                                {
                                    con.Open();
                                    SqlCommand cmd21 = new SqlCommand("select dd1_id from DecisionDecImpact as d where d.dd1_id='" + dd1 + "' and d.dd2_id='" + dd2 + "'", con);
                                    SqlDataReader dr21 = cmd21.ExecuteReader();
                                    while (dr21.Read())
                                    {
                                        //Console.WriteLine(dr2["DD_name"].ToString());
                                        check.Add(dr21["dd1_id"].ToString());
                                    }
                                    con.Close();
                                    dr21.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                finally
                                {
                                    if (con != null)
                                    {
                                        con.Close();
                                    }
                                }
                                if (check.Count > 0)
                                {
                                    cnt += 1;
                                    count -= 1;
                                }
                                else
                                {
                                    try
                                    {
                                        SqlCommand cmd13 = new SqlCommand("insert into DecisionDecImpact(impact,dd1_id,dd2_id,project_id) select i.impact,'" + dd1 + "','" + dd2 + "','" + ss + "' from DecisionDecImpact as i where dr1_id='" + dr1 + "' and dr2_id='" + dr2 + "'", con);
                                        con.Open();
                                        cmd13.ExecuteReader();
                                        con.Close();
                                        count += 1;
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                    finally
                                    {
                                        if (con != null)
                                        {
                                            con.Close();
                                        }
                                    }
                                }


                            }
                        }
                    }
                }
                if (count > 0)
                {
                    MessageBox.Show("Impact successfuly added");
                }
                if (cnt > 0)
                { MessageBox.Show("Impact Already Exist"); }
                foreach (DataGridViewRow item in dataGridView19.Rows)
                {
                    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)item.Cells[0];

                    cell.Value = false;
                }
                foreach (DataGridViewRow item in dataGridView23.Rows)
                {
                    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)item.Cells[0];

                    cell.Value = false;
                }

            }

        }

        private void QGlbutton_Click(object sender, EventArgs e)
        {
            try
            {
                dtt.Rows.Clear();
                dtt.Columns.Clear();
                //frOrDcorQG = 3;
                SqlCommand cmd = new SqlCommand("select QA_name as 'Name',QA_des as 'Description' from QualityGoal as q inner join QualityAttribute as qa on q.QA_id=qa.QA_id where q.Project_id = '" + ss + "'", con);
                con.Open();
                cmd.ExecuteReader();
                addd = new SqlDataAdapter();
                addd.SelectCommand = cmd;
                con.Close();
                addd.Fill(dtt);
                // DataView dv = new DataView(ds.Tables[0]);
                if (dtt.Rows.Count == 0)
                { MessageBox.Show("No Quality Concern Exist"); }
                else {
                    dataGridView21.DataSource = dtt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void tabControl2_Selected(object sender, TabControlEventArgs e)
        {
            Donebutton.Enabled = false;
            CatagoryButton.Visible = false;
            label8.Visible = false;
            label7.Visible = false;
            label4.Visible = false;
            label9.Visible = false;
            label63.Visible = false;
            comboBox9.Visible = false;
            FRAddbutton.Visible = false;
            frxmlbutton.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            Dcmanualbutton.Visible = false;
            Dcxmlbutton.Visible = false;
            DcLoadbutton.Visible = false;
        }

        private void ManualFRbutton_Click(object sender, EventArgs e)
        {
            label8.Visible = false;
            label7.Visible = true;
            label4.Visible = true;
            label9.Visible = true;
            FRAddbutton.Visible = true;
            frxmlbutton.Visible = false;
            textBox1.Visible = true;
            textBox2.Visible = true;
            label63.Visible = true;
            comboBox9.Visible = true;
        }

        private void XMLfrbutton_Click(object sender, EventArgs e)
        {
            label8.Visible = true;
            label7.Visible = false;
            label4.Visible = false;
            label9.Visible = false;
            FRAddbutton.Visible = false;
            frxmlbutton.Visible = true;
            textBox1.Visible = false;
            textBox2.Visible = false;
            label63.Visible = false;
            comboBox9.Visible = false;
        }

        private void Manualconstraintsbutton_Click(object sender, EventArgs e)
        {
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = false;
            label15.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            Dcmanualbutton.Visible = true;
            Dcxmlbutton.Visible = false;
        }

        private void XMLconstraintsbutton_Click(object sender, EventArgs e)
        {
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = true;
            label15.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            Dcmanualbutton.Visible = false;
            Dcxmlbutton.Visible = true;
        }

        private void tabControl3_Selected(object sender, TabControlEventArgs e)
        {
            button2.Visible = false;
            groupBox7.Visible = false;
            label51.Visible = false;
            label52.Visible = false;
            label53.Visible = false;
            comboBox7.Visible = false;
            comboBox8.Visible = false;
            dataGridView23.Visible = false;
            dataGridView19.Visible = false;
            DtoDrelationbutton.Visible = false;
            loadDRbutton.Visible = false;
            label50.Visible = false;
            pictureBox2.Visible = true;

        }
        bool newOrOld = false;
        private void Newdecisionrelationbutton_Click(object sender, EventArgs e)
        {

            newOrOld = true;
            groupBox7.Visible = true;
            label50.Visible = true;
            label51.Visible = true;
            label52.Visible = true;
            label53.Visible = true;
            comboBox7.Visible = true;
            comboBox8.Visible = true;
            dataGridView23.Visible = true;
            dataGridView19.Visible = true;
            dataGridView23.DataSource = null;
            dataGridView19.DataSource = null;
            button2.Visible = false;
            DtoDrelationbutton.Visible = true;
            loadDRbutton.Visible = true;
        }

        private void Getdecisionimpactbutton_Click(object sender, EventArgs e)
        {
            //button2.Visible = true;
            newOrOld = false;
            groupBox7.Visible = false;
            label50.Visible = true;
            label51.Visible = true;
            label52.Visible = true;
            label53.Visible = true;
            comboBox7.Visible = true;
            comboBox8.Visible = true;
            dataGridView23.Visible = true;
            dataGridView19.Visible = true;
            dataGridView23.DataSource = null;
            dataGridView19.DataSource = null;
            button2.Visible = false;
            DtoDrelationbutton.Visible = true;
            loadDRbutton.Visible = true;
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            impact[7] = "positive";
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            impact[7] = "negative";
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            impact[7] = "neutral";
        }

        private void FinalDecisionTab_Selected(object sender, TabControlEventArgs e)
        {
            //label45.Visible = false;
            button3.Visible = false;
            button1.Visible = false;
            // label44.Visible = false;
            decisionUpdatebutton.Visible = false;
            label42.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            uploadartifactbutton.Visible = false;
            pictureBox2.Visible = false;


        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void Checkqualitybutton_Click(object sender, EventArgs e)
        {
            string impact = "a";
            int count = 0;
            List<string> finalqa = new List<string>();
            List<string> conflict = new List<string>();


            //foreach (ListViewItem item in listView2.Items)
            //{
            //    check.Add(item.Text);
            //}
            //int c = check.Count-1;
            //for (int i = check.Count; i > 0; i--)
            //{
            //    if (q.Count == 0)
            //    {
            //        q.Add(check[i - c]);
            //        Console.WriteLine(check[i - c].ToString());
            //    }
            //    else
            //    {
            //        SqlCommand cmd = new SqlCommand("select impact from QAQArelation where QA_1='" + check[i] + "' and QA_2='" + q[i] + "'", con);
            //        con.Open();
            //        SqlDataReader dr = cmd.ExecuteReader();
            //        while (dr.Read())
            //        {
            //            impact = Convert.ToString(dr["impact"]);
            //        }
            //        dr.Close();
            //        con.Close();
            //        if (impact != "negative")
            //        {

            //        }

            //    }
            //}
            foreach (ListViewItem item in listView2.Items)
            {
                count = 0;
                Console.WriteLine(item.ToString());
                if (finalqa.Count == 0)
                {
                    finalqa.Add(item.Text);
                }
                else
                {

                    for (int i = 0; i < finalqa.Count; i++)
                    {
                        try
                        {
                            SqlCommand cmd = new SqlCommand("select impact from QAQArelation where QA_1='" + finalqa[i] + "' and QA_2='" + item.Text + "'", con);
                            con.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                impact = Convert.ToString(dr["impact"]);
                                Console.WriteLine(finalqa[i] + " " + impact);
                            }
                            dr.Close();
                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            if (con != null)
                            {
                                con.Close();
                            }
                        }
                        if (impact != "negative")
                        {
                            count += 1;
                        }

                    }
                    if (count == finalqa.Count)
                    {
                        if (!finalqa.Contains(item.Text))
                        {
                            finalqa.Add(item.Text);
                        }
                    }
                    else
                    {
                        if (!conflict.Contains(item.Text))
                        {
                            conflict.Add(item.Text);
                        }
                    }

                }
            }
            listView2.Items.Clear();
            q.Clear();
            foreach (string s in finalqa)
            {
                listView2.Items.Add(s);

                q.Add(s);

                // Console.WriteLine(s.ToString());
            }

            int conf = conflict.Count;
            if (conf == 1)
            {
                MessageBox.Show("conflicting quality " + conflict[0]);

            }
            else if (conf == 2)
            {
                MessageBox.Show("conflicting quality Attributes  " + conflict[0] + "  " + conflict[1]);
            }
            else if (conf == 3)
            {
                MessageBox.Show("conflicting quality Attributes  " + conflict[0] + "  " + conflict[1] + "  " + conflict[2]);
            }
            else if (conf == 4)
            {
                MessageBox.Show("conflicting quality Attributes  " + conflict[0] + "  " + conflict[1] + "  " + conflict[2] + "  " + conflict[3]);
            }
            else if (conf == 5)
            {
                MessageBox.Show("conflicting quality Attributes  " + conflict[0] + "  " + conflict[1] + "  " + conflict[2] + "  " + conflict[3] + "  " + conflict[4]);
            }
            else
                MessageBox.Show("No conflict found among the selected Quality Attributes");

            if(listView2.Items.Count!=0)
            { Donebutton.Enabled = true; }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Check All")
            {
                foreach (DataGridViewRow item in dataGridView23.Rows)
                {
                    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)item.Cells[0];

                    cell.Value = true;
                }

                foreach (DataGridViewRow item in dataGridView19.Rows)
                {
                    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)item.Cells[0];

                    cell.Value = true;
                }
                button2.Text = "Uncheck All";
            }
            else {
                foreach (DataGridViewRow item in dataGridView23.Rows)
                {
                    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)item.Cells[0];

                    cell.Value = false;
                }

                foreach (DataGridViewRow item in dataGridView19.Rows)
                {
                    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)item.Cells[0];

                    cell.Value = false;
                }
                button2.Text = "Check All";
            }


            /*         foreach (Control c in dataGridView23.Controls)
         {
             if (c is CheckBox)
             {
                 CheckBox cb = (CheckBox)c;
                 if (cb.Checked == false)
                 {
                     cb.Checked = true;
                 }
                 else {

                     cb.Checked = false;
                 }
             }

         }*/
        }

        private void getReportbutton_Click(object sender, EventArgs e)
        {

            try
            {
                this.ProjectTableAdapter.Fill(this.DataSetReport.Project, ss);
                this.QualityAttributeTableAdapter.Fill(this.DataSetReport.QualityAttribute, ss);
                this.FunctReqTableAdapter.Fill(this.DataSetReport.FunctReq, ss);
                this.DataTable2TableAdapter.Fill(this.DataSetReport.DataTable2, ss);
                this.DataTable1TableAdapter.Fill(this.DataSetReport.DataTable1, ss);
                this.DataTable3TableAdapter.Fill(this.DataSetReport.DataTable3, ss);



                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void comboBox9_DropDown(object sender, EventArgs e)
        {
            try
            {
                comboBox9.Items.Clear();
                SqlCommand cmd = new SqlCommand("select concategory_name from concerncategory", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox9.Items.Add(dr["concategory_name"]);
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel7.Enabled = true;
            dataGridView24.Enabled = false;

            dataGridView24.DefaultCellStyle.BackColor = SystemColors.Control;
            dataGridView24.DefaultCellStyle.ForeColor = SystemColors.GrayText;
            dataGridView24.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.GrayText;
            dataGridView24.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
            dataGridView24.EnableHeadersVisualStyles = false;
            dataGridView24.GridColor = SystemColors.GrayText;
            reusableDecisionToolStripMenuItem.Enabled = false;

            //s = new StartPJ ();
            //s.Show();

        }

        private void reusableDecisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ReusableDecision r = new ReusableDecision();
            //r.MdiParent = this;
            ReusableDecision r = ReusableDecision.GetInstance();
            if (!r.Visible)
            {
                r.ShowDialog();
            }
            else
            {
                r.BringToFront();
            }
            //  r.Show();
            // r.BringToFront();
        }

        private void dataGridView24_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dataGridView24.Columns[e.ColumnIndex].Name == "ResumePJ")
                {
                    String iddd = Convert.ToString(dataGridView24.Rows[e.RowIndex].Cells["P_name"].Value.ToString());
                    Console.WriteLine(iddd);
                    //  Form2 f2 = new Form2(iddd);
                    // ProjectFrom pf = new ProjectFrom(iddd);
                    //Visible = false;
                    //pf.Show();

                    SqlCommand cmd = new SqlCommand("select Project_id from Project as p where p.Project_name ='" + iddd + "'", con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ss = Convert.ToInt32(dr["Project_id"]);
                    }
                    Console.WriteLine(ss);
                    dr.Close();
                    con.Close();
                    panel8.Enabled = false;
                    dataGridView24.Enabled = false;
                    panel7.Enabled = false;
                    FinalDecisionTab.Enabled = true;
                    newProjectToolStripMenuItem.Enabled = false;
                    reusableDecisionToolStripMenuItem.Enabled = false;

                    dataGridView24.DefaultCellStyle.BackColor = SystemColors.Control;
                    dataGridView24.DefaultCellStyle.ForeColor = SystemColors.GrayText;
                    dataGridView24.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.GrayText;
                    dataGridView24.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
                    dataGridView24.EnableHeadersVisualStyles = false;
                    dataGridView24.GridColor = SystemColors.GrayText;
                    MessageBox.Show("Welcome Back. Project Title: "+iddd);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox9.Text != "")
            {
                try
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("insert into Project(Project_name,Project_des) values ('" + textBox9.Text + "','" + textBox8.Text + "')", con);
                    cmd1.ExecuteReader();
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }// ProjectFrom pf = new ProjectFrom();
                //this.Visible = false;
                // Form1 f1 = new Form1();
                // f1.Visible = false;
                // pf.Show();


                //int project_count = 0;
                try
                {
                    SqlCommand cmd = new SqlCommand("select Project_id from Project where Project_name='" + textBox9.Text + "'", con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {

                        ss = Convert.ToInt32(dr["Project_id"]);
                    }
                    dr.Close();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }
                //Form2 f2 = new Form2(textBox1.Text);
                //f2.Show();
                Console.WriteLine("project id" + ss);
                MessageBox.Show("Welcome. Project Title: "+textBox9.Text);
                textBox9.Clear();
                textBox8.Clear();
                panel8.Enabled = false;
                dataGridView24.Enabled = false;
                panel7.Enabled = false;
                FinalDecisionTab.Enabled = true;
                Newdecisionrelationbutton.Enabled = false;
                reusableDecisionToolStripMenuItem.Enabled = false;
            }
            else
            {
                MessageBox.Show("Enter a Project Name");
            }
        }

        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox8.Clear();
            textBox9.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();
            comboBox7.Items.Clear();
            comboBox8.Items.Clear();
            comboBox9.Items.Clear();
           
            listBox2.Items.Clear();
            listView2.Items.Clear();
            panel7.Enabled = false;
            panel8.Enabled = true;
            dataGridView24.Enabled = true;
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            dataGridView3.DataSource = null;
            dataGridView4.DataSource = null;
            dataGridView5.DataSource = null;
            dataGridView6.DataSource = null;
            dataGridView7.DataSource = null;
            dataGridView8.DataSource = null;
            dataGridView9.DataSource = null;
            dataGridView10.DataSource = null;
            dataGridView11.DataSource = null;
            dataGridView12.DataSource = null;
            dataGridView13.DataSource = null;
            dataGridView14.DataSource = null;
            dataGridView15.DataSource = null;
            dataGridView16.DataSource = null;
            dataGridView17.DataSource = null;
            dataGridView18.DataSource = null;
            dataGridView19.DataSource = null;
            dataGridView20.DataSource = null;
            dataGridView21.DataSource = null;
            dataGridView22.DataSource = null;
            dataGridView23.DataSource = null;
            dataGridView24.DataSource = null;
            DecisionEditordataGridView.DataSource = null;
            reusableDecisionToolStripMenuItem.Enabled = true;
            newProjectToolStripMenuItem.Enabled = true;
            checkedListBox1.Items.Clear();
            FinalDecisionTab.Enabled = false;
            dataGridView24.DataSource = null;
            dataGridView24.DefaultCellStyle.BackColor = SystemColors.Window;
            dataGridView24.DefaultCellStyle.ForeColor = SystemColors.ControlText;
           dataGridView24.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.WindowText;
            dataGridView24.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
            dataGridView24.GridColor = SystemColors.ActiveCaption;
            dataGridView24.EnableHeadersVisualStyles = true;

            try
            {
                dataGridView24.Rows.Clear();
                SqlCommand cmd = new SqlCommand("select Project_name,Project_des from Project", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int n = dataGridView24.Rows.Add();
                    dataGridView24.Rows[n].Cells[1].Value = dr["Project_name"];
                    dataGridView24.Rows[n].Cells[2].Value = dr["Project_des"];
                }

                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }


        }

        private void Clearbutton_Click(object sender, EventArgs e)
        {
            finaldecisiondt.Clear();
        }

        private void DcConfirmRelation_Click(object sender, EventArgs e)
        {
            if (fr)
            {

                for (int i = dataGridView4.RowCount - 1; i >= 0; i--)
                {
                    DataGridViewRow row = dataGridView4.Rows[i];
                    if (Convert.ToBoolean(row.Cells["Column2"].Value))
                    {
                        for (int j = dataGridView3.RowCount - 1; j >= 0; j--)
                        {
                            DataGridViewRow roww = dataGridView3.Rows[j];
                            if (Convert.ToBoolean(roww.Cells["sc"].Value))
                            {
                                String idd = Convert.ToString(dataGridView4.Rows[i].Cells["Requirement Name"].Value.ToString());
                                String iddd = Convert.ToString(dataGridView3.Rows[j].Cells["Constraints Name"].Value.ToString());

                                //chekck duplicacy
                                List<string> check = new List<string>();
                                try
                                {
                                    con.Open();
                                    SqlCommand cmd2 = new SqlCommand("select d.FR_id as fr from DC_Relation as d inner join FunctReq as f on d.FR_id=f.FR_id inner join DConst as c on d.Dc_id=c.Dc_id where f.FR_name='" + idd + "' and c.Dc_name='" + iddd + "' and d.Project_id='" + ss + "'", con);
                                    SqlDataReader dr2 = cmd2.ExecuteReader();
                                    while (dr2.Read())
                                    {
                                        //Console.WriteLine(dr2["DD_name"].ToString());
                                        check.Add(dr2["fr"].ToString());
                                    }
                                    con.Close();
                                    dr2.Close();

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                finally
                                {
                                    if (con != null)
                                    {
                                        con.Close();
                                    }
                                }
                                if (check.Count > 0)
                                {
                                    MessageBox.Show("Impact Already Exist");
                                }
                                else
                                {
                                    try
                                    {
                                        SqlCommand cmd10 = new SqlCommand("insert into DC_Relation(FR_id,Dc_id,Project_id) select FR_id,Dc_id,dd.Project_id from FunctReq as dd inner join Project as p on dd.Project_id=p.Project_id inner join DConst as f on p.Project_id=f.Project_id where p.Project_id='" + ss + "' and f.Dc_name='" + iddd + "' and dd.FR_name='" + idd + "'", con);
                                        con.Open();
                                        cmd10.ExecuteReader();
                                        con.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                    finally
                                    {
                                        if (con != null)
                                        {
                                            con.Close();
                                        }
                                    }
                                    MessageBox.Show("Relation successfull");
                                }


                            }
                        }
                    }

                }

            }
            else if (qg)
            {
                for (int i = dataGridView4.RowCount - 1; i >= 0; i--)
                {
                    DataGridViewRow row = dataGridView4.Rows[i];
                    if (Convert.ToBoolean(row.Cells["Column2"].Value))
                    {
                        for (int j = dataGridView3.RowCount - 1; j >= 0; j--)
                        {
                            DataGridViewRow roww = dataGridView3.Rows[j];
                            if (Convert.ToBoolean(roww.Cells["sc"].Value))
                            {
                                String idd = Convert.ToString(dataGridView4.Rows[i].Cells["QG Name"].Value.ToString());
                                String iddd = Convert.ToString(dataGridView3.Rows[j].Cells["Constraints Name"].Value.ToString());

                                List<string> check = new List<string>();
                                try
                                {
                                    con.Open();
                                    SqlCommand cmd2 = new SqlCommand("select d.QG_id as fr from DC_Relation as d inner join QualityGoal as f on d.QG_id=f.QG_id inner join QualityAttribute as qa on f.QA_id=qa.QA_id inner join DConst as c on d.Dc_id=c.Dc_id where qa.QA_name='" + idd + "' and c.Dc_name='" + iddd + "' and d.Project_id='" + ss + "'", con);
                                    SqlDataReader dr2 = cmd2.ExecuteReader();
                                    while (dr2.Read())
                                    {
                                        //Console.WriteLine(dr2["DD_name"].ToString());
                                        check.Add(dr2["fr"].ToString());
                                    }
                                    con.Close();
                                    dr2.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                finally
                                {
                                    if (con != null)
                                    {
                                        con.Close();
                                    }
                                }
                                if (check.Count > 0)
                                {
                                    MessageBox.Show("Impact Already Exist");
                                }
                                else {
                                    try
                                    {
                                        SqlCommand cmd10 = new SqlCommand("insert into DC_Relation(QG_id,Dc_id,Project_id) select QG_id,Dc_id,dd.Project_id from QualityGoal as dd inner join Project as p on dd.Project_id=p.Project_id inner join QualityAttribute as q on dd.QA_id=q.QA_id inner join DConst as f on p.Project_id=f.Project_id where p.Project_id='" + ss + "' and f.Dc_name='" + iddd + "' and q.QA_name='" + idd + "'", con);
                                        con.Open();
                                        cmd10.ExecuteReader();
                                        con.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                    finally
                                    {
                                        if (con != null)
                                        {
                                            con.Close();
                                        }
                                    }
                                    MessageBox.Show("Relation successfull");
                                }

                            }
                        }
                    }
                }

            }
        }

        private void CatagoryButton_Click(object sender, EventArgs e)
        {
            cat = true;
            qaa = false;
            comboBox5.Items.Clear();
            panel2.Visible = false;
            panel3.Visible = true;
            panel3.BringToFront();
            try
            {
                SqlCommand cmd = new SqlCommand("select catagoryName from DCatagory", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox5.Items.Add(dr["catagoryName"]);
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

        }

        private void loadFRbutton_Click(object sender, EventArgs e)
        {
            fr = true;
            qg = false;
            RelateQG.Visible = true;
            //CatagoryButton.Visible = true;
            dataGridView4.DataSource=null;
            try
            {
                SqlCommand cmd8 = new SqlCommand("select FR_name as 'Requirement Name',FR_desc as 'Description' from FunctReq where Project_id = '" + ss + "'", con);
                con.Open();
                SqlDataReader dr = cmd8.ExecuteReader();
                BindingSource bs = new BindingSource();
                bs.DataSource = dr;
                dataGridView4.DataSource = bs;
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
    }
}
