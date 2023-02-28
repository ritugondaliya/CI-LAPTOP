﻿using System;
using System.Collections.Generic;

namespace CI_Application.Entities.DataModels;

public partial class MissionTheme
{
    public long MissionThemeId { get; set; }

    public string Title { get; set; } = null!;

    public byte Status { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Misson> Missons { get; } = new List<Misson>();
}