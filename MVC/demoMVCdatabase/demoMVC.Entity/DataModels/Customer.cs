using System;
using System.Collections.Generic;

namespace demoMVC.Entity.DataModels;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? CustName { get; set; }

    public string? City { get; set; }

    public int? Grade { get; set; }

    public int? SalesmanId { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual Salesman? Salesman { get; set; }
}
