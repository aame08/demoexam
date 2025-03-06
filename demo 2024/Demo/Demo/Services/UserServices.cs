using Demo.Models;
using Demo.Models.Data;

namespace Demo.Services
{
    public class UserServices
    {
        public static List<RoleUser> GetRoles()
        {
            using (ApplicationsContext context = new ApplicationsContext())
            {
                var result = context.RoleUsers.ToList();
                return result;
            }
        }
        public static List<User> GetUsers()
        {
            using (ApplicationsContext context = new ApplicationsContext())
            {
                var result = context.Users.ToList();
                return result;
            }
        }
        public static User GetUserByLoginAndPassword(string login, string password)
        {
            using (ApplicationsContext context = new ApplicationsContext())
            {
                var user = context.Users.FirstOrDefault(u => u.LoginUser == login && u.PasswordUser == password);
                return user;
            }
        }
        public static string GetRoleNameByUserId(int userId)
        {
            using (ApplicationsContext context = new ApplicationsContext())
            {
                var role = context.RoleUsers.FirstOrDefault(r => r.IdRole == userId);
                return role?.NameRole;
            }
        }
        public static string GetFIOUser(int userId)
        {
            using (ApplicationsContext context = new ApplicationsContext())
            {
                var user = context.Users.FirstOrDefault(u => u.IdUser == userId);
                if (user != null)
                {
                    var fio = user.SurnameUser + " " + user.NameUser + " " + user.PatronymicUser;
                    return fio;
                }
                return "Ошибка.";
            }
        }
        public static string GetIDPerformer(int userId)
        {
            using (ApplicationsContext context = new ApplicationsContext())
            {
                var user = context.Users.FirstOrDefault(u => u.IdUser == userId);
                if (user != null)
                {
                    var id = user.IdUser.ToString();
                    return id;
                }
                return "Ошибка.";
            }
        }

        public static List<string> GetPerformersList()
        {
            using (ApplicationsContext context = new ApplicationsContext())
            {
                var result = context.Users.Where(u => u.IdRole == 2).Select(u => u.SurnameUser + " " + u.NameUser + " " + u.PatronymicUser).ToList();
                return result;
            }
        }
        public static int GetPerformerIDByName(string name)
        {
            using (ApplicationsContext context = new ApplicationsContext())
            {
                var performer = context.Users.FirstOrDefault(p => (p.SurnameUser + " " + p.NameUser + " " + p.PatronymicUser) == name);
                if (performer != null)
                {
                    return performer.IdUser;
                }
                else { return -1; }
            }
        }
        public static string GetPerformerFIOByID(int id)
        {
            using (ApplicationsContext context = new ApplicationsContext())
            {
                var performer = context.Users.FirstOrDefault(u => u.IdUser == id);
                if (performer != null)
                {
                    return performer.SurnameUser + " " + performer.NameUser + " " + performer.PatronymicUser;
                }
                else { return null; }
            }
        }
    }
}
