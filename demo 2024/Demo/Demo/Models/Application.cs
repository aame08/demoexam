using System;
using System.Collections.Generic;

namespace Demo.Models;

public partial class Application
{
    public int IdApplication { get; set; }

    public int IdUser { get; set; }

    public string CustomersNumber { get; set; }

    public DateOnly DateAddition { get; set; }

    public int IdEquipment { get; set; }

    public int IdMalfunction { get; set; }

    public string DescriptionProblem { get; set; }

    public string StatusApplication { get; set; }

    public string Priority { get; set; }

    public virtual ICollection<CommentApplication> CommentApplications { get; set; } = new List<CommentApplication>();

    public virtual Equipment IdEquipmentNavigation { get; set; }

    public virtual Malfunction IdMalfunctionNavigation { get; set; }

    public virtual User IdUserNavigation { get; set; }

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual ICollection<Sparepart> Spareparts { get; set; } = new List<Sparepart>();
}
