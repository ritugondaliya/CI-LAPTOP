using System;
using System.Collections.Generic;

namespace demoMVC.Entity.DataModels;

public partial class Order
{
    public int OrdNo { get; set; }

    public decimal? PurchAmt { get; set; }

    public DateTime? OrdDate { get; set; }

    public int? CustomerId { get; set; }

    public int? SalesmanId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Salesman? Salesman { get; set; }
}
