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
using UASS;

namespace Project_akhir
{
    public partial class AdminMenu: Form
    {
        private pengguna _akun;
        public AdminMenu(pengguna akun)
        {
            InitializeComponent();
            _akun = akun;

            // ⬇️ Masukkan nama ke label
            lblNamaAdmin.Text = $"Halo, {_akun.NamaLengkap}";
        }

        private void lblNamaAdmin_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var frm = new VarianprodukAdmin(_akun))
            {
                this.Close();

                frm.ShowDialog();

                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var frm = new InputProduk(_akun))
            {
                this.Close();

                frm.ShowDialog();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var frm = new FormPemasok(_akun))
            {
                this.Close();

                frm.ShowDialog();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (var frm = new Detailbeli(_akun))
            {
                this.Close();

                frm.ShowDialog();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var frm = new LaporanPenjualan(_akun))
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
