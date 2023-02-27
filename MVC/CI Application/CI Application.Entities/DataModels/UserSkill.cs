﻿using System;
using System.Collections.Generic;

namespace CI_Application.Entities.DataModels;

public partial class UserSkill
{
    public long UserSkillId { get; set; }

    public long UserId { get; set; }

    public long SkillId { get; set; }

    public byte[] CrestedAt { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Skill Skill { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
