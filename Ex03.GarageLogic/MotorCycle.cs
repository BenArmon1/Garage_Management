using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class MotorCycle : Vehicle
    {
        private Enum.eLicenseType m_LicenseType;
        private int m_EngineCapacity;

        public MotorCycle()
        {
            m_VehicleTires = new List<Tire>(2) { new Tire(null, 0, 31), new Tire(null, 0, 31) };
        }

        public Enum.eLicenseType LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }

        public int EngineCapacity
        {
            get { return m_EngineCapacity; }
            set { m_EngineCapacity = value; }
        }

        public override void SetFeaturesForTheVhicle(Dictionary<string, string> i_AllFeatures)
        {
            OwnerName = i_AllFeatures.Values.ElementAt(0);
            OwnerPhoneNumber = i_AllFeatures.Values.ElementAt(1);
            ModelName = i_AllFeatures.Values.ElementAt(2);
            LicensePlate = i_AllFeatures.Values.ElementAt(3);
            for (int i = 0; i < VehicleTires.Count; i++)
            {
                VehicleTires[i].ManufaturerName = i_AllFeatures.Values.ElementAt(4);
                VehicleTires[i].AirPressure = float.Parse(i_AllFeatures.Values.ElementAt(5)); // FormatException
            }

            LicenseType = Enum.StringLicenseTypeToEnumLicenseType(i_AllFeatures.Values.ElementAt(6));
            EngineCapacity = int.Parse(i_AllFeatures.Values.ElementAt(7));
            Engine.CurrentAmountInEngine = float.Parse(i_AllFeatures.Values.ElementAt(8));
            EnergyPrecentage = Engine.CurrentAmountInEngine / Engine.MaxCapcityOfTheEngine * 100;
        }

        public override bool CheckValidtionForCustomerDetails(string i_DetailsToCheck, string i_TheFeatureThatWeAskFromTheUser)
        {
            bool checkValidtion = true;

            if (i_TheFeatureThatWeAskFromTheUser == "Your name")
            {
                foreach (char c in i_DetailsToCheck)
                {
                    if (!char.IsLetter(c))
                    {
                        throw new FormatException("Please enter your name with only letters");
                    }
                }
            }
            else if (i_TheFeatureThatWeAskFromTheUser == "Your phone number")
            {
                foreach (char c in i_DetailsToCheck)
                {
                    if (!char.IsDigit(c))
                    {
                        throw new FormatException("Please enter your phone with only digit");
                    }
                }
            }
            else if (i_TheFeatureThatWeAskFromTheUser == "Your air pressure of your wheels")
            {
                try
                {
                    float airPressure = float.Parse(i_DetailsToCheck);
                    if (airPressure > 31)
                    {
                        throw new ValueOutOfRangeException(new Exception(), airPressure, 31, "air pressure");
                    }
                }
                catch (FormatException ex)
                {
                    throw new FormatException("Please enter your air pressure in digit");
                }
            }
            else if (i_TheFeatureThatWeAskFromTheUser == "Your current amount of fuel")
            {
                try
                {
                    float currentAmountOfFuel = float.Parse(i_DetailsToCheck);
                    if (currentAmountOfFuel > 6.2f)
                    {
                        throw new ValueOutOfRangeException(new Exception(), currentAmountOfFuel, 6.2f, "fuel tank");
                    }
                }
                catch (FormatException ex)
                {
                    throw new FormatException("Please enter the current amount of fuel in digit");
                }
            }
            else if (i_TheFeatureThatWeAskFromTheUser == "Your current amount of battery")
            {
                try
                {
                    float currentAmountOfBattery = float.Parse(i_DetailsToCheck);
                    if (currentAmountOfBattery > 2.5 * 60)
                    {
                        throw new ValueOutOfRangeException(new Exception(), currentAmountOfBattery, 2.5f * 60, "battery charge");
                    }
                }
                catch
                {
                    throw new FormatException("Please enter the current amount of battery in digit");
                }
            }
            else if (i_DetailsToCheck == "Your licencse type")
            {
                if (i_DetailsToCheck != "A" && i_DetailsToCheck != "A1" && i_DetailsToCheck != "B1" && i_DetailsToCheck != "BB")
                {
                    throw new ArgumentException("Sorry we can't handle your car");
                }
            }
            else if (i_TheFeatureThatWeAskFromTheUser == "Your engine capacity")
            {
                try
                {
                    int engineCapacity = int.Parse(i_DetailsToCheck);
                }
                catch
                {
                    throw new FormatException("Please type Your engine capacity in digit");
                }
            }

            return checkValidtion;
        }

        public override string ToString()
        {
            StringBuilder fullMessage = new StringBuilder(this.VehicleToString());

            if (Engine is EngineUsingFuel)
            {
                fullMessage.Append(string.Format(
@"License Type: {0}
EngineCapacity: {1}
The current fuel state is: {2}% and it's {3}",LicenseType, EngineCapacity,EnergyPrecentage, ((EngineUsingFuel)Engine).FuelType.ToString()));
            }
            else
            {
                fullMessage.Append(string.Format(
@"License Type: {1}
EngineCapacity: {2}
The current battry state is: {3}%",LicenseType, EngineCapacity,StateOfTheVehicleInTheGarage, EnergyPrecentage));
            }

            return fullMessage.ToString();
        }
    }
}
