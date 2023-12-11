using System;
using System.Collections.Generic;

namespace ASPMind.Models;

public partial class MonitorAsignation
{
    public int Id { get; set; }

    public int IdInventoy { get; set; }

    public int IdEmployee { get; set; }
}
