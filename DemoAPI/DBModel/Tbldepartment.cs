using System;
using System.Collections.Generic;

namespace DemoAPI.DBModel;

public partial class Tbldepartment
{
    public int DeptId { get; set; }

    public string DeptName { get; set; } = null!;

    public virtual ICollection<TblEmployee> TblEmployees { get; set; } = new List<TblEmployee>();
}
