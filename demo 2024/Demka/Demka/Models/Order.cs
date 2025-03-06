using System;
using System.Collections.Generic;

namespace Demka.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime OrderDeliveryDate { get; set; }

    public int PickupPointId { get; set; }

    public string? OrderClient { get; set; }

    public int RecieveCode { get; set; }

    public string OrderStatus { get; set; } = null!;

    public virtual ICollection<Orderproduct> Orderproducts { get; set; } = new List<Orderproduct>();

    public virtual Pickuppoint PickupPoint { get; set; } = null!;
}
