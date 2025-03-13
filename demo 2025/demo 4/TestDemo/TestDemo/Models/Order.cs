using System;
using System.Collections.Generic;

namespace TestDemo.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public DateOnly DateOrder { get; set; }

    public DateOnly DateDelivery { get; set; }

    public int IdPoint { get; set; }

    public string? SurnameClient { get; set; }

    public string? NameClient { get; set; }

    public string? PatronymicClient { get; set; }

    public int CodeOrder { get; set; }

    public string StatusOrder { get; set; } = null!;

    public virtual Point IdPointNavigation { get; set; } = null!;

    public virtual ICollection<Productsorder> Productsorders { get; set; } = new List<Productsorder>();
}
