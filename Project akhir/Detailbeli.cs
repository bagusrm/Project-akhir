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
    public partial class Detailbeli : Form
    {
        distroshopDataContext db = new distroshopDataContext();
        private pengguna _akun;

        public Detailbeli(pengguna akun)
        {
            InitializeComponent();
            _akun = akun;

            // ⬇️ Masukkan nama ke label
            lblNamaAdmin.Text = $"Halo, {_akun.NamaLengkap}";
        }

        private void LoadDetailPembelian(string keyword = "")
        {
            var data = from d in db.detailpembelians
                       join p in db.pembelians on d.IdPembelian equals p.IdPembelian
                       join v in db.varianproduks on d.IdVarian equals v.IdVarian
                       select new
                       {
                           d.Id,
                           d.IdPembelian,
                           v.IdVarian,
                           d.Jumlah,
                           d.HargaBeli,
                           d.SubTotal
                       };

            dgvdetailpembelian.DataSource = data.ToList();
        }


        private void btnvarian_Click(object sender, EventArgs e)
        {
            using (var frm = new VarianprodukAdmin(_akun))
            {
                this.Close();

                frm.ShowDialog();

            }
        }

        private void btnlaporan_Click(object sender, EventArgs e)
        {
            using (var frm = new LaporanPenjualan(_akun))
            {
                this.Close();

                frm.ShowDialog();

            }
        }

        private void btninputproduk_Click(object sender, EventArgs e)
        {
            using (var frm = new InputProduk(_akun))
            {
                this.Close();

                frm.ShowDialog();

            }
        }

        private void btninputpembelian_Click(object sender, EventArgs e)
        {
            using (var frm = new FormPemasok(_akun))
            {
                this.Close();

                frm.ShowDialog();

            }
        }

        private void btndetailpembelian_Click(object sender, EventArgs e)
        {

        }

        private void dgvdetailpembelian_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtcari_TextChanged(object sender, EventArgs e)
        {
            LoadDetailPembelian(txtcari.Text);
        }

        private void btncari_Click(object sender, EventArgs e)
        {
            LoadDetailPembelian(txtcari.Text);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadDetailPembelian();
        }

        private void label2_Click(object sender, EventArgs e)
        {

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
