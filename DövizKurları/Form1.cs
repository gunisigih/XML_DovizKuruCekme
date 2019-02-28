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
using System.Xml;

namespace DövizKurları
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Doviz secilenDoviz = (Doviz)listBox1.SelectedItem;
            label5.Text = secilenDoviz.AlısFiyat.ToString();
            label6.Text = secilenDoviz.SatısFiyat.ToString();
            label4.Text = secilenDoviz.Birim.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            XmlDocument xmldock = new XmlDocument();
            xmldock.Load("https://www.tcmb.gov.tr/kurlar/today.xml");
            XmlElement rooteleman = xmldock.DocumentElement;//tüm döküman
            XmlNodeList liste = rooteleman.GetElementsByTagName("Currency");
            List<Doviz> dlist = new List<Doviz>();
            foreach (var item in liste)
            {
                Doviz d = new Doviz();
                XmlElement curreny = (XmlElement)item;
                string isim = curreny.GetElementsByTagName("Isim").Item(0).InnerText;

                d.DovizAdı = isim;
                string alısFiyat = curreny.GetElementsByTagName("ForexBuying").Item(0).InnerText;

                string satısFiyat = curreny.GetElementsByTagName("ForexSelling").Item(0).InnerText;

                string biirim = curreny.GetElementsByTagName("Unit").Item(0).InnerText;


                if (!string.IsNullOrEmpty(alısFiyat))
                {
                    d.AlısFiyat = Convert.ToDecimal(alısFiyat);
                }
                if (!string.IsNullOrEmpty(satısFiyat))
                {
                    d.SatısFiyat = Convert.ToDecimal(satısFiyat);
                }
                if (!string.IsNullOrEmpty(biirim))
                {
                    d.Birim = Convert.ToInt32(biirim);
                }
                listBox1.Items.Add(d);
                dlist.Add(d);
            }
            dataGridView1.DataSource = dlist;
            int i = 0;
            foreach (var item in dlist)
            {
                try
                {
                    dataGridView2.Rows.Add();
                    dataGridView2.Rows[i].Cells[0].Value = item.DovizAdı;
                    dataGridView2.Rows[i].Cells[1].Value = item.SatısFiyat;
                    i++;
                }
                catch (Exception)
                {

                  
                }
            }
        }
    }
}
