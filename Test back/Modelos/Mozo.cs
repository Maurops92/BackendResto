using System;
using System.Collections.Generic;

namespace Test_back.Modelos;

public partial class Mozo
{
    public int MozoId { get; set; }

    public int RolId { get; set; }

    public int TurnoId { get; set; }

    public string Name { get; set; } = null!;

    public int? Age { get; set; }

    public int? IsActive { get; set; }

    public virtual ICollection<Mesa> Mesas { get; set; } = new List<Mesa>();

    public virtual Rol Rol { get; set; } = null!;

    public virtual Turno Turno { get; set; } = null!;

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
