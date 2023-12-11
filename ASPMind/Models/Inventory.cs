using System;
using System.Collections.Generic;

namespace ASPMind.Models;

public partial class Inventory
{
    public int Id { get; set; }

    public string SerialNumber { get; set; } = null!;

    public int IdModel { get; set; }

    public int IdType { get; set; }

    public bool Available { get; set; }

    public string? Description { get; set; }
}
