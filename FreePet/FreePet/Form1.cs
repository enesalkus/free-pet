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
using StackExchange;
using StackExchange.Redis;

namespace FreePet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static readonly ConnectionMultiplexer muxer = ConnectionMultiplexer.Connect(Genel.connString);
        IDatabase bag = muxer.GetDatabase();

        void girisGetir()
        {
            panel1.Dock = DockStyle.Fill;
            panel1.BringToFront();
            panel1.Visible = true;
            panel2.Visible = false;
        }



        void kayitGetir()
        {
            panel2.Dock = DockStyle.Fill;
            panel2.BringToFront();
            panel2.Visible = true;
            panel1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            girisGetir();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        void girisYap()
        {

            if (textBox1.Text != "" && textBox2.Text != "" && textBox1.Text != "Kullanıcı Adı" && textBox2.Text != "Şifre")
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
                        if (rv.ToString().Split(';')[3] != "null")
                            Genel.profil = Image.FromStream(new MemoryStream(Convert.FromBase64String(rv.ToString().Split(';')[3])));
                        MessageBox.Show("Giriş Başarılı");
                        Form2 frm2 = new Form2();
                        frm2.Show();
                        Hide();
                    }
                    else MessageBox.Show("Şifreniz yanlış, lütfen tekrar deneyiniz.");
                }
                else MessageBox.Show("Böyle bir kullanıcı bulunamadı");
                textBox1.Text = "Kullanıcı Adı";
                textBox2.Text = "Şifre";
            }
            else MessageBox.Show("Lütfen tüm alanları doldurunuz.");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            girisYap();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            t.ForeColor = Color.Silver;
            if (t.Name == "textBox1" && t.Text == "Kullanıcı Adı") textBox1.Clear();
            else if (t.Name == "textBox2" && t.Text == "Şifre")
            {
                textBox2.PasswordChar = '●';
                textBox2.Font = new Font(textBox2.Font.Name, 8, textBox2.Font.Style);
                textBox2.Clear();
            }
            else if (t.Name == "k_adsoyad" && t.Text == "Ad Soyad") k_adsoyad.Clear();
            else if (t.Name == "k_eposta" && t.Text == "E Posta") k_eposta.Clear();
            else if (t.Name == "k_kullaniciadi" && t.Text == "Kullanıcı Adı") k_kullaniciadi.Clear();
            else if (t.Name == "k_sifre" && t.Text == "Şifre") k_sifre.Clear();
            else if (t.Name == "k_sifretekrar" && t.Text == "Şifre Tekrar") k_sifretekrar.Clear();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (t.Text == "" && t.Name == "textBox1") textBox1.Text = "Kullanıcı Adı";
            else if (t.Text == "" && t.Name == "textBox2")
            {
                textBox2.PasswordChar = '\0';
                textBox2.Font = new Font(textBox2.Font.Name, 11, textBox2.Font.Style);
                textBox2.Text = "Şifre";
            }
            else if (t.Text == "" && t.Name == "k_adsoyad") k_adsoyad.Text = "Ad Soyad";
            else if (t.Text == "" && t.Name == "k_eposta") k_eposta.Text = "E Posta";
            else if (t.Text == "" && t.Name == "k_kullaniciadi") k_kullaniciadi.Text = "Kullanıcı Adı";
            else if (t.Text == "" && t.Name == "k_sifre") k_sifre.Text = "Şifre";
            else if (t.Text == "" && t.Name == "k_sifretekrar") k_sifretekrar.Text = "Şifre Tekrar";
            if (t.Text == "Ad Soyad" || t.Text == "Şifre" || t.Text == "Şifre Tekrar" || t.Text == "E Posta" || t.Text == "Kullanıcı Adı")
                t.ForeColor = Color.Silver;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("test");
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                girisYap();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            kayitGetir();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            girisGetir();
        }

        void temizle()
        {
            k_sifretekrar.Clear();
            k_sifre.Clear();
            k_kullaniciadi.Clear();
            k_eposta.Clear();
            k_adsoyad.Clear();
            k_sifretekrar.Text = "Şifre Tekrar";
            k_sifre.Text = "Şifre";
            k_kullaniciadi.Text = "Kullanıcı Adı";
            k_eposta.Text = "E Posta";
            k_adsoyad.Text = "Ad Soyad";
            k_sifretekrar.ForeColor = Color.Silver;
            k_sifre.ForeColor = Color.Silver;
            k_kullaniciadi.ForeColor = Color.Silver;
            k_eposta.ForeColor = Color.Silver;
            k_adsoyad.ForeColor = Color.Silver;
        }
        private void button2_Click_1(object sender, EventArgs e)
        {

            if (k_adsoyad.Text != "" && k_eposta.Text != "" && k_kullaniciadi.Text != "" && k_sifre.Text != "" &&
                k_adsoyad.Text != "Ad Soyad" && k_eposta.Text != "E Posta" && k_kullaniciadi.Text != "Kullanıcı Adı" && k_sifre.Text != "Şifre" && k_sifretekrar.Text != "Şifre Tekrar")
            {
                if (k_sifre.Text == k_sifretekrar.Text)
                {
                    RedisValue rv1 = bag.HashGet("Users", k_kullaniciadi.Text);
                    if (!rv1.HasValue)
                    {
                        string veri = k_adsoyad.Text + ";" + k_sifre.Text + ";" + k_eposta.Text + ";null";
                        bag.HashSet("Users", k_kullaniciadi.Text, veri);
                        Genel.kad = k_kullaniciadi.Text;
                        Genel.sifre = k_sifre.Text;
                        Genel.adsoyad = k_adsoyad.Text;
                        Genel.eposta = k_eposta.Text;
                        temizle();
                        MessageBox.Show("Kayıt başarılı");
                        Form2 frm2 = new Form2();
                        frm2.Show();
                        Hide();

                    }
                    else MessageBox.Show("Böyle Bir Kullanıcı Zaten Mevcut.");
                }
                else MessageBox.Show("Şifreler Uyuşmuyor.");
            }
            else
            {
                temizle();
                MessageBox.Show("Lütfen Tüm Alanları Doldurun.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
