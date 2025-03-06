using System.ComponentModel.DataAnnotations.Schema;

namespace Demka.Models;

public partial class Product
{
    public string ProductArticleNumber { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string ProductDescription { get; set; } = null!;

    public string ProductUnit { get; set; } = null!;

    public decimal ProductCost { get; set; }
    [NotMapped]
    public float? DisplayedPrice => (float?)(ProductDiscountAmount != 0 ? ProductCost - (ProductCost * ProductDiscountAmount / 100) : null);

    public sbyte ProductMaxDiscountAmount { get; set; }

    public int ManufacturerId { get; set; }

    public int DeliveryId { get; set; }

    public int CategoryId { get; set; }

    public sbyte? ProductDiscountAmount { get; set; }

    public int ProductQuantityInStock { get; set; }

    public string? ProductPhoto { get; set; }
    [NotMapped]
    public string DisplayedImage => $"/Resources/ProductImage/{ProductPhoto = (ProductPhoto == null ? "picture.png" : ProductPhoto)}";

    public virtual Category Category { get; set; } = null!;

    public virtual Delivery Delivery { get; set; } = null!;

    public virtual Manufacturer Manufacturer { get; set; } = null!;

    public virtual ICollection<Orderproduct> Orderproducts { get; set; } = new List<Orderproduct>();
}
