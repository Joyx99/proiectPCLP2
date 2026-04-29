using System;

namespace LOG
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Parola = new System.Windows.Forms.Label();
            this.butonLOGIN = new System.Windows.Forms.Button();
            this.txtmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.mail = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtpass = new Guna.UI2.WinForms.Guna2TextBox();
            this.linksignup = new System.Windows.Forms.Label();
            this.checkpass = new Guna.UI2.WinForms.Guna2CheckBox();
            this.SuspendLayout();

            // Parola
            this.Parola.AutoSize = true;
            this.Parola.BackColor = System.Drawing.Color.Transparent;
            this.Parola.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Parola.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Parola.Location = new System.Drawing.Point(85, 478);
            this.Parola.Name = "Parola";
            this.Parola.Size = new System.Drawing.Size(166, 45);
            this.Parola.TabIndex = 0;
            this.Parola.Text = "Password";

            // butonLOGIN
            this.butonLOGIN.BackColor = System.Drawing.Color.MediumBlue;
            this.butonLOGIN.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butonLOGIN.ForeColor = System.Drawing.Color.AliceBlue;
            this.butonLOGIN.Location = new System.Drawing.Point(133, 683);
            this.butonLOGIN.Name = "butonLOGIN";
            this.butonLOGIN.Size = new System.Drawing.Size(204, 61);
            this.butonLOGIN.TabIndex = 2;
            this.butonLOGIN.Text = "LOGIN";
            this.butonLOGIN.UseVisualStyleBackColor = false;
            this.butonLOGIN.Click += new System.EventHandler(this.butonLOGIN_Click);

            // txtmail
            this.txtmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtmail.DefaultText = "";
            this.txtmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            this.txtmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
            this.txtmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtmail.ForeColor = System.Drawing.Color.Black;
            this.txtmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtmail.Location = new System.Drawing.Point(93, 408);
            this.txtmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtmail.Name = "txtmail";
            this.txtmail.PlaceholderText = "Username";
            this.txtmail.SelectedText = "";
            this.txtmail.Size = new System.Drawing.Size(282, 48);
            this.txtmail.TabIndex = 11;

            // mail
            this.mail.AutoSize = true;
            this.mail.BackColor = System.Drawing.Color.Transparent;
            this.mail.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mail.ForeColor = System.Drawing.SystemColors.Control;
            this.mail.Location = new System.Drawing.Point(85, 349);
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(104, 45);
            this.mail.TabIndex = 10;
            this.mail.Text = "Username";
            this.mail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // label1
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(129, 789);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "Not Register?";
            this.label1.Click += new System.EventHandler(this.label1_Click);

            // txtpass
            this.txtpass.BackColor = System.Drawing.Color.Transparent;
            this.txtpass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtpass.DefaultText = "";
            this.txtpass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            this.txtpass.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
            this.txtpass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtpass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtpass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtpass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtpass.ForeColor = System.Drawing.Color.Black;
            this.txtpass.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtpass.Location = new System.Drawing.Point(96, 544);
            this.txtpass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtpass.Name = "txtpass";
            this.txtpass.PlaceholderText = "Type Password here";
            this.txtpass.SelectedText = "";
            this.txtpass.Size = new System.Drawing.Size(279, 48);
            this.txtpass.TabIndex = 12;
            this.txtpass.UseSystemPasswordChar = true;

            // linksignup
            this.linksignup.AutoSize = true;
            this.linksignup.BackColor = System.Drawing.Color.Transparent;
            this.linksignup.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linksignup.ForeColor = System.Drawing.Color.DodgerBlue;
            this.linksignup.Location = new System.Drawing.Point(263, 789);
            this.linksignup.Name = "linksignup";
            this.linksignup.Size = new System.Drawing.Size(74, 23);
            this.linksignup.TabIndex = 15;
            this.linksignup.Text = "Sign Up";
            this.linksignup.Click += new System.EventHandler(this.linksignup_Click);

            // checkpass
            this.checkpass.AutoSize = true;
            this.checkpass.BackColor = System.Drawing.Color.Transparent;
            this.checkpass.CheckedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.checkpass.CheckedState.BorderRadius = 0;
            this.checkpass.CheckedState.BorderThickness = 0;
            this.checkpass.CheckedState.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.checkpass.CheckMarkColor = System.Drawing.Color.Cyan;
            this.checkpass.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkpass.ForeColor = System.Drawing.Color.Cyan;
            this.checkpass.Location = new System.Drawing.Point(241, 614);
            this.checkpass.Name = "checkpass";
            this.checkpass.Size = new System.Drawing.Size(125, 21);
            this.checkpass.TabIndex = 16;
            this.checkpass.Text = "Show Password";
            this.checkpass.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(125, 137, 149);
            this.checkpass.UncheckedState.BorderRadius = 0;
            this.checkpass.UncheckedState.BorderThickness = 0;
            this.checkpass.UncheckedState.FillColor = System.Drawing.Color.FromArgb(125, 137, 149);
            this.checkpass.UseVisualStyleBackColor = false;
            this.checkpass.CheckedChanged += new System.EventHandler(this.checkpass_CheckedChanged);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1663, 993);
            this.Controls.Add(this.checkpass);
            this.Controls.Add(this.linksignup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.txtmail);
            this.Controls.Add(this.mail);
            this.Controls.Add(this.butonLOGIN);
            this.Controls.Add(this.Parola);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UniGaming - Login";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            FormSignUp signup = new FormSignUp();
            signup.ShowDialog();
        }

        #endregion
        private System.Windows.Forms.Label Parola;
        private System.Windows.Forms.Button butonLOGIN;
        private Guna.UI2.WinForms.Guna2TextBox txtmail;
        private System.Windows.Forms.Label mail;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtpass;
        private System.Windows.Forms.Label linksignup;
        private Guna.UI2.WinForms.Guna2CheckBox checkpass;
    }
}