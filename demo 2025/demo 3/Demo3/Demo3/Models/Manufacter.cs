namespace Demo3.Models;

public partial class Manufacter
{
    public int IdManufacter { get; set; }

    public string NameManufacter { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
