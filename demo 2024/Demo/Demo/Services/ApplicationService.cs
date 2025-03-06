using Demo.Models;
using Demo.Models.Data;
using System.Windows;

namespace Demo.Services
{
    public class ApplicationService
    {
        public static List<User> GetUsers()
        {
            using (ApplicationsContext context = new ApplicationsContext())
            {
                var result = context.Users.ToList();
                return result;
            }
        }
        public static List<Equipment> GetEquipment()
        {
            using (ApplicationsContext context = new ApplicationsContext())
            {
                var result = context.Equipment.ToList();
                return result;
            }
        }
        public static List<Malfunction> GetMalfunction()
        {
            using (ApplicationsContext context = new ApplicationsContext())
            {
                var result = context.Malfunctions.ToList();
                return result;
            }
        }
        public static List<Demo.Models.Application> GetApplications()
        {
            using (ApplicationsContext context = new ApplicationsContext())
            {
                context.Users.ToList();
                context.Equipment.ToList();
                context.Malfunctions.ToList();
                var result = context.Applications.ToList();
                return result;
            }
        }

        public static List<string> GetEquipmentsList()
        {
            using (ApplicationsContext context = new ApplicationsContext())
            {
                return context.Equipment.Select(e => e.NameEquipment).ToList();
            }
        }
        public static List<string> GetMalfunctionList()
        {
            using (ApplicationsContext context = new ApplicationsContext())
            {
                return context.Malfunctions.Select(m => m.NameMalfunction).ToList();
            }
        }
        public static string GetMalfuctionNameByID(int id)
        {
            using (ApplicationsContext context = new ApplicationsContext())
            {
                var malfuction = context.Malfunctions.FirstOrDefault(m => m.IdMalfunction == id);
                return malfuction.NameMalfunction;
            }
        }
        public static int GetEquipmentIDByName(string name)
        {
            using (ApplicationsContext context = new ApplicationsContext())
            {
                var equipment = context.Equipment.FirstOrDefault(e => e.NameEquipment == name);
                if (equipment != null)
                {
                    return equipment.IdEquipment;
                }
                else { return -1; }
            }
        }
        public static int GetMalfuctionIDByName(string name)
        {
            using (ApplicationsContext context = new ApplicationsContext())
            {
                var malfuction = context.Malfunctions.FirstOrDefault(m => m.NameMalfunction == name);
                if (malfuction != null)
                {
                    return malfuction.IdMalfunction;
                }
                else { return -1; }
            }
        }

        public static int GetOrCreateEquipmentID(string name, ApplicationsContext context)
        {
            int id = ApplicationService.GetEquipmentIDByName(name);
            if (id != -1)
            {
                return id;
            }
            else
            {
                var newEquipment = new Equipment
                {
                    NameEquipment = name
                };
                context.Equipment.Add(newEquipment);
                context.SaveChanges();
                return ApplicationService.GetEquipmentIDByName(newEquipment.NameEquipment);
            }
        }
        public static int GetOrCreateMalfuctionID(string name, ApplicationsContext context)
        {
            int id = ApplicationService.GetMalfuctionIDByName(name);
            if (id != -1)
            {
                return id;
            }
            else
            {
                var newMalfuction = new Malfunction
                {
                    NameMalfunction = name
                };
                context.Malfunctions.Add(newMalfuction);
                context.SaveChanges();
                return ApplicationService.GetMalfuctionIDByName(newMalfuction.NameMalfunction);
            }
        }
        public static List<Demo.Models.Application> GetApplicationsByIDPerformer(int idPerformer)
        {
            using (ApplicationsContext context = new ApplicationsContext())
            {
                var applications = context.Applications.Where(a => a.IdUser == idPerformer).ToList();
                return applications;
            }
        }
    }
}
