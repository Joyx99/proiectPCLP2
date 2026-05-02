using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LOG
{
    public partial class Dashboard : Form
    {
        private string username;

        private List<(string Nume, string Gen, string Culoare)> jocuri = new List<(string, string, string)>
        {
            ("CS2", "FPS / Shooter", "#E84057"),
            ("Valorant", "FPS / Tactical", "#FF4655"),
            ("League of Legends", "MOBA", "#C89B3C"),
            ("Minecraft", "Sandbox", "#62B47A"),
            ("GTA V", "Open World", "#F7941D"),
            ("Fortnite", "Battle Royale", "#9B59B6"),
            ("Dota 2", "MOBA", "#C0392B"),
            ("Apex Legends", "Battle Royale", "#DA3C23"),
            ("FIFA", "Sport", "#2ECC71"),
            ("Rocket League", "Sport", "#3498DB"),
            ("Among Us", "Social", "#7F8C8D"),
            ("Rust", "Survival", "#8B4513"),
        };

        public Dashboard(string username)
        {
            InitializeComponent();
            this.username = username;
            this.Text = "UniGaming Lobby";
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            labelWelcome.Text = "🎮 Bun venit, " + username + "!";
            IncarcaJocuri();

            // Conectare buton Profil
            btnProfil.Click += (s, ev) =>
            {
                FormProfil profil = new FormProfil(username);
                profil.ShowDialog();
            };

            //buton cautare utilizatori
            btnChat.Click += (s, ev) =>
            {
                FormCautare cautare = new FormCautare(username);
                cautare.ShowDialog();
            };
        }

        private void IncarcaJocuri()
        {
            panelJocuri.Controls.Clear();
            panelJocuri.AutoScroll = true;

            int x = 20, y = 20;
            int cardW = 200, cardH = 120;
            int spacing = 20;
            int coloane = (panelJocuri.Width - 20) / (cardW + spacing);
            if (coloane < 1) coloane = 1;
            int col = 0;

            foreach (var joc in jocuri)
            {
                Panel card = new Panel();
                card.Size = new Size(cardW, cardH);
                card.Location = new Point(x, y);
                card.BackColor = ColorTranslator.FromHtml(joc.Culoare);
                card.Cursor = Cursors.Hand;
                card.Tag = joc.Nume;

                card.Paint += (s, pe) =>
                {
                    pe.Graphics.DrawRectangle(new Pen(Color.White, 1), 0, 0, card.Width - 1, card.Height - 1);
                };

                Label lblNume = new Label();
                lblNume.Text = joc.Nume;
                lblNume.Font = new Font("Segoe UI", 13, FontStyle.Bold);
                lblNume.ForeColor = Color.White;
                lblNume.Location = new Point(10, 15);
                lblNume.Size = new Size(180, 30);
                lblNume.Tag = joc.Nume;

                Label lblGen = new Label();
                lblGen.Text = joc.Gen;
                lblGen.Font = new Font("Segoe UI", 9);
                lblGen.ForeColor = Color.FromArgb(220, 220, 220);
                lblGen.Location = new Point(10, 50);
                lblGen.Size = new Size(180, 20);
                lblGen.Tag = joc.Nume;

                Button btnDetalii = new Button();
                btnDetalii.Text = "Vezi detalii →";
                btnDetalii.FlatStyle = FlatStyle.Flat;
                btnDetalii.FlatAppearance.BorderColor = Color.White;
                btnDetalii.BackColor = Color.FromArgb(50, 0, 0, 0);
                btnDetalii.ForeColor = Color.White;
                btnDetalii.Font = new Font("Segoe UI", 8);
                btnDetalii.Size = new Size(120, 28);
                btnDetalii.Location = new Point(10, 80);
                btnDetalii.Tag = joc.Nume;
                btnDetalii.Click += BtnDetalii_Click;

                card.Controls.Add(lblNume);
                card.Controls.Add(lblGen);
                card.Controls.Add(btnDetalii);
                card.Click += Card_Click;
                lblNume.Click += Card_Click;
                lblGen.Click += Card_Click;

                panelJocuri.Controls.Add(card);

                col++;
                if (col >= coloane)
                {
                    col = 0;
                    x = 20;
                    y += cardH + spacing;
                }
                else
                {
                    x += cardW + spacing;
                }
            }
        }

        private void Card_Click(object sender, EventArgs e)
        {
            Control c = sender as Control;
            string numeJoc = c.Tag?.ToString();
            if (numeJoc != null)
                DeschideDetalii(numeJoc);
        }

        private void BtnDetalii_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string numeJoc = btn.Tag?.ToString();
            if (numeJoc != null)
                DeschideDetalii(numeJoc);
        }

        private void DeschideDetalii(string numeJoc)
        {
            FormDetaliiJoc detalii = new FormDetaliiJoc(numeJoc, username);
            detalii.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Close();
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}