using Demka.Models;
using Demka.Models.Data;

namespace Demka.Services
{
    public class ProductServices
    {
        public static List<Category> GetCategory()
        {
            using (TradeContext db = new())
            {
                var result = db.Categories.ToList();
                return result;
            }
        }

        public static List<Manufacturer> GetManufacturer()
        {
            using (TradeContext db = new())
            {
                var result = db.Manufacturers.ToList();
                return result;
            }
        }

        public static List<Delivery> GetDelivery()
        {
            using (TradeContext db = new())
            {
                var result = db.Deliveries.ToList();
                return result;
            }
        }

        public static List<Product> GetProducts()
        {
            using (TradeContext db = new())
            {
                db.Categories.ToList();
                db.Manufacturers.ToList();
                db.Deliveries.ToList();
                var result = db.Products.ToList();
                return result;
            }
        }

        //Добавление товара
        public static List<string> GetCategoryList()
        {
            using (var context = new TradeContext())
            {
                return context.Categories.Select(c => c.CategoryName).ToList();
            }
        }
        public static List<string> GetManufacturerList()
        {
            using (var context = new TradeContext())
            {
                return context.Manufacturers.Select(m => m.ManufacturerName).ToList();
            }
        }
        public static List<string> GetDeliverersList()
        {
            using (var context = new TradeContext())
            {
                return context.Deliveries.Select(d => d.DeliveryName).ToList();
            }
        }
        public static int GetCategoryIDByName(string nameManufacturer)
        {
            using (var context = new TradeContext())
            {
                var category = context.Categories.FirstOrDefault(m => m.CategoryName == nameManufacturer);
                if (category != null)
                {
                    return category.CategoryId;
                }
                else { return -1; }
            }
        }
        public static int GetManufacturerIDByName(string nameManufacturer)
        {
            using (var context = new TradeContext())
            {
                var manufacturer = context.Manufacturers.FirstOrDefault(m => m.ManufacturerName == nameManufacturer);
                if (manufacturer != null)
                {
                    return manufacturer.ManufacturerId;
                }
                else { return -1; }
            }
        }
        public static int GetDeliveryIDByName(string nameManufacturer)
        {
            using (var context = new TradeContext())
            {
                var delivery = context.Deliveries.FirstOrDefault(m => m.DeliveryName == nameManufacturer);
                if (delivery != null)
                {
                    return delivery.DeliveryId;
                }
                else { return -1; }
            }
        }
        public static bool ProductArticleOccupancy(string productArticle)
        {
            using (var context = new TradeContext())
            {
                var occupancy = context.Products.FirstOrDefault(a => a.ProductArticleNumber == productArticle);
                if (occupancy != null)
                {
                    return false;
                }
                return true;
            }
        }

        //Изменение товара
        public static string GetCategoryById(int id)
        {
            using (var context = new TradeContext())
            {
                var category = context.Categories.FirstOrDefault(c => c.CategoryId == id);
                if (category != null)
                {
                    return category.CategoryName;
                }
                else { return null; }
            }
        }
        public static string GetManufacturerById(int id)
        {
            using (var context = new TradeContext())
            {
                var manufacturer = context.Manufacturers.FirstOrDefault(c => c.ManufacturerId == id);
                if (manufacturer != null)
                {
                    return manufacturer.ManufacturerName;
                }
                else { return null; }
            }
        }
        public static string GetDeliveryById(int id)
        {
            using (var context = new TradeContext())
            {
                var delivery = context.Deliveries.FirstOrDefault(c => c.DeliveryId == id);
                if (delivery != null)
                {
                    return delivery.DeliveryName;
                }
                else { return null; }
            }
        }
    }
}
