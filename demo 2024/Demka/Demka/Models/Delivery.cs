﻿using System;
using System.Collections.Generic;

namespace Demka.Models;

public partial class Delivery
{
    public int DeliveryId { get; set; }

    public string DeliveryName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
