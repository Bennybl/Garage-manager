using Ex03.GarageLogic.vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Truck : Vehicle
    {
        protected bool m_isHavingDangerousMetrials;
        protected float m_MaxCapcity;
        internal static readonly int sr_NumOfTires = 16;
        internal static readonly float sr_MaxTirePressure = 26f;
    }
}
