using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class VehicleCreator
    {
        private Dictionary<string, Object> m_VehicleMetrials;
        private eEngineBased m_EngineBased;
        private eVehicleType m_eVehicleType;
        private string m_LicenceNumber;
        private string m_ModelName;

        
        private int m_EngineVolume;
        private eLicenseType m_LicenseType;
        private eColor m_Color;
        private int m_numOfDoors;
        

        internal VehicleCreator(Dictionary<string, Object> i_VehicleMetrials)
        {
            m_VehicleMetrials = i_VehicleMetrials;
            m_EngineBased = (eEngineBased) m_VehicleMetrials["EngineBased"];
            m_eVehicleType = (eVehicleType)m_VehicleMetrials[""];
            m_ModelName = (string)m_VehicleMetrials[""];
            

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
           
        switch (m_VehicleMetrials["VehicleType"])
        {
            

            case eVehicleType.Car:
                vehicle = new Car(, m_VehicleMetrials["numOfDoors"], m_VehicleMetrials["LicenceNumber"], m_VehicleMetrials["ModelName"]);
                break;
            
            case eVehicleType.Motorcycle:
                bool isHavingDangerousMetrials = (bool)m_VehicleMetrials[""];
                float maxCapcity = (float)m_VehicleMetrials[""];
                vehicle = new Motorcycle(m_VehicleMetrials["EngineBased"], m_VehicleMetrials["LicenseType"], m_VehicleMetrials["EngineVolume"], m_VehicleMetrials["ModelName"]);
                break;
            
            case eVehicleType.Truck:
                bool isHavingDangerousMetrials = (bool)m_VehicleMetrials[""];
                float maxCapcity = (float)m_VehicleMetrials[""];
                vehicle = new Truck(m_EngineBased, maxCapcity, isHavingDangerousMetrials,m_LicenceNumber, m_ModelName);
                break;
        }
            return vehicle;
        }
    }
}
