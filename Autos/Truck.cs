﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autos
{
    public abstract class Truck : Car
    {
        private int maxTrailerWeight;
        private int trailerWeight;

        public string Goods { get; set; }

        public int MaxTrailerWeight
        {
            get
            {
                return maxTrailerWeight;
            }
            set
            {
                if (value > 0)
                {
                    maxTrailerWeight = value;
                }
            }
        }

        public int TrailerWeight
        {
            get
            {
                return trailerWeight;
            }
            set
            {
                if (value <= maxTrailerWeight)
                {
                    trailerWeight = value;
                }
            }
        }

        public Truck()
            : base()
        {
        }
    }
}
