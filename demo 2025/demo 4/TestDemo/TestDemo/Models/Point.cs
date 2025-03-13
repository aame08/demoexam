using System;
using System.Collections.Generic;

namespace TestDemo.Models;

public partial class Point
{
    public int IdPoint { get; set; }

    public int IndexPoint { get; set; }

    public string CityPoint { get; set; } = null!;

    public string StreetPoint { get; set; } = null!;

    public string HomePoint { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
