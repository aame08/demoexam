using System.ComponentModel.DataAnnotations.Schema;

namespace TestDemo.Models;

public partial class Product
{
    public string ArticleProduct { get; set; } = null!;

    public string NameProduct { get; set; } = null!;

    public string UnitProduct { get; set; } = null!;

    public int CostProduct { get; set; }

    [NotMapped]
    public double DisplayedPrice => (double)(NowDiscount != 0 ? CostProduct - (CostProduct * NowDiscount / 100) : 0.0);

    public int MaxDiscount { get; set; }

    public int IdManufacter { get; set; }

    public int IdSupplier { get; set; }

    public int IdCategory { get; set; }

    public int NowDiscount { get; set; }

    public int QuantityProduct { get; set; }

    public string DescProduct { get; set; } = null!;

    public string? ImageProduct { get; set; }

    [NotMapped]
    public string DisplayedImage => $"/Resources/{ImageProduct = (ImageProduct == null ? "picture.png" : ImageProduct)}";

    public virtual Category IdCategoryNavigation { get; set; } = null!;

    public virtual Manufacter IdManufacterNavigation { get; set; } = null!;

    public virtual Supplier IdSupplierNavigation { get; set; } = null!;

    public virtual ICollection<Productsorder> Productsorders { get; set; } = new List<Productsorder>();
}
