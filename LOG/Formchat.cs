using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace LOG
{
    public partial class FormChat : Form
    {
        private string username;
        private string joc;
        private Timer timer;
        private RichTextBox chatBox;
        private TextBox txtMesaj;
        private int lastId = 0;

        public FormChat(string username, string joc)
        {
            InitializeComponent();
            this.username = username;
            this.joc = joc;
            this.Text = "💬 Lobby " + joc;
            this.ClientSize = new Size(600, 500);
            this.BackColor = Color.FromArgb(18, 18, 30);
            this.StartPosition = FormStartPosition.CenterScreen;
            BuildUI();
            IncarcaMesaje();
            StartTimer();
        }

        private void BuildUI()
        {
            Label lblTitlu = new Label();
            lblTitlu.Text = "💬 Lobby " + joc;
            lblTitlu.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTitlu.ForeColor = Color.FromArgb(0, 230, 180);
            lblTitlu.Location = new Point(10, 10);
            lblTitlu.Size = new Size(580, 35);

            chatBox = new RichTextBox();
            chatBox.Location = new Point(10, 55);
            chatBox.Size = new Size(580, 350);
            chatBox.BackColor = Color.FromArgb(30, 30, 50);
            chatBox.ForeColor = Color.White;
            chatBox.Font = new Font("Segoe UI", 10);
            chatBox.ReadOnly = true;
            chatBox.BorderStyle = BorderStyle.None;
            chatBox.ScrollBars = RichTextBoxScrollBars.Vertical;

            txtMesaj = new TextBox();
            txtMesaj.Location = new Point(10, 415);
            txtMesaj.Size = new Size(470, 35);
            txtMesaj.Font = new Font("Segoe UI", 11);
            txtMesaj.BackColor = Color.FromArgb(40, 40, 60);
            txtMesaj.ForeColor = Color.White;
            txtMesaj.BorderStyle = BorderStyle.FixedSingle;
            txtMesaj.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    TrimiteMessaj();
                }
            };

            Button btnTrimite = new Button();
            btnTrimite.Text = "Trimite";
            btnTrimite.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnTrimite.BackColor = Color.FromArgb(0, 180, 140);
            btnTrimite.ForeColor = Color.White;
            btnTrimite.FlatStyle = FlatStyle.Flat;
            btnTrimite.Size = new Size(110, 35);
            btnTrimite.Location = new Point(490, 415);
            btnTrimite.Click += (s, e) => TrimiteMessaj();

            Button btnBack = new Button();
            btnBack.Text = "← Înapoi";
            btnBack.Font = new Font("Segoe UI", 9);
            btnBack.BackColor = Color.FromArgb(50, 50, 80);
            btnBack.ForeColor = Color.White;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Size = new Size(100, 30);
            btnBack.Location = new Point(10, 458);
            btnBack.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[]
            {
                lblTitlu, chatBox, txtMesaj, btnTrimite, btnBack
            });
        }

        private void TrimiteMessaj()
        {
            if (string.IsNullOrWhiteSpace(txtMesaj.Text)) return;

            try
            {
                using (var con = new SQLiteConnection("Data Source=proiect.db;Version=3;"))
                {
                    con.Open();
                    string sql = "INSERT INTO messages (username, joc, mesaj, timp) VALUES (@username, @joc, @mesaj, @timp)";
                    SQLiteCommand cmd = new SQLiteCommand(sql, con);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@joc", joc);
                    cmd.Parameters.AddWithValue("@mesaj", txtMesaj.Text);
                    cmd.Parameters.AddWithValue("@timp", DateTime.Now.ToString("HH:mm"));
                    cmd.ExecuteNonQuery();
                }
                txtMesaj.Clear();
                IncarcaMesaje();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message);
            }
        }

        private void IncarcaMesaje()
        {
            try
            {
                using (var con = new SQLiteConnection("Data Source=proiect.db;Version=3;"))
                {
                    con.Open();
                    string sql = "SELECT id, username, mesaj, timp FROM messages WHERE joc=@joc AND id > @lastId ORDER BY id ASC";
                    SQLiteCommand cmd = new SQLiteCommand(sql, con);
                    cmd.Parameters.AddWithValue("@joc", joc);
                    cmd.Parameters.AddWithValue("@lastId", lastId);

                    SQLiteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lastId = Convert.ToInt32(reader["id"]);
                        string user = reader["username"].ToString();
                        string mesaj = reader["mesaj"].ToString();
                        string timp = reader["timp"].ToString();

                        if (user == username)
                            chatBox.SelectionColor = Color.FromArgb(0, 230, 180);
                        else
                            chatBox.SelectionColor = Color.FromArgb(100, 180, 255);

                        chatBox.AppendText("[" + timp + "] " + user + ": ");
                        chatBox.SelectionColor = Color.White;
                        chatBox.AppendText(mesaj + "\n");
                    }
                    chatBox.ScrollToCaret();
                }
            }
            catch { }
        }

        private void StartTimer()
        {
            timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += (s, e) => IncarcaMesaje();
            timer.Start();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            timer.Stop();
            base.OnFormClosed(e);
        }
    }
}