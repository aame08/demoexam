namespace Demo3.Models;

public partial class ListOrder
{
    public int IdOrder { get; set; }

    public string IdProduct { get; set; } = null!;

    public int? CountProduct { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
