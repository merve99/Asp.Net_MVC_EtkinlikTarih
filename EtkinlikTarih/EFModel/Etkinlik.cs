using System;
using System.Collections.Generic;

namespace EtkinlikTarih.EFModel
{
    public partial class Etkinlik
    {
        public int Id { get; set; }
        public string Konu { get; set; }
        public string Tanim { get; set; }
        public DateTime? Baslangic { get; set; }
        public DateTime? Bitis { get; set; }
        public string Renk { get; set; }
        public bool? Tumgun { get; set; }
    }
}
