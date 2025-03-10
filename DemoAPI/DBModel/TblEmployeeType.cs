using System;
using System.Collections.Generic;

namespace DemoAPI.DBModel;

public partial class TblEmployeeType
{
    public int EpmTypeId { get; set; }

    public string EmpTypeName { get; set; } = null!;

    public virtual ICollection<TblEmployee> TblEmployees { get; set; } = new List<TblEmployee>();
}
