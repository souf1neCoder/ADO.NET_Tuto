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

namespace COMPLEX_Conseiller
{
    public partial class Form1 : Form
    {
        public SqlConnection cnx = new SqlConnection("Data Source=DESKTOP-VKH4DQQ;Initial Catalog=COMPLE_X;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public Conseiller rechercheConseiller(int matricule , int codeSecret)
        {
            cnx.Open();
            SqlCommand cmd = new SqlCommand("select * from Conseiller where matricule = " + matricule +" and codeSecret = " + codeSecret + "", cnx);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
            dr.Read();
                
                return new Conseiller(dr.GetInt32(0),dr.GetString(1),dr.GetString(2),dr.GetInt32(3),dr.GetInt32(4),dr.GetInt32(5));
               
            }
            else
            {
            cnx.Close();
                return null;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(rechercheConseiller(int.Parse(textBox1.Text), int.Parse(textBox2.Text)) is Conseiller)
            {
                this.Hide();
                Accueil ac = new Accueil();
                ac.Show();
            }
            else
            {
                MessageBox.Show("Not Found");
            }
        }
    }
}
