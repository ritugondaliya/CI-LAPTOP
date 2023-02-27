﻿using System;
using System.Collections.Generic;

namespace CI_Application.Entities.DataModels;

public partial class Story
{
    public long StoryId { get; set; }

    public long UserId { get; set; }

    public long MissionId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public byte[] Status { get; set; } = null!;

    public DateTime? PublishedAt { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Misson Mission { get; set; } = null!;

    public virtual ICollection<StoryMedium> StoryMedia { get; } = new List<StoryMedium>();

    public virtual User User { get; set; } = null!;
}
