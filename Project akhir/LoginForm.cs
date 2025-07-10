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
    public partial class LoginForm: Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var frm = new RegisterForm())
            {
                this.Hide();

                frm.ShowDialog();

                this.Show();
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Username dan password wajib diisi.",
                                "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Ambil akun dari DB via LINQ to SQL
            using (distroshopDataContext db = new distroshopDataContext())
            {
                var akun = db.penggunas
                             .FirstOrDefault(p => p.Username == txtUsername.Text.Trim()
                                               );

                // 3. Cek akun & verifikasi hash password
                if (akun != null &&
                    BCrypt.Net.BCrypt.Verify(txtPassword.Text, akun.PasswordHash))
                {
                    // 4. Routing berdasarkan Role
                    this.Hide();  // sembunyikan LoginForm

                    Form nextForm = null;
                    if (akun.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                        nextForm = new AdminMenu(akun);      // (opsional) kirim objek akun
                    else if (akun.Role.Equals("Kasir", StringComparison.OrdinalIgnoreCase))
                        nextForm = new KaryawanMenu(akun);
                    else
                    {
                        MessageBox.Show("Role tidak dikenali.", "Info",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Show();
                        return;
                    }

                    // tampilkan form tujuan; saat ditutup, kembalikan LoginForm
                    nextForm.FormClosed += (s, args) => this.Show();
                    nextForm.Show();
                }
                else
                {
                    MessageBox.Show("Username atau password salah / akun non-aktif.",
                                    "Login gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void SetHint(TextBox box, string hint, bool isPassword = false)
        {
            // tampilkan placeholder
            box.Text = hint;
            box.ForeColor = Color.Gray;
            if (isPassword) box.PasswordChar = '\0';          // tampilkan teks biasa

            box.Enter += (s, e) =>
            {
                if (box.Text == hint)
                {
                    box.Text = "";
                    box.ForeColor = Color.Black;
                    if (isPassword) box.PasswordChar = '●';   // mulai masking
                }
            };

            box.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(box.Text))
                {
                    box.Text = hint;
                    box.ForeColor = Color.Gray;
                    if (isPassword) box.PasswordChar = '\0';  // hentikan masking
                }
            };
        }



        private void LoginForm_Load(object sender, EventArgs e)
        {
            SetHint(txtUsername, "Username");
            SetHint(txtPassword, "Password");
        }
    }
}
