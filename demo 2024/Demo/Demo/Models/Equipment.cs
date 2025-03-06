using System;
using System.Collections.Generic;

namespace Demo.Models;

public partial class Equipment
{
    public int IdEquipment { get; set; }

    public string? NameEquipment { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
