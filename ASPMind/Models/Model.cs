using System;
using System.Collections.Generic;

namespace ASPMind.Models;

public partial class Model
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IdType { get; set; }

    public int IdBrand { get; set; }

    public int? Stock { get; set; }

    public int? StockAvailable { get; set; }
}
