using System;
using System.Collections.Generic;

namespace KazanSession5Api.Models;

public partial class RockType
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string BackgroundColor { get; set; } = null!;

    public virtual ICollection<WellLayer> WellLayers { get; set; } = new List<WellLayer>();
}
