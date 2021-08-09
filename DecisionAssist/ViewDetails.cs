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
    public partial class ViewDetails : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DAssist.mdf;Initial Catalog=DAssist;Integrated Security=True;Connect Timeout=30");

        // SqlConnection con = new SqlConnection("data source= IMRAN;database=DAssist;integrated security= SSPI");
        private int p_id,id,type;

        

        public ViewDetails(string name, string des,int p,int i,int t)
        {
            InitializeComponent();
            p_id = p;
            id = i;
            type = t;
            button2.Visible = false;
            button1.Visible = false;
            pictureBox1.Visible = false;
            if (type == 4||type==5||type==7||type==8||type==3)
            {
                Updatebutton.Visible = false;
            }
            
            if (type != 8)
            {
                textBox1.Text = name;
                textBox2.Text = des;
            }
            else {
                textBox1.Text = name;
                try
                {
                    SqlCommand cmd8 = new SqlCommand("Select DD_des from DesignDecision where DD_name='" + name + "' and Project_id='" + p + "'", con);
                    con.Open();
                    SqlDataReader dr = cmd8.ExecuteReader();
                    while (dr.Read())
                    {
                        textBox2.Text = Convert.ToString(dr["DD_des"].ToString());
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
            }

           
        }

        private void Updatebutton_Click(object sender, EventArgs e)
        {
            if (type == 1)
            {
                try
                {
                    try
                    {
                        SqlCommand cmd8 = new SqlCommand("Update FunctReq set FR_name='" + textBox1.Text + "',FR_desc='" + textBox2.Text + "'  where Project_id='" + p_id + "' and FR_id='" + id + "'", con);
                        con.Open();
                        cmd8.ExecuteReader();
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
                    MessageBox.Show("successfully updated");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            else if (type == 2)
            {
                try
                {

                    SqlCommand cmd8 = new SqlCommand("Update DConst set Dc_name='" + textBox1.Text + "',Dc_des='" + textBox2.Text + "'  where Project_id='" + p_id + "' and Dc_id='" + id + "'", con);
                    con.Open();
                    cmd8.ExecuteReader();
                    con.Close();

                    MessageBox.Show("successfully updated");
                    this.Close();
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
            else if (type == 3)
            {
                try
                {
                    string qname = textBox1.Text;
                    SqlCommand cmd8 = new SqlCommand("Update QualityAttribute set QA_name='" + textBox1.Text + "',QA_des='" + textBox2.Text + "' where QA_name='" + qname + "'", con);
                    con.Open();
                    cmd8.ExecuteReader();
                    con.Close();
                    MessageBox.Show("successfully updated");
                    this.Close();
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
            else if (type == 6)
            {
                try
                {
                    string Dname = textBox1.Text;
                    SqlCommand cmd8 = new SqlCommand("Update DesignDecision set DD_name='" + textBox1.Text + "',DD_des='" + textBox2.Text + "' where DD_id='" + id + "' and Project_id='"+p_id+"'", con);
                    con.Open();
                    cmd8.ExecuteReader();
                    con.Close();
                    MessageBox.Show("successfully updated");
                    this.Close();
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
            else if (type == 9)
            {
                try
                {
                    string Dname = textBox1.Text;
                    SqlCommand cmd8 = new SqlCommand("Update DecisionRepo set DR_name='" + textBox1.Text + "',DR_des='" + textBox2.Text + "' where DR_id='"+id+"'", con);
                    con.Open();
                    cmd8.ExecuteReader();
                    con.Close();
                    MessageBox.Show("successfully updated");
                    this.Close();
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

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd8 = new SqlCommand("Select dd_image from DesignDecision where DD_id='" + id+ "' and Project_id='" + p_id + "'", con);
            con.Open();
            SqlDataReader dr = cmd8.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                Image img = new Bitmap("dr[0]");
                byte[] iii = (byte[])(dr[0]);
                Console.WriteLine("test2");
                if (iii == null)
                {
                    pictureBox1.Visible = false;
                    Console.WriteLine("test3");
                }
                else
                {
                    Console.WriteLine("test4");
                    // pictureBox1.Image = GetDataToImage(iii);
                    try
                    {
                        // MemoryStream ms = new MemoryStream(iii);
                        

                        pictureBox1.Image = img;
                        //ms.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }


                con.Close();
            }
            else {
                MessageBox.Show("No artifact found");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            { pictureBox1.Image.Dispose(); }
            
            
                Console.WriteLine("retrieve image of id"+id);
              //  pictureBox1.Visible = true;
                SqlCommand cmd8 = new SqlCommand("Select dd_image from DesignDecision where DD_id='"+id+ "' and Project_id='" + p_id + "'", con);
                con.Open();
                SqlDataReader dr = cmd8.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    byte[] iii = (byte[])(dr[0]);
                    Console.WriteLine("oiiii2");
                    if (iii == null)
                    {
                        pictureBox1.Visible = false;
                        Console.WriteLine("oiiii3");
                    }
                    else
                    {
                        Console.WriteLine("oiiii4");
                   // pictureBox1.Image = iii;
                        // MemoryStream ms = new MemoryStream(iii);
                        //pictureBox1.Image = Image.FromStream(ms);
                    //ms.Dispose();
                    }

                
                con.Close();
            }
        }

        public Image GetDataToImage(byte[] pData)
        {
            try
            {
                ImageConverter imgConverter = new ImageConverter();
                return imgConverter.ConvertFrom(pData) as Image;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
