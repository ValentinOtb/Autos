using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automobiles
{
    public class CarList
    {
        List<Car> cars = new List<Car>();
        private int count;
        public int Count
        {
            get
            {
                return cars.Count;
            }
        }

        public Car this[int index]
        {
            get
            {
                return cars[index];
            }
        }

        public CarList()
        {

        }

        public void Add(Car car)
        {
            cars.Add(car);
        }

        public void RemoveAt(int index)
        {
            cars.RemoveAt(index);
        }

        public void Remove(Car car)
        {
            cars.Remove(car);
        }

        public string GetCarNames()
        {
            StringBuilder carNames = new StringBuilder();
            for (int i = 0; i < cars.Count; i++)
            {
                carNames.AppendLine(string.Format("{0}. {1}", i + 1, cars[i].Name));
            }

            return carNames.ToString();
        }
    }
}
