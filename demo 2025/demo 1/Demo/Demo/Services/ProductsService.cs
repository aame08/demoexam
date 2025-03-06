using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Services
{
    public class ProductsService
    {
        public static List<ProductType> GetProductTypes()
        {
            using (var context = new DemoContext())
            {
                var productsTypes = context.ProductTypes.ToList();
                return productsTypes;
            }
        }

        public static List<MaterialType> GetMaterialTypes()
        {
            using (var context = new DemoContext())
            {
                var materials = context.MaterialTypes.ToList();
                return materials;
            }
        }

        public static ProductType GetProductTypeById(int typeId)
        {
            using (var context = new DemoContext())
            {
                return context.ProductTypes
                    .FirstOrDefault(p => p.IdProductType == typeId);
            }
        }
        public static MaterialType GetMaterialById(int matetialId)
        {
            using (var context = new DemoContext())
            {
                return context.MaterialTypes.FirstOrDefault(m => m.IdMaterialType == matetialId);
            }
        }
        // Метод для расчета необходимого материала
        public static int CalculateMaterial(int typeId, int materialId, int quantity, double param1, double param2)
        {
            var type = GetProductTypeById(typeId);
            if (type == null) { return -1; }

            var material = GetMaterialById(materialId);
            if (material == null) { return -1; }

            // Подсчет количества материала для одного продукта
            double materialCount = param1 * param2 * type.CoefficientProductType;

            // Подсчет процента брака
            double materialWithDefect = materialCount * (1 + material.DefectType / 100);

            int totalMaterialNeeded = (int)Math.Ceiling(materialWithDefect * quantity);

            return totalMaterialNeeded;
        }
    }
}
