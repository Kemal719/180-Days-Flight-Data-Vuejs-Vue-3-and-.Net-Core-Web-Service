using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class HavaAlanlari
{
    public int ID { get; set; }




    public string HavaalaniAdi { get; set; }

    public int Varis { get; set; }

    public int? Tip1 { get; set; }

    public int? Tip2 { get; set; }


}
