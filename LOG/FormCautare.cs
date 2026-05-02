using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace LOG
{
    public partial class FormCautare : Form
    {
        private string username;
        private TextBox txtCautare;
        private ListBox listRezultate;
        private Label lblInfo;

        public FormCautare(string username)
        {
            InitializeComponent();
            this.username = username;
            this.Text = "🔍 Caută Utilizatori";
            this.ClientSize = new Size(500, 450);
            this.BackColor = Color.FromArgb(18, 18, 30);
            this.StartPosition = FormStartPosition.CenterScreen;
            BuildUI();
        }

        private void BuildUI()
        {
            Label lblTitlu = new Label();
            lblTitlu.Text = "🔍 Caută Utilizatori";
            lblTitlu.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitlu.ForeColor = Color.FromArgb(0, 230, 180);
            lblTitlu.Location = new Point(20, 15);
            lblTitlu.Size = new Size(460, 45);

            Label lblCauta = new Label();
            lblCauta.Text = "Introdu username:";
            lblCauta.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblCauta.ForeColor = Color.White;
            lblCauta.Location = new Point(20, 75);
            lblCauta.Size = new Size(200, 25);

            txtCautare = new TextBox();
            txtCautare.Location = new Point(20, 100);
            txtCautare.Size = new Size(350, 35);
            txtCautare.Font = new Font("Segoe UI", 11);
            txtCautare.BackColor = Color.FromArgb(40, 40, 60);
            txtCautare.ForeColor = Color.White;
            txtCautare.BorderStyle = BorderStyle.FixedSingle;
            txtCautare.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    Cauta();
                }
            };

            Button btnCauta = new Button();
            btnCauta.Text = "Caută";
            btnCauta.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnCauta.BackColor = Color.FromArgb(0, 180, 140);
            btnCauta.ForeColor = Color.White;
            btnCauta.FlatStyle = FlatStyle.Flat;
            btnCauta.Size = new Size(110, 35);
            btnCauta.Location = new Point(380, 100);
            btnCauta.Click += (s, e) => Cauta();

            lblInfo = new Label();
            lblInfo.Text = "";
            lblInfo.Font = new Font("Segoe UI", 9);
            lblInfo.ForeColor = Color.Gray;
            lblInfo.Location = new Point(20, 145);
            lblInfo.Size = new Size(460, 25);

            listRezultate = new ListBox();
            listRezultate.Location = new Point(20, 175);
            listRezultate.Size = new Size(460, 200);
            listRezultate.BackColor = Color.FromArgb(30, 30, 50);
            listRezultate.ForeColor = Color.White;
            listRezultate.Font = new Font("Segoe UI", 11);
            listRezultate.BorderStyle = BorderStyle.None;
            listRezultate.DoubleClick += ListRezultate_DoubleClick;

            Label lblHint = new Label();
            lblHint.Text = "💡 Dublu click pe un utilizator pentru a vedea profilul";
            lblHint.Font = new Font("Segoe UI", 9);
            lblHint.ForeColor = Color.Gray;
            lblHint.Location = new Point(20, 385);
            lblHint.Size = new Size(460, 20);

            Button btnBack = new Button();
            btnBack.Text = "← Înapoi";
            btnBack.Font = new Font("Segoe UI", 10);
            btnBack.BackColor = Color.FromArgb(50, 50, 80);
            btnBack.ForeColor = Color.White;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Size = new Size(120, 40);
            btnBack.Location = new Point(20, 400);
            btnBack.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[]
            {
                lblTitlu, lblCauta, txtCautare, btnCauta,
                lblInfo, listRezultate, lblHint, btnBack
            });
        }

        private void Cauta()
        {
            if (string.IsNullOrWhiteSpace(txtCautare.Text)) return;

            listRezultate.Items.Clear();

            try
            {
                using (var con = new SQLiteConnection("Data Source=proiect.db;Version=3;"))
                {
                    con.Open();
                    string sql = "SELECT username FROM users WHERE username LIKE @search AND username != @me";
                    SQLiteCommand cmd = new SQLiteCommand(sql, con);
                    cmd.Parameters.AddWithValue("@search", "%" + txtCautare.Text + "%");
                    cmd.Parameters.AddWithValue("@me", username);

                    SQLiteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        listRezultate.Items.Add("👤 " + reader["username"].ToString());

                    lblInfo.Text = listRezultate.Items.Count + " utilizator(i) găsit(i)";

                    if (listRezultate.Items.Count == 0)
                        lblInfo.Text = "Niciun utilizator găsit.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message);
            }
        }

        private void ListRezultate_DoubleClick(object sender, EventArgs e)
        {
            if (listRezultate.SelectedItem == null) return;

            string userSelectat = listRezultate.SelectedItem.ToString().Replace("👤 ", "");
            FormProfil profil = new FormProfil(userSelectat);
            profil.ShowDialog();
        }
    }
}