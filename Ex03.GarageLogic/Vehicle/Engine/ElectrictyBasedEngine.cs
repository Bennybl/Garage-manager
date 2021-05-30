using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class ElectrictyBasedEngine : Engine
    {

        internal float Houerslfet
        {
            get { return m_CurrentEnergy; }
        }

        public override string ToString()
        {
            return String.Format("Eneing Based: {0}, Amount of electricity left (in hours): {1}, Maximum of fuel capcity (in liter):{2} ", m_FuelType, m_CurrentEnergy, m_MaximumEnergy);
        }

    }
}
