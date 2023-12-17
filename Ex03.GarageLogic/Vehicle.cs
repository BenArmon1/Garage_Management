using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_OwnerName = null;
        protected string m_OwnerPhoneNumber = null;
        protected Enum.eStateInTheGarage m_StateOfTheVehicleInTheGarage = Enum.eStateInTheGarage.InReapair;
        protected string m_ModelName = null;
        protected string m_LicensePlate = null;
        protected float m_EnergyPrecentage = 0;
        protected List<Tire> m_VehicleTires;
        protected Engine m_Engine;

        public string OwnerName
        {
            get { return m_OwnerName; }
            set { m_OwnerName = value; }
        }

        public string OwnerPhoneNumber
        {
            get { return m_OwnerPhoneNumber; }
            set { m_OwnerPhoneNumber = value; }
        }

        public Enum.eStateInTheGarage StateOfTheVehicleInTheGarage
        {
            get { return m_StateOfTheVehicleInTheGarage; }
            set { m_StateOfTheVehicleInTheGarage = value; }
        }

        public string ModelName
        {
            get { return m_ModelName; }
            set { m_ModelName = value; }
        }

        public string LicensePlate
        {
            get { return m_LicensePlate; }
            set { m_LicensePlate = value; }
        }

        public float EnergyPrecentage
        {
            get { return m_EnergyPrecentage; }
            set { m_EnergyPrecentage = value; }
        }

        public List<Tire> VehicleTires
        {
            get { return m_VehicleTires; }
        }

        public Engine Engine
        {
            get { return m_Engine; }
            set { m_Engine = value; }
        }

        public abstract void SetFeaturesForTheVhicle(Dictionary<string,string> i_AllFeatures);

        public abstract bool CheckValidtionForCustomerDetails(string i_DetailsToCheck, string i_TheFeatureThatWeAskFromTheUser);

        public string VehicleToString()
        {
            string fullMessage = string.Format(
@"For Car with license plate: {0}
Owner name: {1} 
Owner phone number: {2}
Model of the car: {3}
Manufaturer name of the wheels: {4}
Air pressure of the wheels: {5}
State in the Garge: {6}", LicensePlate, OwnerName, OwnerPhoneNumber, ModelName, VehicleTires[0].ManufaturerName, VehicleTires[0].AirPressure, StateOfTheVehicleInTheGarage);

            return fullMessage;
        }
    }
}
