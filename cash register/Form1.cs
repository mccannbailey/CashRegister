using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
        string subtotal;
        string grandtotal;
        string taxalone;
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
            subtotal = subtotaldouble.ToString("C");
            subtotallabel.Text = "Subtotal: " + subtotal;

            double taxbefore = subtotaldouble * taxmultiplier;
            taxalone = taxbefore.ToString("C");
            taxlabel.Text = "Tax: " + taxalone;

            total = subtotaldouble * tax;
            grandtotal = total.ToString("C");
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
                change = changedouble.ToString("C");
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

        private void emptycartbutton_Click(object sender, EventArgs e)
        {
            shirtcounter = 0;
            jeancounter = 0;
            bandanacounter = 0;
            timbscounter = 0;

            outputlabel1.Text = "";
            outputlabel2.Text = "";
            outputlabel3.Text = "";
            outputlabel4.Text = "";
            subtotallabel.Text = "Subtotal: ";
            taxlabel.Text = "Tax: ";
            grandtotallabel.Text = "Grand Total: ";
            changelabel.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics receipt = this.CreateGraphics();
            Font receiptFont = new Font("Consolas", 11, FontStyle.Regular);
            SolidBrush receiptBrush = new SolidBrush(Color.Black);
            if (tender > 0)
            {
                receipt.DrawString("The Crip Walk", receiptFont, receiptBrush, 575, 50);
                Thread.Sleep(500);
                receipt.DrawString("White T-Shirt x" + shirtcounter + " @ $5.00/ea", receiptFont, receiptBrush, 530, 80);
                Thread.Sleep(500);
                receipt.DrawString("Jeans         x" + jeancounter + " @ $10.50/ea", receiptFont, receiptBrush, 530, 100);
                Thread.Sleep(500);
                receipt.DrawString("Bandana       x" + bandanacounter + " @ $2.50/ea", receiptFont, receiptBrush, 530, 120);
                Thread.Sleep(500);
                receipt.DrawString("Timbs         x" + timbscounter + " @ $100/ea", receiptFont, receiptBrush, 530, 140);
                Thread.Sleep(500);
                receipt.DrawString("Subtotal:       " + subtotal, receiptFont, receiptBrush, 530, 200);
                Thread.Sleep(500);
                receipt.DrawString("Tax:            " + taxalone, receiptFont, receiptBrush, 530, 220);
                Thread.Sleep(500);
                receipt.DrawString("Grand Total:    " + grandtotal, receiptFont, receiptBrush, 530, 240);
                Thread.Sleep(500);
                receipt.DrawString("Tender:         $" + tender, receiptFont, receiptBrush, 530, 260);
                Thread.Sleep(500);
                receipt.DrawString("Change:         " + change, receiptFont, receiptBrush, 530, 280);
            }
            else
            {
                receipt.DrawString("Please enter tender first" + subtotal, receiptFont, receiptBrush, 530, 220);
            }
        }
    }
}


