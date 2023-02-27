﻿using System;
using System.Collections.Generic;

namespace CI_Application.Entities.DataModels;

public partial class Country
{
    public long CountryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Iso { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public DateTime? DeletedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<City> Cities { get; } = new List<City>();

    public virtual ICollection<Misson> Missons { get; } = new List<Misson>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}
