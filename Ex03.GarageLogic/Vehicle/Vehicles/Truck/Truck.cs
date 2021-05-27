
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        protected bool m_isHavingDangerousMetrials;
        protected float m_MaxCapcity;
        internal static readonly int sr_NumOfTires = 16;
        internal static readonly float sr_MaxTirePressure = 26f;

        //to implement
        internal Truck()
        {

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

        //to implement
        internal override void EnergyRefill(float i_AmountOfGivenEnergy, eFuelType i_FuelType)
        {
            throw new NotImplementedException();
        }
    }
}
