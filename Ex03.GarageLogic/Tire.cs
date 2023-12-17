using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Tire
    {
        private string m_ManufaturerName;
        public float m_AirPressure;
        private readonly float r_MaxAirPressure;

        public Tire(string i_ManufaturerName, float i_AirPressure, float i_MaxAirPressure)
        {
            m_ManufaturerName = i_ManufaturerName;
            m_AirPressure = i_AirPressure;
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public void InflationAction(float i_PressureToAdd)
        {
            if(AirPressure + i_PressureToAdd <= MaxAirPressure)
            {
                AirPressure += i_PressureToAdd;
            }
        }

        public float MaxAirPressure
        {
            get { return r_MaxAirPressure; }
        }

        public float AirPressure
        {
            get { return m_AirPressure; }
            set { m_AirPressure = value; }
        }

        public string ManufaturerName
        {
            get { return m_ManufaturerName; }
            set { m_ManufaturerName = value; }
        }
    }
}
