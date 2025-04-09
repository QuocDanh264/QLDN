using QLDN.Data;
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
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var context = new AppDbContext();
            var registerService = new RegisterService(context);
            string error;

            var username = txtUsername.Text.Trim();
            var email = txtEmail.Text.Trim();
            var password = txtPassword.Text;

            bool result = registerService.Register(username, email, password, out error);

            if (result)
            {
                MessageBox.Show("Đăng ký thành công! Quay lại đăng nhập.");
                this.Close(); // hoặc mở LoginForm
            }
            else
            {
                lblMessage.Text = error;
            }
        }
    }
}
