using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        static readonly ConnectionMultiplexer muxer = ConnectionMultiplexer.Connect("185.93.69.87:6379,password=");
        IDatabase bag = muxer.GetDatabase();

        private void Form1_Load(object sender, EventArgs e)
        {
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
                        MessageBox.Show("Giriş Başarılı");
                        Form2 frm2 = new Form2();
                        frm2.Show();
                        Hide();
                    }
                    else MessageBox.Show("Şifreniz yanlış, lütfen tekrar deneyiniz.");
                }
                else MessageBox.Show("Böyle bir kullanıcı bulunamadı");
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
            if (t.Text == "Kullanıcı Adı") textBox1.Clear();
            else if (t.Text == "Şifre") textBox2.Clear();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (t.Text == "" && t.Name == "textBox1") textBox1.Text = "Kullanıcı Adı";
            else if (t.Text == "" && t.Name == "textBox2") textBox2.Text = "Şifre";
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
            panel2.Dock = DockStyle.Fill;
            panel2.BringToFront();
            panel2.Visible = true;
            panel1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Dock = DockStyle.Fill;
            panel1.BringToFront();
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            if(k_adsoyad.Text!="" && k_eposta.Text!="" && k_kullaniciadi.Text!="" && k_sifre.Text!="")
            {
                if(k_sifre.Text == k_sifretekrar.Text)
                {
                    RedisValue rv1 = bag.HashGet("Users",k_kullaniciadi.Text);
                    if (!rv1.HasValue)
                    {
                        string veri = k_adsoyad.Text + ";" + k_sifre.Text+";"+k_eposta.Text;
                        bag.HashSet("Users", k_kullaniciadi.Text,veri);
                    }
                    else MessageBox.Show("Böyle Bir Kullanıcı Zaten Mevcut.");
                }
                else MessageBox.Show("Şifreler Uyuşmuyor.");
            }
            else MessageBox.Show("Lütfen Tüm Alanları Doldurun.");




        }
    }
}
