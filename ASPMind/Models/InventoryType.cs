using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPMind.Models;

public partial class InventoryType
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;
}
