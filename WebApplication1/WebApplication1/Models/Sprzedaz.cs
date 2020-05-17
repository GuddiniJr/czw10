using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Sprzedaz
    {
        public int IdSprzedaz { get; set; }
        public int IdKlient { get; set; }
        public int IdPracownik { get; set; }
        public int IdProdukt { get; set; }
        public DateTime DataSprzedazy { get; set; }
        public int Ilosc { get; set; }
    }
}
