using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Project_akhir;
using distro;
using UASS;

namespace projekfix
{
    public partial class InputProduk : Form
    {
        private pengguna _akun;

        public InputProduk(pengguna akun)
        {
            InitializeComponent();
            _akun = akun;

            // ⬇️ Masukkan nama ke label
            lblnamaAdmin.Text = $"Halo, {_akun.NamaLengkap}";
            _akun = akun;
        }

        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=distroshop;Integrated Security=True");

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                // Validasi isi ComboBox
                if (cmbIdPemasok.SelectedIndex == -1 || cmbIdPengguna.SelectedIndex == -1 || cmbIdKategori.SelectedIndex == -1)
                {
                    MessageBox.Show("Silakan pilih semua data pada ComboBox (Pemasok, Pengguna, dan Kategori).", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validasi teks wajib
                if (string.IsNullOrWhiteSpace(txtNama.Text) || string.IsNullOrWhiteSpace(txtHargaDasar.Text))
                {
                    MessageBox.Show("Nama dan Harga Dasar tidak boleh kosong.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                conn.Open();
                string query = "INSERT INTO Produk (Nama, IDPemasok, IDPengguna, IDKategori, Deskripsi, HargaDasar) " +
                               "VALUES (@Nama, @Pemasok, @Pengguna, @Kategori, @Deskripsi, @HargaDasar)";
                SqlCommand cmd = new SqlCommand(query, conn);

                // Parameter dari input form
                cmd.Parameters.AddWithValue("@Nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@Pemasok", cmbIdPemasok.SelectedValue);
                cmd.Parameters.AddWithValue("@Pengguna", cmbIdPengguna.SelectedValue);
                cmd.Parameters.AddWithValue("@Kategori", cmbIdKategori.SelectedValue);
                cmd.Parameters.AddWithValue("@Deskripsi", txtDeskripsi.Text);
                cmd.Parameters.AddWithValue("@HargaDasar", txtHargaDasar.Text);

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Data berhasil disimpan.");
                ClearData();
                TampilData(); // Refresh DataGridView
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Gagal menyimpan: " + ex.Message);
            }
        }

        private void ClearData()
        {
            txtNama.Clear();
            txtDeskripsi.Clear();
            txtHargaDasar.Clear();
            cmbIdKategori.SelectedIndex = -1;
            cmbIdPemasok.SelectedIndex = -1;
            cmbIdPengguna.SelectedIndex = -1;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInputProduk.SelectedRows.Count > 0)
                {
                    string idProduk = dgvInputProduk.SelectedRows[0].Cells["IDProduk"].Value.ToString();

                    conn.Open();
                    string query = "UPDATE Produk SET Nama=@Nama, IDPemasok=@Pemasok, IDPengguna=@Pengguna, IDKategori=@Kategori, Deskripsi=@Deskripsi, HargaDasar=@HargaDasar WHERE IDProduk=@ID";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@ID", idProduk); // Penting: WHERE IDProduk
                    cmd.Parameters.AddWithValue("@Nama", txtNama.Text);
                    cmd.Parameters.AddWithValue("@Pemasok", cmbIdPemasok.SelectedValue);
                    cmd.Parameters.AddWithValue("@Pengguna", cmbIdPengguna.SelectedValue);
                    cmd.Parameters.AddWithValue("@Kategori", cmbIdKategori.SelectedValue);
                    cmd.Parameters.AddWithValue("@Deskripsi", txtDeskripsi.Text);
                    cmd.Parameters.AddWithValue("@HargaDasar", txtHargaDasar.Text);

                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Data berhasil diupdate.");
                    ClearData();
                    TampilData(); // Refresh isi DataGridView
                }
                else
                {
                    MessageBox.Show("Pilih data yang ingin diedit terlebih dahulu.");
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Gagal update: " + ex.Message);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvInputProduk.SelectedRows.Count > 0)
            {
                // Ambil IDProduk dari baris yang dipilih
                string idProduk = dgvInputProduk.SelectedRows[0].Cells["IDProduk"].Value.ToString();

                DialogResult result = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM Produk WHERE IDProduk=@ID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", idProduk);
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Data berhasil dihapus.");
                        TampilData(); // Refresh DataGridView
                        ClearData();  // Kosongkan input
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        MessageBox.Show("Gagal hapus: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih data yang ingin dihapus terlebih dahulu.");
            }
        }

        private void TampilData()
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Produk", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvInputProduk.DataSource = dt;
            conn.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadKategori();
            LoadPemasok();
            LoadPengguna();
            TampilData();
        }

        private void dgvInputProduk_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvInputProduk.Rows[e.RowIndex];

                // Isi TextBox
                txtNama.Text = row.Cells["Nama"].Value.ToString();
                txtDeskripsi.Text = row.Cells["Deskripsi"].Value.ToString();
                txtHargaDasar.Text = row.Cells["HargaDasar"].Value.ToString();

                // Isi ComboBox berdasarkan ID yang ada di DataGridView
                cmbIdPemasok.SelectedValue = row.Cells["IDPemasok"].Value;
                cmbIdPengguna.SelectedValue = row.Cells["IDPengguna"].Value;
                cmbIdKategori.SelectedValue = row.Cells["IDKategori"].Value;
            }
        }

