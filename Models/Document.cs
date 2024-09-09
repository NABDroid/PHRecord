using System;
using System.Collections.Generic;

namespace PHRecord.Models;

public partial class Document
{
    public long DocumentId { get; set; }

    public long? UserId { get; set; }

    public string? DocumentTitle { get; set; }

    public string? DocumentDescription { get; set; }

    public string? MainDocument { get; set; }

    public string? FileType { get; set; }

    public DateOnly? FileDate { get; set; }

    public int? DocTypeId { get; set; }

    public DateTime? UploadTime { get; set; }

    public bool? IsActive { get; set; }
}
