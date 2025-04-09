using System.Text.RegularExpressions;
using BCrypt.Net;
using QLDN.Data;
using QLDN.Models;
using System.Linq;


public class RegisterService
{
    private AppDbContext _context;

    public RegisterService(AppDbContext context)
    {
        _context = context;
    }

    public bool UsernameExists(string username) => _context.Users.Any(u => u.Username == username);
    public bool EmailExists(string email) => _context.Users.Any(u => u.Email == email);

    public bool IsStrongPassword(string password)
    {
        var pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$";
        return Regex.IsMatch(password, pattern);
    }

    public bool Register(string username, string email, string password, out string error)
    {
        if (UsernameExists(username)) { error = "Username đã tồn tại"; return false; }
        if (EmailExists(email)) { error = "Email đã tồn tại"; return false; }
        if (!IsStrongPassword(password)) { error = "Password không đủ mạnh"; return false; }

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        var user = new User { Username = username, Email = email, PasswordHash = hashedPassword };
        _context.Users.Add(user);
        _context.SaveChanges();

        error = null;
        return true;
    }
}
