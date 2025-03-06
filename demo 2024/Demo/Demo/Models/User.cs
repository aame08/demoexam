using System;
using System.Collections.Generic;

namespace Demo.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string? SurnameUser { get; set; }

    public string? NameUser { get; set; }

    public string? PatronymicUser { get; set; }

    public string? LoginUser { get; set; }

    public string? PasswordUser { get; set; }

    public int IdRole { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual ICollection<CommentApplication> CommentApplications { get; set; } = new List<CommentApplication>();

    public virtual RoleUser? IdRoleNavigation { get; set; }
}
