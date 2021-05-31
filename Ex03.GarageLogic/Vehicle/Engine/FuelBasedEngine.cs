using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class FuelBasedEngine : Engine
    {
        internal float FuelLeft
        {
            get { return m_CurrentEnergy; }
        }

        public override string ToString()
        {
            return string.Format(
@"Eneing Based: {0}, 
Amount of fuel left (in liter): {1}, 
Maximum of fuel capcity (in liter):{2} ", m_FuelType, m_CurrentEnergy, m_MaximumEnergy);
        }
    }
}
