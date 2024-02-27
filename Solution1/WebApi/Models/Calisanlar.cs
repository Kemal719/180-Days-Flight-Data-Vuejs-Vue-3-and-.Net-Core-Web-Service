using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Calisanlar
{
    public int Id { get; set; }

    public string CalisanAdi { get; set; }

    public string CalisanSoyad { get; set; }

    public int? Yas { get; set; }

    public string Telefon { get; set; }

    public string EPosta { get; set; }

    public string Meslek { get; set; }

    public string CalistigiFirma { get; set; }

    public DateTime? IseGirisTarihi { get; set; }

    public decimal? Maas { get; set; }
}
