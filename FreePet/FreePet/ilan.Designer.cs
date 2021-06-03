
namespace FreePet
{
    partial class ilan
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ilan));
            this.ilanFoto = new System.Windows.Forms.PictureBox();
            this.yas = new System.Windows.Forms.Label();
            this.cinsiyet = new System.Windows.Forms.Label();
            this.tur = new System.Windows.Forms.Label();
            this.engelDurum = new System.Windows.Forms.Label();
            this.cins = new System.Windows.Forms.Label();
            this.isim = new System.Windows.Forms.Label();
            this.ilanNo = new System.Windows.Forms.Label();
            this.yas1 = new System.Windows.Forms.Label();
            this.cinsiyet1 = new System.Windows.Forms.Label();
            this.tur1 = new System.Windows.Forms.Label();
            this.engelDurum1 = new System.Windows.Forms.Label();
            this.cins1 = new System.Windows.Forms.Label();
            this.isim1 = new System.Windows.Forms.Label();
            this.konum = new System.Windows.Forms.Label();
            this.konum1 = new System.Windows.Forms.Label();
            this.ilanBaslik = new System.Windows.Forms.LinkLabel();
            this.sil = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ilanFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sil)).BeginInit();
            this.SuspendLayout();
            // 
            // ilanFoto
            // 
            this.ilanFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ilanFoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ilanFoto.Location = new System.Drawing.Point(5, 5);
            this.ilanFoto.Margin = new System.Windows.Forms.Padding(4);
            this.ilanFoto.Name = "ilanFoto";
            this.ilanFoto.Size = new System.Drawing.Size(180, 180);
            this.ilanFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ilanFoto.TabIndex = 0;
            this.ilanFoto.TabStop = false;
            // 
            // yas
            // 
            this.yas.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yas.Location = new System.Drawing.Point(213, 57);
            this.yas.Name = "yas";
            this.yas.Size = new System.Drawing.Size(123, 22);
            this.yas.TabIndex = 1;
            this.yas.Text = "Yaşı :";
            this.yas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cinsiyet
            // 
            this.cinsiyet.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cinsiyet.Location = new System.Drawing.Point(213, 88);
            this.cinsiyet.Name = "cinsiyet";
            this.cinsiyet.Size = new System.Drawing.Size(123, 22);
            this.cinsiyet.TabIndex = 1;
            this.cinsiyet.Text = "Cinsiyeti :";
            this.cinsiyet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tur
            // 
            this.tur.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tur.Location = new System.Drawing.Point(213, 119);
            this.tur.Name = "tur";
            this.tur.Size = new System.Drawing.Size(123, 22);
            this.tur.TabIndex = 1;
            this.tur.Text = "Türü :";
            this.tur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // engelDurum
            // 
            this.engelDurum.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.engelDurum.Location = new System.Drawing.Point(213, 150);
            this.engelDurum.Name = "engelDurum";
            this.engelDurum.Size = new System.Drawing.Size(123, 22);
            this.engelDurum.TabIndex = 1;
            this.engelDurum.Text = "Engel Durumu :";
            this.engelDurum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cins
            // 
            this.cins.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cins.Location = new System.Drawing.Point(470, 57);
            this.cins.Name = "cins";
            this.cins.Size = new System.Drawing.Size(73, 22);
            this.cins.TabIndex = 1;
            this.cins.Text = "Cinsi :";
            this.cins.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // isim
            // 
            this.isim.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.isim.Location = new System.Drawing.Point(470, 88);
            this.isim.Name = "isim";
            this.isim.Size = new System.Drawing.Size(73, 22);
            this.isim.TabIndex = 1;
            this.isim.Text = "İsimi :";
            this.isim.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ilanNo
            // 
            this.ilanNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ilanNo.ForeColor = System.Drawing.Color.Gray;
            this.ilanNo.Location = new System.Drawing.Point(655, 163);
            this.ilanNo.Name = "ilanNo";
            this.ilanNo.Size = new System.Drawing.Size(79, 24);
            this.ilanNo.TabIndex = 2;
            this.ilanNo.Text = "000000";
            this.ilanNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // yas1
            // 
            this.yas1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.yas1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yas1.ForeColor = System.Drawing.Color.Yellow;
            this.yas1.Location = new System.Drawing.Point(342, 57);
            this.yas1.Name = "yas1";
            this.yas1.Size = new System.Drawing.Size(122, 22);
            this.yas1.TabIndex = 1;
            this.yas1.Text = "-";
            this.yas1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cinsiyet1
            // 
            this.cinsiyet1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cinsiyet1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cinsiyet1.ForeColor = System.Drawing.Color.Yellow;
            this.cinsiyet1.Location = new System.Drawing.Point(342, 88);
            this.cinsiyet1.Name = "cinsiyet1";
            this.cinsiyet1.Size = new System.Drawing.Size(122, 22);
            this.cinsiyet1.TabIndex = 1;
            this.cinsiyet1.Text = "-";
            this.cinsiyet1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tur1
            // 
            this.tur1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tur1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tur1.ForeColor = System.Drawing.Color.Yellow;
            this.tur1.Location = new System.Drawing.Point(342, 119);
            this.tur1.Name = "tur1";
            this.tur1.Size = new System.Drawing.Size(122, 22);
            this.tur1.TabIndex = 1;
            this.tur1.Text = "-";
            this.tur1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // engelDurum1
            // 
            this.engelDurum1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.engelDurum1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.engelDurum1.ForeColor = System.Drawing.Color.Yellow;
            this.engelDurum1.Location = new System.Drawing.Point(342, 150);
            this.engelDurum1.Name = "engelDurum1";
            this.engelDurum1.Size = new System.Drawing.Size(122, 22);
            this.engelDurum1.TabIndex = 1;
            this.engelDurum1.Text = "-";
            this.engelDurum1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cins1
            // 
            this.cins1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cins1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cins1.ForeColor = System.Drawing.Color.Yellow;
            this.cins1.Location = new System.Drawing.Point(549, 57);
            this.cins1.Name = "cins1";
            this.cins1.Size = new System.Drawing.Size(153, 22);
            this.cins1.TabIndex = 1;
            this.cins1.Text = "-";
            this.cins1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // isim1
            // 
            this.isim1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.isim1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.isim1.ForeColor = System.Drawing.Color.Yellow;
            this.isim1.Location = new System.Drawing.Point(549, 88);
            this.isim1.Name = "isim1";
            this.isim1.Size = new System.Drawing.Size(153, 22);
            this.isim1.TabIndex = 1;
            this.isim1.Text = "-";
            this.isim1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // konum
            // 
            this.konum.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.konum.Location = new System.Drawing.Point(470, 119);
            this.konum.Name = "konum";
            this.konum.Size = new System.Drawing.Size(73, 22);
            this.konum.TabIndex = 1;
            this.konum.Text = "Konumu :";
            this.konum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // konum1
            // 
            this.konum1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.konum1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.konum1.ForeColor = System.Drawing.Color.Yellow;
            this.konum1.Location = new System.Drawing.Point(549, 119);
            this.konum1.Name = "konum1";
            this.konum1.Size = new System.Drawing.Size(153, 22);
            this.konum1.TabIndex = 1;
            this.konum1.Text = "-";
            this.konum1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ilanBaslik
            // 
            this.ilanBaslik.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(90)))), ((int)(((byte)(0)))));
            this.ilanBaslik.AutoSize = true;
            this.ilanBaslik.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.ilanBaslik.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.ilanBaslik.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ilanBaslik.Location = new System.Drawing.Point(213, 16);
            this.ilanBaslik.Name = "ilanBaslik";
            this.ilanBaslik.Size = new System.Drawing.Size(95, 22);
            this.ilanBaslik.TabIndex = 3;
            this.ilanBaslik.TabStop = true;
            this.ilanBaslik.Text = "İlan Başlık";
            this.ilanBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sil
            // 
            this.sil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sil.Image = ((System.Drawing.Image)(resources.GetObject("sil.Image")));
            this.sil.Location = new System.Drawing.Point(698, 4);
            this.sil.Name = "sil";
            this.sil.Size = new System.Drawing.Size(35, 35);
            this.sil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sil.TabIndex = 4;
            this.sil.TabStop = false;
            this.sil.Visible = false;
            // 
            // ilan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.sil);
            this.Controls.Add(this.ilanBaslik);
            this.Controls.Add(this.ilanNo);
            this.Controls.Add(this.engelDurum1);
            this.Controls.Add(this.engelDurum);
            this.Controls.Add(this.konum1);
            this.Controls.Add(this.isim1);
            this.Controls.Add(this.konum);
            this.Controls.Add(this.isim);
            this.Controls.Add(this.cins1);
            this.Controls.Add(this.cins);
            this.Controls.Add(this.tur1);
            this.Controls.Add(this.tur);
            this.Controls.Add(this.cinsiyet1);
            this.Controls.Add(this.cinsiyet);
            this.Controls.Add(this.yas1);
            this.Controls.Add(this.yas);
            this.Controls.Add(this.ilanFoto);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ilan";
            this.Size = new System.Drawing.Size(737, 192);
            this.Load += new System.EventHandler(this.ilan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ilanFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label yas;
        private System.Windows.Forms.Label cinsiyet;
        private System.Windows.Forms.Label tur;
        private System.Windows.Forms.Label engelDurum;
        private System.Windows.Forms.Label cins;
        private System.Windows.Forms.Label isim;
        private System.Windows.Forms.Label ilanNo;
        private System.Windows.Forms.Label yas1;
        private System.Windows.Forms.Label cinsiyet1;
        private System.Windows.Forms.Label tur1;
        private System.Windows.Forms.Label engelDurum1;
        private System.Windows.Forms.Label cins1;
        private System.Windows.Forms.Label isim1;
        private System.Windows.Forms.Label konum;
        private System.Windows.Forms.Label konum1;
        public System.Windows.Forms.LinkLabel ilanBaslik;
        public System.Windows.Forms.PictureBox ilanFoto;
        public System.Windows.Forms.PictureBox sil;
    }
}
