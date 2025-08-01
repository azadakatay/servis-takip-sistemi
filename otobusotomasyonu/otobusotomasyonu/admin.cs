using System;
using System.Windows.Forms;

namespace otobusotomasyonu
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();

            // Form yeniden boyutlandığında ortala
            this.Resize += Admin_Resize;
            CenterPanel();

            // Başlangıçta şifre gizli
            textBox2.UseSystemPasswordChar = true;

            // CheckBox ile şifreyi göster/gizle
            checkBox1.CheckedChanged += (s, e) =>
            {
                textBox2.UseSystemPasswordChar = !checkBox1.Checked;
            };
        }

        private void Admin_Resize(object sender, EventArgs e)
        {
            CenterPanel();
        }

        private void CenterPanel()
        {
            // panelContainer form ortasında olacak
            panelContainer.Left = (this.ClientSize.Width - panelContainer.Width) / 2;
            panelContainer.Top = (this.ClientSize.Height - panelContainer.Height) / 2;
        }

        private void admin_Load(object sender, EventArgs e)
        {
            // boş
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (username == "a" && password == "1")
            {
                // 1. Giriş başarılı etiketi oluşur
                Label mesajLabel = new Label();
                mesajLabel.Text = "Giriş Başarılı ! Hoş geldiniz.";
                mesajLabel.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                mesajLabel.ForeColor = Color.White;
                mesajLabel.BackColor = Color.FromArgb(50, 50, 50); // Hafif koyu arka plan
                mesajLabel.AutoSize = false;
                mesajLabel.Size = new Size(400, 120);
                mesajLabel.TextAlign = ContentAlignment.MiddleCenter;
                mesajLabel.BorderStyle = BorderStyle.FixedSingle;
                mesajLabel.Location = new Point((this.ClientSize.Width - mesajLabel.Width) / 2,
                                                (this.ClientSize.Height - mesajLabel.Height) / 2);
                this.Controls.Add(mesajLabel);
                mesajLabel.BringToFront();

                // 2. Fade-in animasyonu (0 → 100% opaklık)
                for (int i = 0; i <= 100; i += 10)
                {
                    mesajLabel.BackColor = Color.FromArgb(i * 2, 50, 50, 50);
                    await Task.Delay(15);
                }

                // 3. 1 saniye bekle
                await Task.Delay(1000);

                // 4. Fade-out animasyonu (100% → 0 opaklık)
                for (int i = 100; i >= 0; i -= 10)
                {
                    mesajLabel.BackColor = Color.FromArgb(i * 2, 50, 50, 50);
                    await Task.Delay(15);
                }

                // 5. Etiketi kaldır
                this.Controls.Remove(mesajLabel);
                mesajLabel.Dispose();

                // 6. Form1’e geçiş
                Form1 form1 = new Form1();
                form1.FormClosed += (s, args) => this.Close();
                form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Boş şimdilik gerek yok
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Boş şimdilik gerek yok
        }
    }
}
