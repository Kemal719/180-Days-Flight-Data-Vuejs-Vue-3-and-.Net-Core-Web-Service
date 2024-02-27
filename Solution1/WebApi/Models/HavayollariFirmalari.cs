using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class HavayollariFirmalari
{
    public int Id { get; set; }

    public string FirmaAdi { get; set; }

    public DateTime? FaaliyeteGecmeTarihi { get; set; }

    public string Sehir { get; set; }

    public string Ulke { get; set; }
}
