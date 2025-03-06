using Demka.Models;
using Demka.Models.Data;

namespace Demka.Services
{
    public class UserServices
    {
        public static List<Role> GetRole()
        {
            using (TradeContext db = new TradeContext())
            {
                var result = db.Roles.ToList();
                return result;
            }
        }

        public static List<User> GetUsers()
        {
            using (TradeContext db = new TradeContext())
            {
                db.Roles.ToList();
                var result = db.Users.ToList();
                return result;
            }
        }

        public static User GetUserByLoginAndPassword(string login, string password)
        {
            using (TradeContext db = new TradeContext())
            {
                var user = db.Users.FirstOrDefault(u => u.UserLogin == login && u.UserPassword == password);
                return user;
            }
        }

        public static string GetRoleNameByUserId(int userId)
        {
            using (TradeContext db = new TradeContext())
            {
                var role = db.Roles.FirstOrDefault(r => r.RoleId == userId);
                return role?.RoleName;
            }
        }

        public static string GetFIOUser(int userID)
        {
            using (TradeContext db = new TradeContext())
            {
                var user = db.Users.FirstOrDefault(u => u.UserId == userID);
                if (user != null)
                {
                    var fio = user.UserSurname + " " + user.UserName + " " + user.UserPatronymic;
                    return fio;
                }
                return "Ошибка";
            }
        }
    }
}
