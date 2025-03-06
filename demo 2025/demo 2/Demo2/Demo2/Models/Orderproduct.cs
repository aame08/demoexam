namespace Demo2.Models;

public partial class Orderproduct
{
    public int OrderId { get; set; }

    public string ArticleNumberProduct { get; set; } = null!;

    public int CountProduct { get; set; }

    public virtual Product ArticleNumberProductNavigation { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
