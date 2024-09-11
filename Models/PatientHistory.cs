using System;
using System.Collections.Generic;

namespace PHRecord.Models;

public partial class PatientHistory
{
    public long HistoryId { get; set; }

    public int UserId { get; set; }

    public int TitleId { get; set; }

    public bool IsTrue { get; set; }

    public string? Remarks { get; set; }

    public bool? IsActive { get; set; }
}
