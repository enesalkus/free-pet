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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        static readonly ConnectionMultiplexer muxer = ConnectionMultiplexer.Connect(Genel.connString);
        IDatabase bag = muxer.GetDatabase();

        private void Giris_Load(object sender, EventArgs e)
        {

        }
        private void panel3_Click(object sender, EventArgs e)
        {
            Panel pl = (Panel)sender;
            if (pl.Name=="facebook") System.Diagnostics.Process.Start("https://www.fb.com");
            else if (pl.Name == "discord") System.Diagnostics.Process.Start("https://www.discord.com");
            else if (pl.Name == "twitter") System.Diagnostics.Process.Start("https://www.twitter.com");
            else if (pl.Name == "instagram") System.Diagnostics.Process.Start("https://www.instagram.com");
        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        void girisYap()
        {

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string kad = textBox1.Text, pass = textBox2.Text;
                RedisValue rv = bag.HashGet("Users", kad);
                if (rv.HasValue)
                {
                    if (rv.ToString().Split(';')[1] == pass)
                    {
                        Genel.kad = kad;
                        Genel.sifre = pass;
                        Genel.adsoyad = rv.ToString().Split(';')[0];
                        Genel.eposta = rv.ToString().Split(';')[2];
                        if (rv.ToString().Split(';').Length >= 3 && rv.ToString().Split(';')[3] != "")
                            Genel.profil = Image.FromStream(new MemoryStream(Convert.FromBase64String(rv.ToString().Split(';')[3])));
                        Form2 frm2 = new Form2();
                        frm2.Show();
                        lbl_hata.Text = " ";
                        Hide();
                    }
                    else {lbl_hata.Text = "Şifreniz yanlış, lütfen tekrar deneyiniz.";}

                }
                else {lbl_hata.Text = "Böyle bir kullanıcı bulunamadı.";}
                
            }
            else {lbl_hata.Text = "Lütfen tüm alanları doldurunuz.";}
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            girisYap();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) girisYap();

        }
    }
}
