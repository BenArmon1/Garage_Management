using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        protected List<Vehicle> m_VehiclesInTheGarage = new List<Vehicle>();

        public List<Vehicle> VehiclesInTheGarage
        {
            get { return m_VehiclesInTheGarage; }
            set { m_VehiclesInTheGarage = value; }
        }

        public void AddANewVechileToTheGarage(Vehicle i_VehicleThatNeedToFix)
        {
            foreach (Vehicle vehicle in VehiclesInTheGarage)
            {
                if (i_VehicleThatNeedToFix.LicensePlate == vehicle.LicensePlate)
                {
                    vehicle.StateOfTheVehicleInTheGarage = Enum.eStateInTheGarage.InReapair;
                    break;
                }
            }

            VehiclesInTheGarage.Add(i_VehicleThatNeedToFix);
        }

        // Return all the license plate for the vehicles in the garge by state
        public List<string> VehiclesInTheGarageByStateOfTheVehicleInTheGarage(string i_StateOfTheVehicleInTheGarage)
        {
            List<string> vehicles = new List<string>();

            foreach (Vehicle vehicle in VehiclesInTheGarage)
            {
                if (vehicle.StateOfTheVehicleInTheGarage == Enum.StringStateInTheGarageToEnumStateInTheGarage(i_StateOfTheVehicleInTheGarage))
                {
                    vehicles.Add(vehicle.LicensePlate);
                }
            }

            return vehicles;
        }

        public string ListToString(List<string> i_ListOfState)
        {
            StringBuilder fromListToString = new StringBuilder();
            foreach (string vehicleId in i_ListOfState)
            {
                fromListToString.Append(vehicleId + "\n");
            }

            return fromListToString.ToString();
        }

        // Return all the license plate for the vehicles in the garge
        public List<string> AllVehiclesInTheGarage()
        {
            List<string> vehicles = new List<string>();
            foreach (Vehicle vehicle in VehiclesInTheGarage)
            {
                vehicles.Add(vehicle.LicensePlate);
            }

            return vehicles;
        }

        public void ChangeVehicleState(string i_LicensePlate, string i_NewStateOfTheVehicle)
        {
            foreach (Vehicle vehicle in VehiclesInTheGarage)
            {
                if (vehicle.LicensePlate == i_LicensePlate)
                {
                    vehicle.StateOfTheVehicleInTheGarage = Enum.StringStateInTheGarageToEnumStateInTheGarage(i_NewStateOfTheVehicle);
                    break;
                }
            }
        }

        public void ToInflateTheWheelsOfAVehicleToTheMax(string i_LicensePlate)
        {
            foreach (Vehicle vehicle in VehiclesInTheGarage)
            {
                if (vehicle.LicensePlate == i_LicensePlate)
                {
                    for (int i = 0; i < vehicle.VehicleTires.Count; i++)
                    {
                        vehicle.VehicleTires[i].AirPressure = vehicle.VehicleTires[i].MaxAirPressure;
                    }

                    break;
                }
            }
        }

        public void ToFillGas(string i_LicensePlate, string i_GasType, float i_GasAmountToAdd)
        {
            foreach (Vehicle vehicle in VehiclesInTheGarage)
            {
                if (vehicle.LicensePlate == i_LicensePlate)
                {
                    if (vehicle.Engine is EngineUsingFuel)
                    {
                        ((EngineUsingFuel)vehicle.Engine).Refuel(i_GasAmountToAdd, i_GasType);
                        break;
                    }
                    else
                    {
                        throw new ArgumentException("You dont have vehicle that drives on fuel");
                    }
                }
            }
        }

        public void ToFillBatary(string i_LicensePlate, float i_TimeToFillTheBatteryInMinutes)
        {
            foreach (Vehicle vehicle in VehiclesInTheGarage)
            {
                if (vehicle.LicensePlate == i_LicensePlate)
                {
                    if (vehicle.Engine is EngineByBattery)
                    {
                        ((EngineByBattery)vehicle.Engine).FillBattery(i_TimeToFillTheBatteryInMinutes);
                        break;
                    }
                    else
                    {
                        throw new ArgumentException("You dont have electric Vehicle");
                    }
                }
            }
        }

        public string ToStringAllDataByLicensePlate(string i_LicensePlate)
        {
            string fullMessage = " ";

            foreach (Vehicle vehicle in VehiclesInTheGarage)
            {
                if (vehicle.LicensePlate == i_LicensePlate)
                {
                    fullMessage = vehicle.ToString();
                }
            }

            return fullMessage;
        }
    }
}
