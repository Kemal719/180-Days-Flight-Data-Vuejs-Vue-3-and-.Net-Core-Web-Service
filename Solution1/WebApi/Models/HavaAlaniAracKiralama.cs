using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class HavaAlaniAracKiralama
{
    public int Id { get; set; }

    public string AracKiralamaFirmasiAdi { get; set; }

    public string TeslimAlinacakKonum { get; set; }

    public DateTime? TeslimAlmaTarihi { get; set; }

    public DateTime? TeslimEtmeTarihi { get; set; }

    public decimal? OdemeTutari { get; set; }
}
