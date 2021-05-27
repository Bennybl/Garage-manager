using Ex03.GarageLogic.vehicles;
using Ex03.GarageLogic.vehicles.Motorcycle;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Motorcycle : Vehicle
    {
        protected int m_EngineVolume;
        protected eLicenseType m_LicenseType;
        internal static readonly int sr_NumOfTires = 2;
        internal static readonly float sr_MaxTirePressure = 30f;

    }
}
