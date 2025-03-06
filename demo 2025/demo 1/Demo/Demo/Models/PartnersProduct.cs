namespace Demo.Models;

public partial class PartnersProduct
{
    public int IdPartnersProducts { get; set; }

    public string ArticleProduct { get; set; } = null!;

    public int IdPartner { get; set; }

    public int CountProduct { get; set; }

    public DateOnly DateSale { get; set; }

    public virtual Product ArticleProductNavigation { get; set; } = null!;

    public virtual Partner IdPartnerNavigation { get; set; } = null!;
}
