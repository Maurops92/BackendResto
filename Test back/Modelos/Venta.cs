using System;
using System.Collections.Generic;

namespace Test_back.Modelos;

public partial class Venta
{
    public int VentaId { get; set; }

    public int? MozoId { get; set; }

    public decimal TotalAmount { get; set; }

    public DateOnly? SaleDate { get; set; }

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();

    public virtual Mozo? Mozo { get; set; }
}
