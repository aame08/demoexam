using Demo2.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace Demo2.Services
{
    class ProductService
    {
        public static List<Product> GetProducts()
        {
            using (var context = new Demo2Context())
            {
                var products = context.Products
                    .Include(p => p.Manufacturer)
                    .Include(p => p.Supplier)
                    .Include(p => p.Type)
                    .ToList();
                return products;
            }
        }

        public static List<Order> GetOrders()
        {
            using (var context = new Demo2Context())
            {
                var orders = context.Orders
                    .Include(o => o.Orderproducts)
                    .ThenInclude(op => op.ArticleNumberProductNavigation)
                    .ToList();
                return orders;
            }
        }

        public static List<string> GetManufacters()
        {
            using (var context = new Demo2Context())
            {
                var manufacters = context.Manufacturers.Select(m => m.ManufacturerName).ToList();
                return manufacters;
            }
        }
        public static List<string> GetSuppliers()
        {
            using (var context = new Demo2Context())
            {
                var suppliers = context.Suppliers.Select(m => m.SupplierName).ToList();
                return suppliers;
            }
        }
        public static List<string> GetTypes()
        {
            using (var context = new Demo2Context())
            {
                var types = context.Producttypes.Select(m => m.TypeName).ToList();
                return types;
            }
        }

        public static bool AddProduct(Product product)
        {
            try
            {
                using (var context = new Demo2Context())
                {
                    context.Products.Add(product);
                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool EditProduct(string articleProduct, string nameProduct, int costProduct, int discountProduct, int maxDiscountProduct, int quantityProduct, string descriptionProduct, string unitProduct, int manufacterId, int supplierId, int typeId)
        {
            try
            {
                using (var context = new Demo2Context())
                {
                    var product = context.Products.FirstOrDefault(p => p.ArticleNumberProduct == articleProduct);
                    if (product == null) { return false; }

                    product.NameProduct = nameProduct;
                    product.CostProduct = costProduct;
                    product.DiscountAmountProduct = discountProduct;
                    product.MaxDiscountProduct = maxDiscountProduct;
                    product.QuantityInStockProduct = quantityProduct;
                    product.DescriptionProduct = descriptionProduct;
                    product.UnitProduct = unitProduct;
                    product.ManufacturerId = manufacterId;
                    product.SupplierId = supplierId;
                    product.TypeId = typeId;

                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
