using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        protected Enum.eColors m_CarColor;
        protected Enum.eDoors m_NumberOfDoors;

        public Car()
        {
            m_VehicleTires = new List<Tire>(4) { new Tire(null, 0, 29), new Tire(null, 0, 29), new Tire(null, 0, 29), new Tire(null, 0, 29) };
        }

        public Enum.eColors CarColor
        {
            get { return m_CarColor; }
            set { m_CarColor = value; }
        }

        public Enum.eDoors NumberOfDoors
        {
            get { return m_NumberOfDoors; }
            set { m_NumberOfDoors = value; }
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
                VehicleTires[i].AirPressure = float.Parse(i_AllFeatures.Values.ElementAt(5));
            }

            CarColor = Enum.StringColorToEnumColor(i_AllFeatures.Values.ElementAt(6));
            NumberOfDoors = Enum.IntDoorsToEnumDoors(int.Parse(i_AllFeatures.Values.ElementAt(7)));
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
                    if (airPressure > 29)
                    {
                        throw new ValueOutOfRangeException(new Exception(), airPressure, 29, "air pressure");
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
                    if (currentAmountOfFuel > 38)
                    {
                        throw new ValueOutOfRangeException(new Exception(), currentAmountOfFuel, 38, "fuel tank");
                    }
                }
                catch
                {
                    throw new FormatException("Please enter the current amount of fuel in digit");
                }
            }
            else if (i_TheFeatureThatWeAskFromTheUser == "Your current amount of battery")
            {
                try
                {
                    float currentAmountOfBattery = float.Parse(i_DetailsToCheck);
                    if (currentAmountOfBattery > 3.3 * 60)
                    {
                        throw new ValueOutOfRangeException(new Exception(), currentAmountOfBattery, 3.3f * 60, "battery charge");
                    }
                }
                catch (FormatException ex)
                {
                    throw new FormatException("Please enter the current amount of battery in digit");
                }
            }
            else if (i_TheFeatureThatWeAskFromTheUser == "Your car color")
            {
                if (i_DetailsToCheck.ToLower() != "red" && i_DetailsToCheck.ToLower() != "blue" && i_DetailsToCheck.ToLower() != "white" && i_DetailsToCheck.ToLower() != "green")
                {
                    throw new ArgumentException("Sorry we can't handle your car");
                }
            }
            else if (i_TheFeatureThatWeAskFromTheUser == "Number of doors in your car")
            {
                try
                {
                    int numberOfDoors = int.Parse(i_DetailsToCheck);
                    if (numberOfDoors != 2 && numberOfDoors != 3 && numberOfDoors != 4 && numberOfDoors != 5)
                    {
                        checkValidtion = false;
                        throw new ArgumentException("Sorry we can't handle your car");
                    }
                }
                catch
                {
                    throw new FormatException("Please enter your number of door in digit");
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
@"Car color: {0}
Number of doors: {1}
The current fuel state is: {2}% and it's {3}",CarColor, NumberOfDoors, EnergyPrecentage, ((EngineUsingFuel)Engine).FuelType.ToString()));
            }
            else
            {
                fullMessage.Append(string.Format(
@"Car color: {0}
Number of doors: {1}
The current battry state is: {2}%",CarColor, NumberOfDoors, EnergyPrecentage));
            }

            return fullMessage.ToString();
        }
    }
}
