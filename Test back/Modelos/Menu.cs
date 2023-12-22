using System;
using System.Collections.Generic;

namespace Test_back.Modelos;

public partial class Menu
{
    public int MenuId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int? IsActive { get; set; }

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();
}
