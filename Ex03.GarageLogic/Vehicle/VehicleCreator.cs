using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class VehicleCreator
    {
        private eEngineBased m_EngineBased;
        private eVehicleType m_eVehicleType;
        private string m_LicenceNumber;
        private string m_ModelName;
        private bool m_isHavingDangerousMetrials;
        private float m_MaxCapcity;
        private int m_EngineVolume;
        private eLicenseType m_LicenseType;
        private eColor m_Color;
        private int m_numOfDoors;


        internal VehicleCreator(eEngineBased i_EngineBased, eVehicleType i_eVehicleType, string i_LicenceNumber, string i_ModelName)
        {
            m_EngineBased = i_EngineBased;
            m_eVehicleType = i_eVehicleType;
            m_LicenceNumber = i_LicenceNumber;
            m_ModelName = i_ModelName;
        }

        internal Vehicle SetCarMaterials(eColor i_color, int i_numOfDoors)
        {
            m_Color = i_color;
            m_numOfDoors = i_numOfDoors;

            return CreateVehicle();
        }
        internal Vehicle SetMotorcycleMaterials(int i_EngineVolume, eLicenseType i_LicenseType)
        {
            m_EngineVolume = i_EngineVolume;
            m_LicenseType = i_LicenseType;

            return CreateVehicle();
        }
        internal Vehicle SetTruckMaterials(float i_MaxCapcity,bool i_isHavingDangerousMetrials)
        {
            m_isHavingDangerousMetrials = i_isHavingDangerousMetrials;
            m_MaxCapcity = i_MaxCapcity;

            return CreateVehicle();
        }

        internal Vehicle CreateVehicle()
        {
            Vehicle vehicle = null;
            
                            

        switch (m_eVehicleType)
        {
            case eVehicleType.Car:
                vehicle = new Car(m_EngineBased, m_numOfDoors, eColor.Black, m_LicenceNumber, m_ModelName);
                break;

            case eVehicleType.Motorcycle:
                vehicle = new Motorcycle(m_EngineBased, m_LicenseType, m_EngineVolume, m_LicenceNumber, m_ModelName);
                break;
            case eVehicleType.Truck:
                vehicle = new Truck(m_EngineBased, m_MaxCapcity, m_isHavingDangerousMetrials, m_LicenceNumber, m_ModelName);
                break;
        }
            return vehicle;
        }
    }
}
