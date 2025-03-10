using System;
using System.Collections.Generic;

namespace DemoAPI.DBModel;

public partial class TblProduct
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<TblProductsSale> TblProductsSales { get; set; } = new List<TblProductsSale>();
}
