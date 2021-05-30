using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Vehicle
    {
        protected string m_LicenceNumber;
        protected float m_CurrentEnergy;
        protected List<Tire> m_VehicleTire;
        protected string m_ModelName;
        protected eEngineBased m_EngineBased;
        protected Engine m_Engine;
        

        internal abstract void SetVehicleType();

        internal abstract void EnergyRefill(float i_AmountOfGivenEnergy, eFuelType i_FuelType);

        internal abstract void SetTires();

        internal abstract void InflameTire(float i_GivenAirPressure);

        internal abstract void InflameTireToMax();

        internal string LicenseNumber
        {
            get { return m_LicenceNumber; }
        }

        public override string ToString()
        {
            return String.Format("{0} Model Name: {1} Tires {2}", m_Engine.ToString(), m_ModelName, m_VehicleTire[0].ToString());
        }
    }
}
