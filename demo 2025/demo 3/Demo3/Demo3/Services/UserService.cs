using Demo3.Models;

namespace Demo3.Services
{
    class UserService
    {
        public static User LoginUser(string login, string password)
        {
            using (var context = new Demo3Context())
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
