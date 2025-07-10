using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_akhir
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            cmbRole.Items.AddRange(new[] { "Admin", "Kasir"});
            cmbRole.SelectedIndex = 0;
            txtPassword.PasswordChar = '●';
        }
        private void SetHint(TextBox box, string hint, bool isPassword = false)
        {
            box.Text = hint;
            box.ForeColor = Color.Gray;
            if (isPassword) box.PasswordChar = '\0';   // placeholder terlihat

            box.Enter += (s, e) =>
            {
                if (box.Text == hint)
                {
                    box.Text = "";
                    box.ForeColor = Color.Black;
                    if (isPassword) box.PasswordChar = '●'; // aktifkan masking
                }
            };

            box.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(box.Text))
                {
                    box.Text = hint;
                    box.ForeColor = Color.Gray;
                    if (isPassword) box.PasswordChar = '\0'; // nonaktifkan masking
                }
            };
        }



        private void RegisterForm_Load(object sender, EventArgs e)
        {
            SetHint(txtNamaLengkap, "Nama Lengkap");
            SetHint(txtUsername, "Username");
            SetHint(txtPassword, "Password", true);
        }



        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNamaLengkap.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Semua field wajib diisi!", "Validasi",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- Akses DB langsung ---
            using (distroshopDataContext db = new distroshopDataContext())
            {
                // cek username duplikat
                bool exists = db.penggunas.Any(p => p.Username == txtUsername.Text.Trim());
                if (exists)
                {
                    MessageBox.Show("Username sudah dipakai, pilih yang lain.",
                                    "Registrasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // buat entitas pengguna baru
                var akun = new pengguna
                {
                    NamaLengkap = txtNamaLengkap.Text.Trim(),
                    Username = txtUsername.Text.Trim(),
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text),
                    Role = cmbRole.SelectedItem?.ToString() ?? "User",
                };

                db.penggunas.InsertOnSubmit(akun);
                db.SubmitChanges();         // simpan ➜ IdPengguna terisi otomatis

                MessageBox.Show($"Registrasi berhasil!",
                                "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();               // kembali ke login
            }
        }
    }
}
