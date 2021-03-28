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
    public partial class ilan : UserControl
    {
        public ilan()
        {
            InitializeComponent();
        }

        public Image Fotograf
        {
            get { return ilanFoto.Image; }
            set { ilanFoto.Image = value; }
        }

        public string Baslik
        {
            get { return ilanBaslik.Text; }
            set { ilanBaslik.Text = value; }
        }

        public string Yas
        {
            get { return yas1.Text; }
            set { yas1.Text = value; }
        }

        public string Cinsiyet
        {
            get { return cinsiyet1.Text; }
            set { cinsiyet1.Text = value; }
        }

        public string Tur
        {
            get { return tur1.Text; }
            set { tur1.Text = value; }
        }
        public string Cins
        {
            get { return cins1.Text; }
            set { cins1.Text = value; }
        }
        public string Isim
        {
            get { return isim1.Text; }
            set { isim1.Text = value; }
        }
        public string Konum
        {
            get { return konum1.Text; }
            set { konum1.Text = value; }
        }
        public string ID
        {
            get { return ilanNo.Text; }
            set { ilanNo.Text = value; }
        }

        public string EngelDurumu
        {
            get { return engelDurum1.Text; }
            set { engelDurum1.Text = value; }
        }


        public void Proje_Click(EventHandler handler)
        {
            ilanFoto.Click += handler;
            ilanBaslik.Click += handler;
        }
        public void sil_Click(EventHandler handler)
        {
            sil.Click += handler;
        }
    }
}
