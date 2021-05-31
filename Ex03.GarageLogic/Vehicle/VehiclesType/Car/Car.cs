using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private eColor m_Color;
        private eNumOfDoors m_numOfDoors;
        internal static readonly int sr_NumOfTires = 4;
        internal static readonly float sr_MaxTirePressure = 32f;

        internal Car(eEngineBased i_EngineBased, eNumOfDoors i_NumberOfDoors, eColor i_Color, string i_LicenceNumber, string i_ModelName)
        {
            if (isValidInput(i_Color, i_NumberOfDoors))
            {
                m_numOfDoors = i_NumberOfDoors;
                m_Color = i_Color;
                m_EngineBased = i_EngineBased;
                m_LicenceNumber = i_LicenceNumber;
                m_ModelName = i_ModelName;
                SetVehicleType();
                SetTires();
            }
            else
            {
                throw new WrongVehicleInputExeption("Invalis Input, doors range: 2-5 , avalible colors are: red, silver, black and white ");
            }
        }

        private bool isValidInput(eColor i_Color, eNumOfDoors i_NumberOfDoors)
        {
            bool color = Enum.IsDefined(typeof(eColor), i_Color);
            bool numberOfDoors = Enum.IsDefined(typeof(eNumOfDoors), i_NumberOfDoors);
            bool isValid = true;
            if(!color || !numberOfDoors)
            {
                isValid = false;
            }

            return isValid;
        }

        internal override void SetVehicleType()
        {
            if(m_EngineBased == eEngineBased.Electricty)
            {
                m_Engine = new ElectrictyBasedEngine();
                m_Engine.MaximumEnergy = 3.2f;
                m_Engine.m_FuelType = eFuelType.electricty;   
            }
            else
            {
                m_Engine = new FuelBasedEngine();
                m_Engine.MaximumEnergy = 45f;
                m_Engine.m_FuelType = eFuelType.Octan95;
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
            m_Engine.EnergyRefil(i_AmountOfGivenEnergy, i_FuelType);
            m_CurrentEnergy = m_Engine.CurrentEnergy;
        }

        internal eFuelType FuelType
        {
            get { return m_Engine.m_FuelType; }
        }

        internal eNumOfDoors NumberOfDoors
        {
            get { return m_numOfDoors; }
        }

        internal eColor Color
        {
            get { return m_Color; }
        }

        public override string ToString()
        {
            return string.Format("{0}, Color: {1}, Number of doors: {2}", base.ToString(), m_Color, m_numOfDoors);
        }
    }
}
