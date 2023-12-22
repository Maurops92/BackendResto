using System;
using System.Collections.Generic;

namespace Test_back.Modelos;

public partial class Mesa
{
    public int MesaId { get; set; }

    public int? MozoId { get; set; }

    public int Capacity { get; set; }

    public int? IsOccupied { get; set; }

    public string Name { get; set; } = null!;

    public virtual Mozo? Mozo { get; set; }
}
