using System;
using System.Collections.Generic;

namespace Test_back.Modelos;

public partial class Rol
{
    public int RolId { get; set; }

    public string RolName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Ceo> Ceos { get; set; } = new List<Ceo>();

    public virtual ICollection<Gerente> Gerentes { get; set; } = new List<Gerente>();

    public virtual ICollection<Mozo> Mozos { get; set; } = new List<Mozo>();
}
