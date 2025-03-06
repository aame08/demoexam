using System.ComponentModel.DataAnnotations.Schema;

namespace Demo3.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public DateOnly? DateOrder { get; set; }

    public DateOnly? DateDeliverOrder { get; set; }

    public int IdPoint { get; set; }

    public string? SurnameClient { get; set; }

    public string? NameClient { get; set; }

    public string? PatronymicClient { get; set; }

    [NotMapped]
    public string FIO => $"{SurnameClient} {NameClient} {PatronymicClient}";

    [NotMapped]
    public decimal? TotalAmount => ListOrders.Sum(op => op.CountProduct * (op.IdProductNavigation.CostProduct - op.IdProductNavigation.DisplayedPrice));
    [NotMapped]
    public decimal TotalDiscount => (decimal)ListOrders.Sum(op =>
        op.CountProduct * op.IdProductNavigation.CostProduct * op.IdProductNavigation.NowDicount / 100);

    public int CodeGiveOrder { get; set; }

    public string StatusOrder { get; set; } = null!;

    public virtual Point IdPointNavigation { get; set; } = null!;

    public virtual ICollection<ListOrder> ListOrders { get; set; } = new List<ListOrder>();
}
