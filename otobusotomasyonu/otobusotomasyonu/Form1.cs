using System;
using System.Drawing;
using System.Windows.Forms;

namespace otobusotomasyonu
{
    public partial class Form1 : Form
    {
        private string[] servisler = new string[]
        {
            "Menemen", "Aliaða", "Bergama",
            "Ýzmir", "Bornova", "Karþýyaka",
            "Konak", "Çiðli", "Balçova",
            "Bayraklý", "Gaziemir", "Karabaðlar",
            "Narlýdere", "Buca", "Seferihisar",
            "Urla", "Foça", "Dikili",
            "Menderes", "Torbalý"
        };

        private Dictionary<string, bilgiler> acikBilgilerFormlari = new Dictionary<string, bilgiler>();
        private Form2 form2Instance;

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;

            for (int i = 1; i <= 20; i++)
            {
                var button = this.Controls["button" + i] as Button;
                if (button != null && i <= servisler.Length)
                {
                    button.Text = servisler[i - 1];
                    button.Click += Button_Click;
                }
            }

            btnKartSayfasi.Click += btnKartSayfasi_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.Font = new Font("Segoe UI", 10);

            for (int i = 1; i <= 20; i++)
            {
                var button = this.Controls["button" + i] as Button;
                if (button != null)
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.BackColor = Color.FromArgb(0, 120, 215);
                    button.ForeColor = Color.White;
                    button.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    button.Cursor = Cursors.Hand;
                }
            }

            if (btnKartSayfasi != null)
            {
                btnKartSayfasi.FlatStyle = FlatStyle.Flat;
                btnKartSayfasi.FlatAppearance.BorderSize = 0;
                btnKartSayfasi.BackColor = Color.FromArgb(96, 125, 139);
                btnKartSayfasi.ForeColor = Color.White;
                btnKartSayfasi.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btnKartSayfasi.Cursor = Cursors.Hand;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                string servisAdi = btn.Text;

                // Eðer bu servis için açýk bir form varsa onu öne getir
                if (acikBilgilerFormlari.ContainsKey(servisAdi) && !acikBilgilerFormlari[servisAdi].IsDisposed)
                {
                    acikBilgilerFormlari[servisAdi].Show();
                    acikBilgilerFormlari[servisAdi].BringToFront();
                }
                else
                {
                    bilgiler frm = new bilgiler(servisAdi);
                    frm.FormClosed += (s, args) => acikBilgilerFormlari.Remove(servisAdi); // kapandýðýnda listeden çýkar
                    acikBilgilerFormlari[servisAdi] = frm;
                    frm.Show();
                }
                this.Hide();
            }
        }

        private void btnKartSayfasi_Click(object sender, EventArgs e)
        {
            if (form2Instance == null || form2Instance.IsDisposed)
            {
                form2Instance = new Form2();
                form2Instance.FormClosed += (s, args) => form2Instance = null;
                form2Instance.Show();
            }
            else
            {
                form2Instance.Show();
                form2Instance.BringToFront();
            }

            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            // boþ
        }

        private void raporagitbtn_Click(object sender, EventArgs e)
        {
            Rapor raporForm = new Rapor();
            raporForm.Show();  // Form1 açýk kalýr, Rapor yeni pencerede açýlýr
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
