namespace projekfix
{
    partial class VarianprodukAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.dgvVarian = new System.Windows.Forms.DataGridView();
            this.txtJumlah = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHargaJual = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWarna = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ID_Pemasok = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtCariVarian = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblAdminNama = new System.Windows.Forms.Label();
            this.cmbIdProduk = new System.Windows.Forms.ComboBox();
            this.txtIdVarian = new System.Windows.Forms.TextBox();
            this.txtUkuran = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVarian)).BeginInit();
            this.panelSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHapus
            // 
            this.btnHapus.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnHapus.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHapus.Location = new System.Drawing.Point(608, 176);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 29);
            this.btnHapus.TabIndex = 61;
            this.btnHapus.Text = "HAPUS";
            this.btnHapus.UseVisualStyleBackColor = false;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEdit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEdit.Location = new System.Drawing.Point(491, 176);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 29);
            this.btnEdit.TabIndex = 60;
            this.btnEdit.Text = "EDIT";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSimpan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSimpan.Location = new System.Drawing.Point(377, 176);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 29);
            this.btnSimpan.TabIndex = 59;
            this.btnSimpan.Text = "SIMPAN";
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // dgvVarian
            // 
            this.dgvVarian.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVarian.Location = new System.Drawing.Point(254, 242);
            this.dgvVarian.Margin = new System.Windows.Forms.Padding(2);
            this.dgvVarian.Name = "dgvVarian";
            this.dgvVarian.RowHeadersWidth = 62;
            this.dgvVarian.RowTemplate.Height = 28;
            this.dgvVarian.Size = new System.Drawing.Size(991, 428);
            this.dgvVarian.TabIndex = 58;
            // 
            // txtJumlah
            // 
            this.txtJumlah.Location = new System.Drawing.Point(693, 120);
            this.txtJumlah.Multiline = true;
            this.txtJumlah.Name = "txtJumlah";
            this.txtJumlah.Size = new System.Drawing.Size(64, 20);
            this.txtJumlah.TabIndex = 57;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(691, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 56;
            this.label6.Text = "Jumlah";
            // 
            // txtHargaJual
            // 
            this.txtHargaJual.Location = new System.Drawing.Point(615, 120);
            this.txtHargaJual.Multiline = true;
            this.txtHargaJual.Name = "txtHargaJual";
            this.txtHargaJual.Size = new System.Drawing.Size(64, 20);
            this.txtHargaJual.TabIndex = 55;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(613, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Harga Jual";
            // 
            // txtWarna
            // 
            this.txtWarna.Location = new System.Drawing.Point(533, 120);
            this.txtWarna.Multiline = true;
            this.txtWarna.Name = "txtWarna";
            this.txtWarna.Size = new System.Drawing.Size(64, 20);
            this.txtWarna.TabIndex = 53;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(531, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 52;
            this.label4.Text = "Warna";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(451, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Ukuran";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "ID Produk";
            // 
            // ID_Pemasok
            // 
            this.ID_Pemasok.AutoSize = true;
            this.ID_Pemasok.Location = new System.Drawing.Point(251, 98);
            this.ID_Pemasok.Name = "ID_Pemasok";
            this.ID_Pemasok.Size = new System.Drawing.Size(51, 13);
            this.ID_Pemasok.TabIndex = 46;
            this.ID_Pemasok.Text = "ID Varian";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(494, 55);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(53, 25);
            this.textBox1.TabIndex = 45;
            this.textBox1.Text = "Filter";
            // 
            // txtCariVarian
            // 
            this.txtCariVarian.Location = new System.Drawing.Point(254, 55);
            this.txtCariVarian.Multiline = true;
            this.txtCariVarian.Name = "txtCariVarian";
            this.txtCariVarian.Size = new System.Drawing.Size(236, 25);
            this.txtCariVarian.TabIndex = 44;
            this.txtCariVarian.Text = "Cari";
            this.txtCariVarian.TextChanged += new System.EventHandler(this.txtCariVarian_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(261, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 24);
            this.label1.TabIndex = 43;
            this.label1.Text = "VARIAN PRODUK";
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.SystemColors.Control;
            this.panelSidebar.Controls.Add(this.button5);
            this.panelSidebar.Controls.Add(this.button4);
            this.panelSidebar.Controls.Add(this.button3);
            this.panelSidebar.Controls.Add(this.button2);
            this.panelSidebar.Controls.Add(this.button1);
            this.panelSidebar.Controls.Add(this.lblAdminNama);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(220, 681);
            this.panelSidebar.TabIndex = 42;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Location = new System.Drawing.Point(29, 173);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(148, 23);
            this.button5.TabIndex = 10;
            this.button5.Text = "DETAIL PEMBELIAN";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Location = new System.Drawing.Point(29, 144);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(148, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "INPUT PEMASOK";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(29, 115);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(148, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "INPUT PRODUK";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(29, 86);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "LAPORAN PENJUALAN";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(29, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "VARIAN PRODUK";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lblAdminNama
            // 
            this.lblAdminNama.AutoSize = true;
            this.lblAdminNama.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminNama.Location = new System.Drawing.Point(25, 25);
            this.lblAdminNama.Name = "lblAdminNama";
            this.lblAdminNama.Size = new System.Drawing.Size(0, 20);
            this.lblAdminNama.TabIndex = 0;
            // 
            // cmbIdProduk
            // 
            this.cmbIdProduk.FormattingEnabled = true;
            this.cmbIdProduk.Location = new System.Drawing.Point(333, 120);
            this.cmbIdProduk.Margin = new System.Windows.Forms.Padding(2);
            this.cmbIdProduk.Name = "cmbIdProduk";
            this.cmbIdProduk.Size = new System.Drawing.Size(65, 21);
            this.cmbIdProduk.TabIndex = 63;
            // 
            // txtIdVarian
            // 
            this.txtIdVarian.Location = new System.Drawing.Point(226, 121);
            this.txtIdVarian.Name = "txtIdVarian";
            this.txtIdVarian.Size = new System.Drawing.Size(100, 20);
            this.txtIdVarian.TabIndex = 65;
            // 
            // txtUkuran
            // 
            this.txtUkuran.Location = new System.Drawing.Point(427, 121);
            this.txtUkuran.Name = "txtUkuran";
            this.txtUkuran.Size = new System.Drawing.Size(100, 20);
            this.txtUkuran.TabIndex = 66;
            // 
            // VarianprodukAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.txtUkuran);
            this.Controls.Add(this.txtIdVarian);
            this.Controls.Add(this.cmbIdProduk);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.dgvVarian);
            this.Controls.Add(this.txtJumlah);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtHargaJual);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtWarna);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ID_Pemasok);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtCariVarian);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelSidebar);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "VarianprodukAdmin";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvVarian)).EndInit();
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.DataGridView dgvVarian;
        private System.Windows.Forms.TextBox txtJumlah;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtHargaJual;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtWarna;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ID_Pemasok;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtCariVarian;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Label lblAdminNama;
        private System.Windows.Forms.ComboBox cmbIdProduk;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtIdVarian;
        private System.Windows.Forms.TextBox txtUkuran;
    }
}

