using System;
using System.Collections.Generic;

namespace entityDataFirst.DataModels;

public partial class Employee
{
    public int EmpId { get; set; }

    public int? DeptId { get; set; }

    public int? MngrId { get; set; }

    public string? EmpName { get; set; }

    public int? Salary { get; set; }
}
