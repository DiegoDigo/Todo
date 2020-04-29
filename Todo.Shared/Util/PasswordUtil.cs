namespace Todo.Shared.Util
{
    public class PasswordUtil
    {
        public static string Hash(string password) => BCrypt.Net.BCrypt.HashPassword(password);
    }
}