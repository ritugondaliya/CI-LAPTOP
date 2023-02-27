﻿using System;
using System.Collections.Generic;

namespace CI_Application.Entities.DataModels;

public partial class CmsPage
{
    public long CmsPageId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public bool Status { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
}
