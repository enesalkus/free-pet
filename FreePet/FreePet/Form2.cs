using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            sayfaDegistir(menu2);
            hayvanYasi2.SelectedIndex = 0;
            hayvanTuru.SelectedIndex = 0;
            label3.Text = "@" + Genel.kad;
            label2.Text = Genel.adsoyad;
           // label1.Text = Genel.adsoyad + "\n" + Genel.kad + "\n" + Genel.sifre + "\n" + Genel.eposta;
        }

        string stage = "Ana Sayfa";
        private void sayfaDegistir(Control c)
        {
            string[] menuler = { "menu1", "menu2", "menu3", "menu4", "menu5" };
            menu.Location = new Point(0, c.Location.Y);
            stage = c.Text; menuBaslik.Text = c.Text;
            Control cl = this.Controls[c.Name + "_Panel"];
            foreach (string item in menuler)
            { if (item != c.Name) this.Controls[item + "_Panel"].Visible = false; }
            if (galeri.Visible == true)
            {
                galeri.Controls.Clear();
                resimler.Clear();
                galeri.Visible = false;
            }
            cl.Dock = DockStyle.Fill;
            cl.BringToFront();
            cl.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sayfaDegistir(menu1);
            hayvanYasi2.SelectedIndex = 0;
            hayvanTuru.SelectedIndex = 0;
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
            if(hayvanTuru.SelectedIndex >= 0 && hayvanTuru.SelectedItem.ToString()=="Diğer") hayvanTuru2.Visible = true;
            else hayvanTuru2.Visible = false;
        }

        Dictionary<string, string> resimler = new Dictionary<string, string>();


        private void galeri_Click(object sender, EventArgs e)
        {
            galeri.Controls.Clear();
            resimler.Remove(((PictureBox)sender).Name);
            foreach (var item in resimler)
            {
                PictureBox pb = new PictureBox();
                pb.Name = item.Key;
                pb.Image = Image.FromFile(item.Value);
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Size = new Size(galeri.Width - 25, galeri.Width - 25);
                pb.BorderStyle = BorderStyle.FixedSingle;
                pb.Click += galeri_Click;
                pb.Cursor = Cursors.Hand;
                if (galeri.Controls.Count > 0) pb.Location = new Point(0, galeri.Controls[galeri.Controls.Count - 1].Location.Y + 10 + galeri.Width);
                else pb.Location = new Point(0, 10);
                galeri.Controls.Add(pb);
            }
            if (galeri.Controls.Count < 1) galeri.Visible = false;
        }

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
                galeri.Controls.Clear();
                resimler.Clear();
                galeri.Visible = true;
                for (int i = 0; i < DosyaYolu.Length; i++)
                {
                    PictureBox pb = new PictureBox();
                    pb.Name = "resim_" + (resimler.Count + 1);
                    resimler.Add(pb.Name, DosyaYolu[i]);
                    pb.Image = Image.FromFile(DosyaYolu[i]);
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    pb.Size = new Size(galeri.Width-25, galeri.Width-25);
                    pb.BorderStyle = BorderStyle.FixedSingle;
                    pb.Click += galeri_Click;
                    pb.Cursor = Cursors.Hand;
                    if (resimler.Count > 1) pb.Location = new Point(0, galeri.Controls[galeri.Controls.Count - 1].Location.Y + 10 +galeri.Width);
                    else pb.Location = new Point(0, 10);
                    galeri.Controls.Add(pb);
                }
            }
          
        }

        static readonly ConnectionMultiplexer muxer = ConnectionMultiplexer.Connect("localhost:6379,password=");
        IDatabase bag = muxer.GetDatabase();
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (ilanBaslik.Text != "" && hayvanAdi.Text != "" && 
                ((hayvanTuru.SelectedItem.ToString() == "Diğer" && hayvanTuru2.Text != "") || hayvanTuru.SelectedItem.ToString() != "") &&
                hayvanCinsi.Text != "" && hayvanYasi2.SelectedItem.ToString() != "" && resimler.Count > 0)
            {
                Random rdm = new Random();
                int id = rdm.Next(100000, 1000000);
                RedisValue rv = bag.HashGet("Advert", id);
                if (!rv.HasValue)
                {
                    foreach (var item in resimler.Values)
                    {
                        byte[] imageArray = System.IO.File.ReadAllBytes(item.ToString());
                        bag.ListInsertAfter("Images", bag.ListGetByIndex("Images", bag.ListLength("Images") - 1), id + ";" + Convert.ToBase64String(imageArray));
                    }
                    bag.HashSet("Advert", id, ilanBaslik.Text + ";" + hayvanAdi.Text + ";"
                        + hayvanTuru.Text + ";" + hayvanYasi.Value + " " + hayvanYasi2.Text + ";"
                        + (engelDurumu.Checked ? "Yok" : "Var") + ";" + (iletisimBilgisi.Checked ? "Evet" : "Hayır") + ";"
                        + ilanAciklama.Text);
                    MessageBox.Show("İlanınız başarıyla oluşturuldu!");
                    ilanBaslik.Clear();
                    hayvanAdi.Clear();
                    hayvanTuru.SelectedIndex = 0;
                    hayvanYasi.Value = 1;
                    hayvanYasi2.SelectedIndex = 0;
                    hayvanCinsi.Clear();
                    engelDurumu.Checked = true;
                    iletisimBilgisi.Checked = true;
                    ilanAciklama.Clear();
                    resimler.Clear();
                    galeri.Controls.Clear();
                    galeri.Visible = false;
                }
                else this.InvokeOnClick(ilanOlustur, EventArgs.Empty);
            }
            else MessageBox.Show("Lütfen tüm alanları doldurunuz.");
        }
    }
}
