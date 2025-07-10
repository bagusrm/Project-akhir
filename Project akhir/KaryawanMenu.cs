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
    public partial class KaryawanMenu: Form
    {
        private pengguna _akun;
        public KaryawanMenu(pengguna akun)
        {
            InitializeComponent();
            _akun = akun;

            lblNamaKaryawan.Text = $"Selamat datang, {_akun.NamaLengkap}";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var frm = new Inputpelanggan(_akun))
            {
                this.Close();

                frm.ShowDialog();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var frm = new VarianProdukkaryawan(_akun))
            {
                this.Close();

                frm.ShowDialog();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var frm = new LaporanPenjualankaryawan(_akun))
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

        private void button3_Click(object sender, EventArgs e)
        {
            using (var frm = new Inputpesanan(_akun))
            {
                this.Hide();
                frm.ShowDialog();
            }
            this.Close();
        }

        private void KaryawanMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
