using System;
using System.Collections.Generic;
using System.Text;

namespace EmlakciLib
{
    public class KiralikEv : Ev
    {
        public float Kira { get; set; }
        public float Depozito { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", Kira: {Kira}\nDepozito: { Depozito} TL";
        }
    }

    
}