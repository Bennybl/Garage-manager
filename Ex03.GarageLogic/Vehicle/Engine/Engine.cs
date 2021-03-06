using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Engine
    {
        protected const float k_MinValue = 0;
        protected float m_CurrentEnergy;
        protected float m_MaximumEnergy;
        internal eFuelType m_FuelType;
        
        internal float MaximumEnergy
        {
            get { return m_MaximumEnergy; }
            set { m_MaximumEnergy = value; }
        }

        internal float CurrentEnergy
        {
            get { return m_CurrentEnergy; }
            set { m_CurrentEnergy = value; }
        }

        internal void EnergyRefil(float i_AmountOfGivenEnergy, eFuelType i_FuelType)
        {
            if (i_AmountOfGivenEnergy + m_CurrentEnergy > m_MaximumEnergy)
            {
                throw new ValueOutOfRangeException(k_MinValue, m_MaximumEnergy - m_CurrentEnergy);
            }
            else if (m_FuelType != i_FuelType)
            {
                throw new WrongFuelTypeExeption(m_FuelType);
            }
            else
            {
                m_CurrentEnergy += i_AmountOfGivenEnergy;
            }
        }

        internal void EnergyRefilToMax()
        {
            m_CurrentEnergy = m_MaximumEnergy;
        }

        public override string ToString()
        {
            return string.Format(
@"Eneing Based: {0}, 
Current amount of energy: {1}, 
Maximum of energy capcity: {2}", m_FuelType, m_CurrentEnergy, m_MaximumEnergy);
        }
    }
}
