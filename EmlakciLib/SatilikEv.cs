using System;
using System.Collections.Generic;
using System.Text;

namespace EmlakciLib
{
    public class SatilikEv:Ev
    {
        public float Fiyat { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", Fiyat: {Fiyat} TL";
        }
    }
}
