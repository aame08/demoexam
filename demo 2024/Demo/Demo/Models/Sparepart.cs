using System;
using System.Collections.Generic;

namespace Demo.Models;

public partial class Sparepart
{
    public int IdSpareParts { get; set; }

    public int IdApplication { get; set; }

    public string? NameSpareParts { get; set; }

    public int? CostSpareParts { get; set; }

    public int? QuantitySpareParts { get; set; }

    public virtual Application IdApplicationNavigation { get; set; } = null!;
}
