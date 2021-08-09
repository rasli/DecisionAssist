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
using System.IO;

namespace DecisionAssist
{
    public partial class ReusableDecision : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DAssist.mdf;Initial Catalog=DAssist;Integrated Security=True;Connect Timeout=30");

        // SqlConnection con = new SqlConnection("data source= IMRAN;database=DAssist;integrated security= SSPI");
        //static string path = Path.GetFullPath(Environment.CurrentDirectory);
        //static string databaseName = "DAssist.mdf";
        //SqlConnection con = new SqlConnection(@"data source=(localdb)\v11.0;AttachDbFilename=" + path + @"\" + databaseName + ";integrated security= true");
        private static ReusableDecision _instance;
        public static ReusableDecision GetInstance()
        {
            
                if (_instance == null)
                    _instance = new ReusableDecision();
                return _instance;
            

        }
        string[] impact = new string[8];
        public ReusableDecision()
        {

            InitializeComponent();
            label17.Visible = false;
            label18.Visible = false;
            uploadartifactbutton.Visible = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        

       
        private void radioButton17_CheckedChanged_1(object sender, EventArgs e)
        {
            impact[1] = "positive";
        }

        private void radioButton16_CheckedChanged_1(object sender, EventArgs e)
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

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            List<string> x = new List<string>();
            try
            {
                if (comboBox1.SelectedIndex > -1)
                {
                    SqlCommand cmd21 = new SqlCommand("select catagory_id from DCatagory as c where c.catagoryName='" + comboBox1.SelectedItem.ToString() + "'", con);
                    con.Open();
                    SqlDataReader dr = cmd21.ExecuteReader();
                    while (dr.Read())
                    {
                        x.Add(dr["catagory_id"].ToString());
                    }
                    int a = Convert.ToInt32(x[0]);
                    con.Close();

                    if (textBox1.Text != "")
                    {
                        if (impact[1] == null || impact[2] == null || impact[3] == null || impact[4] == null || impact[5] == null || impact[6] == null)
                        {
                            MessageBox.Show("Please Check whether any quality relation is unselected");
                        }
                        else
                        {
                            SqlCommand cmd11 = new SqlCommand("insert into DecisionRepo(DR_name,DR_des,catagory_id,dr_image) values('" + textBox1.Text + "','" + textBox2.Text + "','" + a + "','" + img + "') ", con);
                            con.Open();
                            cmd11.ExecuteReader();
                            con.Close();


                            SqlCommand cmd10 = new SqlCommand("insert into DecisionQAimpact(DR_id,QA_id,Impact) select DR_id,1,'" + impact[1] + "' from DecisionRepo as dd where dd.DR_name='" + textBox1.Text + "' ", con);
                            con.Open();
                            cmd10.ExecuteReader();
                            con.Close();



                            SqlCommand cmd = new SqlCommand("insert into DecisionQAimpact(DR_id,QA_id,Impact) select DR_id,2,'" + impact[2] + "' from DecisionRepo as dd where dd.DR_name='" + textBox1.Text + "' ", con);
                            con.Open();
                            cmd.ExecuteReader();
                            con.Close();

                            SqlCommand cmd1 = new SqlCommand("insert into DecisionQAimpact(DR_id,QA_id,Impact) select DR_id,3,'" + impact[3] + "' from DecisionRepo as dd where dd.DR_name='" + textBox1.Text + "' ", con);
                            con.Open();
                            cmd1.ExecuteReader();
                            con.Close();

                            SqlCommand cmd2 = new SqlCommand("insert into DecisionQAimpact(DR_id,QA_id,Impact) select DR_id,4,'" + impact[4] + "' from DecisionRepo as dd where dd.DR_name='" + textBox1.Text + "' ", con);
                            con.Open();
                            cmd2.ExecuteReader();
                            con.Close();

                            SqlCommand cmd3 = new SqlCommand("insert into DecisionQAimpact(DR_id,QA_id,Impact) select DR_id,5,'" + impact[5] + "' from DecisionRepo as dd where dd.DR_name='" + textBox1.Text + "' ", con);
                            con.Open();
                            cmd3.ExecuteReader();
                            con.Close();

                            SqlCommand cmd4 = new SqlCommand("insert into DecisionQAimpact(DR_id,QA_id,Impact) select DR_id,6,'" + impact[6] + "' from DecisionRepo as dd where dd.DR_name='" + textBox1.Text + "' ", con);
                            con.Open();
                            cmd4.ExecuteReader();
                            con.Close();


                            textBox1.Clear();
                            textBox2.Clear();
                            // textBox3.Clear();

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

                            MessageBox.Show("Decision Successfuly Added in Decision Repository");

                        }


                    }
                    else
                    { MessageBox.Show("Please Add a Decision Name"); }

                }
                else
                {
                    MessageBox.Show("Decision Type Unselected");
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

        private void comboBox1_DropDown_1(object sender, EventArgs e)
        {
            try
            {
                comboBox1.Items.Clear();
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
            finally
            {
                if (con != null)
                {
                    con.Close();
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

        private void radioButton18_CheckedChanged_1(object sender, EventArgs e)
        {
            impact[1] = "neutral";
        }

        private void radioButton26_CheckedChanged_1(object sender, EventArgs e)
        {
            impact[2] = "positive";
        }

        private void radioButton25_CheckedChanged_1(object sender, EventArgs e)
        {
            impact[2] = "negative";
        }

        private void radioButton27_CheckedChanged_1(object sender, EventArgs e)
        {
            impact[2] = "neutral";
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            impact[3] = "positive";
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            impact[3] = "negative";
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            impact[3] = "neutral";
        }

        private void radioButton11_CheckedChanged_1(object sender, EventArgs e)
        {
            impact[4] = "positive";
        }

        private void radioButton10_CheckedChanged_1(object sender, EventArgs e)
        {
            impact[4] = "negative";
        }

        private void radioButton12_CheckedChanged_1(object sender, EventArgs e)
        {
            impact[4] = "neutral";
        }

        private void radioButton8_CheckedChanged_1(object sender, EventArgs e)
        {
            impact[5] = "positive";
        }

        private void radioButton7_CheckedChanged_1(object sender, EventArgs e)
        {
            impact[5] = "negative";
        }

        private void radioButton9_CheckedChanged_1(object sender, EventArgs e)
        {
            impact[5] = "neutral";
        }

        private void radioButton5_CheckedChanged_1(object sender, EventArgs e)
        {
            impact[6] = "positive";
        }

        private void radioButton4_CheckedChanged_1(object sender, EventArgs e)
        {
            impact[6] = "negative";
        }

        private void radioButton6_CheckedChanged_1(object sender, EventArgs e)
        {
            impact[6] = "neutral";
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
        DataTable decisiondt = new DataTable();
        DataTable decisiondt1 = new DataTable();
        private void loadDRbutton_Click(object sender, EventArgs e)
        {
            decisiondt.Rows.Clear();
            decisiondt.Columns.Clear();
            decisiondt1.Rows.Clear();
            decisiondt1.Columns.Clear();
            try
            {
                SqlCommand cmd8 = new SqlCommand("select DR_name,DR_des,catagoryName from DecisionRepo as d inner join DCatagory as c on d.catagory_id=c.catagory_id", con);
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
                //BindingSource bs = new BindingSource();
                //bs.DataSource = dr8;
                //dataGridView18.DataSource = bs;

                con.Close();
                dr8.Close();
                addd.Fill(decisiondt);
                addd.Fill(decisiondt1);
                // DataView dv = new DataView(ds.Tables[0]);
                dataGridView1.DataSource = decisiondt;
                dataGridView18.DataSource = decisiondt1;

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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(decisiondt1);
            dv.RowFilter = string.Format("catagoryName Like '%{0}%'", comboBox2.SelectedItem.ToString());
            dataGridView18.DataSource = dv;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(decisiondt);
            dv.RowFilter = string.Format("catagoryName Like '%{0}%'", comboBox3.SelectedItem.ToString());
            dataGridView1.DataSource = dv;
        }

        private void DtoDrelationbutton_Click(object sender, EventArgs e)
        {
            int dr1=0,dr2=0;
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
                            String idd = Convert.ToString(dataGridView18.Rows[i].Cells["DR_name"].Value.ToString());
                            String iddd = Convert.ToString(dataGridView1.Rows[j].Cells["DR_name"].Value.ToString());
                            //SqlCommand cmd10 = new SqlCommand("insert into DecisionDecImpact(dr1_id,dr2_id,impact) select dd.DR_id,dr.DR_id,'"+impact[7]+"' from DecisionRepo as dd inner join DecisionDecImpact di on dd.DR_id=di.dr1_id inner join DecisionRepo as dr on dr.DR_id=di.dr2_id  where  dd.DR_name='" + iddd + "' and dr.DR_name='" + idd + "'", con);
                            try
                            {
                                SqlCommand cmd10 = new SqlCommand("select DR_id from DecisionRepo where DR_name='" + idd + "'", con);
                                con.Open();
                                SqlDataReader dr = cmd10.ExecuteReader();
                                while (dr.Read())
                                {
                                    dr1 = Convert.ToInt32(dr["DR_id"]);
                                }
                                con.Close();
                                dr.Close();
                                SqlCommand cmd11 = new SqlCommand("select DR_id from DecisionRepo where DR_name='" + iddd + "'", con);
                                con.Open();
                                SqlDataReader dr3 = cmd11.ExecuteReader();
                                while (dr3.Read())
                                {
                                    dr2 = Convert.ToInt32(dr3["DR_id"]);
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
                            List<string> check = new List<string>();
                            try
                            {
                                con.Open();
                                SqlCommand cmd22 = new SqlCommand("select dr1_id from DecisionDecImpact as d where d.dr1_id='" + dr1 + "' and d.dr2_id='" + dr2 + "' ", con);
                                SqlDataReader dr21 = cmd22.ExecuteReader();
                                while (dr21.Read())
                                {
                                    //Console.WriteLine(dr2["DD_name"].ToString());
                                    check.Add(dr21["dr1_id"].ToString());
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
                                MessageBox.Show("Impact Already Exist");
                            }
                            else
                            {
                                try
                                {
                                    SqlCommand cmd12 = new SqlCommand("insert into DecisionDecImpact(dr1_id,dr2_id,impact) select '" + dr1 + "','" + dr2 + "','" + impact[7] + "'", con);
                                    con.Open();
                                    cmd12.ExecuteReader();
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
                }
            }
            MessageBox.Show("Relation successfull");
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)item.Cells[0];

                cell.Value = false;
            }

        }

        private void CheckUncheckbutton_Click(object sender, EventArgs e)
        {
            if (CheckUncheckbutton.Text == "Check All")
            {
                foreach (DataGridViewRow item in dataGridView18.Rows)
                {
                    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)item.Cells[0];

                    cell.Value = true;
                }

                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)item.Cells[0];

                    cell.Value = true;
                }
                CheckUncheckbutton.Text = "Uncheck All";
            }
            else {
                foreach (DataGridViewRow item in dataGridView18.Rows)
                {
                    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)item.Cells[0];

                    cell.Value = false;
                }

                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)item.Cells[0];

                    cell.Value = false;
                }
                CheckUncheckbutton.Text = "Check All";
            }
        }
        SqlCommandBuilder scom;
        DataTable dr_dt = new DataTable();
        private void DecisionEditordataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DecisionEditordataGridView.Columns[e.ColumnIndex].Name == "DelDr")
            {
                if (MessageBox.Show("Are you sure to delete the requirements", "Delete Requirements", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    String dt = Convert.ToString(DecisionEditordataGridView.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    try
                    {
                        SqlCommand cmd8 = new SqlCommand("delete from DecisionQAimpact where  Dr_id='" + Convert.ToInt32(dt) + "'", con);
                        con.Open();
                        SqlDataReader dr = cmd8.ExecuteReader();
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
                    DecisionEditordataGridView.Rows.RemoveAt(DecisionEditordataGridView.CurrentCell.RowIndex);
                    try
                    {
                        scom = new SqlCommandBuilder(addd);
                        addd.Update(dr_dt);
                        SqlCommand cmd9 = new SqlCommand("delete from DecisionRepo where  DR_id='" + Convert.ToInt32(dt) + "'", con);
                        con.Open();
                        cmd9.ExecuteReader();
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
            else if (DecisionEditordataGridView.Columns[e.ColumnIndex].Name == "viewdr")
            {
                int fid = Convert.ToInt32(DecisionEditordataGridView.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                String fname = Convert.ToString(DecisionEditordataGridView.Rows[e.RowIndex].Cells["Decision Name"].Value.ToString());
                String fdes = Convert.ToString(DecisionEditordataGridView.Rows[e.RowIndex].Cells["Description"].Value.ToString());
                ViewDetails v = new ViewDetails(fname, fdes, 1, fid, 9);
                v.ShowDialog();
            }
        }
        SqlDataAdapter addd;
        private void CDlaodbutton_Click(object sender, EventArgs e)
        {
            dr_dt.Rows.Clear();
            dr_dt.Columns.Clear();
            //this.dataGridView9.AutoSizeColumnsMode=DataGridViewAutoSizeColumnMode.Fill;
            //DAssistDesignConcernEntities fre = new DAssistDesignConcernEntities();           
            //this.dataGridView9.DataSource = fre.FunctReqs.Where(f => f.Project_id.Equals(ss)).ToList();

            try
            {
                SqlCommand cmd8 = new SqlCommand("select DecisionRepo.Dr_id as 'ID',DecisionRepo.Dr_name as 'Decision Name',DecisionRepo.Dr_des as 'Description',DCatagory.catagoryName as Category from DecisionRepo,DCatagory  where DecisionRepo.catagory_id=DCatagory.catagory_id", con);
                con.Open();
                SqlDataReader dr8 = cmd8.ExecuteReader();
                addd = new SqlDataAdapter();
                addd.SelectCommand = cmd8;
                con.Close();
                dr8.Close();
                addd.Fill(dr_dt);
                // DataView dv = new DataView(ds.Tables[0]);
                DecisionEditordataGridView.DataSource = dr_dt;
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
        Image img = null;
        private void uploadartifactbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                img = Image.FromFile(ofd.FileName);
                MemoryStream ms = new MemoryStream();
                img.Save(ms, img.RawFormat);
                //using (ArtiEntity af = new ArtiEntity())
                //{
                //    af.Artifacts.Add(new Artifact() { artifacts = ms.ToArray() });
                //    af.SaveChanges();
                //}

                //MessageBox.Show("succesfully added");

            }
        }
    }
}
