using QLDN.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDN.Services
{
    public class LoginService
    {
		private readonly AppDbContext _context;

		public LoginService()
		{
			_context = new AppDbContext();
		}

		public (bool isSuccess, string message) Login(string username, string PasswordHash)
		{
			var user = _context.Users.FirstOrDefault(u => u.Username == username);

			if (user == null)
				return (false, "Tài khoản không tồn tại!");

			if (user.PasswordHash != PasswordHash)
				return (false, "Mật khẩu không đúng!");

			return (true, "Đăng nhập thành công!");
		}
	}
}
