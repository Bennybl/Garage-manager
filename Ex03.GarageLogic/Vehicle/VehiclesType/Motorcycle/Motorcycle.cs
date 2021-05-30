
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

        internal Motorcycle(eEngineBased i_VehicleType, eLicenseType i_LicenseType, int i_EngineVolume, string i_LicenceNumber, string i_ModelName)
        {

            if (isValidInput(i_LicenseType))
            {
                m_LicenseType = i_LicenseType;
                m_EngineVolume = i_EngineVolume;
                m_EngineBased = i_VehicleType;
                m_LicenceNumber = i_LicenceNumber;
                m_ModelName = i_ModelName;
                SetVehicleType();
                SetTires();
            }
            else
            {
                throw new WrongVehicleInputExeption("Lisence tyoe should be: AA, BB, B1, A");
            }
        }

        private bool isValidInput(eLicenseType i_LicenseType)
        {
            bool licenseType = Enum.IsDefined(typeof(eLicenseType), i_LicenseType);

            return licenseType;
        }
        internal override void SetVehicleType()
        {
            if (m_EngineBased == eEngineBased.Electricty)
            {
                ElectrictyBasedEngine m_Engine = new ElectrictyBasedEngine();
                m_Engine.MaximumEnergy = 1.8f;
                m_Engine.m_FuelType = eFuelType.electricty;

            }
            else
            {
                FuelBasedEngine m_Engine = new FuelBasedEngine();
                m_Engine.MaximumEnergy = 6f;
                m_Engine.m_FuelType = eFuelType.Octan98;
            }
        }

        internal override void SetTires()
        {
            m_VehicleTire = new List<Tire>();
            for (int i = 0; i < sr_NumOfTires; i++)
            {
                m_VehicleTire.Add(new Tire(sr_MaxTirePressure / 2, sr_MaxTirePressure));
            }
        }

        internal override void InflameTireToMax()
        {
            foreach (Tire tire in m_VehicleTire)
            {
                tire.InflameToMax();
            }
        }

        internal override void InflameTire(float i_GivenAirPressure)
        {

            foreach (Tire tire in m_VehicleTire)
            {
                tire.Inflame(i_GivenAirPressure);
            }
        }

        internal override void EnergyRefill(float i_AmountOfGivenEnergy, eFuelType i_FuelType)
        {
            m_Engine.EnergyRefil(i_AmountOfGivenEnergy, FuelType);
            m_CurrentEnergy = m_Engine.CurrentEnergy;
        }

        internal eFuelType FuelType
        {
            get { return m_Engine.m_FuelType; }

        }

        //to implement
        public override string ToString()
        {
            return String.Format("{0} License type: {1}  Engine volume: {2}", base.ToString(), m_LicenseType, m_EngineVolume);
        }
    }
}
