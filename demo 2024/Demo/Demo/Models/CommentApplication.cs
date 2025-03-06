using System;
using System.Collections.Generic;

namespace Demo.Models;

public partial class CommentApplication
{
    public int IdComment { get; set; }

    public int? IdApplication { get; set; }

    public int? IdUser { get; set; }

    public string? TextComment { get; set; }

    public DateOnly? DateWriting { get; set; }

    public virtual Application? IdApplicationNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
