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
        private Vehicle m_CurrentVehicle;

        internal VehicleCreator(Dictionary<string, Object> i_VehicleMetrials)
        {
            m_VehicleMetrials = i_VehicleMetrials;
            m_EngineBased = (eEngineBased) m_VehicleMetrials["EngineBased"];
            m_eVehicleType = (eVehicleType)m_VehicleMetrials["VehicleType"];
            m_ModelName = (string)m_VehicleMetrials["ModelName"];
            m_LicenceNumber = (string)m_VehicleMetrials["LicenceNumber"];
            m_CurrentVehicle = CreateVehicle();

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
                vehicle = new Motorcycle(m_EngineBased, licenseType,engineVolume, m_LicenceNumber, m_ModelName);
                break;
            
            case eVehicleType.Truck:
                bool isHavingDangerousMetrials = (bool)m_VehicleMetrials["IsHavingDangerousMetrials"];
                float maxCapcity = (float)m_VehicleMetrials["MaxCapcity"];
                vehicle = new Truck(m_EngineBased, maxCapcity, isHavingDangerousMetrials,m_LicenceNumber, m_ModelName);
                break;
        }
            return vehicle;
        }

        internal Vehicle Vehicle
        {
            get { return m_CurrentVehicle; }
        }
    }
}
