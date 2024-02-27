using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class OtelKonaklama
{
    public int Id { get; set; }

    public DateTime? GirisTarihi { get; set; }

    public DateTime? CikisTarihi { get; set; }

    public int? OdaSayisi { get; set; }

    public int? YetiskinSayisi { get; set; }

    public int? CocukSayisi { get; set; }
}
