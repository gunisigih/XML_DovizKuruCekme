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

namespace DovizKurlarıDataSource
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Yukle_Click(object sender, EventArgs e)
        {
            DataSet doviz = new DataSet();
            doviz.ReadXml("https://www.tcmb.gov.tr/kurlar/today.xml");
            dataGridView1.DataSource = doviz.Tables[1];
           
        }
    }
}
