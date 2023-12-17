using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public float MaxValue
        {
            get { return m_MaxValue; }
        }

        public float MinValue
        {
            get { return m_MinValue; }
        }

         public ValueOutOfRangeException(Exception i_InnerException, float i_AmountToFill, float i_MaxAmountToFill, string i_TypeOfTheVehicle)
             : base(string.Format("An error occured while trying to fill the {0} with {1} and its pass the maximun - {2}", i_TypeOfTheVehicle, i_AmountToFill, i_MaxAmountToFill),
                   i_InnerException)
        { }
    }
}
