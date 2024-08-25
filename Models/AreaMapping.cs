using System;
using System.Collections.Generic;

namespace PHRecord.Models;

public partial class AreaMapping
{
    public int AreaId { get; set; }

    public string AreaName { get; set; } = null!;

    public int ParentId { get; set; }

    public int AreaTypeId { get; set; }

    public bool IsActive { get; set; }

    public long? CurrentPopulation { get; set; }
}
