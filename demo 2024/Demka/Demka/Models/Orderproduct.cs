﻿using System;
using System.Collections.Generic;

namespace Demka.Models;

public partial class Orderproduct
{
    public int OrderId { get; set; }

    public string ProductArticleNumber { get; set; } = null!;

    public int? Quantity { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product ProductArticleNumberNavigation { get; set; } = null!;
}
