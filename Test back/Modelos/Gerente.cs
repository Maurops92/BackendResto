using System;
using System.Collections.Generic;

namespace Test_back.Modelos;

public partial class Gerente
{
    public int GerenteId { get; set; }

    public int RolId { get; set; }

    public string Name { get; set; } = null!;

    public int? Age { get; set; }

    public int? IsActive { get; set; }

    public virtual Rol Rol { get; set; } = null!;
}
