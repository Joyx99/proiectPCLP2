namespace LOG
{
    partial class Dashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelWelcome = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelJocuri = new System.Windows.Forms.Panel();
            this.btnLeaderboard = new System.Windows.Forms.Button();
            this.btnChat = new System.Windows.Forms.Button();
            this.btnProfil = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Form
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Text = "UniGaming Lobby";
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 30);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Dashboard_FormClosed);
            this.Load += new System.EventHandler(this.Dashboard_Load);

            // panelTop
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(30, 30, 50);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 70;
            this.panelTop.Controls.Add(this.labelWelcome);
            this.panelTop.Controls.Add(this.btnLogout);
            this.panelTop.Controls.Add(this.btnProfil);

            // labelWelcome
            this.labelWelcome.ForeColor = System.Drawing.Color.FromArgb(0, 230, 180);
            this.labelWelcome.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold);
            this.labelWelcome.Location = new System.Drawing.Point(20, 15);
            this.labelWelcome.Size = new System.Drawing.Size(500, 40);

            // btnProfil
            this.btnProfil.Text = "👤 Profil";
            this.btnProfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfil.BackColor = System.Drawing.Color.FromArgb(50, 50, 80);
            this.btnProfil.ForeColor = System.Drawing.Color.White;
            this.btnProfil.Font = new System.Drawing.Font("Segoe UI", 10);
            this.btnProfil.Size = new System.Drawing.Size(100, 40);
            this.btnProfil.Location = new System.Drawing.Point(800, 15);

            // btnLogout
            this.btnLogout.Text = "🚪 Logout";
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(180, 30, 30);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10);
            this.btnLogout.Size = new System.Drawing.Size(100, 40);
            this.btnLogout.Location = new System.Drawing.Point(920, 15);
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // panelJocuri
            this.panelJocuri.BackColor = System.Drawing.Color.FromArgb(18, 18, 30);
            this.panelJocuri.Dock = System.Windows.Forms.DockStyle.Fill;

            // btnLeaderboard
            this.btnLeaderboard.Text = "🏆 Leaderboard";
            this.btnLeaderboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeaderboard.BackColor = System.Drawing.Color.FromArgb(50, 50, 80);
            this.btnLeaderboard.ForeColor = System.Drawing.Color.White;
            this.btnLeaderboard.Font = new System.Drawing.Font("Segoe UI", 10);
            this.btnLeaderboard.Size = new System.Drawing.Size(150, 45);
            this.btnLeaderboard.Location = new System.Drawing.Point(20, 500);

            // btnChat
            this.btnChat.Text = "💬 Chat";
            this.btnChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChat.BackColor = System.Drawing.Color.FromArgb(50, 50, 80);
            this.btnChat.ForeColor = System.Drawing.Color.White;
            this.btnChat.Font = new System.Drawing.Font("Segoe UI", 10);
            this.btnChat.Size = new System.Drawing.Size(150, 45);
            this.btnChat.Location = new System.Drawing.Point(190, 500);

            this.panelJocuri.Controls.Add(this.btnLeaderboard);
            this.panelJocuri.Controls.Add(this.btnChat);

            this.Controls.Add(this.panelJocuri);
            this.Controls.Add(this.panelTop);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelJocuri;
        private System.Windows.Forms.Button btnLeaderboard;
        private System.Windows.Forms.Button btnChat;
        private System.Windows.Forms.Button btnProfil;
        private System.Windows.Forms.Button btnLogout;
    }
}