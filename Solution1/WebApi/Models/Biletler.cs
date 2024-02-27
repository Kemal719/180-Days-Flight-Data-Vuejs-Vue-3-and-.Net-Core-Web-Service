using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Biletler
{
    public int Id { get; set; }

    public string SinifKoltuk { get; set; }

    public string UcusSirketi { get; set; }

    public long? UcusNumarasi { get; set; }

    public string YolcuAdi { get; set; }

    public decimal? Fiyat { get; set; }
}
