﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autos
{
    public class PassengerCar : Car
    {
        private int totalSeats;
        private int passengersCount;
        private int trunkSpace;

        public bool FrontDrive { get; set; }
        public int TrunkSpace
        {
            get
            {
                return trunkSpace;
            }
            set
            {
                if (value > 0)
                {
                    trunkSpace = value;
                }
            }
        }
        public int TotalSeats
        {
            get
            {
                return totalSeats;
            }
            set
            {
                if (value > 0)
                {
                    totalSeats = value;
                }
            }
        }
        public int PassengersCount
        {
            get
            {
                return passengersCount;
            }
            set
            {
                if (value > 0)
                {
                    passengersCount = value;
                }
            }
        }

        public PassengerCar(int totalSeats, int passengersCount, bool frontDrive)
            : base()
        {
            this.TotalSeats = totalSeats;
            this.PassengersCount = passengersCount;
            this.FrontDrive = frontDrive;
            TextualRepresentation = "Passenger car";
        }
        public PassengerCar()
            : this(0, 0, false)
        {
        }
    }
}
