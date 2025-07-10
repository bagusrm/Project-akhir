using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using distro;
using Project_akhir;
using UASS;

namespace projekfix
{
    public partial class Inputpesanan : Form
    {
        private pengguna _akun;
        // Pastikan connection string ini sudah benar
        private readonly SqlConnection conn = new SqlConnection("Data Source=DESKTOP-OEL5F93;Initial Catalog=distroshop;Integrated Security=True");

        public Inputpesanan(pengguna akun)
        {
            InitializeComponent();
            _akun = akun;

            // Jika Anda memiliki label untuk nama karyawan, aktifkan baris ini
            // lblNamaKaryawan.Text = $"Selamat datang, {_akun.NamaLengkap}";

            // Menghubungkan event handler ke metodenya
            this.dgvPesanan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPesanan_CellClick);
            this.cmbVarian.SelectedIndexChanged += new System.EventHandler(this.cmbVarian_SelectedIndexChanged);
            this.txtHargaSatuan.TextChanged += new System.EventHandler(this.txtHargaSatuan_Or_txtJumlah_TextChanged);
            this.txtJumlah.TextChanged += new System.EventHandler(this.txtHargaSatuan_Or_txtJumlah_TextChanged);
            // PENAMBAHAN: Menghubungkan event untuk kotak pencarian
            this.txtCariPesanan.TextChanged += new System.EventHandler(this.txtCariPesanan_TextChanged);

            // Memuat data awal saat form dibuka
            LoadComboBoxData();
            LoadDataGridView();
            _akun = akun;

            lblNamaKaryawan.Text = $"Selamat datang, {_akun.NamaLengkap}";

        }

        #region Metode untuk Memuat Data

