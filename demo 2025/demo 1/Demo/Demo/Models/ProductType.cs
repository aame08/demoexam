namespace Demo.Models;

public partial class ProductType
{
    public int IdProductType { get; set; }

    public string NameProductType { get; set; } = null!;

    public double CoefficientProductType { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
