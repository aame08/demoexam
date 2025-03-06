using Demo2.Models;

namespace Demo2.Services
{
    class UsersService
    {
        public static User LoginUser(string login, string password)
        {
            using (var context = new Demo2Context())
            {
                var user = context.Users.FirstOrDefault(u => u.LoginUser == login && u.PasswordUser == password);
                if (user != null)
                {
                    return user;
                }
                else { return null; }
            }
        }
    }
}
