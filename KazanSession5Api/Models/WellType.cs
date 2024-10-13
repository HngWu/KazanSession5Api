using System;
using System.Collections.Generic;

namespace KazanSession5Api.Models;

public partial class WellType
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Well> Wells { get; set; } = new List<Well>();
}
