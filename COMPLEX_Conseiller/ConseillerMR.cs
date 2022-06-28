using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace COMPLEX_Conseiller
{
    public partial class ConseillerMR : Form
    {
        public SqlConnection cnx;
        public SqlCommand cmd;
        public SqlDataReader dr;
        public ConseillerMR()
        {
            InitializeComponent();
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            cnx.Open();
            cmd.CommandText = "select * from Conseiller where matricule = " + textBox1.Text + "";
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                //dr.GetInt32(0),dr.GetString(1),dr.GetString(2),dr.GetInt32(3),dr.GetInt32(4),dr.GetInt32(5)
                textBox2.Text = dr.GetString(1);
                textBox3.Text = dr.GetString(2);
                textBox5.Text = dr.GetInt32(3).ToString();
                textBox4.Text = dr.GetInt32(5).ToString();

               comboBox1.Text = dr.GetInt32(4).ToString();


            }
            else
            {
                MessageBox.Show("Introuvable");
            }
            cnx.Close();
        }

        private void ConseillerMR_Load(object sender, EventArgs e)
        {
            cnx = new SqlConnection("Data Source=DESKTOP-VKH4DQQ;Initial Catalog=COMPLE_X;Integrated Security=True");
            cmd = new SqlCommand("", cnx);
            SqlDataAdapter dap = new SqlDataAdapter("select codecomplex from Complex", cnx);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "codecomplex";
            comboBox1.ValueMember = "codecomplex";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cnx.Open();
            cmd.CommandText = string.Format("update Conseiller set nom = '{0}' , prenom = '{1}' , codeSecret = {2} , codecomplex = {3} , nombrevisite = {4} where matricule = {5}",textBox2.Text,textBox3.Text,int.Parse(textBox5.Text),comboBox1.SelectedValue,int.Parse(textBox4.Text),int.Parse(textBox1.Text));
            
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Modifier Bien");


            }
            else
            {
                MessageBox.Show("Introuvable");
            }
            cnx.Close();
        }
        //
      
    }
}
