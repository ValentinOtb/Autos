using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automobiles
{
    public class SpecialCar : Car
    {
        public string CallNumber { get; set; }
        public Flasher flasher = new Flasher();

        public SpecialCar()
            : this(null)
        {

        }

        public SpecialCar(string callNumber)
            : base()
        {
            CallNumber = callNumber;
            Fields.Add("CallNumber", CallNumber);
            Fields.Add("FlasherOn", flasher.IsOn);
        }

    }
}
