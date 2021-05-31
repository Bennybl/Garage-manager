using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Tire
    {
        private readonly float m_MaxPressure;
        private float m_CurrentPressure;
        private string m_FactoryName = "Michelin";

        internal Tire(float i_currentPressure, float i_MaxPressure)
        {
            this.m_CurrentPressure = i_currentPressure;
            this.m_MaxPressure = i_MaxPressure;
        }
        ////Exeption to implement
        internal void Inflame(float i_AirPressure)
        {
            if(i_AirPressure + m_CurrentPressure <= m_MaxPressure)
            {
                m_CurrentPressure += i_AirPressure;
            }
            else
            {
                throw new SystemException();
            }
        }

        internal void InflameToMax()
        {
            this.m_CurrentPressure = this.m_MaxPressure;
        }

        internal float AirPressure
        {
            get { return m_CurrentPressure; }
        }

        internal float MaxAirPressure
        {
            get { return m_MaxPressure; }
        }

        internal string Factory
        {
            get { return m_FactoryName; }
        }

        public override string ToString()
        {
            return string.Format("Air pressure: {0}, Factory: {1}", m_CurrentPressure, m_FactoryName);
        }
    }
}
