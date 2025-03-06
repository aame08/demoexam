using Demo3.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo3.Services
{
    class ProductService
    {
        public static List<Product> GetProducts()
        {
            using (var context = new Demo3Context())
            {
                var products = context.Products
                    .Include(p => p.IdManufacterNavigation)
                    .Include(p => p.IdSupplierNavigation)
                    .Include(p => p.IdCategoryNavigation)
                    .ToList();
                return products;
            }
        }

        public static List<Order> GetOrders()
        {
            using (var context = new Demo3Context())
            {
                var orders = context.Orders
                    .Include(o => o.ListOrders)
                    .ThenInclude(op => op.IdProductNavigation)
                    .ToList();
                return orders;
            }
        }

        public static List<string> GetManufacters()
        {
            using (var context = new Demo3Context())
            {
                var manufacters = context.Manufacters.Select(m => m.NameManufacter).ToList();
                return manufacters;
            }
        }
        public static List<string> GetSuppliers()
        {
            using (var context = new Demo3Context())
            {
                var suppliers = context.Suppliers.Select(m => m.NameSupplier).ToList();
                return suppliers;
            }
        }
        public static List<string> GetCategories()
        {
            using (var context = new Demo3Context())
            {
                var types = context.Categories.Select(m => m.NameCategory).ToList();
                return types;
            }
        }

        public static bool AddProduct(Product product)
        {
            try
            {
                using (var context = new Demo3Context())
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

        public static bool EditProduct(string articleProduct, string nameProduct, int costProduct, int discountProduct, int maxDiscountProduct, int quantityProduct, string descriptionProduct, string unitProduct, int manufacterId, int supplierId, int categoryId)
        {
            try
            {
                using (var context = new Demo3Context())
                {
                    var product = context.Products.FirstOrDefault(p => p.IdProduct == articleProduct);
                    if (product == null) { return false; }

                    product.NameProduct = nameProduct;
                    product.CostProduct = costProduct;
                    product.NowDicount = discountProduct;
                    product.MaxDiscount = maxDiscountProduct;
                    product.CountProduct = quantityProduct;
                    product.DescProduct = descriptionProduct;
                    product.UnitProduct = unitProduct;
                    product.IdManufacter = manufacterId;
                    product.IdSupplier = supplierId;
                    product.IdCategory = categoryId;

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
