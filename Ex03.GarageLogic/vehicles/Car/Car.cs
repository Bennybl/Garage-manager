
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        protected eColor m_Color;
        protected  int m_numOfDoors;
        protected eFuelType m_FuelType;
        protected Engine engine;
        internal static readonly int sr_NumOfTires = 4;
        internal static readonly float sr_MaxTirePressure = 32f;

        internal Car (eFuelType i_fuelType, i_NumberOfDoors, eColor i_Color)
        {
           NumberOfDoors(i_NumberOfDoors);
           Color(i_Color);
           FuelType(i_fuelType);
           
        }

        private void SetEngine()
        {
            if(m_FuelType == eFuelType.electricty)
            {
                this.engine = new ElectrictyBasedEngine();
                engine.SetE();
            }
        }
        internal eFuelType FuelType
        {
            set { m_FuelType = value; }
            get { return m_FuelType; }

        }

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
