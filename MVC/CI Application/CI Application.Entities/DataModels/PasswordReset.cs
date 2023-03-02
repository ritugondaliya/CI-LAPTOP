﻿using System;
using System.Collections.Generic;

namespace CI_Application.Entities.DataModels;

public partial class PasswordReset
{
    public string? Email { get; set; }

    public string Token { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
