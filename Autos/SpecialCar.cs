using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autos
{
    public class SpecialCar : Car
    {
        public string CallNumber { get; set; }
        public Flasher flasher = new Flasher();

        public SpecialCar()
        {

        }

        public SpecialCar(string callNumber)
        {
            CallNumber = callNumber;
        }

    }
}
