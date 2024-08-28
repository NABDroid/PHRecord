using System;
using System.Collections.Generic;

namespace PHRecord.Models;

public partial class UserType
{
    public int UserTypeId { get; set; }

    public string? UserTypeTitle { get; set; }

    public bool? IsActive { get; set; }
}
