
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private eColor m_Color;
        private  int m_numOfDoors;
        private eFuelType m_FuelType;
        protected readonly Engine m_Engine;
        internal static readonly int sr_NumOfTires = 4;
        internal static readonly float sr_MaxTirePressure = 32f;

        internal Car (eFuelType i_FuelType, int i_NumberOfDoors, eColor i_Color, string i_LicenceNumber, string i_ModelName)
        {
            m_numOfDoors =  i_NumberOfDoors;
            m_Color = i_Color;
            m_FuelType = i_FuelType;
            m_LicenceNumber = i_LicenceNumber;
            m_ModelName = i_ModelName;
            SetEngineType();


        }

        private void SetEngineType()
        {
            if(m_FuelType == eFuelType.electricty)
            {
                ElectrictyBasedEngine m_Engine = new ElectrictyBasedEngine();
                
            }
            else
            {
                FuelBasedEngine m_Engine = new FuelBasedEngine();
            }
        }

        internal override void SetTires()
        {
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
            get { return m_FuelType; }

        }

        internal int NumberOfDoors
        {
            get { return m_numOfDoors; }

        }

        internal eColor Color
        {
            get { return m_Color; }
        }

        public override string ToString()
        {
            return String.Format("Car color: {0} Number of doors: {1}" ,m_Color, m_numOfDoors);
        }

     
    }
}
