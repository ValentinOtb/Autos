using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autos
{
    public class CarObjects
    {
        public Action<PassengerCar> PassengerCarAssignFields;
        public Action<TrailerTruck> TrailerTruckAssignFields;
        public Action<Ambulance> AmbulanceAssignFields;

        public CarObjects(Action<PassengerCar> passengerCarAssignFields,
            Action<TrailerTruck> trailerTruckAssignFields,
            Action<Ambulance> ambulanceAssignFields)
        {
            this.PassengerCarAssignFields = passengerCarAssignFields;
            this.TrailerTruckAssignFields = trailerTruckAssignFields;
            this.AmbulanceAssignFields = ambulanceAssignFields;
        }

        public PassengerCar GetPassengerCar()
        {
            PassengerCar passengerCar = new PassengerCar();
            PassengerCarAssignFields(passengerCar);
            return passengerCar;
        }

        public TrailerTruck GetTrailerTruck()
        {
            TrailerTruck trailerTruck = new TrailerTruck();
            TrailerTruckAssignFields(trailerTruck);
            return trailerTruck;
        }

        public Ambulance GetAmbulance()
        {
            Ambulance ambulance = new Ambulance();
            AmbulanceAssignFields(ambulance);
            return ambulance;
        }
    }
}
