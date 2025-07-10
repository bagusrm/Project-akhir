using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using distro;
using Project_akhir;
using projekfix;

namespace UASS
{
    public partial class Inputpelanggan : Form
    {
        // Koneksi ke database menggunakan LINQ to SQL
        distroshopDataContext db = new distroshopDataContext();
        private pengguna _akun;

        // Constructor: Dijalankan saat form dibuat
        public Inputpelanggan(pengguna akun)
        {
            InitializeComponent();
            _akun = akun;
            // lblNamaKaryawan.Text = $"Selamat datang, {_akun.NamaLengkap}";
        }


        // Metode untuk mengambil data dari database dan menampilkannya di DataGridView
        private void LoadData()
        {
            try
            {
                var dataPelanggan = from p in db.pelanggans
                                    orderby p.IdPelanggan descending
                                    select new
                                    {
                                        ID = p.IdPelanggan,
                                        Nama = p.Nama,
                                        JenisPelanggan = p.JenisPelanggan,
                                        Email = p.Email,
                                        NoTelepon = p.NoTelepon,
                                        Alamat = p.Alamat,
                                        TanggalDaftar = p.TanggalDaftar
                                    };
                dgpelanggan.DataSource = dataPelanggan.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data pelanggan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Metode untuk membersihkan semua field input di form
        private void ClearForm()
        {
            txtidpelanggan.Clear();
            txtnama.Clear();
            txtjenispelanggan.Clear();
            txtemail.Clear();
            txtnotelp.Clear();
            txtalamat.Clear();
            txttanggal.Value = DateTime.Now;
        }

        // Event yang dijalankan saat tombol 'SIMPAN' diklik
        private void btnsimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtnama.Text) || string.IsNullOrWhiteSpace(txtnotelp.Text))
            {
                MessageBox.Show("Nama dan Nomor Telepon wajib diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                pelanggan p = new pelanggan
                {
                    Nama = txtnama.Text,
                    JenisPelanggan = txtjenispelanggan.Text,
                    Email = txtemail.Text,
                    NoTelepon = txtnotelp.Text,
                    Alamat = txtalamat.Text,
                    TanggalDaftar = txttanggal.Value.Date
                };

                db.pelanggans.InsertOnSubmit(p);
                db.SubmitChanges();

                MessageBox.Show("Data berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event untuk sel di tabel, bisa dikembangkan untuk fitur update/delete
        private void dgpelanggan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kosongkan untuk saat ini
        }

        // --- EVENT HANDLER UNTUK NAVIGASI ---

        private void btnvarian_Click(object sender, EventArgs e)
        {
            using (var frm = new VarianProdukkaryawan(_akun))
            {
                this.Hide();
                frm.ShowDialog();
            }
            this.Close();
        }

        private void btnlaporan_Click(object sender, EventArgs e)
        {
            using (var frm = new LaporanPenjualankaryawan(_akun))
            {
                this.Hide();
                frm.ShowDialog();
            }
            this.Close();
        }

        // Event untuk tombol Logout atau kembali ke Login
        private void button6_Click(object sender, EventArgs e)
        {
            using (var frm = new LoginForm())
            {
                this.Hide();
                frm.ShowDialog();
            }
            this.Close();
        }

        private void btninput_Click(object sender, EventArgs e)
        {
            using (var frm = new Inputpesanan(_akun))
            {
                this.Hide();
                frm.ShowDialog();
            }
            this.Close();
        }

        private void Inputpelanggan_Load_1(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}