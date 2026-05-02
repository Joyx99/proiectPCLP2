using System;
using System.Drawing;
using System.Windows.Forms;

namespace LOG
{
    public partial class FormDetaliiJoc : Form
    {
        private string numeJoc;
        private string username;

        public FormDetaliiJoc(string numeJoc, string username)
        {
            InitializeComponent();
            this.numeJoc = numeJoc;
            this.username = username;
            this.Text = numeJoc + " - Detalii";
            this.ClientSize = new Size(600, 400);
            this.BackColor = Color.FromArgb(18, 18, 30);
            IncarcaDetalii();
        }

        private void IncarcaDetalii()
        {
            // Titlu
            Label lblTitlu = new Label();
            lblTitlu.Text = "🎮 " + numeJoc;
            lblTitlu.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblTitlu.ForeColor = Color.FromArgb(0, 230, 180);
            lblTitlu.Location = new Point(30, 30);
            lblTitlu.Size = new Size(540, 50);

            // Descriere
            Label lblDesc = new Label();
            lblDesc.Text = "Jucători activi în facultate: 0\nParticipanți turneu: 0\nStatus: Coming Soon";
            lblDesc.Font = new Font("Segoe UI", 11);
            lblDesc.ForeColor = Color.White;
            lblDesc.Location = new Point(30, 100);
            lblDesc.Size = new Size(540, 80);

            // Buton Chat Lobby

            Button btnChat = new Button();
            btnChat.Text = "💬 Intră în Lobby Chat";
            btnChat.FlatStyle = FlatStyle.Flat;
            btnChat.BackColor = Color.FromArgb(0, 180, 140);
            btnChat.ForeColor = Color.White;
            btnChat.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnChat.Size = new Size(250, 45);
            btnChat.Location = new Point(30, 200);
            btnChat.Click += (s, e) =>
            {
                FormChat chat = new FormChat(username, numeJoc);
                chat.ShowDialog();
            };

            // Buton înapoi
            Button btnBack = new Button();
            btnBack.Text = "← Înapoi";
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.BackColor = Color.FromArgb(50, 50, 80);
            btnBack.ForeColor = Color.White;
            btnBack.Font = new Font("Segoe UI", 10);
            btnBack.Size = new Size(120, 40);
            btnBack.Location = new Point(30, 320);
            btnBack.Click += (s, e) => this.Close();

            this.Controls.Add(lblTitlu);
            this.Controls.Add(lblDesc);
            this.Controls.Add(btnChat);
            this.Controls.Add(btnBack);
        }
    }
}