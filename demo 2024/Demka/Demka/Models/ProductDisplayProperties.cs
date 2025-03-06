using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demka.Models;

namespace Demka.Models
{
    public class ProductDisplayProperties
    {
        public decimal ProductCost { get; set; }
        public sbyte? ProductDiscountAmount { get; set; }
        [NotMapped]
        public float? DisplayedPrice => (float?)(ProductDiscountAmount != 0 ? ProductCost - (ProductCost * ProductDiscountAmount / 100) : null);
        public string? ProductPhoto { get; set; }
        [NotMapped]
        public string DisplayedImage => $"C:\\Users\\Я\\source\\repos\\DemoExam\\DemoExam\\Resources\\ProductImage\\ {ProductPhoto = (ProductPhoto == null ? "picture.png" : ProductPhoto)}";
    }
}
