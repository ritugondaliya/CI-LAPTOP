using System;
using System.Collections.Generic;

namespace entityDataFirst.DataModels;

public partial class Salesman
{
    public int SalesmanId { get; set; }

    public string? Name { get; set; }

    public string? City { get; set; }

    public double? Commission { get; set; }

    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
