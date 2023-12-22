using System;
using System.Collections.Generic;

namespace Test_back.Modelos;

public partial class Turno
{
    public int TurnoId { get; set; }

    public string TurnoName { get; set; } = null!;

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public virtual ICollection<Mozo> Mozos { get; set; } = new List<Mozo>();
}
