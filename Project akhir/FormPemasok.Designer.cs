namespace distro
{
    partial class FormPemasok
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
            this.lblNamaAdmin = new System.Windows.Forms.Label();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.btnVarianProduk = new System.Windows.Forms.Button();
            this.btnInputProduk = new System.Windows.Forms.Button();
            this.btnDetailPembelian = new System.Windows.Forms.Button();
            this.btnLaporanPenjualan = new System.Windows.Forms.Button();
            this.btnInputPemasok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ID_Pemasok = new System.Windows.Forms.Label();
            this.lblNama = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIDPemasok = new System.Windows.Forms.TextBox();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtNoTelepon = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.txtKeterangan = new System.Windows.Forms.TextBox();
            this.dtpTanggal = new System.Windows.Forms.DateTimePicker();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.txtCariPemasok = new System.Windows.Forms.TextBox();
            this.dgvPemasok = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPemasok)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNamaAdmin
            // 
            this.lblNamaAdmin.AutoSize = true;
            this.lblNamaAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamaAdmin.Location = new System.Drawing.Point(25, 25);
            this.lblNamaAdmin.Name = "lblNamaAdmin";
            this.lblNamaAdmin.Size = new System.Drawing.Size(0, 20);
            this.lblNamaAdmin.TabIndex = 0;
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelSidebar.Controls.Add(this.button6);
            this.panelSidebar.Controls.Add(this.btnVarianProduk);
            this.panelSidebar.Controls.Add(this.btnInputProduk);
            this.panelSidebar.Controls.Add(this.btnDetailPembelian);
            this.panelSidebar.Controls.Add(this.btnLaporanPenjualan);
            this.panelSidebar.Controls.Add(this.btnInputPemasok);
            this.panelSidebar.Controls.Add(this.lblNamaAdmin);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(220, 681);
            this.panelSidebar.TabIndex = 1;
            this.panelSidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSidebar_Paint);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.White;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Location = new System.Drawing.Point(12, 646);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(70, 23);
            this.button6.TabIndex = 9;
            this.button6.Text = "LOGOUT";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnVarianProduk
            // 
            this.btnVarianProduk.BackColor = System.Drawing.Color.White;
            this.btnVarianProduk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVarianProduk.Location = new System.Drawing.Point(29, 75);
            this.btnVarianProduk.Name = "btnVarianProduk";
            this.btnVarianProduk.Size = new System.Drawing.Size(147, 23);
            this.btnVarianProduk.TabIndex = 5;
            this.btnVarianProduk.Text = "VARIAN PRODUK\r\n";
            this.btnVarianProduk.UseVisualStyleBackColor = false;
            this.btnVarianProduk.Click += new System.EventHandler(this.btnVarianProduk_Click);
            // 
            // btnInputProduk
            // 
            this.btnInputProduk.BackColor = System.Drawing.Color.White;
            this.btnInputProduk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInputProduk.Location = new System.Drawing.Point(29, 133);
            this.btnInputProduk.Name = "btnInputProduk";
            this.btnInputProduk.Size = new System.Drawing.Size(147, 23);
            this.btnInputProduk.TabIndex = 4;
            this.btnInputProduk.Text = "INPUT PRODUK";
            this.btnInputProduk.UseVisualStyleBackColor = false;
            this.btnInputProduk.Click += new System.EventHandler(this.btnInputProduk_Click);
            // 
            // btnDetailPembelian
            // 
            this.btnDetailPembelian.BackColor = System.Drawing.Color.White;
            this.btnDetailPembelian.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDetailPembelian.Location = new System.Drawing.Point(29, 204);
            this.btnDetailPembelian.Name = "btnDetailPembelian";
            this.btnDetailPembelian.Size = new System.Drawing.Size(147, 23);
            this.btnDetailPembelian.TabIndex = 3;
            this.btnDetailPembelian.Text = "DETAIL PEMBELIAN";
            this.btnDetailPembelian.UseVisualStyleBackColor = false;
            this.btnDetailPembelian.Click += new System.EventHandler(this.btnDetailPembelian_Click);
            // 
            // btnLaporanPenjualan
            // 
            this.btnLaporanPenjualan.BackColor = System.Drawing.Color.White;
            this.btnLaporanPenjualan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLaporanPenjualan.Location = new System.Drawing.Point(29, 104);
            this.btnLaporanPenjualan.Name = "btnLaporanPenjualan";
            this.btnLaporanPenjualan.Size = new System.Drawing.Size(147, 23);
            this.btnLaporanPenjualan.TabIndex = 2;
            this.btnLaporanPenjualan.Text = "LAPORAN PENJUALAN";
            this.btnLaporanPenjualan.UseVisualStyleBackColor = false;
            this.btnLaporanPenjualan.Click += new System.EventHandler(this.btnLaporanPenjualan_Click);
            // 
            // btnInputPemasok
            // 
            this.btnInputPemasok.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnInputPemasok.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInputPemasok.Location = new System.Drawing.Point(29, 167);
            this.btnInputPemasok.Name = "btnInputPemasok";
            this.btnInputPemasok.Size = new System.Drawing.Size(147, 23);
            this.btnInputPemasok.TabIndex = 1;
            this.btnInputPemasok.Text = "INPUT PEMASOK";
            this.btnInputPemasok.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(261, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "INPUT PEMASOK";
            // 
            // ID_Pemasok
            // 
            this.ID_Pemasok.AutoSize = true;
            this.ID_Pemasok.Location = new System.Drawing.Point(262, 126);
            this.ID_Pemasok.Name = "ID_Pemasok";
            this.ID_Pemasok.Size = new System.Drawing.Size(65, 13);
            this.ID_Pemasok.TabIndex = 3;
            this.ID_Pemasok.Text = "ID Pemasok";
            // 
            // lblNama
            // 
            this.lblNama.AutoSize = true;
            this.lblNama.Location = new System.Drawing.Point(262, 167);
            this.lblNama.Name = "lblNama";
            this.lblNama.Size = new System.Drawing.Size(35, 13);
            this.lblNama.TabIndex = 4;
            this.lblNama.Text = "Nama";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "No Telepon";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(262, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tanggal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 320);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Alamat";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(265, 371);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Keterangan";
            // 
            // txtIDPemasok
            // 
            this.txtIDPemasok.Location = new System.Drawing.Point(423, 114);
            this.txtIDPemasok.Multiline = true;
            this.txtIDPemasok.Name = "txtIDPemasok";
            this.txtIDPemasok.Size = new System.Drawing.Size(449, 25);
            this.txtIDPemasok.TabIndex = 10;
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(423, 155);
            this.txtNama.Multiline = true;
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(449, 25);
            this.txtNama.TabIndex = 11;
            // 
            // txtNoTelepon
            // 
            this.txtNoTelepon.Location = new System.Drawing.Point(423, 201);
            this.txtNoTelepon.Multiline = true;
            this.txtNoTelepon.Name = "txtNoTelepon";
            this.txtNoTelepon.Size = new System.Drawing.Size(449, 25);
            this.txtNoTelepon.TabIndex = 12;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(423, 241);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(449, 25);
            this.txtEmail.TabIndex = 13;
            // 
            // txtAlamat
            // 
            this.txtAlamat.Location = new System.Drawing.Point(423, 317);
            this.txtAlamat.Multiline = true;
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(449, 36);
            this.txtAlamat.TabIndex = 14;
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.Location = new System.Drawing.Point(423, 359);
            this.txtKeterangan.Multiline = true;
            this.txtKeterangan.Name = "txtKeterangan";
            this.txtKeterangan.Size = new System.Drawing.Size(449, 25);
            this.txtKeterangan.TabIndex = 15;
            // 
            // dtpTanggal
            // 
            this.dtpTanggal.Location = new System.Drawing.Point(423, 285);
            this.dtpTanggal.Name = "dtpTanggal";
            this.dtpTanggal.Size = new System.Drawing.Size(311, 20);
            this.dtpTanggal.TabIndex = 16;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(489, 404);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 23);
            this.btnSimpan.TabIndex = 17;
            this.btnSimpan.Text = "SIMPAN";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(603, 404);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 18;
            this.btnEdit.Text = "EDIT";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(720, 404);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 23);
            this.btnHapus.TabIndex = 19;
            this.btnHapus.Text = "HAPUS";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // txtCariPemasok
            // 
            this.txtCariPemasok.Location = new System.Drawing.Point(265, 75);
            this.txtCariPemasok.Multiline = true;
            this.txtCariPemasok.Name = "txtCariPemasok";
            this.txtCariPemasok.Size = new System.Drawing.Size(236, 25);
            this.txtCariPemasok.TabIndex = 20;
            this.txtCariPemasok.TextChanged += new System.EventHandler(this.txtCariPemasok_TextChanged);
            // 
            // dgvPemasok
            // 
            this.dgvPemasok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPemasok.Location = new System.Drawing.Point(265, 433);
            this.dgvPemasok.Name = "dgvPemasok";
            this.dgvPemasok.Size = new System.Drawing.Size(987, 236);
            this.dgvPemasok.TabIndex = 21;
            this.dgvPemasok.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPemasok_CellContentClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(517, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Cari";
            // 
            // FormPemasok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvPemasok);
            this.Controls.Add(this.txtCariPemasok);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.dtpTanggal);
            this.Controls.Add(this.txtKeterangan);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtNoTelepon);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.txtIDPemasok);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblNama);
            this.Controls.Add(this.ID_Pemasok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelSidebar);
            this.Name = "FormPemasok";
            this.Text = "FormPemasok";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormPemasok_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPemasok)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNamaAdmin;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Button btnLaporanPenjualan;
        private System.Windows.Forms.Button btnInputPemasok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ID_Pemasok;
        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIDPemasok;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtNoTelepon;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.TextBox txtKeterangan;
        private System.Windows.Forms.DateTimePicker dtpTanggal;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.TextBox txtCariPemasok;
        private System.Windows.Forms.DataGridView dgvPemasok;
        private System.Windows.Forms.Button btnVarianProduk;
        private System.Windows.Forms.Button btnInputProduk;
        private System.Windows.Forms.Button btnDetailPembelian;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button6;
    }
}