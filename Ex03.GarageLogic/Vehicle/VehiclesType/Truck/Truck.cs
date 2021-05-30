
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

        internal Truck(eEngineBased i_EngineBased, float i_MaxCapcity, bool i_isHavingDangerousMetrials, string i_LicenceNumber, string i_ModelName)
        {
            m_EngineBased = i_EngineBased;
            m_MaxCapcity = i_MaxCapcity;
            m_isHavingDangerousMetrials = i_isHavingDangerousMetrials;
            m_LicenceNumber = i_LicenceNumber;
            m_ModelName = i_ModelName;
            SetVehicleType();
            SetTires();
        }

        internal override void SetVehicleType()
        {
                FuelBasedEngine m_Engine = new FuelBasedEngine();
                m_Engine.MaximumEnergy = 120f;
                m_Engine.m_FuelType = eFuelType.Soler;
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
            return String.Format("{0} Max Capcity: {1} is having dangerous metrials: {2}", base.ToString(), m_MaxCapcity, m_isHavingDangerousMetrials);
        }
    }
}
