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
    public partial class acilvet : UserControl
    {
        public acilvet()
        {
            InitializeComponent();
        }
        public string Adres
        {
            get { return klnkadres1.Text; }
            set { klnkadres1.Text = value; }
        }

        public string Sahip
        {
            get { return klnksahip1.Text; }
            set { klnksahip1.Text = value; }
        }
        public string Klinikad
        {
            get { return klnkad1.Text; }
            set { klnkad1.Text = value; }
        }
        public string Telefon
        {
            get { return klnktel1.Text; }
            set { klnktel1.Text = value; }
        }
        public string VETID
        {
            get { return vetNo.Text; }
            set { vetNo.Text = value; }
        }

        public Image Fotograf
        {
            get { return vetfoto.Image; }
            set { vetfoto.Image = value; }
        }


        private void klnkadres1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            //panel1.Dock = DockStyle.Fill;
            //pictureBox1.Visible = false;
            //webBrowser1.Visible = true;     
            //webBrowser1.Dock = DockStyle.Fill;
            
        }
    }
}
