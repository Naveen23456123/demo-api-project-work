using System;
using System.Collections.Generic;

namespace DemoAPI.DBModel;

public partial class TblEmployee
{
    public int EmpId { get; set; }

    public string EmpName { get; set; } = null!;

    public int? EmpGender { get; set; }

    public int? MonthlySalary { get; set; }

    public string Email { get; set; } = null!;

    public int Age { get; set; }

    public string? EmpAddress { get; set; }

    public int? EmpDeptId { get; set; }

    public int? EmpType { get; set; }

    public int? AnnualSalary { get; set; }

    public virtual Tbldepartment? EmpDept { get; set; }

    public virtual TblGender? EmpGenderNavigation { get; set; }

    public virtual TblEmployeeType? EmpTypeNavigation { get; set; }
}
