using System.ComponentModel.DataAnnotations.Schema;

namespace Demo3.Models;

public partial class Product
{
    public string IdProduct { get; set; } = null!;

    public string NameProduct { get; set; } = null!;

    public string UnitProduct { get; set; } = null!;

    public int CostProduct { get; set; }
    [NotMapped]
    public decimal? DisplayedPrice => (decimal?)(NowDicount != 0 ? CostProduct - (CostProduct * NowDicount / 100) : null);

    public int? MaxDiscount { get; set; }

    public int IdManufacter { get; set; }

    public int IdSupplier { get; set; }

    public int IdCategory { get; set; }

    public int? NowDicount { get; set; }

    public int CountProduct { get; set; }

    public string DescProduct { get; set; } = null!;

    public string? ImageProduct { get; set; }
    [NotMapped]
    public string DisplayedImage => $"/Resources/{ImageProduct = (ImageProduct == null ? "picture.png" : ImageProduct)}";

    public virtual Category IdCategoryNavigation { get; set; } = null!;

    public virtual Manufacter IdManufacterNavigation { get; set; } = null!;

    public virtual Supplier IdSupplierNavigation { get; set; } = null!;

    public virtual ICollection<ListOrder> ListOrders { get; set; } = new List<ListOrder>();
}
