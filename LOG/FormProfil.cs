using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace LOG
{
    public partial class FormProfil : Form
    {
        private string username;
        private TextBox txtBio;
        private Label lblUsername;
        private Label lblMessaje;
        private PictureBox avatar;

        public FormProfil(string username)
        {
            InitializeComponent();
            this.username = username;
            this.Text = "👤 Profil - " + username;
            this.ClientSize = new Size(500, 550);
            this.BackColor = Color.FromArgb(18, 18, 30);
            this.StartPosition = FormStartPosition.CenterScreen;
            BuildUI();
            IncarcaProfil();
        }

        private void BuildUI()
        {
            // Titlu
            Label lblTitlu = new Label();
            lblTitlu.Text = "👤 Profilul Meu";
            lblTitlu.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitlu.ForeColor = Color.FromArgb(0, 230, 180);
            lblTitlu.Location = new Point(30, 20);
            lblTitlu.Size = new Size(440, 45);

            // Avatar
            avatar = new PictureBox();
            avatar.Size = new Size(100, 100);
            avatar.Location = new Point(30, 80);
            avatar.BackColor = Color.FromArgb(50, 50, 80);
            avatar.BorderStyle = BorderStyle.FixedSingle;
            avatar.SizeMode = PictureBoxSizeMode.Zoom;
            avatar.Cursor = Cursors.Hand;
            avatar.Click += Avatar_Click;

            Label lblClickAvatar = new Label();
            lblClickAvatar.Text = "Click pentru\na schimba poza";
            lblClickAvatar.Font = new Font("Segoe UI", 8);
            lblClickAvatar.ForeColor = Color.Gray;
            lblClickAvatar.Location = new Point(140, 100);
            lblClickAvatar.Size = new Size(150, 40);

            // Username
            Label lblUserTitle = new Label();
            lblUserTitle.Text = "Username";
            lblUserTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblUserTitle.ForeColor = Color.White;
            lblUserTitle.Location = new Point(30, 200);
            lblUserTitle.Size = new Size(200, 25);

            lblUsername = new Label();
            lblUsername.Font = new Font("Segoe UI", 12);
            lblUsername.ForeColor = Color.FromArgb(0, 230, 180);
            lblUsername.Location = new Point(30, 225);
            lblUsername.Size = new Size(440, 30);

            // Bio
            Label lblBioTitle = new Label();
            lblBioTitle.Text = "Bio";
            lblBioTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblBioTitle.ForeColor = Color.White;
            lblBioTitle.Location = new Point(30, 270);
            lblBioTitle.Size = new Size(200, 25);

            txtBio = new TextBox();
            txtBio.Location = new Point(30, 295);
            txtBio.Size = new Size(440, 60);
            txtBio.Font = new Font("Segoe UI", 10);
            txtBio.BackColor = Color.FromArgb(40, 40, 60);
            txtBio.ForeColor = Color.White;
            txtBio.BorderStyle = BorderStyle.FixedSingle;
            txtBio.Multiline = true;

            // Statistici
            Label lblStatTitle = new Label();
            lblStatTitle.Text = "Statistici";
            lblStatTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblStatTitle.ForeColor = Color.White;
            lblStatTitle.Location = new Point(30, 370);
            lblStatTitle.Size = new Size(200, 25);

            lblMessaje = new Label();
            lblMessaje.Font = new Font("Segoe UI", 10);
            lblMessaje.ForeColor = Color.White;
            lblMessaje.Location = new Point(30, 395);
            lblMessaje.Size = new Size(440, 25);

            // Buton Salvează
            Button btnSalveaza = new Button();
            btnSalveaza.Text = "💾 Salvează";
            btnSalveaza.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnSalveaza.BackColor = Color.FromArgb(0, 180, 140);
            btnSalveaza.ForeColor = Color.White;
            btnSalveaza.FlatStyle = FlatStyle.Flat;
            btnSalveaza.Size = new Size(200, 45);
            btnSalveaza.Location = new Point(30, 460);
            btnSalveaza.Click += BtnSalveaza_Click;

            // Buton Înapoi
            Button btnBack = new Button();
            btnBack.Text = "← Înapoi";
            btnBack.Font = new Font("Segoe UI", 10);
            btnBack.BackColor = Color.FromArgb(50, 50, 80);
            btnBack.ForeColor = Color.White;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Size = new Size(120, 45);
            btnBack.Location = new Point(350, 460);
            btnBack.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[]
            {
                lblTitlu, avatar, lblClickAvatar,
                lblUserTitle, lblUsername,
                lblBioTitle, txtBio,
                lblStatTitle, lblMessaje,
                btnSalveaza, btnBack
            });
        }

        private void IncarcaProfil()
        {
            try
            {
                using (var con = new SQLiteConnection("Data Source=proiect.db;Version=3;"))
                {
                    con.Open();

                    // Incarca bio si avatar
                    string sql = "SELECT bio, avatar FROM users WHERE username=@username";
                    SQLiteCommand cmd = new SQLiteCommand(sql, con);
                    cmd.Parameters.AddWithValue("@username", username);
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtBio.Text = reader["bio"] != DBNull.Value ? reader["bio"].ToString() : "";
                        string avatarPath = reader["avatar"] != DBNull.Value ? reader["avatar"].ToString() : "";
                        if (!string.IsNullOrEmpty(avatarPath) && System.IO.File.Exists(avatarPath))
                            avatar.Image = Image.FromFile(avatarPath);
                    }
                    reader.Close();

                    // Numara mesajele trimise
                    string sqlMsg = "SELECT COUNT(*) FROM messages WHERE username=@username";
                    SQLiteCommand cmdMsg = new SQLiteCommand(sqlMsg, con);
                    cmdMsg.Parameters.AddWithValue("@username", username);
                    int nrMesaje = Convert.ToInt32(cmdMsg.ExecuteScalar());

                    lblUsername.Text = username;
                    lblMessaje.Text = "💬 Mesaje trimise: " + nrMesaje;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message);
            }
        }

        private void Avatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Imagini|*.jpg;*.jpeg;*.png;*.bmp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                avatar.Image = Image.FromFile(dialog.FileName);
                // Salvează calea avatarului
                try
                {
                    using (var con = new SQLiteConnection("Data Source=proiect.db;Version=3;"))
                    {
                        con.Open();
                        string sql = "UPDATE users SET avatar=@avatar WHERE username=@username";
                        SQLiteCommand cmd = new SQLiteCommand(sql, con);
                        cmd.Parameters.AddWithValue("@avatar", dialog.FileName);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch { }
            }
        }

        private void BtnSalveaza_Click(object sender, EventArgs e)
        {
            try
            {
                using (var con = new SQLiteConnection("Data Source=proiect.db;Version=3;"))
                {
                    con.Open();
                    string sql = "UPDATE users SET bio=@bio WHERE username=@username";
                    SQLiteCommand cmd = new SQLiteCommand(sql, con);
                    cmd.Parameters.AddWithValue("@bio", txtBio.Text);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Profil salvat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message);
            }
        }
    }
}