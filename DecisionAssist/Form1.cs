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
    public partial class Form1 : Form
    {
        //static string path = Path.GetFullPath(Environment.CurrentDirectory);
        // static string databaseName = "DAssist.mdf";
        //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\v11.0;AttachDbFilename=" + path + @"\" + databaseName + ";Integrated Security= False");
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DAssist.mdf;Initial Catalog=DAssist;Integrated Security=True;Connect Timeout=30");

        public Form1()
        {
            InitializeComponent();
            //Console.WriteLine("connection path: "+path);
           // SqlConnection con = new SqlConnection();
            //con.ConnectionString = "data source= IMRAN;database=DAssist;integrated security= SSPI";
            SqlCommand cmd = new SqlCommand("select Project_name from Project", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr["Project_name"];
            }

            dr.Close();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            //s = new StartPJ ();
            //s.Show();
            if (!panel1.Controls.Contains(StartProjcs.Instance))
            {
                panel1.Controls.Add(StartProjcs.Instance);
                StartProjcs.Instance.Dock = DockStyle.Fill;
                StartProjcs.Instance.BringToFront();

            }
            else
                StartProjcs.Instance.BringToFront();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dataGridView1.Columns[e.ColumnIndex].Name == "ResumePJ")
                {
                    //String iddd = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["P_name"].Value.ToString());
                   // Console.WriteLine(iddd);
                    //  Form2 f2 = new Form2(iddd);
                   // ProjectFrom pf = new ProjectFrom(iddd);
                    //Visible = false;
                    //pf.Show();


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        ReusableDecision r;
        private void reusableDecisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            r = new ReusableDecision();

            r.Show();
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            //s = new StartPJ ();
            //s.Show();
            if (!panel1.Controls.Contains(StartProjcs.Instance))
            {
                panel1.Controls.Add(StartProjcs.Instance);
                StartProjcs.Instance.Dock = DockStyle.Fill;
                StartProjcs.Instance.BringToFront();

            }
            else
                StartProjcs.Instance.BringToFront();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
