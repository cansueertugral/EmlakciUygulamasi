using System;

namespace EmlakciLib
{
    public class Ev : Object
    {
        public int OdaSayisi { get; set; }
        public int KatNo { get; set; }
        public int Alan { get; set; }

        public override string ToString()
        {
            return $"Oda Sayısı: {OdaSayisi}\nKat Numarası: {KatNo}\nAlan: {Alan} ";
        }

    }
}
