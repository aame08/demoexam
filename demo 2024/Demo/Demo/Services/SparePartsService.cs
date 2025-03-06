using Demo.Models;
using Demo.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Services
{
    public class SparePartsService
    {
        public static List<Sparepart> GetSpareparts()
        {
            using (ApplicationsContext context = new ApplicationsContext())
            {
                var result = context.Spareparts.ToList();
                return result;
            }
        }
        public static List<string> GetSparepartsList()
        {
            using (ApplicationsContext context = new ApplicationsContext())
            {
                return context.Spareparts.Select(s => s.NameSpareParts).Distinct().ToList();
            }
        }

        public static int GetSparepartsIDByNameAndApplication(string name, int applicationId)
        {
            using (var context = new ApplicationsContext())
            {
                var sparepart = context.Spareparts.FirstOrDefault(s => s.NameSpareParts == name && s.IdApplication == applicationId);
                return sparepart != null ? sparepart.IdSpareParts : -1;
            }
        }
        public static int GetOrCreateSparepartID(string name, string idApp, string cost, string count)
        {
            int id = SparePartsService.GetSparepartsIDByNameAndApplication(name, int.Parse(idApp));
            if (id != -1)
            {
                return id;
            }
            else
            {
                using (var context = new ApplicationsContext())
                {
                    var newSparepart = new Sparepart
                    {
                        NameSpareParts = name,
                        IdApplication = int.Parse(idApp),
                        CostSpareParts = int.Parse(cost),
                        QuantitySpareParts = int.Parse(count)
                    };
                    context.Spareparts.Add(newSparepart);
                    context.SaveChanges();
                    return newSparepart.IdSpareParts;
                }
            }
        }

    }
}
