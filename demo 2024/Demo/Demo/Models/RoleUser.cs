using System;
using System.Collections.Generic;

namespace Demo.Models;

public partial class RoleUser
{
    public int IdRole { get; set; }

    public string? NameRole { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
