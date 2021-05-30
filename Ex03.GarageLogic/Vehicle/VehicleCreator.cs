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
           
        switch (m_eVehicleType)
        {
           
            case eVehicleType.Car:
                    int numOfDoors = (int)m_VehicleMetrials["NumOfDoors"];
                    eColor color = (eColor)m_VehicleMetrials["Color"];
                    vehicle = new Car(m_EngineBased, numOfDoors, color, m_LicenceNumber, m_ModelName);
                break;
            
            case eVehicleType.Motorcycle:
                int engineVolume  = (int)m_VehicleMetrials["EngineVolume"];
                eLicenseType licenseType = (eLicenseType)m_VehicleMetrials["LicenseType"];
                vehicle = new Motorcycle(m_EngineBased, licenseType,engineVolume, m_LicenceNumber, m_ModelName   );
                break;
            
            case eVehicleType.Truck:
                bool isHavingDangerousMetrials = (bool)m_VehicleMetrials["IsHavingDangerousMetrials"];
                float maxCapcity = (float)m_VehicleMetrials["MaxCapcity"];
                vehicle = new Truck(m_EngineBased, maxCapcity, isHavingDangerousMetrials,m_LicenceNumber, m_ModelName);
                break;
        }
            return vehicle;
        }
    }
}
