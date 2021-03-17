using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreePet
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            label3.Text = Genel.adsoyad;
            label2.Text = Genel.kad;
           // label1.Text = Genel.adsoyad + "\n" + Genel.kad + "\n" + Genel.sifre + "\n" + Genel.eposta;
        }

        string stage = "Ana Sayfa";
        private void sayfaDegistir(Control c)
        {
            menu.Location = new Point(0, c.Location.Y);
            stage = c.Text; menuBaslik.Text = c.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sayfaDegistir(menu1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void menu2_Click(object sender, EventArgs e)
        {
            sayfaDegistir(menu2);
        }

        private void menu3_Click(object sender, EventArgs e)
        {
            sayfaDegistir(menu3);
        }

        private void menu4_Click(object sender, EventArgs e)
        {
            sayfaDegistir(menu4);
        }

        private void menu5_Click(object sender, EventArgs e)
        {
            sayfaDegistir(menu5);
        }

        private void menu6_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1(); frm1.Show(); this.Close();
        }
    }
}
