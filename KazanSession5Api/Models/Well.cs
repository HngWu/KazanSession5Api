using System;
using System.Collections.Generic;

namespace KazanSession5Api.Models;

public partial class Well
{
    public long Id { get; set; }

    public long WellTypeId { get; set; }

    public string WellName { get; set; } = null!;

    public long GasOilDepth { get; set; }

    public long Capacity { get; set; }

    public virtual ICollection<WellLayer> WellLayers { get; set; } = new List<WellLayer>();

    public virtual WellType WellType { get; set; } = null!;
}
