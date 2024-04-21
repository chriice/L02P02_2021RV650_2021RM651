using System;
using System.Collections.Generic;

namespace L02P02_2021RV650.Models;

public partial class PedidoEncabezado
{
    public int Id { get; set; }

    public int? IdCliente { get; set; }

    public int? CantidadLibros { get; set; }

    public decimal? Total { get; set; }

    public string? Estado { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; } = new List<PedidoDetalle>();
}
