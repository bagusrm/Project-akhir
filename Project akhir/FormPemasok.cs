using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_akhir;
using projekfix;
using UASS;

namespace distro
{
    public partial class FormPemasok : Form
    {
        private pengguna _akun;
        public FormPemasok(pengguna akun)
        {
            InitializeComponent();
            _akun = akun;

            // ⬇️ Masukkan nama ke label
            lblNamaAdmin.Text = $"Halo, {_akun.NamaLengkap}";
            _akun = akun;
        }

       
        private distroshopDataContext dbContext;

        private void LoadPemasok()
        {
            using (dbContext = new distroshopDataContext())
            {
      
                var data = dbContext.pemasoks
                    .Select(p => new
                    {
                        p.IdPemasok,
                        p.Nama,
                        p.NoTelepon,
                        p.Email,
                        p.Tanggal,
                        p.Alamat,
                        p.Keterangan
                    })
                    .ToList();
                dgvPemasok.DataSource = data;
            }
        }

        private void txtCariPemasok_TextChanged(object sender, EventArgs e)
        {
            SearchPemasok(txtCariPemasok.Text.Trim());
        }

        private void SearchPemasok(string keyword)
        {
            using (dbContext = new distroshopDataContext()) 
            {
                var query = dbContext.pemasoks
                    .Where(p =>
                        string.IsNullOrEmpty(keyword) ||
                        p.Nama.Contains(keyword) ||
                        p.NoTelepon.Contains(keyword) ||
                        p.Email.Contains(keyword) ||
                        p.Keterangan.Contains(keyword)
                    )
                    .Select(p => new
                    {
                        p.IdPemasok,
                        p.Nama,
                        p.NoTelepon,
                        p.Email,
                        p.Tanggal,
                        p.Alamat,
                        p.Keterangan
                    })
                    .ToList();

                dgvPemasok.DataSource = query;
            }
        }

        private void FormPemasok_Load(object sender, EventArgs e)
        {
            LoadPemasok();
        }

        private void panelSidebar_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void ClearInput()
        {
            txtIDPemasok.Text = "";
            txtNama.Text = "";
            txtNoTelepon.Text = "";
            txtEmail.Text = "";
            dtpTanggal.Value = DateTime.Now;
            txtAlamat.Text = "";
            txtKeterangan.Text = "";
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            using (dbContext = new distroshopDataContext()) 
            {
         
                pemasok newPemasok = new pemasok()
                {
                    Nama = txtNama.Text,
                    NoTelepon = txtNoTelepon.Text,
                    Email = txtEmail.Text,
                    Tanggal = dtpTanggal.Value,
                    Alamat = txtAlamat.Text,
                    Keterangan = txtKeterangan.Text
                };

                dbContext.pemasoks.InsertOnSubmit(newPemasok); 
                dbContext.SubmitChanges(); 
                MessageBox.Show("Pemasok berhasil ditambahkan!");
                LoadPemasok();
                ClearInput();
            }
        }

        private void dgvPemasok_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPemasok.Rows[e.RowIndex];
                txtIDPemasok.Text = row.Cells["IdPemasok"].Value?.ToString();
                txtNama.Text = row.Cells["Nama"].Value?.ToString();
                txtNoTelepon.Text = row.Cells["NoTelepon"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                if (row.Cells["Tanggal"].Value != null)
                {
                    dtpTanggal.Value = Convert.ToDateTime(row.Cells["Tanggal"].Value);
                }
                txtAlamat.Text = row.Cells["Alamat"].Value?.ToString();
                txtKeterangan.Text = row.Cells["Keterangan"].Value?.ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIDPemasok.Text))
            {
                MessageBox.Show("Pilih data yang mau diedit.");
                return;
            }

            int id = int.Parse(txtIDPemasok.Text);
            using (dbContext = new distroshopDataContext()) 
            {
                var pemasokToUpdate = dbContext.pemasoks.FirstOrDefault(p => p.IdPemasok == id);
                if (pemasokToUpdate != null)
                {
                    pemasokToUpdate.Nama = txtNama.Text;
                    pemasokToUpdate.NoTelepon = txtNoTelepon.Text;
                    pemasokToUpdate.Email = txtEmail.Text;
                    pemasokToUpdate.Tanggal = dtpTanggal.Value;
                    pemasokToUpdate.Alamat = txtAlamat.Text;
                    pemasokToUpdate.Keterangan = txtKeterangan.Text;

                    dbContext.SubmitChanges(); 
                    MessageBox.Show("Data berhasil diupdate.");
                    LoadPemasok();
                    ClearInput();
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIDPemasok.Text))
            {
                MessageBox.Show("Pilih data yang mau dihapus.");
                return;
            }

            int id = int.Parse(txtIDPemasok.Text);

            using (dbContext = new distroshopDataContext()) 
            {
             

                var pemasokToDelete = dbContext.pemasoks.FirstOrDefault(p => p.IdPemasok == id);
                if (pemasokToDelete != null)
                {
                    dbContext.pemasoks.DeleteOnSubmit(pemasokToDelete);
                    dbContext.SubmitChanges(); 
                    MessageBox.Show("Data berhasil dihapus.");
                    LoadPemasok();
                    ClearInput();
                }
            }
        }

        private void btnLaporanPenjualan_Click(object sender, EventArgs e)
        {
            LaporanPenjualan frm = new LaporanPenjualan(_akun);
            frm.Show();
            this.Hide();
        }

        private void btnVarianProduk_Click(object sender, EventArgs e)
        {
            using (var frm = new VarianprodukAdmin(_akun))
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

        private void btnDetailPembelian_Click(object sender, EventArgs e)
        {
            using (var frm = new Detailbeli(_akun))
            {
                this.Close();

                frm.ShowDialog();

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (var frm = new LoginForm())
            {
                this.Close();

                frm.ShowDialog();

            }
        }
    }
}