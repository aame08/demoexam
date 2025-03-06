namespace Demo.Models;

public partial class Product
{
    public string ArticleProduct { get; set; } = null!;

    public int IdProductType { get; set; }

    public string NameProduct { get; set; } = null!;

    public double MinCost { get; set; }

    public virtual ProductType IdProductTypeNavigation { get; set; } = null!;

    public virtual ICollection<PartnersProduct> PartnersProducts { get; set; } = new List<PartnersProduct>();
}
