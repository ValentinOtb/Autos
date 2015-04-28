using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automobiles
{
    public class Flasher
    {
        public bool IsOn { get; set; }

        public Flasher()
        {
            IsOn = false;
        }

        public string Sound()
        {
            if (IsOn)
            {
                return "Weeeu-Weeeeeeu-Weeeu";
            }
            else
                return "";
        }
    }
}
