using System;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace LOG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreareBazaDate();
            this.AcceptButton = null;
            this.CancelButton = null;
            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape) e.SuppressKeyPress = true;
            };
        }

        string HashPassword(string parola)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(parola));
                return Convert.ToBase64String(bytes);
            }
        }

        public void CreareBazaDate()
        {
            if (!System.IO.File.Exists("proiect.db"))
            {
                SQLiteConnection.CreateFile("proiect.db");
                using (var con = new SQLiteConnection("Data Source=proiect.db;Version=3;"))
                {
                    con.Open();

                    string sqlUsers = @"CREATE TABLE users (
                id INTEGER PRIMARY KEY AUTOINCREMENT, 
                username TEXT, 
                password TEXT,
                bio TEXT,
                avatar TEXT)";
                    new SQLiteCommand(sqlUsers, con).ExecuteNonQuery();

                    string sqlMessages = @"CREATE TABLE messages (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                username TEXT,
                joc TEXT,
                mesaj TEXT,
                timp TEXT)";
                    new SQLiteCommand(sqlMessages, con).ExecuteNonQuery();
                }
            }
        }

        private void butonLOGIN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtmail.Text))
            {
                MessageBox.Show("Introduceți username-ul!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtpass.Text))
            {
                MessageBox.Show("Introduceți parola!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var con = new SQLiteConnection("Data Source=proiect.db;Version=3;"))
                {
                    con.Open();
                    string sql = "SELECT username FROM users WHERE username=@username AND password=@password";
                    SQLiteCommand cmd = new SQLiteCommand(sql, con);
                    cmd.Parameters.AddWithValue("@username", txtmail.Text);
                    cmd.Parameters.AddWithValue("@password", HashPassword(txtpass.Text));

                    object result = cmd.ExecuteScalar();
                    string usernameGasit = result != null ? result.ToString() : null;

                    if (usernameGasit != null)
                    {
                        Dashboard dashboard = new Dashboard(usernameGasit);
                        dashboard.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Username sau parolă incorectă!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkpass_CheckedChanged(object sender, EventArgs e)
        {
            txtpass.UseSystemPasswordChar = !checkpass.Checked;
        }

        private void linksignup_Click(object sender, EventArgs e)
        {
            FormSignUp signup = new FormSignUp();
            signup.ShowDialog();
        }
    }
}