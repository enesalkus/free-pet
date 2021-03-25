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
        }

        public void sayfaDegistir(Control c)
        {
            string[] menuler = { "menu1", "menu2", "menu2_1", "menu2_2", "menu3", "menu4", "menu5" };
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
            ilanlar = bag.HashGetAll("Advert");
            ilanListele(1);
            ilan_altPanel.Visible = true;
        }

        public void menu2_2_Click(object sender, EventArgs e)
        {
            sayfaDegistir(menu2_2);
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
                menu2_3_hayvanAdi.Text = rv.ToString().Split(';')[1];
                menu2_3_hayvanTuru.Text = rv.ToString().Split(';')[2];
                menu2_3_hayvanCinsi.Text = rv.ToString().Split(';')[3];
                menu2_3_hayvanYasi.Text = rv.ToString().Split(';')[4];
                menu2_3_engelDurumu.Text = rv.ToString().Split(';')[5];
                menu2_3_iletisim.Text = rv.ToString().Split(';')[6];
                menu2_3_aciklama.Text = rv.ToString().Split(';')[7];

                galeri.Controls.Clear();
                resimler.Clear();
                galeri.Visible = true;

                for (int i = 0; i < bag.ListLength("Images"); i++)
                {
                    string[] veri = bag.ListGetByIndex("Images", i).ToString().Split(';');
                    if (veri[0] == c.Tag.ToString())
                    {
                        PictureBox pb = new PictureBox();
                        pb.Name = "resim_" + i;
                        pb.Image = Image.FromStream(new MemoryStream(Convert.FromBase64String(veri[1])));
                        pb.SizeMode = PictureBoxSizeMode.Zoom;
                        pb.Size = new Size(galeri.Width - 25, galeri.Width - 25);
                        pb.BorderStyle = BorderStyle.FixedSingle;
                        pb.Cursor = Cursors.Hand;
                        if (galeri.Controls.Count > 1) pb.Location = new Point(0, galeri.Controls[galeri.Controls.Count - 1].Location.Y + 10 + galeri.Width);
                        else pb.Location = new Point(0, 10);
                        galeri.Controls.Add(pb);
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
                    int h = 180, w = 180;
                    if (img.Width > img.Height)
                        h = img.Height / (img.Width / 180);
                    else if (img.Height > img.Width)
                        w = img.Width / (img.Height / 180);

                    using (Bitmap b = new Bitmap(img, new Size(w, h)))
                    {
                        using (MemoryStream ms2 = new MemoryStream())
                        {
                            b.Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg);
                            imageBytes = ms2.ToArray();
                        }
                    }
                }
            }
            return imageBytes;
        }

        Dictionary<string, Image> ilanResimleri = new Dictionary<string, Image>();
        HashEntry[] ilanlar; int maxIlan = 5;
        void ilanListele(int syf)
        {
            menu4_icerik.Controls.Clear();
            
            ilan_sayfaBilgi.Text = "Toplam " + Math.Ceiling(decimal.Parse("" + (ilanlar.Length / (float)maxIlan))) + " sayfa içerisinde " + syf + ". sayfayı görmektesiniz.";
            int sayfa = (syf * maxIlan);
            for (int i = sayfa - maxIlan; i < ilanlar.Length; i++)
            {
                if (i < sayfa)
                {
                    ilan il = new ilan();
                    string[] veri = ilanlar[i].Value.ToString().Split(';');
                    il.ID = "#" + ilanlar[i].Name;
                    il.ilanBaslik.Tag = ilanlar[i].Name;
                    il.ilanFoto.Tag = ilanlar[i].Name;
                    il.Baslik = veri[0];
                    il.Isim = veri[1];
                    il.Tur = veri[2];
                    il.Cins = veri[3];
                    il.Yas = veri[4];
                    il.EngelDurumu = veri[5];
                    il.Cinsiyet = "Belirsiz";
                    il.Konum = "Belirsiz";
                    il.Name = ilanlar[i].Name;
                    il.Proje_Click(new EventHandler(ilan_Click));
                    if (ilanResimleri.ContainsKey(ilanlar[i].Name)) il.Fotograf = ilanResimleri[ilanlar[i].Name];
                    il.Width = menu4_icerik.Width - 40;
                    if (menu4_icerik.Controls.Count > 0)
                        il.Location = new Point(10, menu4_icerik.Controls[menu4_icerik.Controls.Count - 1].Location.Y + il.Size.Height + 10);
                    else il.Location = new Point(10, 10);
                    menu4_icerik.Controls.Add(il);
                }
            }
        }

        private void ilan_sayfaIleri_Click(object sender, EventArgs e)
        {
            int sayfa = int.Parse(ilan_sayfa.Text);
            float max = ilanlar.Length / (float)maxIlan;
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

        static readonly ConnectionMultiplexer muxer = ConnectionMultiplexer.Connect("185.255.93.52:6379,password=");
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
                        bag.ListInsertAfter("Images", bag.ListGetByIndex("Images", bag.ListLength("Images") - 1), id + ";" + Convert.ToBase64String(test(imageArray)));
                    }
                    bag.HashSet("Advert", id, ilanBaslik.Text + ";" + hayvanAdi.Text + ";"
                        + hayvanTuru.Text + ";" + hayvanCinsi.Text + ";" + hayvanYasi.Value + " " + hayvanYasi2.Text + ";"
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

    }
}
