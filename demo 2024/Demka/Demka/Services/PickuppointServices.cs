using Demka.Models.Data;
using Demka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demka.Services
{
    public class PickuppointServices
    {
        public static List<Pickuppoint> GetPickuppoint()
        {
            using (TradeContext db = new TradeContext())
            {
                var result = db.Pickuppoints.ToList();
                return result;
            }
        }
        public static List<string> GetAddresses()
        {
            List<string> addresses = new List<string>();

            foreach (var item in GetPickuppoint())
            {
                string address = $"{item.PickupPointCity}, {item.PickupPointStreet}, {item.PickupPointStreetNumber}";
                addresses.Add(address);
            }

            return addresses;
        }
    }
}
