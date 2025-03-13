using TestDemo.Models;

namespace TestDemo.Services
{
    public class UsersService
    {
        public static User Login(string login, string password)
        {
            try
            {
                using (var context = new TestdemoContext())
                {
                    var user = context.Users
                        .FirstOrDefault(u => u.LoginUser == login && u.PasswordUser == password);
                    if (user == null) { return null; }

                    return user;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string GetNameRole(User user)
        {
            try
            {
                using (var context = new TestdemoContext())
                {
                    var role = context.Roles
                        .FirstOrDefault(r => r.IdRole == user.IdRole);

                    return role.NameRole;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
