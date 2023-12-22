using System;
using System.Collections.Generic;

namespace Test_back.Modelos;

public partial class DetalleVentum
{
    public int VentaId { get; set; }

    public int MenuId { get; set; }

    public int? Quantity { get; set; }

    public decimal? Subtotal { get; set; }

    public virtual Menu Menu { get; set; } = null!;

    public virtual Venta Venta { get; set; } = null!;
}
