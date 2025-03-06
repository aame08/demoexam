using System.ComponentModel.DataAnnotations.Schema;

namespace Demo2.Models;

public partial class Product
{
    public string ArticleNumberProduct { get; set; } = null!;

    public string NameProduct { get; set; } = null!;

    public string UnitProduct { get; set; } = null!;

    public int CostProduct { get; set; }
    [NotMapped]
    public decimal? DisplayedPrice => (decimal?)(DiscountAmountProduct != 0 ? CostProduct - (CostProduct * DiscountAmountProduct / 100) : null);

    public int MaxDiscountProduct { get; set; }

    public int ManufacturerId { get; set; }

    public int SupplierId { get; set; }

    public int TypeId { get; set; }

    public decimal DiscountAmountProduct { get; set; }

    public int QuantityInStockProduct { get; set; }

    public string DescriptionProduct { get; set; } = null!;

    public string? PhotoProduct { get; set; }
    [NotMapped]
    public string DisplayedImage => $"/Resources/{PhotoProduct = (PhotoProduct == null ? "picture.png" : PhotoProduct)}";

    public virtual Manufacturer Manufacturer { get; set; } = null!;

    public virtual ICollection<Orderproduct> Orderproducts { get; set; } = new List<Orderproduct>();

    public virtual Supplier Supplier { get; set; } = null!;

    public virtual Producttype Type { get; set; } = null!;
}