        private void LoadKategori()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT IdKategori, NamaKategori FROM Kategori", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();

                cmbIdKategori.DataSource = dt;
                cmbIdKategori.DisplayMember = "NamaKategori"; // Menampilkan nama
                cmbIdKategori.ValueMember = "IdKategori";     // Nilainya tetap ID
                cmbIdKategori.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Gagal memuat kategori: " + ex.Message);
            }
        }

        private void LoadPemasok()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT IdPemasok, Nama FROM Pemasok", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();

                cmbIdPemasok.DataSource = dt;
                cmbIdPemasok.DisplayMember = "Nama";      // Menampilkan nama
                cmbIdPemasok.ValueMember = "IdPemasok";   // Nilainya tetap ID
                cmbIdPemasok.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Gagal memuat pemasok: " + ex.Message);
            }
        }

        private void LoadPengguna()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT IdPengguna, NamaLengkap FROM Pengguna", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();

                cmbIdPengguna.DataSource = dt;
                cmbIdPengguna.DisplayMember = "NamaLengkap"; // Menampilkan nama
                cmbIdPengguna.ValueMember = "IdPengguna";    // Nilainya tetap ID
                cmbIdPengguna.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Gagal memuat pengguna: " + ex.Message);
            }
        }

        private void CariProduk(string keyword)
        {
            try
            {
                string query = "SELECT * FROM Produk WHERE Nama LIKE @keyword OR Deskripsi LIKE @keyword";

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvInputProduk.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mencari data: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void txtCariProduk_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtCariProduk.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                TampilData();
            }
            else
            {
                CariProduk(keyword);
            }
        }

        private void btnVarianProduk_Click(object sender, EventArgs e)
        {
            using (var frm = new VarianprodukAdmin(_akun))
            {
                this.Close();
                frm.ShowDialog();
            }
        }

        private void btnLaporanPenjualan_Click(object sender, EventArgs e)
        {
            using (var frm = new LaporanPenjualan(_akun))
            {
                this.Close();
                frm.ShowDialog();
            }
        }

        private void btnInputProduk_Click(object sender, EventArgs e)
        {
            using (var frm = new InputProduk(_akun))
            {
                this.Close();
                frm.ShowDialog();
            }
        }

        private void btnInputPemasok_Click(object sender, EventArgs e)
        {
            using (var frm = new FormPemasok(_akun))
            {
                this.Close();
                frm.ShowDialog();
            }
        }

        private void btnDetailPembelian_Click(object sender, EventArgs e)
        {
            using (var frm = new Detailbeli(_akun))
            {
                this.Close();
                frm.ShowDialog();
            }
        }
    }
}