﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autos
{
    public class Ambulance : SpecialCar
    {
        public bool PatientInside { get; set; }

        public Ambulance()
        {
            TextualRepresentation = "Ambulance";
        }

    }
}
