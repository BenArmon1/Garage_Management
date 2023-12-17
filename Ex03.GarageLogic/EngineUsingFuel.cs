using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class EngineUsingFuel: Engine
    {
        protected Enum.eFuelType m_FuelType;

        public EngineUsingFuel(string i_FuelType, float i_MaxFualCapacity, float i_CurrentFualAmount)
        {
            m_FuelType = Enum.StringFuelToEnumFuel(i_FuelType);
            m_MaxCapcityOfTheEngine = i_MaxFualCapacity;
            m_CurrentAmountInEngine = i_CurrentFualAmount;
        }

        public Enum.eFuelType FuelType
        {
            get { return m_FuelType; }
            set { m_FuelType = value; }
        }

        public void Refuel(float i_FualAmount, string i_FualType)
        {
            if(i_FualType == FuelType.ToString())
            {
                if (i_FualAmount + CurrentAmountInEngine <= MaxCapcityOfTheEngine && i_FualAmount + CurrentAmountInEngine > 0)
                {
                    m_CurrentAmountInEngine += i_FualAmount;
                }
                else
                {
                    ValueOutOfRangeException valueOutOfRangeException = new ValueOutOfRangeException(new Exception(), i_FualAmount, MaxCapcityOfTheEngine, "fuel tank");
                    throw valueOutOfRangeException;
                }
            }
            else
            {
                throw new ArgumentException(string.Format("You requset to refuel with {0} but the appropriate fuel is {1}",i_FualType, FuelType.ToString()));
            }
        }
    }
}