        /// <summary>
        /// Memuat data untuk semua ComboBox dari database.
        /// </summary>
        private void LoadComboBoxData()
        {
            using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
            {
                try
                {
                    connection.Open();
                    // Load Pelanggan
                    SqlDataAdapter daPelanggan = new SqlDataAdapter("SELECT IdPelanggan, Nama FROM pelanggan", connection);
                    DataTable dtPelanggan = new DataTable();
                    daPelanggan.Fill(dtPelanggan);
                    cmbPelanggan.DisplayMember = "Nama";
                    cmbPelanggan.ValueMember = "IdPelanggan";
                    cmbPelanggan.DataSource = dtPelanggan;

                    // Load Pengguna (Karyawan)
                    SqlDataAdapter daPengguna = new SqlDataAdapter("SELECT IdPengguna, NamaLengkap FROM pengguna", connection);
                    DataTable dtPengguna = new DataTable();
                    daPengguna.Fill(dtPengguna);
                    cmbPengguna.DisplayMember = "NamaLengkap";
                    cmbPengguna.ValueMember = "IdPengguna";
                    cmbPengguna.DataSource = dtPengguna;

                    // Load Varian Produk (Ukuran + Warna)
                    SqlDataAdapter daVarian = new SqlDataAdapter("SELECT IdVarian, Ukuran + ' - ' + Warna AS VarianInfo FROM varianproduk", connection);
                    DataTable dtVarian = new DataTable();
                    daVarian.Fill(dtVarian);
                    cmbVarian.DisplayMember = "VarianInfo";
                    cmbVarian.ValueMember = "IdVarian";
                    cmbVarian.DataSource = dtVarian;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data ComboBox: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ClearData();
        }

        /// <summary>
        /// MODIFIKASI: Memuat data pesanan ke DGV, dengan parameter pencarian opsional.
        /// </summary>
        /// <param name="searchTerm">Kata kunci untuk memfilter data.</param>
        private void LoadDataGridView(string searchTerm = "")
        {
            try
            {
                string baseQuery = @"SELECT 
                                        p.IdPesanan, p.Tanggal, p.IdPelanggan, pl.Nama AS NamaPelanggan, 
                                        p.IdPengguna, pg.NamaLengkap AS NamaKaryawan, p.TotalHarga, 
                                        p.StatusPengiriman, p.Ekspedisi, p.NoResi 
                                     FROM pesanan p
                                     JOIN pelanggan pl ON p.IdPelanggan = pl.IdPelanggan
                                     JOIN pengguna pg ON p.IdPengguna = pg.IdPengguna";

                string whereClause = "";
                // Jika ada kata kunci pencarian, tambahkan klausa WHERE
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    whereClause = @" WHERE pl.Nama LIKE @searchTerm
                                      OR pg.NamaLengkap LIKE @searchTerm
                                      OR p.StatusPengiriman LIKE @searchTerm
                                      OR p.NoResi LIKE @searchTerm";
                }

                string finalQuery = baseQuery + whereClause + " ORDER BY p.IdPesanan DESC";
                SqlDataAdapter sda = new SqlDataAdapter(finalQuery, conn);

                // Tambahkan parameter jika sedang melakukan pencarian
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    sda.SelectCommand.Parameters.AddWithValue("@searchTerm", $"%{searchTerm}%");
                }

                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvPesanan.DataSource = dt;

                // Mengatur header kolom (tidak berubah)
                if (dgvPesanan.Columns.Count > 0)
                {
                    dgvPesanan.Columns["IdPesanan"].HeaderText = "ID";
                    dgvPesanan.Columns["NamaPelanggan"].HeaderText = "Pelanggan";
                    dgvPesanan.Columns["NamaKaryawan"].HeaderText = "Karyawan";
                    dgvPesanan.Columns["TotalHarga"].HeaderText = "Total";
                    dgvPesanan.Columns["StatusPengiriman"].HeaderText = "Status";
                    dgvPesanan.Columns["IdPelanggan"].Visible = false;
                    dgvPesanan.Columns["IdPengguna"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data pesanan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Event Handler untuk Interaktivitas Form

        /// <summary>
        /// PENAMBAHAN: Event handler untuk kotak pencarian.
        /// </summary>
        private void txtCariPesanan_TextChanged(object sender, EventArgs e)
        {
            // Memanggil metode LoadDataGridView dengan teks dari kotak pencarian
            LoadDataGridView(txtCariPesanan.Text);
        }

        private void dgvPesanan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvPesanan.Rows[e.RowIndex];
                txtIdpesanan.Text = row.Cells["IdPesanan"].Value.ToString();
                dtpTanggal.Value = Convert.ToDateTime(row.Cells["Tanggal"].Value);
                cmbPelanggan.SelectedValue = row.Cells["IdPelanggan"].Value;
                cmbPengguna.SelectedValue = row.Cells["IdPengguna"].Value;
                txtTotalHarga.Text = row.Cells["TotalHarga"].Value.ToString();
                txtStatusPengiriman.Text = row.Cells["StatusPengiriman"].Value?.ToString() ?? "";
                txtekspedisi.Text = row.Cells["Ekspedisi"].Value?.ToString() ?? "";
                TxtNoResi.Text = row.Cells["NoResi"].Value?.ToString() ?? "";
                cmbVarian.SelectedIndex = -1;
                txtHargaSatuan.Clear();
                txtJumlah.Clear();
            }
        }

        private void cmbVarian_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVarian.SelectedValue != null && int.TryParse(cmbVarian.SelectedValue.ToString(), out int idVarian))
            {
                using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("SELECT HargaJual FROM varianproduk WHERE IdVarian = @IdVarian", connection);
                        cmd.Parameters.AddWithValue("@IdVarian", idVarian);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            txtHargaSatuan.Text = result.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal mengambil harga: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtHargaSatuan_Or_txtJumlah_TextChanged(object sender, EventArgs e)
        {
            UpdateTotalHarga();
        }
        #endregion

        #region Tombol Aksi (CRUD)

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (cmbPelanggan.SelectedValue == null || cmbPengguna.SelectedValue == null || string.IsNullOrWhiteSpace(txtTotalHarga.Text))
            {
                MessageBox.Show("Harap lengkapi data Pelanggan, Karyawan, dan Produk.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO pesanan (Tanggal, IdPelanggan, IdPengguna, TotalHarga, StatusPengiriman, Ekspedisi, NoResi) VALUES (@Tanggal, @IdPelanggan, @IdPengguna, @TotalHarga, @StatusPengiriman, @Ekspedisi, @NoResi)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Tanggal", dtpTanggal.Value);
                        cmd.Parameters.AddWithValue("@IdPelanggan", cmbPelanggan.SelectedValue);
                        cmd.Parameters.AddWithValue("@IdPengguna", cmbPengguna.SelectedValue);
                        cmd.Parameters.AddWithValue("@TotalHarga", Convert.ToDecimal(txtTotalHarga.Text));
                        cmd.Parameters.AddWithValue("@StatusPengiriman", txtStatusPengiriman.Text);
                        cmd.Parameters.AddWithValue("@Ekspedisi", txtekspedisi.Text);
                        cmd.Parameters.AddWithValue("@NoResi", TxtNoResi.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Data pesanan berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearData();
                LoadDataGridView(); // Refresh tabel
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdpesanan.Text))
            {
                MessageBox.Show("Silakan pilih data pesanan dari tabel yang akan di-edit.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
                {
                    connection.Open();
                    string query = "UPDATE pesanan SET Tanggal=@Tanggal, IdPelanggan=@IdPelanggan, IdPengguna=@IdPengguna, TotalHarga=@TotalHarga, StatusPengiriman=@StatusPengiriman, Ekspedisi=@Ekspedisi, NoResi=@NoResi WHERE IdPesanan=@IdPesanan";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@IdPesanan", txtIdpesanan.Text);
                        cmd.Parameters.AddWithValue("@Tanggal", dtpTanggal.Value);
                        cmd.Parameters.AddWithValue("@IdPelanggan", cmbPelanggan.SelectedValue);
                        cmd.Parameters.AddWithValue("@IdPengguna", cmbPengguna.SelectedValue);
                        cmd.Parameters.AddWithValue("@TotalHarga", Convert.ToDecimal(txtTotalHarga.Text));
                        cmd.Parameters.AddWithValue("@StatusPengiriman", txtStatusPengiriman.Text);
                        cmd.Parameters.AddWithValue("@Ekspedisi", txtekspedisi.Text);
                        cmd.Parameters.AddWithValue("@NoResi", TxtNoResi.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Data pesanan berhasil diupdate.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearData();
                LoadDataGridView(); // Refresh tabel
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengupdate data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdpesanan.Text))
            {
                MessageBox.Show("Silakan pilih data pesanan dari tabel yang akan dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM pesanan WHERE IdPesanan=@IdPesanan", connection);
                        cmd.Parameters.AddWithValue("@IdPesanan", txtIdpesanan.Text);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Data pesanan berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                    LoadDataGridView(); // Refresh tabel
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menghapus data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Metode Bantuan (Helpers)

        private void UpdateTotalHarga()
        {
            if (decimal.TryParse(txtHargaSatuan.Text, out decimal hargaSatuan) && int.TryParse(txtJumlah.Text, out int jumlah))
            {
                txtTotalHarga.Text = (hargaSatuan * jumlah).ToString();
            }
            else if (string.IsNullOrWhiteSpace(txtJumlah.Text))
            {
                txtTotalHarga.Clear();
            }
        }

        private void ClearData()
        {
            txtIdpesanan.Clear();
            dtpTanggal.Value = DateTime.Now;
            cmbPelanggan.SelectedIndex = -1;
            cmbPengguna.SelectedIndex = -1;
            cmbVarian.SelectedIndex = -1;
            txtHargaSatuan.Clear();
            txtJumlah.Clear();
            txtTotalHarga.Clear();
            txtStatusPengiriman.Clear();
            txtekspedisi.Clear();
            TxtNoResi.Clear();
            // PENAMBAHAN: Kosongkan juga kotak pencarian saat clear data
            txtCariPesanan.Clear();
        }
        #endregion
    }
}