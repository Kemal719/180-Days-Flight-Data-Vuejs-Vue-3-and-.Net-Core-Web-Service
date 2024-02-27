using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class HavaAlaniOtopark
{
    public string AracTipi { get; set; }

    public DateTime? AracGirisTarihi { get; set; }

    public TimeSpan? AracGirisSaat { get; set; }

    public DateTime? AracCikisTarihi { get; set; }

    public TimeSpan? AracCikisSaati { get; set; }

    public decimal? Fiyat { get; set; }
}
