﻿using System;
using System.Collections.Generic;

namespace CI_Application.Entities.DataModels;

public partial class MissionRating
{
    public long MissionRatingId { get; set; }

    public long UserId { get; set; }

    public long MissionId { get; set; }

    public bool Rating { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Mission Mission { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
