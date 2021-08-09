using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace DecisionAssist
{
    public partial class DesignConcernFRDc : UserControl
    {
        SqlConnection con = new SqlConnection("data source= IMRAN;database=DAssist;integrated security= SSPI");
        int pro_id;
        int fr = 0;
        private static DesignConcernFRDc _instance;
        public static DesignConcernFRDc Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DesignConcernFRDc();
                return _instance;
            }

        }
        private int ii;
        public int i
        {
            get { return ii; }
            set { ii = value; }
        }
        private int bbb;
        public int bb
        {
            get { return bbb; }
            set { bbb = value; }
        }
        public DesignConcernFRDc()
        {
            InitializeComponent();
            //panel2.Visible = false;
            if (bbb == 1)
            {
                comboBox2.Visible = false;
                label6.Visible = false;
                label5.Visible = false;
                comboBox1.Visible = false;
                button5.Hide();
                button4.Hide();
                fr = bbb;
            }
            else
            {
                label5.Visible = false;
                comboBox1.Visible = false;
                button6.Hide();
                button3.Hide();
            }
            pro_id = ii;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DAssistDesignConcernEntities fre = new DAssistDesignConcernEntities();
            DConst dc = new DConst();
            dc.Dc_name = textBox1.Text;
            dc.Dc_des = textBox2.Text;
            dc.Project_id = pro_id;
            fre.DConsts.Add(dc);
            fre.SaveChanges();
            this.dataGridView1.DataSource = fre.DConsts.Where(f => f.Project_id.Equals(1)).ToList();

           
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

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //panel2.Visible = true;
            //if (!panel2.Controls.Contains(DesignConcern.Instance))
            //{
            //    panel2.Controls.Add(DesignConcern.Instance);
            //    DesignConcern.Instance.Dock = DockStyle.Fill;
            //    DesignConcern.Instance.BringToFront();
            //    //DesignConcern.Instance.bb = 1;
            //    //DesignConcern.Instance.i = ii;
            //    //MessageBox.Show("Use the tool to input Design Concerns" + Environment.NewLine + "For Functional Requirement Click FR" + Environment.NewLine + "For Design Constraints Click Constaints and For Quality Goal Click QG", "Design Concerns");
            //}
            //else {
            //    DesignConcern.Instance.BringToFront();
            //    //  MessageBox.Show("Use the tool to input Design Concerns"+Environment.NewLine+ " For Functional Requirement Click FR, For Design Constraints Click DConst and For Quality Goal Click QG", "Design Concerns");
            //}

        }
    }
}
