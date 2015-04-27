using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.Serialization;

namespace Autos
{
    [DataContract]
    public abstract class Car
    {
        private int weight;
        private int maxSpeed;
        public int horsePower;
        private int speed;
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Number { get; set; }
        [DataMember]
        public Brush Color { get; set; }
        [DataMember]
        public bool EngineOn { get; set; }
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
    }
}
