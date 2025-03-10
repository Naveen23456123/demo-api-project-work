using System;
using System.Collections.Generic;

namespace DemoAPI.DBModel;

public partial class TblGender
{
    public int GenId { get; set; }

    public string GenName { get; set; } = null!;

    public virtual ICollection<TblEmployee> TblEmployees { get; set; } = new List<TblEmployee>();
}
