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
    public partial class Accueil : Form
    {
        public SqlConnection cnx;

        public Accueil()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dap = new SqlDataAdapter("select l.codelycee , l.nomlycee , l.ville from Lycee l where l.codelycee not in (select codelycee from Visite)", cnx);
            
            DataSet ds = new DataSet();
            dap.Fill(ds,"lycees");
            
           ds.Tables[0].WriteXml("lycees.xml");
            MessageBox.Show("Bien Exporter!");

            
        }

        private void Accueil_Load(object sender, EventArgs e)
        {
            cnx = new SqlConnection("Data Source=DESKTOP-VKH4DQQ;Initial Catalog=COMPLE_X;Integrated Security=True");
        }
    }
}
