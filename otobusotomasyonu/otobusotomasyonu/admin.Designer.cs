namespace otobusotomasyonu
{
    partial class admin
    {
        private System.ComponentModel.IContainer components = null;

        // Kontroller
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonLogin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelContainer = new Panel();
            checkBox1 = new CheckBox();
            labelTitle = new Label();
            labelUsername = new Label();
            textBox1 = new TextBox();
            labelPassword = new Label();
            textBox2 = new TextBox();
            buttonLogin = new Button();
            panelContainer.SuspendLayout();
            SuspendLayout();
            // 
            // panelContainer
            // 
            panelContainer.BackColor = Color.FromArgb(40, 40, 40);
            panelContainer.BorderStyle = BorderStyle.FixedSingle;
            panelContainer.Controls.Add(checkBox1);
            panelContainer.Controls.Add(labelTitle);
            panelContainer.Controls.Add(labelUsername);
            panelContainer.Controls.Add(textBox1);
            panelContainer.Controls.Add(labelPassword);
            panelContainer.Controls.Add(textBox2);
            panelContainer.Controls.Add(buttonLogin);
            panelContainer.Location = new Point(450, 90);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(350, 320);
            panelContainer.TabIndex = 0;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.ForeColor = SystemColors.ButtonHighlight;
            checkBox1.Location = new Point(30, 208);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(95, 19);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "Şifreyi Göster";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // labelTitle
            // 
            labelTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            labelTitle.ForeColor = Color.FromArgb(0, 120, 215);
            labelTitle.Location = new Point(10, 10);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(330, 50);
            labelTitle.TabIndex = 1;
            labelTitle.Text = "Servis Kayıt Sistemi";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Font = new Font("Segoe UI", 11F);
            labelUsername.ForeColor = Color.White;
            labelUsername.Location = new Point(30, 80);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(92, 20);
            labelUsername.TabIndex = 2;
            labelUsername.Text = "Kullanıcı Adı";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 11F);
            textBox1.Location = new Point(30, 105);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(290, 27);
            textBox1.TabIndex = 3;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 11F);
            labelPassword.ForeColor = Color.White;
            labelPassword.Location = new Point(30, 150);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(39, 20);
            labelPassword.TabIndex = 4;
            labelPassword.Text = "Şifre";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 11F);
            textBox2.Location = new Point(30, 175);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(290, 27);
            textBox2.TabIndex = 5;
            textBox2.UseSystemPasswordChar = true;
            // 
            // buttonLogin
            // 
            buttonLogin.BackColor = Color.FromArgb(0, 120, 215);
            buttonLogin.FlatAppearance.BorderSize = 0;
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonLogin.ForeColor = Color.White;
            buttonLogin.Location = new Point(30, 259);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(290, 40);
            buttonLogin.TabIndex = 6;
            buttonLogin.Text = "Giriş Yap";
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(1238, 600);
            Controls.Add(panelContainer);
            Name = "admin";
            Text = "Kullanıcı Girişi";
            WindowState = FormWindowState.Maximized;
            Load += admin_Load;
            panelContainer.ResumeLayout(false);
            panelContainer.PerformLayout();
            ResumeLayout(false);
        }
        private CheckBox checkBox1;
    }
}
