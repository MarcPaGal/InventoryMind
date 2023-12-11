using System;
using System.Collections.Generic;

namespace ASPMind.Models;

public partial class InventoryAsignation
{
    public int Id { get; set; }

    public int IdInventory { get; set; }

    public int IdEmployee { get; set; }
}
