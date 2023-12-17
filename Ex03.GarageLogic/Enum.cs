using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Enum
    {
      public enum eColors
      {
            Red,
            Blue,
            White,
            Green
      }

      public static Enum.eColors StringColorToEnumColor(string i_CarColor)
      {
            Enum.eColors carColor = new Enum.eColors();
            if (i_CarColor.ToLower() == "red")
            {
                carColor = Enum.eColors.Red;
            }
            else if (i_CarColor.ToLower() == "blue")
            {
                carColor = Enum.eColors.Blue;
            }
            else if (i_CarColor.ToLower() == "white")
            {
                carColor = Enum.eColors.White;
            }
            else if (i_CarColor.ToLower() == "green")
            {
                carColor = Enum.eColors.Green;
            }

            return carColor;
      }

      public enum eDoors
      {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
      }

      public static Enum.eDoors IntDoorsToEnumDoors(int i_NumberOfDoors)
      {
            Enum.eDoors doors = new Enum.eDoors();
            if (i_NumberOfDoors == 2)
            {
                doors = Enum.eDoors.Two;
            }
            else if (i_NumberOfDoors == 3)
            {
                doors = Enum.eDoors.Three;
            }
            else if (i_NumberOfDoors == 4)
            {
                doors = Enum.eDoors.Four;
            }
            else if (i_NumberOfDoors == 5)
            {
                doors = Enum.eDoors.Five;
            }

            return doors;
      }

      public enum eFuelType
      {
            Soler,
            Octan95,
            Octan96,
            Octan98
      }

      public static Enum.eFuelType StringFuelToEnumFuel(string i_FuelType)
      {
            Enum.eFuelType fuelType = new Enum.eFuelType();
            if (i_FuelType == "Solar")
            {
                fuelType = Enum.eFuelType.Soler;
            }
            else if (i_FuelType == "Octan95")
            {
                fuelType = Enum.eFuelType.Octan95;
            }
            else if (i_FuelType == "Octan96")
            {
                fuelType = Enum.eFuelType.Octan96;
            }
            else if (i_FuelType == "Octan98")
            {
                fuelType = Enum.eFuelType.Octan98;
            }

            return fuelType;
      }

      public enum eLicenseType
       {
            A,
            A1,
            B1,
            BB
       }

      public static Enum.eLicenseType StringLicenseTypeToEnumLicenseType(string i_LicenseType)
      {
            Enum.eLicenseType license = new eLicenseType();
            if (i_LicenseType == "A")
            {
                license = Enum.eLicenseType.A;
            }
            else if (i_LicenseType == "A1")
            {
                license = Enum.eLicenseType.A1;
            }
            else if (i_LicenseType == "B1")
            {
                license = Enum.eLicenseType.B1;
            }
            else if (i_LicenseType == "BB")
            {
                license = Enum.eLicenseType.BB;
            }

            return license;
      }

      public enum eStateInTheGarage
      {
            InReapair,
            Fixed,
            Payed
      }

      public static Enum.eStateInTheGarage StringStateInTheGarageToEnumStateInTheGarage(string i_StateInGarge)
      {
            Enum.eStateInTheGarage state = new eStateInTheGarage();
            if (i_StateInGarge.ToLower() == "inreapair")
            {
                state = eStateInTheGarage.InReapair;
            }
            else if (i_StateInGarge.ToLower() == "payed")
            {
                state = eStateInTheGarage.Payed;
            }
            else if (i_StateInGarge.ToLower() == "fixed")
            {
                state = eStateInTheGarage.Fixed;
            }

            return state;
      }
    }
}
