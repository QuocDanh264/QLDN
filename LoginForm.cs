using QLDN.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDN
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;

            var loginService = new LoginService();
            var (success, message) = loginService.Login(username, password);

            lblMessage.Text = message;
            lblMessage.ForeColor = success ? Color.Green : Color.Red;

            if (success)
            {
                MessageBox.Show("Đăng nhập thành công!");
                // TODO: Mở form chính ở đây
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}
