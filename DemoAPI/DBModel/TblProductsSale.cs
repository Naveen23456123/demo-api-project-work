using System;
using System.Collections.Generic;

namespace DemoAPI.DBModel;

public partial class TblProductsSale
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int? Price { get; set; }

    public int? QuantitySold { get; set; }

    public virtual TblProduct? Product { get; set; }
}
