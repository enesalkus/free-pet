using StackExchange.Redis;
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
    public partial class Kayit : Form
    {
        public Kayit()
        {
            InitializeComponent();
        }

        static readonly ConnectionMultiplexer muxer = ConnectionMultiplexer.Connect(Genel.connString);
        IDatabase bag = muxer.GetDatabase();

        void temizle()
        {
            k_sifretekrar.Clear();
            k_sifre.Clear();
            k_kullaniciadi.Clear();
            k_eposta.Clear();
            k_adsoyad.Clear();
        }
        private void panel1_Click(object sender, EventArgs e)
        {
            if (k_adsoyad.Text != "" && k_eposta.Text != "" && k_kullaniciadi.Text != "" && k_sifre.Text != "")
            {
                if (k_sifre.Text == k_sifretekrar.Text)
                {
                    RedisValue rv1 = bag.HashGet("Users", k_kullaniciadi.Text);
                    if (!rv1.HasValue)
                    {
                        string veri = k_adsoyad.Text + ";" + k_sifre.Text + ";" + k_eposta.Text + ";";
                        bag.HashSet("Users", k_kullaniciadi.Text, veri);
                        Genel.kad = k_kullaniciadi.Text;
                        Genel.sifre = k_sifre.Text;
                        Genel.adsoyad = k_adsoyad.Text;
                        Genel.eposta = k_eposta.Text;
                        temizle();
                        lbl_hata.Text = "Kayıt başarılı";
                        Form2 frm2 = new Form2();
                        frm2.Show();
                        Hide();

                    }
                    else lbl_hata.Text = "Böyle Bir Kullanıcı Zaten Mevcut.";
                }
                else lbl_hata.Text = "Şifreler Uyuşmuyor.";
            }
            else
            {
                temizle();
                lbl_hata.Text = "Lütfen Tüm Alanları Doldurun.";
            }
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            Panel pl = (Panel)sender;
            if (pl.Name == "facebook") System.Diagnostics.Process.Start("https://www.fb.com");
            else if (pl.Name == "discord") System.Diagnostics.Process.Start("https://www.discord.com");
            else if (pl.Name == "twitter") System.Diagnostics.Process.Start("https://www.twitter.com");
            else if (pl.Name == "instagram") System.Diagnostics.Process.Start("https://www.instagram.com");
        }
        private void panel2_Click(object sender, EventArgs e)
        {
            Giris grs = new Giris();
            grs.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
