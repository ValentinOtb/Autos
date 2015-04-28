using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automobiles
{
    public abstract class Car
    {
        public Dictionary<string, dynamic> Fields = new Dictionary<string, dynamic>();
        private int weight;
        private int maxSpeed;
        private int horsePower;
        private int speed;
        public string Name { get; set; }
        public string Number { get; set; }
        public string Color { get; set; }
        public bool EngineOn { get; set; }
        public int MaxSpeed
        {
            get
            {
                return maxSpeed;
            }
            set
            {
                if (value > 0)
                    maxSpeed = value;
            }
        }
        public int Speed
        {
            get
            {
                return speed;
            }
            set
            {
                if (value >= 0 && value <= MaxSpeed)
                    speed = value;
            }
        }
        public int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value > 0)
                    weight = value;
            }
        }
        public int HorsePower
        {
            get
            {
                return horsePower;
            }
            set
            {
                if (value > 0)
                {
                    horsePower = value;
                }
            }
        }

        public Car()
        {
            Fields.Add("Weight", Weight);
            Fields.Add("Speed", Speed);
            Fields.Add("MaxSpeed", MaxSpeed);
            Fields.Add("HorsePower", HorsePower);
            Fields.Add("EngineOn", EngineOn);
            Fields.Add("Color", Color);
            Fields.Add("Number", Number);
            Fields.Add("Name", Name);
            Color = "black";
        }
    }
}
