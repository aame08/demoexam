using System;
using System.Collections.Generic;

namespace TestDemo.Models;

public partial class Productsorder
{
    public int IdOrder { get; set; }

    public string ArticleProduct { get; set; } = null!;

    public int CountProduct { get; set; }

    public virtual Product ArticleProductNavigation { get; set; } = null!;

    public virtual Order IdOrderNavigation { get; set; } = null!;
}
