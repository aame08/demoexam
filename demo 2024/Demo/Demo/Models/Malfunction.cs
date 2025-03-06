using System;
using System.Collections.Generic;

namespace Demo.Models;

public partial class Malfunction
{
    public int IdMalfunction { get; set; }

    public string? NameMalfunction { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
