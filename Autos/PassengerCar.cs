using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Autos
{
    public class PassengerCar : Car
    {
        private int totalSeats;
        private int passengersCount;
        private int trunkSpace;

        public PassengerCar()
            : base()
        {

        }
        [DataMember]
        public bool FrontDrive { get; set; }
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
    }
}
