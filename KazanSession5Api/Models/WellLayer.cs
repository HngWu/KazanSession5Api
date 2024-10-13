using System;
using System.Collections.Generic;

namespace KazanSession5Api.Models;

public partial class WellLayer
{
    public long Id { get; set; }

    public long WellId { get; set; }

    public long RockTypeId { get; set; }

    public long StartPoint { get; set; }

    public long EndPoint { get; set; }

    public virtual RockType RockType { get; set; } = null!;

    public virtual Well Well { get; set; } = null!;
}
