using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using distro;
using Project_akhir;
using UASS;

namespace projekfix
{
    public partial class VarianprodukAdmin : Form
    {
        distroshopDataContext dt = new distroshopDataContext();
        private pengguna _akun;

        public VarianprodukAdmin(pengguna akun)
        {
            InitializeComponent();
            _akun = akun;

            // Panggil method setelah inisialisasi akun
            TampilData();
            LoadProduk();
            ClearData();

            lblAdminNama.Text = $"Halo, {_akun.NamaLengkap}";
        }

        // DIHAPUS: Method ini tidak lagi diperlukan karena Ukuran menggunakan TextBox.
        // private void LoadUkuran() { ... }

        private void LoadProduk()
        {
            var produkList = dt.produks
                .Select(p => new { p.IdProduk, p.Nama })
                .ToList();

            cmbIdProduk.DataSource = produkList;
            cmbIdProduk.DisplayMember = "Nama";
            cmbIdProduk.ValueMember = "IdProduk";
        }

        // DIHAPUS: Method ini tidak lagi diperlukan karena ID Varian menggunakan TextBox.
        // private void LoadVarian() { ... }

        private void TampilData()
        {
            var data = dt.varianproduks
                .Join(dt.produks,
                      varian => varian.IdProduk,
                      produk => produk.IdProduk,
                      (varian, produk) => new
                      {
                          IdVarian = varian.IdVarian,
                          NamaProduk = produk.Nama,
                          Ukuran = varian.Ukuran,
                          Warna = varian.Warna,
                          HargaJual = varian.HargaJual,
                          Jumlah = varian.Jumlah,
                          IdProduk = varian.IdProduk
                      })
                .ToList();

            dgvVarian.DataSource = data;
        }

