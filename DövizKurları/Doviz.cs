using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DövizKurları
{
    class Doviz
    {
        public int Birim { get; set; }
        public string DovizAdı { get; set; }
        public decimal AlısFiyat { get; set; }
        public decimal SatısFiyat { get; set; }

        public override string ToString()
        {
            return DovizAdı + "  " + Birim;
        }
    }
}
