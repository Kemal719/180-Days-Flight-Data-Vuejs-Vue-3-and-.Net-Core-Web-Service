using System;

namespace WebApi.Models
{
    public class DateParm_Result
    {
        public int ID { get; set; }
        public string HavaAlani_Adi { get; set; }
        public string HavaAlani_Varis { get; set; }
        public Nullable<DateTime> Kalkis_Saati { get; set; }
        public Nullable<DateTime> Varis_Saati { get; set; }
        public string HavaYoluSırketi { get; set; }
        public string UcusNo { get; set; }
        public Nullable<bool> UcusDurumu { get; set; }
        public Nullable<DateTime> Tarih { get; set; }
    }
}
