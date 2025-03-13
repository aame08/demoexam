﻿using System;
using System.Collections.Generic;

namespace TestDemo.Models;

public partial class User
{
    public int IdUser { get; set; }

    public int IdRole { get; set; }

    public string SurnameUser { get; set; } = null!;

    public string NameUser { get; set; } = null!;

    public string PatronymicUser { get; set; } = null!;

    public string LoginUser { get; set; } = null!;

    public string PasswordUser { get; set; } = null!;

    public virtual Role IdRoleNavigation { get; set; } = null!;
}
