using Microsoft.EntityFrameworkCore;
using TestDemo.Models;

namespace TestDemo.Services
{
    public class ProductsService
    {
        public static List<Product> GetAllProducts()
        {
            using (var context = new TestdemoContext())
            {
                try
                {
                    var products = context.Products
                        .Include(p => p.IdManufacterNavigation)
                        .Include(p => p.IdCategoryNavigation)
                        .Include(p => p.IdSupplierNavigation)
                        .ToList();

                    return products;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static List<string> GetManufacters()
        {
            using (var context = new TestdemoContext())
            {
                try
                {
                    var manufacters = context.Manufacters
                        .Select(m => m.NameManufacter)
                        .ToList();

                    return manufacters;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static List<string> GetSuppliers()
        {
            using (var context = new TestdemoContext())
            {
                try
                {
                    var suppliers = context.Suppliers
                        .Select(m => m.NameSupplier)
                        .ToList();

                    return suppliers;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static List<string> GetCategories()
        {
            using (var context = new TestdemoContext())
            {
                try
                {
                    var categories = context.Categories
                        .Select(m => m.NameCategory)
                        .ToList();

                    return categories;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        // Проверка артикула товара на уникальность
        public static bool UniqueArticleProduct(string article)
        {
            using (var context = new TestdemoContext())
            {
                try
                {
                    var product = context.Products
                        .FirstOrDefault(p => p.ArticleProduct == article);
                    if (product == null) { return true; }
                    else { return false; }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool AdditingProduct(Product product)
        {
            using (var context = new TestdemoContext())
            {
                try
                {
                    context.Products.Add(product);
                    context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool EditingProduct(Product product)
        {
            using (var context = new TestdemoContext())
            {
                try
                {
                    var editingProduct = context.Products
                        .FirstOrDefault(p => p.ArticleProduct == product.ArticleProduct);

                    if (editingProduct == null) { return false; }

                    editingProduct.NameProduct = product.NameProduct;
                    editingProduct.CostProduct = product.CostProduct;
                    editingProduct.MaxDiscount = product.MaxDiscount;
                    editingProduct.IdManufacter = product.IdManufacter;
                    editingProduct.IdSupplier = product.IdSupplier;
                    editingProduct.IdCategory = product.IdCategory;
                    editingProduct.NowDiscount = product.NowDiscount;
                    editingProduct.QuantityProduct = product.QuantityProduct;
                    editingProduct.DescProduct = product.DescProduct;

                    context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
