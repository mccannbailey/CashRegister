using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cash_register
{
    public partial class Form1 : Form
    {
        const double whiteshirt = 5;
        const double baggyjeans = 10.5;
        const double bandana = 2.5;
        const double timbs = 100;
        const double tax = 1.13;
        const double taxmultiplier = 0.13;
        double total;
        double tender;
        string change;
        string tenderinput;
        int shirtcounter = 0;
        int jeancounter = 0;
        int bandanacounter = 0;
        int timbscounter = 0;


        public Form1()
        {
            InitializeComponent();
        }
        private void shirtbutton_Click(object sender, EventArgs e)
        {
            shirtcounter++;
            outputlabel1.Text = "White T-Shirt (XL) x" + shirtcounter;
        }
        private void jeanbutton_Click(object sender, EventArgs e)
        {
            jeancounter++;
            outputlabel2.Text = "Baggy Jean x" + jeancounter;
        }

        private void bandanabutton_Click(object sender, EventArgs e)
        {
            bandanacounter++;
            outputlabel3.Text = "Bandana x" + bandanacounter;
        }

        private void timbsbutton_Click(object sender, EventArgs e)
        {
            timbscounter++;
            outputlabel4.Text = "Timbs Boots x" + timbscounter;
        }
        private void totalbutton_Click(object sender, EventArgs e)
        {
            double shirtprice = shirtcounter * 5;
            double jeanprice = jeancounter * 10.5;
            double bandanaprice = bandanacounter * 2.5;
            double timbsprice = timbscounter * 100;

            double subtotaldouble = shirtprice + jeanprice + bandanaprice + timbsprice;
            string subtotal = subtotaldouble.ToString("C");
            subtotallabel.Text = "Subtotal: " + subtotal;

            double taxbefore = subtotaldouble * taxmultiplier;
            string taxalone = taxbefore.ToString("C");
            taxlabel.Text = "Tax: " + taxalone;

            total = subtotaldouble * tax;
            string grandtotal = total.ToString("C");
            grandtotallabel.Text = "Grand Total: " + grandtotal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                tenderinput = tenderbox.Text;
                tender = Convert.ToDouble(tenderinput);
                double totalprice = Convert.ToDouble(total);
                double changedouble = tender - totalprice;
                string change = changedouble.ToString("C");
                changelabel.Text = "Change: " + change;
            }
            catch
            {
                changelabel.Text = "Error, did you enter\na number?";
            }
            if (tender < total)
            {
                changelabel.Text = "Not enough funds!";
            }
        }
    }
}


