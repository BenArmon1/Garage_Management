using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Engine
    {
        protected float m_MaxCapcityOfTheEngine;
        protected float m_CurrentAmountInEngine;

        public float MaxCapcityOfTheEngine
        {
            get { return m_MaxCapcityOfTheEngine; }
            set { m_MaxCapcityOfTheEngine = value; }
        }

        public float CurrentAmountInEngine
        {
            get { return m_CurrentAmountInEngine; }
            set { m_CurrentAmountInEngine = value; }
        }
    }
}
