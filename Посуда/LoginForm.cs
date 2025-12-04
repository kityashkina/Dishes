using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Посуда
{
    public partial class LoginForm : Form
    {
        private bool captchaRequired = false;
        private int failedAttempts = 0;
        private Random random = new Random();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txbLogin.Text.Trim();
            string password = txbPassword.Text.Trim();

            //проверка капчи
            if (captchaRequired)
            {
                if (txbutCaptcha.Text.Trim().ToUpper() != "CAPTCHA")
                {
                    MessageBox.Show("Неверная CAPTCHA!", "Ошибка");
                    ShowNewCaptcha();
                    txbutCaptcha.Clear();
                    return;
                }
            }

            //проверяем пользователя в БД
            var (success, role, fio) = DatabaseHelper.ValidateUser(login, password);

            if (success)
            {
                //успешный вход
                failedAttempts = 0;
                captchaRequired = false;
                if (role == "Администратор")
                {
                    AdminPanelForm adminForm = new AdminPanelForm(fio);
                    adminForm.Show();
                }
                else
                {
                    MainForm mainForm = new MainForm(fio, role);
                    mainForm.Show();
                }

                this.Hide();
            }
            else
            {
                // Неудачный вход
                failedAttempts++;

                if (failedAttempts == 1)
                {
                    captchaRequired = true;
                    ShowCaptchaSection();
                    ShowNewCaptcha();
                    MessageBox.Show("Неверный логин или пароль! Введите CAPTCHA.", "Ошибка");
                }
                else if (failedAttempts >= 2)
                {
                    BlockFor10Seconds();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!", "Ошибка");
                }
            }
        }

        //показ секции капчи
        private void ShowCaptchaSection()
        {
            if (lblCAPTCHA != null) lblCAPTCHA.Visible = true;
            if (picCAPTCHA != null) picCAPTCHA.Visible = true;
            if (txbutCaptcha != null) txbutCaptcha.Visible = true;
        }

        //показ капчи
        private void ShowNewCaptcha()
        {
            string[] captchaFiles = { "captcha1.png", "captcha2.png", "captcha3.png" };

            int index = random.Next(captchaFiles.Length);
            string imagePath = Path.Combine("Images", captchaFiles[index]);

            if (File.Exists(imagePath))
            {
                picCAPTCHA.Image = Image.FromFile(imagePath);
                picCAPTCHA.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        //блокировка на 10 секунд
        private void BlockFor10Seconds()
        {
            btnLogin.Enabled = false;
            txbLogin.Enabled = false;
            txbPassword.Enabled = false;
            txbutCaptcha.Enabled = false;
            MessageBox.Show("Слишком много неудачных попыток! Система заблокирована на 10 секунд.", "Блокировка");

            Timer unlockTimer = new Timer();
            unlockTimer.Interval = 10000;
            unlockTimer.Tick += (s, ev) =>
            {
                btnLogin.Enabled = true;
                txbLogin.Enabled = true;
                txbPassword.Enabled = true;
                txbutCaptcha.Enabled = true;
                unlockTimer.Stop();
                unlockTimer.Dispose();
                MessageBox.Show("Система разблокирована. Можете попробовать снова.", "Разблокировка");
            };
            unlockTimer.Start();
        }

        //войти как гость
        private void btnGuest_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm("Гость", "Гость");
            mainForm.Show();
            this.Hide();
        }

        private void txbLogin_TextChanged(object sender, EventArgs e)
        {
            UpdateLoginButton();
        }

        private void txbPassword_TextChanged(object sender, EventArgs e)
        {
            UpdateLoginButton();
        }

        private void txbutCaptcha_TextChanged(object sender, EventArgs e)
        {
            UpdateLoginButton();
        }

        private void UpdateLoginButton()
        {
            bool canLogin = !string.IsNullOrWhiteSpace(txbLogin.Text) &&
                           !string.IsNullOrWhiteSpace(txbPassword.Text);

            if (captchaRequired)
            {
                canLogin = canLogin && !string.IsNullOrWhiteSpace(txbutCaptcha.Text);
            }

            btnLogin.Enabled = canLogin;
        }
        private void label1_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e) { }
        private void LoginForm_Load(object sender, EventArgs e) { }
    }
}