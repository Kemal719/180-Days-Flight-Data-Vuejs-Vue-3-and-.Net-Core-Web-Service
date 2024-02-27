using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Yolcular
{
    public int Id { get; set; }

    public string YolcuAd { get; set; }

    public string YolcuSoyad { get; set; }

    public string Telefon { get; set; }

    public string Adres { get; set; }

    public string Ulke { get; set; }
}
