namespace Demo2.Models;

public partial class Pickuppoint
{
    public int PointId { get; set; }

    public int PointIndex { get; set; }

    public string PointCity { get; set; } = null!;

    public string PointnStreet { get; set; } = null!;

    public string? PointHome { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
