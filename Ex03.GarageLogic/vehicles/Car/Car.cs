
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Car : Vehicle
    {
        protected eColor m_Color;
        protected  int m_numOfDoors;
        internal static readonly int sr_NumOfTires = 4;
        internal static readonly float sr_MaxTirePressure = 32f;

        internal int NumberOfDoors
        {
            set { m_numOfDoors = value; }
            get { return m_numOfDoors; }

        }

        internal eColor Color
        {
            set { m_Color = value; }
            get { return m_Color; }
        }

        public override string ToString()
        {
            return String.Format("Car color: {0} Number of doors: {1}" ,m_Color, m_numOfDoors);
        }
    }
}
