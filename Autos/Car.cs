﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autos
{
    public abstract class Car
    {
        public string TextualRepresentation = "";
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

        public Car(string name, string number, string color,
            bool engineOn, int maxSpeed, int speed,
            int weight, int horsePower)
        {
            this.Name = name;
            this.Number = number;
            this.Color = color;
            this.EngineOn = engineOn;
            this.MaxSpeed = maxSpeed;
            this.Speed = speed;
            this.Weight = weight;
            this.HorsePower = horsePower;
        }
        public Car()
            : this("", "", "", false, 0, 0, 0, 0)
        {
        }
    }
}
