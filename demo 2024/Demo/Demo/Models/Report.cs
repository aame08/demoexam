using System;
using System.Collections.Generic;

namespace Demo.Models;

public partial class Report
{
    public int IdReport { get; set; }

    public int? IdApplication { get; set; }

    public TimeOnly? LeadTime { get; set; }

    public string? AssistanceProvided { get; set; }

    public string? CauseMalfunction { get; set; }

    public int? Cost { get; set; }

    public virtual Application? IdApplicationNavigation { get; set; }
}
