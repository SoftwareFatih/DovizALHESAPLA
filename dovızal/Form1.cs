using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace dovızal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
           var xmldosya = new XmlDocument();
            xmldosya.Load(bugun);

            string DolarAlis = xmldosya.SelectSingleNode("Tarih_Date / Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            this.DolarAlisText.Text = DolarAlis;

            string DolarSatis = xmldosya.SelectSingleNode("Tarih_Date / Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            this.DolarSatisText.Text = DolarSatis;

            string EuroAlis = xmldosya.SelectSingleNode("Tarih_Date / Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            this.EuroAlisText.Text = EuroAlis;

            string EuroSatis = xmldosya.SelectSingleNode("Tarih_Date / Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            this.EuroSatisText.Text = EuroSatis;


        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnDolarAlis_Click(object sender, EventArgs e)
        {
            txtKUR.Text = DolarAlisText.Text;
        }

        private void btnDolarSatis_Click(object sender, EventArgs e)
        {
            txtKUR.Text = DolarSatisText.Text;
        }

        private void btnEuroAlis_Click(object sender, EventArgs e)
        {
            txtKUR.Text = EuroAlisText.Text;
        }

        private void btnEuroSatis_Click(object sender, EventArgs e)
        {
            txtKUR.Text = EuroSatisText.Text;
        }


        double kur, miktar, tutar;

        private void btnBozdurma_Click(object sender, EventArgs e)
        {
            kur=Convert.ToDouble(txtKUR.Text);
            int miktar=Convert.ToInt32(txtMiktar.Text);
            int Tutar = Convert.ToInt32(miktar / kur);
            txtTUTAR.Text= Tutar.ToString();
            double kalan;
            kalan =miktar % kur;
            tXTKALAN.Text= kalan.ToString();
        }

        private void txtKUR_TextChanged(object sender, EventArgs e)
        {
            txtKUR.Text=txtKUR.Text.Replace(".",",");
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            kur=Convert.ToDouble(txtKUR.Text);
            miktar=Convert.ToDouble(txtMiktar.Text);
            tutar = miktar*kur;

            txtTUTAR.Text=tutar.ToString();
        }
    }
}
