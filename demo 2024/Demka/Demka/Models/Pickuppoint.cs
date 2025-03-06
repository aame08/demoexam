using System;
using System.Collections.Generic;

namespace Demka.Models;

public partial class Pickuppoint
{
    public int PickupPointId { get; set; }

    public int? PickupPointIndex { get; set; }

    public string PickupPointCity { get; set; } = null!;

    public string PickupPointStreet { get; set; } = null!;

    public string? PickupPointStreetNumber { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
