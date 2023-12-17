using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Factory
    {
        // When ever we would like to add new vehicle we will add the name of it in this string list and add new "else if" for it
        private static List<string> m_ListOfValidVehicles = new List<string>(5) { "Car", "ElectricCar", "MotorCycle", "ElectricMotorCycle", "Truck" };

        public static List<string> ListOfValidVehicles
        {
            get { return m_ListOfValidVehicles; }
        }

        public static Vehicle MakingNewVehicleForCustomer(string i_TypeOfVehcile, out List<string> o_ListOfFeatures)
        {
            Vehicle vehicleForCustomer = null;
            List<string> features = new List<string>(5) { "Your name", "Your phone number", "Your vehicle model", "Your vehicle's license plate", "Manufaturer name of your wheels", "Your air pressure of your wheels" };
            if (i_TypeOfVehcile.ToLower() == "Car".ToLower())
            {
                vehicleForCustomer = new Car();
                vehicleForCustomer.Engine = new EngineUsingFuel("Octan95", 38, 0);
                features.Add("Your car color");
                features.Add("Number of doors in your car");
                features.Add("Your current amount of fuel");
            }
            else if (i_TypeOfVehcile.ToLower() == "ElectricCar".ToLower())
            {
                vehicleForCustomer = new Car();
                vehicleForCustomer.Engine = new EngineByBattery(0, 3.3f);
                features.Add("Your car color");
                features.Add("Number of doors in your car");
                features.Add("Your current amount of battery");
            }
            else if (i_TypeOfVehcile.ToLower() == "MotorCycle".ToLower())
            {
                vehicleForCustomer = new MotorCycle();
                vehicleForCustomer.Engine = new EngineUsingFuel("Octan98", 6.2f, 0);
                features.Add("Your licencse type");
                features.Add("Your engine capacity");
                features.Add("Your current amount of fuel");
            }
            else if (i_TypeOfVehcile.ToLower() == "ElectricMotorCycle".ToLower())
            {
                vehicleForCustomer = new MotorCycle();
                vehicleForCustomer.Engine = new EngineByBattery(0, 2.5f);
                features.Add("Your licencse type");
                features.Add("Your engine capacity");
                features.Add("Your current amount of battery");
            }
            else if (i_TypeOfVehcile.ToLower() == "Truck".ToLower())
            {
                vehicleForCustomer = new Truck();
                vehicleForCustomer.Engine = new EngineUsingFuel("Soler", 120, 0);
                features.Add("Do you drive refrigerated contents");
                features.Add("Your trunk volume");
                features.Add("Your current amount of fuel");
            }

            o_ListOfFeatures = features;

            return vehicleForCustomer;
        }

        public static bool CheckValidtionOfTheNewVehicle(string i_TypeOfVehicle)
        {
            bool checkValdition = false;
            List<string> validVehicle = Factory.ListOfValidVehicles;
            foreach (string vhicleType in validVehicle)
            {
                if (i_TypeOfVehicle.ToLower() == vhicleType.ToLower())
                {
                    checkValdition = true;
                    break;
                }
            }

            return checkValdition;
        }
    }
}
