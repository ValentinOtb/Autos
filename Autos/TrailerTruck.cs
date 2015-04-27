using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autos
{
    public class TrailerTruck : Truck
    {
        public bool HasTrailer { get; set; }

        public void HookTrailer(bool hookOn)
        {
            HasTrailer = hookOn;
        }
    }
}
