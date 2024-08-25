using System;
using System.Collections.Generic;

namespace PHRecord.Models;

public partial class LoginCred
{
    public long UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string LoginPassword { get; set; } = null!;

    public bool IsActive { get; set; }
}
