using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class EngineByBattery : Engine
    {
        public EngineByBattery(float i_CurrentBataryLeft, float i_BataryTimeCapacity)
        {
            m_CurrentAmountInEngine = i_CurrentBataryLeft;
            m_MaxCapcityOfTheEngine = i_BataryTimeCapacity * 60;
        }

        public void FillBattery(float i_ElectriTimeToAdd)
        {
            if(i_ElectriTimeToAdd + CurrentAmountInEngine <= MaxCapcityOfTheEngine && i_ElectriTimeToAdd + CurrentAmountInEngine > 0)
            {
                CurrentAmountInEngine += i_ElectriTimeToAdd;
            }
            else
            {
                ValueOutOfRangeException valueOutOfRangeException = new ValueOutOfRangeException(new Exception(), i_ElectriTimeToAdd, MaxCapcityOfTheEngine, "battery");
                throw valueOutOfRangeException;
            }
        }
    }
}
