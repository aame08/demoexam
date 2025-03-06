namespace Demo3.Models;

public partial class Point
{
    public int IdPoint { get; set; }

    public int IndexPoint { get; set; }

    public string CityPoint { get; set; } = null!;

    public string StreetPoint { get; set; } = null!;

    public int? BuildPoint { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
