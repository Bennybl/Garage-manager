using Ex03.GarageLogic.vehicles;
using Ex03.GarageLogic.vehicles.Car;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Car : Vehicle
    {
        protected eColor m_Color;
        protected readonly int r_numOfDoors;
        internal static readonly int sr_NumOfTires = 4;
        internal static readonly float sr_MaxTirePressure = 32f;
    }
}
