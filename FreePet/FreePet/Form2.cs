﻿using StackExchange.Redis;
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
using System.Runtime.InteropServices;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace FreePet
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        static readonly ConnectionMultiplexer muxer = ConnectionMultiplexer.Connect(Genel.connString);
        IDatabase bag = muxer.GetDatabase();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            menuBaslik.Cursor = Cursors.SizeAll;
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void menuBaslik_MouseUp(object sender, MouseEventArgs e)
        {
            menuBaslik.Cursor = Cursors.Default;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            sayfaDegistir(menu1);
            hayvanYasi2.SelectedIndex = 0;
            hayvanTuru.SelectedIndex = 0;
            label3.Text = "@" + Genel.kad;
            label2.Text = Genel.adsoyad;
            pictureBox4.Image = Genel.profil;
        }

        public void sayfaDegistir(Control c)
        {
            string[] menuler = { "menu1", "menu2", "menu2_1", "menu2_2", "menu3", "menu4", "menu5","menu2_3" };
            if (menuler.Contains(c.Name) && c.Name != "menu2_1" && c.Name != "menu2_2")
            {
                menu.Location = new Point(0, c.Location.Y);
                menuBaslik.Text = c.Text;
            }
            Control cl = this.Controls[c.Name + "_Panel"];
            foreach (string item in menuler)
            {
                if (item != c.Name)
                    this.Controls[item + "_Panel"].Visible = false; 
            }
            if (galeri.Visible == true)
            {
                galeri.Controls.Clear();
                resimler.Clear();
                galeri.Visible = false;
            }

            menu4_icerik.Controls.Clear();
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

        private void menu2_1_Click(object sender, EventArgs e)
        {
            sayfaDegistir(menu2_1);
            ilan_sayfa.Text = "1";
            menu4_icerik.Controls.Clear();
            ilanResimleri.Clear();
            ilan_altPanel.Visible = false;

            comboBox3.SelectedIndex = 0;

            #region Yükleniyor
            Label lbl = new Label();
            lbl.Text = "Yükleniyor..";
            lbl.Size = new Size(menu4_icerik.Width - 10, 32);
            lbl.Location = new Point(5, 245);
            lbl.AutoSize = false;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.ForeColor = Color.Silver;
            lbl.Font = new Font("Microsoft Sans Serif", 12);
            menu4_icerik.Controls.Add(lbl);
            #endregion

            for (int i = 0; i < bag.ListLength("Images"); i++)
            {
                string[] veri = bag.ListGetByIndex("Images", i).ToString().Split(';');
                if (!ilanResimleri.ContainsKey(veri[0]))
                    ilanResimleri.Add(veri[0], Image.FromStream(new MemoryStream(Convert.FromBase64String(veri[1]))));
            }

            menu4_icerik.Controls.Clear();
            ilanlar2.Clear();
            if (comboBox3.SelectedIndex != 0)
            {
                foreach (var item in bag.HashGetAll("Advert"))
                {
                    if (item.Value.ToString().Split(';')[2] == comboBox3.SelectedItem.ToString())
                        ilanlar2.Add(item.Name, item.Value);
                }
            }
            else
            {
                foreach (var item in bag.HashGetAll("Advert"))
                { ilanlar2.Add(item.Name, item.Value); }
            }

            ilanListele(1);
            ilan_altPanel.Visible = true;
        }
        Dictionary<string, string> ilanlar2 = new Dictionary<string, string>();
        public void menu2_2_Click(object sender, EventArgs e)
        {
            sayfaDegistir(menu2_2);
        }

        private void menu3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu proje 191103021 Ayet Enes Alkuş, 191103024 Umut Savaş, 191103009 Engin Altun tarafından hazırlanmıştır.");
            sayfaDegistir(menu3);
        }
        private void menu4_Click(object sender, EventArgs e)
        {
            //sayfaDegistir(menu4);
        }

        private void menu5_Click(object sender, EventArgs e)
        {
            sayfaDegistir(menu5);
            vet_sayfa.Text = "1";
            menu5_icerik.Controls.Clear();
            vetfoto.Clear();
            vetAltpanel.Visible = false;

            #region Yükleniyor
            Label lbl = new Label();
            lbl.Text = "Yükleniyor..";
            lbl.Size = new Size(menu5_icerik.Width - 10, 32);
            lbl.Location = new Point(5, 245);
            lbl.AutoSize = false;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.ForeColor = Color.Silver;
            lbl.Font = new Font("Microsoft Sans Serif", 12);
            menu5_icerik.Controls.Add(lbl);
            #endregion
            for (int i = 0; i < bag.ListLength("VetImage"); i++)
            {
                string[] veri = bag.ListGetByIndex("VetImage", i).ToString().Split(';');
                if (!vetfoto.ContainsKey(veri[0]))
                    vetfoto.Add(veri[0], Image.FromStream(new MemoryStream(Convert.FromBase64String(veri[1]))));
            }

            menu5_icerik.Controls.Clear();
            vets = bag.HashGetAll("Vets");
            acilvet(1);
            vetAltpanel.Visible = true;
        }

        private void menu6_Click(object sender, EventArgs e)
        {
            Giris grs = new Giris(); grs.Show(); this.Close();           
        }
        private void sil_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("İlanınızı kaldırmak istediğinize emin misiniz?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                PictureBox p = (PictureBox)sender;
                bag.HashDelete("Advert", p.Tag.ToString());
                for (int i = 0; i < bag.ListLength("Images"); i++)
                {
                    string[] veri = bag.ListGetByIndex("Images", i).ToString().Split(';');
                    if (veri[0] == p.Tag.ToString()) bag.ListRemove("Images", veri[0] + ";" + veri[1]);
                }
                MessageBox.Show("İlanınız başarıyla kaldırıldı!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.InvokeOnClick(menu2_1, EventArgs.Empty);
            }
        }
        private void ilan_Click(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            string[] menuler = { "menu1", "menu2", "menu2_1", "menu2_2", "menu3", "menu4", "menu5" };
            foreach (string item in menuler)
            { this.Controls[item + "_Panel"].Visible = false; }
            menu4_icerik.Controls.Clear();
            menu2_3_Panel.Dock = DockStyle.Fill;
            menu2_3_Panel.BringToFront();
            menu2_3_Panel.Visible = true;
            menu2_3_ilanID.Text = c.Tag.ToString();
            RedisValue rv = bag.HashGet("Advert", c.Tag.ToString());
            if (rv.HasValue)
            {
                string[] kullaniciVerileri = bag.HashGet("Users", rv.ToString().Split(';')[8]).ToString().Split(';');
                menu2_3_hayvanAdi.Text = rv.ToString().Split(';')[1];
                menu2_3_hayvanTuru.Text = rv.ToString().Split(';')[2];
                menu2_3_hayvanCinsi.Text = rv.ToString().Split(';')[3];
                menu2_3_hayvanYasi.Text = rv.ToString().Split(';')[4];
                menu2_3_engelDurumu.Text = rv.ToString().Split(';')[5];
                menu2_3_iletisim.Text = rv.ToString().Split(';')[6];
                menu2_3_aciklama.Text = rv.ToString().Split(';')[7];
                menu2_3_kullaniciAdi.Text = "@" + rv.ToString().Split(';')[8];
                menu2_3_kullaniciIsim.Text = kullaniciVerileri[0];
                if (kullaniciVerileri[3] != "null")
                    menu2_3_kullaniciFoto.Image = Image.FromStream(new MemoryStream(Convert.FromBase64String(kullaniciVerileri[3])));

                galeri.Controls.Clear();
                resimler.Clear();
                galeri.Visible = true;
                long length = bag.ListLength("Images");
                if(length > 0) galeriLbl("Fotoğraf büyültmek için fotoğrafa tıklayınız");
                for (int i = 0; i < length; i++)
                {
                    string[] veri = bag.ListGetByIndex("Images", i).ToString().Split(';');
                    if (veri[0] == c.Tag.ToString())
                    {
                        PictureBox pb = new PictureBox();
                        pb.Name = "resim_" + i;
                        pb.Image = Image.FromStream(new MemoryStream(Convert.FromBase64String(veri[1])));
                        pb.SizeMode = PictureBoxSizeMode.Zoom;
                        pb.Size = new Size(galeri.Width - 50, galeri.Width - 50);
                        pb.BorderStyle = BorderStyle.FixedSingle;
                        pb.Cursor = Cursors.Hand;
                        pb.Click += buyult_Click;
                        if (galeri.Controls.Count > 2) pb.Location = new Point((galeri.Width / 2) - (pb.Size.Width / 2), galeri.Controls[galeri.Controls.Count - 1].Location.Y + galeri.Width - 40);
                        else pb.Location = new Point((galeri.Width / 2) - (pb.Size.Width / 2), 80);
                        galeri.Controls.Add(pb);
                    }
                }
            }
        }
        Dictionary<string, Image> ilanResimleri = new Dictionary<string, Image>();
        HashEntry[] ilanlar; int maxIlan = 5;
        void ilanListele(int syf)
        {
            menu4_icerik.Controls.Clear();
            ilan_sayfaBilgi.Text = "Toplam " + Math.Ceiling(decimal.Parse("" + (ilanlar2.Count / (float)maxIlan))) + " sayfa içerisinde " + syf + ". sayfayı görmektesiniz.";
            int sayfa = (syf * maxIlan);
            int genislik = menu4_icerik.Width;
            int i = 0;
            foreach (var item in ilanlar2)
            {
                i++;
                if (i >= (sayfa - maxIlan) && i <= ilanlar2.Count)
                {
                    if (i < sayfa)
                    {
                        ilan il = new ilan();
                        string[] veri = item.Value.ToString().Split(';');
                        il.ID = "#" + item.Key;
                        il.ilanBaslik.Tag = item.Key;
                        il.ilanFoto.Tag = item.Key;
                        il.sil.Tag = item.Key;
                        il.Baslik = veri[0];
                        il.Isim = veri[1];
                        il.Tur = veri[2];
                        il.Cins = veri[3];
                        il.Yas = veri[4];
                        il.EngelDurumu = veri[5];
                        il.Cinsiyet = "Belirsiz";
                        il.Konum = "Belirsiz";
                        il.Name = item.Key;
                        if (veri[8] == Genel.kad) il.sil.Visible = true;
                        il.Proje_Click(new EventHandler(ilan_Click));
                        il.sil_Click(new EventHandler(sil_Click));
                        if (ilanResimleri.ContainsKey(item.Key)) il.Fotograf = ilanResimleri[item.Key];
                        il.Width = genislik ;
                        if (menu4_icerik.Controls.Count > 0)
                            il.Location = new Point(10, menu4_icerik.Controls[menu4_icerik.Controls.Count - 1].Location.Y + il.Size.Height + 10);
                        else il.Location = new Point(10, 10);
                        menu4_icerik.Controls.Add(il);
                    }
                }
            }
        }
        public byte[] test(byte[] imageBytes)
        {
            using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                using (Image img = Image.FromStream(ms))
                {
                    if (img.Width > 500 || img.Height > 500)
                    {
                        float h = 500, w = 500;
                        if (img.Width > img.Height)
                            h = img.Height / (img.Width / 500f);
                        else if (img.Height > img.Width)
                            w = img.Width / (img.Height / 500f);

                        using (Bitmap b = new Bitmap(img, new Size((int)w, (int)h)))
                        {
                            using (MemoryStream ms2 = new MemoryStream())
                            {
                                b.Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg);
                                imageBytes = ms2.ToArray();
                            }
                        }
                    }
                }
            }
            return imageBytes;
        }

       

        private void ilan_sayfaIleri_Click(object sender, EventArgs e)
        {
            int sayfa = int.Parse(ilan_sayfa.Text);
            float max = ilanlar2.Count / (float)maxIlan;
            if (max > sayfa)
            {
                sayfa++;
                ilan_sayfa.Text = sayfa.ToString();
                ilanListele(sayfa);
                menu2_1_Panel.VerticalScroll.Value = 0;
            }
        }

        private void ilan_sayfaGeri_Click(object sender, EventArgs e)
        {
            int sayfa = int.Parse(ilan_sayfa.Text);
            if (sayfa > 1)
            {
                sayfa--;
                ilan_sayfa.Text = sayfa.ToString();
                ilanListele(sayfa);
                menu2_1_Panel.VerticalScroll.Value = 0;
            }
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
            if (resimler.Count > 0) galeriLbl("Fotoğraf kaldırmak için fotoğrafa tıklayınız");
            foreach (var item in resimler)
            {
                PictureBox pb = new PictureBox();
                pb.Name = item.Key;
                pb.Image = Image.FromFile(item.Value);
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Size = new Size(galeri.Width - 50, galeri.Width - 50);
                pb.BorderStyle = BorderStyle.FixedSingle;
                pb.Click += galeri_Click;
                pb.Cursor = Cursors.Hand;
                if (resimler.Count > 1) pb.Location = new Point((galeri.Width / 2) - (pb.Size.Width / 2), galeri.Controls[galeri.Controls.Count - 1].Location.Y + galeri.Width - 40);
                else pb.Location = new Point((galeri.Width / 2) - (pb.Size.Width / 2), 80);
                galeri.Controls.Add(pb);
            }
            if (galeri.Controls.Count < 1) galeri.Visible = false;
        }
        private void buyult_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            if (pb.Dock != DockStyle.Fill) { galeri.AutoScroll = false; galeri.Dock = DockStyle.Fill; galeri.Controls[galeri.Controls.IndexOfKey("galeriBaslik")].Visible = false; galeri.BringToFront(); pb.Dock = DockStyle.Fill; pb.BringToFront(); }
            else { galeri.AutoScroll = true; galeri.Dock = DockStyle.Right; menu2_3_Panel.BringToFront(); pb.Dock = DockStyle.None; galeri.Controls[galeri.Controls.IndexOfKey("galeriBaslik")].Visible = true; }
        }

        void galeriLbl(string yazi)
        {
            Panel pnl = new Panel();
            pnl.Size = new Size(0, 70);
            pnl.Dock = DockStyle.Top;
            pnl.Name = "galeriBaslik";
            galeri.Controls.Add(pnl);
            Label lbl = new Label();
            lbl.Text = yazi;
            lbl.Size = new Size(236, 50);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Location = new Point((galeri.Width / 2) - (lbl.Width / 2), 10);
            lbl.Anchor = (AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right;
            lbl.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lbl.ForeColor = Color.Gainsboro;
            pnl.Controls.Add(lbl);
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
                galeriLbl("Fotoğraf kaldırmak için fotoğrafa tıklayınız");
                for (int i = 0; i < DosyaYolu.Length; i++)
                {
                    PictureBox pb = new PictureBox();
                    pb.Name = "resim_" + (resimler.Count + 1);
                    resimler.Add(pb.Name, DosyaYolu[i]);
                    pb.Image = Image.FromFile(DosyaYolu[i]);
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    pb.Size = new Size(galeri.Width-50, galeri.Width-50);
                    pb.BorderStyle = BorderStyle.FixedSingle;
                    pb.Click += galeri_Click;
                    pb.Cursor = Cursors.Hand;
                    if (resimler.Count > 1) pb.Location = new Point((galeri.Width / 2) - (pb.Size.Width / 2), galeri.Controls[galeri.Controls.Count - 1].Location.Y + galeri.Width - 40);
                    else pb.Location = new Point((galeri.Width / 2) - (pb.Size.Width / 2), 80);
                    galeri.Controls.Add(pb);
                }
            }
          
        }

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
                        int r = int.Parse(bag.ListLength("Images").ToString());
                        bag.ListLeftPush("Images", id + ";" + Convert.ToBase64String(test(imageArray)));
                    }
                    bag.HashSet("Advert", id, ilanBaslik.Text + ";" + hayvanAdi.Text + ";"
                        + hayvanTuru.Text + ";" + hayvanCinsi.Text + ";" + hayvanYasi.Value + " " + hayvanYasi2.Text + ";"
                        + (engelDurumu.Checked ? "Yok" : "Var") + ";" + (iletisimBilgisi.Checked ? "Evet" : "Hayır") + ";"
                        + ilanAciklama.Text + ";" + Genel.kad);
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


        private void label14_Click(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 13)
                e.Handled = true;
            if (e.KeyChar == 13)
            {
                int max = (int)Math.Ceiling(decimal.Parse("" + (ilanlar.Length / (float)maxIlan)));
                int sayfa = int.Parse(ilan_sayfa.Text);
                if (max >= sayfa) ilanListele(sayfa);
                else { ilanListele(max); ilan_sayfa.Text = max.ToString(); }
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            ilan_sayfa.SelectAll();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All files (*.*)|*.*";
            ofd.RestoreDirectory = true;
            ofd.Title = "Fotoğrafları Seç";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                RedisValue rv = bag.HashGet("Users", Genel.kad);
                string[] veri = rv.ToString().Split(';');
                byte[] imageArray = System.IO.File.ReadAllBytes(ofd.FileName);
                string newPic = $"{veri[0]};{veri[1]};{veri[2]};{Convert.ToBase64String(test(imageArray))};";
                pictureBox4.Image = Image.FromStream(new MemoryStream(test(imageArray)));
                bag.HashSet("Users", Genel.kad, newPic);
            }
        }
        private void vet_Click(object sender, EventArgs e)
        {

            Control c = (Control)sender;
            string[] menuler = { "menu1", "menu2", "menu2_1", "menu2_2", "menu2_3", "menu3", "menu4", "menu5" };
            foreach (string item in menuler)
            { this.Controls[item + "_Panel"].Visible = false; }
            menu5_icerik.Controls.Clear();
            menu5_1panel.Dock = DockStyle.Fill;
            menu5_1panel.BringToFront();
            menu5_1panel.Visible = true;
            galeri.Controls.Clear();
            resimler.Clear();
            galeri.Visible = true;
            RedisValue rv = bag.HashGet("Vets", c.Tag.ToString());
            if (rv.HasValue)
            {
                menu5_1panel_klnksahip.Text = rv.ToString().Split(';')[0];
                menu5_1panel_klnkad.Text = rv.ToString().Split(';')[1];
                menu5_1panel_adres.Text = rv.ToString().Split(';')[2];
                menu5_1panel_iletisim.Text = rv.ToString().Split(';')[3];               
                galeri.Controls.Clear();
                resimler.Clear();
                galeri.Visible = true;

                for (int i = 0; i < bag.ListLength("VetImage"); i++)
                {
                    string[] veri = bag.ListGetByIndex("VetImage", i).ToString().Split(';');
                    if (veri[0]==c.Tag.ToString())
                    {
                        pictureBox1.Image = Image.FromStream(new MemoryStream(Convert.FromBase64String(veri[1])));
                        PictureBox pb = new PictureBox();
                        pb.Name = "resim_" + i;
                        pb.Image = Image.FromStream(new MemoryStream(Convert.FromBase64String(veri[1])));
                        pb.SizeMode = PictureBoxSizeMode.Zoom;
                        pb.Size = new Size(galeri.Width - 50, galeri.Width - 50);
                        pb.BorderStyle = BorderStyle.FixedSingle;
                        pb.Cursor = Cursors.Hand;
                      //  pb.Click += buyult_Click;
                        if (galeri.Controls.Count > 0) pb.Location = new Point((galeri.Width / 2) - (pb.Size.Width / 2), galeri.Controls[galeri.Controls.Count - 1].Location.Y + galeri.Width);
                        else pb.Location = new Point((galeri.Width / 2) - (pb.Size.Width / 2), 10);
                        galeri.Controls.Add(pb);
                    }
                   
                                            

                }

            }

        }
        Dictionary<string, Image> vetfoto = new Dictionary<string, Image>();
        HashEntry[] vets;int toplamvet=5;
         void acilvet(int vet)
        {
            menu5_icerik.Controls.Clear();
            vetSayfaBilgi.Text = "Toplam " + Math.Ceiling(decimal.Parse("" + (vets.Length / (float)toplamvet))) + " sayfa içerisinde " + vet + ". sayfayı görmektesiniz.";
            int sayfa = (vet * toplamvet);
            for (int i = sayfa - toplamvet; i < vets.Length; i++)
            {
                if (i < sayfa)
                {
                    acilvet vt = new acilvet();
                    string[] veri = vets[i].Value.ToString().Split(';');
                    vt.VETID = "#"+vets[i].Name;
                    vt.vetfoto.Tag= vets[i].Name;
                    vt.Klinikad = veri[0];
                    vt.Sahip = veri[1];
                    vt.Adres = veri[2];
                    vt.Telefon = veri[3];
                    vt.Vet_Click(new EventHandler(vet_Click));
                    if (vetfoto.ContainsKey(vets[i].Name)) vt.Fotograf = vetfoto[vets[i].Name];
                    vt.Width = menu5_icerik.Width-40;
                    if (menu5_icerik.Controls.Count > 0)
                        vt.Location = new Point(10, menu5_icerik.Controls[menu5_icerik.Controls.Count - 1].Location.Y + vt.Size.Height + 10);
                    else vt.Location = new Point(10, 10);
                    menu5_icerik.Controls.Add(vt);
                }
            }
        }

        private void vetSayfaGeri_Click(object sender, EventArgs e)
        {
            int sayfa = int.Parse(vet_sayfa.Text);
            if (sayfa > 1)
            {
                sayfa--;
                vet_sayfa.Text = sayfa.ToString();
                ilanListele(sayfa);
                menu5_Panel.VerticalScroll.Value = 0;
            }
        }

        private void vetSayfaİleri_Click(object sender, EventArgs e)
        {
            int sayfa = int.Parse(vet_sayfa.Text);
            float max = vets.Length / (float)toplamvet;
            if (max > sayfa)
            {
                sayfa++;
                vet_sayfa.Text = sayfa.ToString();
                ilanListele(sayfa);
                menu5_Panel.VerticalScroll.Value = 0;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ilanlar2.Clear();
            if (comboBox3.SelectedIndex != 0)
            {
                foreach (var item in bag.HashGetAll("Advert"))
                {
                    if (item.Value.ToString().Split(';')[2] == comboBox3.SelectedItem.ToString())
                        ilanlar2.Add(item.Name, item.Value);
                }
            }
            else
            {
                foreach (var item in bag.HashGetAll("Advert"))
                { ilanlar2.Add(item.Name, item.Value); }
            }
            ilanListele(1);
        }
    }
}
