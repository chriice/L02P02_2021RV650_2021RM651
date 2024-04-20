using System;
using System.Collections.Generic;

namespace L02P02_2021RV650.Models;

public partial class ComentariosLibro
{
    public int Id { get; set; }

    public int? IdLibro { get; set; }

    public string? Comentarios { get; set; }

    public string? Usuario { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Libro? IdLibroNavigation { get; set; }
}
