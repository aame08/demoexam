using System.ComponentModel.DataAnnotations.Schema;

namespace Demo2.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public DateOnly OrderDate { get; set; }

    public DateOnly OrderDeliveryDate { get; set; }

    public int PointId { get; set; }

    public string? SurnameClient { get; set; }

    public string? NameClient { get; set; }

    public string? PatronymicClient { get; set; }

    [NotMapped]
    public string FIO => $"{SurnameClient} {NameClient} {PatronymicClient}";

    [NotMapped]
    public decimal? TotalAmount => Orderproducts.Sum(op => op.CountProduct * (op.ArticleNumberProductNavigation.CostProduct - op.ArticleNumberProductNavigation.DisplayedPrice));
    [NotMapped]
    public decimal TotalDiscount => Orderproducts.Sum(op =>
        op.CountProduct * op.ArticleNumberProductNavigation.CostProduct * op.ArticleNumberProductNavigation.DiscountAmountProduct / 100);

    public int ReceiptCode { get; set; }

    public string OrderStatus { get; set; } = null!;

    public virtual ICollection<Orderproduct> Orderproducts { get; set; } = new List<Orderproduct>();

    public virtual Pickuppoint Point { get; set; } = null!;
}
