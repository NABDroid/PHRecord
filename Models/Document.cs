using System;
using System.Collections.Generic;

namespace PHRecord.Models;

public partial class Document
{
    public long? UserId { get; set; }

    public string? DocumentName { get; set; }

    public string? DocumentType { get; set; }

    public DateTime? UploadTime { get; set; }

    public string? DocDescription { get; set; }

    public string? DocTitle { get; set; }
}
