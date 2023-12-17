using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        protected bool m_RefrigeratedContents;
        protected float m_TrunkVolume;

        public Truck()
        {
            m_VehicleTires = makintTiresForTruck();
        }

        public bool RefrigeratedContents
        {
            get { return m_RefrigeratedContents; }
            set { m_RefrigeratedContents = value; }
        }

        public float TrunkVolume
        {
            get { return m_TrunkVolume; }
            set { m_TrunkVolume = value; }
        }

        private List<Tire> makintTiresForTruck()
        {
            List<Tire> tires = new List<Tire>();
            for (int i = 0; i < 16; i++)
            {
                tires.Add(new Tire(null, 0, 24));
            }

            return tires;
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

            RefrigeratedContents = bool.Parse(i_AllFeatures.Values.ElementAt(6));
            TrunkVolume = float.Parse(i_AllFeatures.Values.ElementAt(7));
            Engine.CurrentAmountInEngine = float.Parse(i_AllFeatures.Values.ElementAt(8));
            EnergyPrecentage = (Engine.CurrentAmountInEngine / Engine.MaxCapcityOfTheEngine) * 100;
        }

        public override bool CheckValidtionForCustomerDetails(string i_DetailsToCheck, string i_TheFeatureThatWeAskFromTheUser)
        {
            bool checkValidtion = true;

            if (i_TheFeatureThatWeAskFromTheUser == "Your name")
            {
                foreach (char c in i_DetailsToCheck)
                {
                    if (!Char.IsLetter(c))
                    {
                        throw new FormatException("Please enter your name with only letters");
                    }
                }
            }
            else if (i_TheFeatureThatWeAskFromTheUser == "Your phone number")
            {
                foreach (char c in i_DetailsToCheck)
                {
                    if (!Char.IsDigit(c))
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
                    if (airPressure > 24)
                    {
                        throw new ValueOutOfRangeException(new Exception(), airPressure, 24, "air pressure");
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
                    if (currentAmountOfFuel > 120)
                    {
                        throw new ValueOutOfRangeException(new Exception(), currentAmountOfFuel, 120, "fuel tank");
                    }
                }
                catch (FormatException ex)
                {
                    throw new FormatException("Please enter the current amount of fuel in digit");
                }
            }
            else if (i_TheFeatureThatWeAskFromTheUser == "Do you drive refrigerated contents")
            {
                try
                {
                    bool refrigeratedContents = bool.Parse(i_DetailsToCheck);
                }
                catch
                {
                    throw new FormatException("Please retype if you drive refrigerated contents - answer with true or false");
                }
            }
            else if (i_TheFeatureThatWeAskFromTheUser == "Your trunk volume")
            {
                try
                {
                    float trunkValume = float.Parse(i_DetailsToCheck);
                }
                catch
                {
                    throw new FormatException("Please type Your trunk valume in digit");
                }
            }

            return checkValidtion;
        }

        public override string ToString()
        {
            StringBuilder fullMessage = new StringBuilder(this.VehicleToString());

            fullMessage.Append(string.Format(
@"Refrigerated contents: {0}
Trunk volume: {1}
The current fuel state is: {2}% and it's {3}",RefrigeratedContents, TrunkVolume, EnergyPrecentage, ((EngineUsingFuel)Engine).FuelType.ToString()));

            return fullMessage.ToString();
        }
    }
}
