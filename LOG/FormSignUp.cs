using System;
using System.Data.SQLite;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace LOG
{
    public partial class FormSignUp : Form
    {
        public FormSignUp()
        {
            InitializeComponent();
            this.Text = "UniGaming - Sign Up";
            this.ClientSize = new Size(500, 500);
            this.BackColor = Color.FromArgb(18, 18, 30);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AcceptButton = null;
            this.CancelButton = null;
            BuildUI();
        }

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtParola;
        private System.Windows.Forms.TextBox txtConfirmParola;

        private void BuildUI()
        {
            Label lblTitlu = new Label();
            lblTitlu.Text = "🎮 Creare Cont";
            lblTitlu.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblTitlu.ForeColor = Color.FromArgb(0, 230, 180);
            lblTitlu.Location = new Point(30, 30);
            lblTitlu.Size = new Size(440, 50);

            Label lblUser = new Label();
            lblUser.Text = "Username";
            lblUser.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblUser.ForeColor = Color.White;
            lblUser.Location = new Point(30, 110);
            lblUser.Size = new Size(200, 25);

            txtUsername = new TextBox();
            txtUsername.Location = new Point(30, 135);
            txtUsername.Size = new Size(440, 35);
            txtUsername.Font = new Font("Segoe UI", 11);
            txtUsername.BackColor = Color.FromArgb(40, 40, 60);
            txtUsername.ForeColor = Color.White;
            txtUsername.BorderStyle = BorderStyle.FixedSingle;

            Label lblParola = new Label();
            lblParola.Text = "Parolă";
            lblParola.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblParola.ForeColor = Color.White;
            lblParola.Location = new Point(30, 185);
            lblParola.Size = new Size(200, 25);

            txtParola = new TextBox();
            txtParola.Location = new Point(30, 210);
            txtParola.Size = new Size(440, 35);
            txtParola.Font = new Font("Segoe UI", 11);
            txtParola.BackColor = Color.FromArgb(40, 40, 60);
            txtParola.ForeColor = Color.White;
            txtParola.BorderStyle = BorderStyle.FixedSingle;
            txtParola.UseSystemPasswordChar = true;

            Label lblConfirm = new Label();
            lblConfirm.Text = "Confirmă Parola";
            lblConfirm.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblConfirm.ForeColor = Color.White;
            lblConfirm.Location = new Point(30, 260);
            lblConfirm.Size = new Size(200, 25);

            txtConfirmParola = new TextBox();
            txtConfirmParola.Location = new Point(30, 285);
            txtConfirmParola.Size = new Size(440, 35);
            txtConfirmParola.Font = new Font("Segoe UI", 11);
            txtConfirmParola.BackColor = Color.FromArgb(40, 40, 60);
            txtConfirmParola.ForeColor = Color.White;
            txtConfirmParola.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmParola.UseSystemPasswordChar = true;

            Button btnRegister = new Button();
            btnRegister.Text = "Creează Cont";
            btnRegister.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            btnRegister.BackColor = Color.FromArgb(0, 180, 140);
            btnRegister.ForeColor = Color.White;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Size = new Size(440, 50);
            btnRegister.Location = new Point(30, 350);
            btnRegister.Click += BtnRegister_Click;

            Label lblLogin = new Label();
            lblLogin.Text = "Ai deja cont? Login";
            lblLogin.Font = new Font("Segoe UI", 10, FontStyle.Underline);
            lblLogin.ForeColor = Color.DodgerBlue;
            lblLogin.Location = new Point(170, 420);
            lblLogin.Size = new Size(200, 25);
            lblLogin.Cursor = Cursors.Hand;
            lblLogin.Click += (s, ev) => { this.Close(); };

            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblTitlu, lblUser, txtUsername,
                lblParola, txtParola, lblConfirm, txtConfirmParola,
                btnRegister, lblLogin
            });
        }

        string HashPassword(string parola)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(parola));
                return Convert.ToBase64String(bytes);
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || txtUsername.Text.Length < 3)
            {
                MessageBox.Show("Username-ul trebuie să aibă minim 3 caractere!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtParola.Text) || txtParola.Text.Length < 4)
            {
                MessageBox.Show("Parola trebuie să aibă minim 4 caractere!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtParola.Text != txtConfirmParola.Text)
            {
                MessageBox.Show("Parolele nu coincid!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var con = new SQLiteConnection("Data Source=proiect.db;Version=3;"))
                {
                    con.Open();

                    string checkUser = "SELECT COUNT(*) FROM users WHERE username=@username";
                    SQLiteCommand checkCmd = new SQLiteCommand(checkUser, con);
                    checkCmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                    {
                        MessageBox.Show("Username-ul există deja!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string sql = "INSERT INTO users (username, password) VALUES (@username, @password)";
                    SQLiteCommand cmd = new SQLiteCommand(sql, con);
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", HashPassword(txtParola.Text));
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cont creat cu succes! Te poți autentifica.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}