        private void ClearData()
        {
            // DIGANTI: Menggunakan .Clear() untuk TextBox
            txtIdVarian.Clear();
            cmbIdProduk.SelectedIndex = -1;
            txtUkuran.Clear();
            txtWarna.Clear();
            txtHargaJual.Clear();
            txtJumlah.Clear();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // DIGANTI: Validasi dan pengambilan data dari TextBox
            if (!int.TryParse(txtIdVarian.Text, out int idVarian))
            {
                MessageBox.Show("ID Varian tidak valid. Harap isi dengan angka.");
                return;
            }

            if (cmbIdProduk.SelectedValue == null || !int.TryParse(cmbIdProduk.SelectedValue.ToString(), out int idProduk))
            {
                MessageBox.Show("ID Produk tidak valid.");
                return;
            }

            // DIGANTI: Validasi untuk TextBox Ukuran
            if (string.IsNullOrWhiteSpace(txtUkuran.Text) ||
                string.IsNullOrWhiteSpace(txtWarna.Text) ||
                !int.TryParse(txtHargaJual.Text, out int hargaJual) ||
                !int.TryParse(txtJumlah.Text, out int jumlah))
            {
                MessageBox.Show("Semua field harus diisi dengan benar.");
                return;
            }

            // DIGANTI: Mengambil data dari TextBox Ukuran
            string ukuran = txtUkuran.Text;
            string warna = txtWarna.Text;

            // Cek apakah ID Varian sudah ada
            if (dt.varianproduks.Any(v => v.IdVarian == idVarian))
            {
                MessageBox.Show($"ID Varian '{idVarian}' sudah ada. Silakan gunakan ID lain.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var varian = new varianproduk
            {
                IdVarian = idVarian,
                IdProduk = idProduk,
                Ukuran = ukuran,
                Warna = warna,
                HargaJual = hargaJual,
                Jumlah = jumlah
            };

            try
            {
                dt.varianproduks.InsertOnSubmit(varian);
                dt.SubmitChanges();
                MessageBox.Show("Data Varian berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TampilData();
                ClearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // DIGANTI: Mengambil ID Varian dari TextBox
            if (!int.TryParse(txtIdVarian.Text, out int idVarian))
            {
                MessageBox.Show("Pilih data dari tabel untuk diedit.");
                return;
            }

            if (cmbIdProduk.SelectedValue == null ||
                !int.TryParse(cmbIdProduk.SelectedValue.ToString(), out int idProduk))
            {
                MessageBox.Show("Produk tidak valid.");
                return;
            }

            if (!int.TryParse(txtHargaJual.Text, out int hargaJual) ||
                !int.TryParse(txtJumlah.Text, out int jumlah))
            {
                MessageBox.Show("Harga Jual dan Jumlah harus berupa angka.");
                return;
            }

            // DIGANTI: Mengambil data dari TextBox
            string ukuran = txtUkuran.Text;
            string warna = txtWarna.Text;

            var brg = dt.varianproduks.FirstOrDefault(v => v.IdVarian == idVarian);

            if (brg != null)
            {
                brg.IdProduk = idProduk;
                brg.Ukuran = ukuran;
                brg.Warna = warna;
                brg.HargaJual = hargaJual;
                brg.Jumlah = jumlah;

                dt.SubmitChanges();
                MessageBox.Show("Data berhasil diedit!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TampilData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Data dengan ID Varian tersebut tidak ditemukan.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            // DIGANTI: Mengambil ID dari TextBox
            if (!int.TryParse(txtIdVarian.Text, out int idVarian))
            {
                MessageBox.Show("Pilih data dari tabel yang ingin dihapus.");
                return;
            }

            var varian = dt.varianproduks.FirstOrDefault(v => v.IdVarian == idVarian);

            if (varian != null)
            {
                var konfirmasi = MessageBox.Show($"Yakin ingin menghapus data varian dengan ID {idVarian}?",
                                                  "Konfirmasi Hapus",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

                if (konfirmasi == DialogResult.Yes)
                {
                    dt.varianproduks.DeleteOnSubmit(varian);
                    dt.SubmitChanges();

                    MessageBox.Show("Data berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TampilData();
                    ClearData();
                }
            }
            else
            {
                MessageBox.Show("Data dengan ID Varian tersebut tidak ditemukan.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // DIHAPUS: Event handler ini tidak lagi relevan.
        // private void cmbIdVarian_SelectedIndexChanged(object sender, EventArgs e) { ... }

        // BARU: Event handler untuk mengisi form saat baris DataGridView di-klik
        private void dgvVarian_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Pastikan yang diklik adalah baris yang valid
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvVarian.Rows[e.RowIndex];

                // Isi form dengan data dari baris yang dipilih
                txtIdVarian.Text = row.Cells["IdVarian"].Value.ToString();
                cmbIdProduk.SelectedValue = row.Cells["IdProduk"].Value; // Set berdasarkan ID Produk
                txtUkuran.Text = row.Cells["Ukuran"].Value.ToString();
                txtWarna.Text = row.Cells["Warna"].Value.ToString();
                txtHargaJual.Text = row.Cells["HargaJual"].Value.ToString();
                txtJumlah.Text = row.Cells["Jumlah"].Value.ToString();
            }
        }

        private void txtCariVarian_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtCariVarian.Text;

            if (string.IsNullOrWhiteSpace(keyword))
            {
                TampilData();
            }
            else
            {
                var data = dt.varianproduks
                             .Join(dt.produks,
                                   v => v.IdProduk,
                                   p => p.IdProduk,
                                   (v, p) => new { varian = v, produk = p })
                             .Where(x => x.varian.Warna.Contains(keyword) ||
                                         x.varian.Ukuran.Contains(keyword) ||
                                         x.produk.Nama.Contains(keyword))
                             .Select(x => new
                             {
                                 IdVarian = x.varian.IdVarian,
                                 NamaProduk = x.produk.Nama,
                                 Ukuran = x.varian.Ukuran,
                                 Warna = x.varian.Warna,
                                 HargaJual = x.varian.HargaJual,
                                 Jumlah = x.varian.Jumlah,
                                 IdProduk = x.varian.IdProduk
                             })
                             .ToList();

                dgvVarian.DataSource = data;
            }
        }

        // --- Event Handler untuk Tombol Navigasi ---
        private void button2_Click(object sender, EventArgs e) // Laporan Penjualan
        {
            using (var frm = new LaporanPenjualan(_akun))
            {
                this.Hide();
                frm.ShowDialog();
            }
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e) // Input Produk
        {
            using (var frm = new InputProduk(_akun))
            {
                this.Hide();
                frm.ShowDialog();
            }
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e) // Input Pemasok
        {
            using (var frm = new FormPemasok(_akun))
            {
                this.Hide();
                frm.ShowDialog();
            }
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e) // Detail Pembelian
        {
            using (var frm = new Detailbeli(_akun))
            {
                this.Hide();
                frm.ShowDialog();
            }
            this.Close();
        }
    }
}