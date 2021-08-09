using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DecisionAssist
{
    public partial class DesignDecisions : UserControl
    {
        private static DesignDecisions _instance;
        public static DesignDecisions Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DesignDecisions();
                return _instance;
            }

        }
        private int xx;
        public int x
        {
            get { return xx; }
            set { xx = value; }
        }
        SqlConnection con = new SqlConnection("data source= IMRAN;database=DAssist;integrated security= SSPI");
        public DesignDecisions()
        {
            InitializeComponent();
            
            
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            SqlCommand cmd = new SqlCommand("select DD_name, DD_des from DesignDecision where Project_id=" + xx + "", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr["DD_name"];
                dataGridView1.Rows[n].Cells[1].Value = dr["DD_des"];

            }
            dr.Close();
            con.Close();

        }
        Recommandation r;
        private void button3_Click(object sender, EventArgs e)
        {
            r = new Recommandation(xx);
            r.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
        NewDecision nd;
        private void button1_Click(object sender, EventArgs e)
        {
            nd = new NewDecision(xx);
            nd.Show();
        }
    }
}
