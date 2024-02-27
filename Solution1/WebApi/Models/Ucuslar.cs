using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Ucuslar
{
    public int Id { get; set; }

    public string HavaAlaniAdi { get; set; }

    public string HavaAlaniVaris { get; set; }

    public DateTime? KalkisSaati { get; set; }

    public DateTime? VarisSaati { get; set; }

    public string HavaYoluSirketi { get; set; }

    public string UcusNo { get; set; }

    public bool? UcusDurumu { get; set; }

    public DateTime? Tarih { get; set; }
}
