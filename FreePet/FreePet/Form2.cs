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

            label3.Text = "@" + Genel.kad;
            label2.Text = Genel.adsoyad;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString()=="Diğer") textBox2.Visible = true;
            else textBox2.Visible = false;
        }

        Dictionary<string, string> resimler = new Dictionary<string, string>();

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All files (*.*)|*.*";
            ofd.RestoreDirectory = true;
            ofd.Title = "Fotoğrafları Seç";
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string[] DosyaYolu = ofd.FileNames;
                string[] DosyaAdi = ofd.SafeFileNames;
                galeri.Controls.Clear();
                resimler.Clear();
                for (int i = 0; i < DosyaYolu.Length; i++)
                {
                    resimler.Add(DosyaAdi[i],DosyaYolu[i]);
                    PictureBox pb = new PictureBox();
                    pb.Name = "resim_" + resimler.Count;
                    pb.Image = Image.FromFile(DosyaYolu[i]);
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    pb.Size = new Size(galeri.Width-25, galeri.Width-25);
                    pb.BorderStyle = BorderStyle.FixedSingle;
                    string isim= "resim_" + (resimler.Count - 1);
                    if (resimler.Count > 1) pb.Location = new Point(0, galeri.Controls[isim].Location.Y + 10 +galeri.Width);
                    else pb.Location = new Point(0, 10);
                    galeri.Controls.Add(pb);
                }
            }
          
        }
    }
}
