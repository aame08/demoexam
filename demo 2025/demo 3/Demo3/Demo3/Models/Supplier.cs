namespace Demo3.Models;

public partial class Supplier
{
    public int IdSupplier { get; set; }

    public string NameSupplier { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
