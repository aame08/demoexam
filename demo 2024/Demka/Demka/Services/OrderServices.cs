using Demka.Models;
using Demka.Models.Data;

namespace Demka.Services
{
    public class OrderServices
    {
        public static List<Order> GetOrder()
        {
            using (TradeContext db = new TradeContext())
            {
                var result = db.Orders.ToList();
                return result;
            }
        }
    }
}
