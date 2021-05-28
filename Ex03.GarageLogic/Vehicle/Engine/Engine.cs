using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Engine
    {
        protected float m_CurrentEnergy;
        protected float m_MaximumEnergy;
        internal eFuelType m_FuelType;

        internal float MaximumEnergy
        {
            set { m_MaximumEnergy = value; }
            get { return m_MaximumEnergy; }
        }
        internal float CurrentEnergy
        {
            set { m_CurrentEnergy = value; }
            get { return m_CurrentEnergy; }
        }

        internal abstract void EnergyRefil(float i_AmountOfGivenEnergy, eFuelType i_FuelType);
        /**
         *         {
            if (i_AmountOfGivenEnergy + m_CurrentEnergy > m_MaximumEnergy)
            {
                throw new SystemException();
            }
            else if (fuelType != i_fuelType)
            {
                throw new SystemException();
            }
            else
            {
                m_CurrentEnergy += i_AmountOfGivenEnergy;
            }
        }
        **/

        internal void EnergyRefilToMax()
        {
            m_CurrentEnergy = m_MaximumEnergy;
        }

        public override string ToString()
        {
            return String.Format("Eneing Based: {0} Current amount of energy: {1} Maximum of energy capcity: {2}",m_FuelType, m_CurrentEnergy, m_MaximumEnergy);
        }
    }
}
