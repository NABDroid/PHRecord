using System;
using System.Collections.Generic;

namespace PHRecord.Models;

public partial class HistoryTitle
{
    public int TitleId { get; set; }

    public string? Title { get; set; }

    public bool? IsActive { get; set; }
}
