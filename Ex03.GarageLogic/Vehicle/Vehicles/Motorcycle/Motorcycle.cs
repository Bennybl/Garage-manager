
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        protected int m_EngineVolume;
        protected eLicenseType m_LicenseType;
        internal static readonly int sr_NumOfTires = 2;
        internal static readonly float sr_MaxTirePressure = 30f;

        //to implement
        internal Motorcycle()
        {

        }

        //to implement
        internal override void EnergyRefill(float i_AmountOfGivenEnergy, eFuelType i_FuelType)
        {
            throw new NotImplementedException();
        }
        //to implement
        internal override void SetTires()
        {
            throw new NotImplementedException();
        }
        //to implement
        internal override void InflameTire(float i_GivenAirPressure)
        {
            throw new NotImplementedException();
        }
        //to implement
        internal override void InflameTireToMax()
        {
            throw new NotImplementedException();
        }
    }
}
