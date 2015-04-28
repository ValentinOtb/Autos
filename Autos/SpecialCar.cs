﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autos
{
    public class SpecialCar : Car
    {
        public string CallNumber { get; set; }
        private Flasher flasher = new Flasher();
        public Flasher Flasher
        {
            get
            {
                return flasher;
            }
        }

        public SpecialCar()
            : this(null)
        {

        }

        public SpecialCar(string callNumber)
            : base()
        {
            CallNumber = callNumber;
        }

    }
}
