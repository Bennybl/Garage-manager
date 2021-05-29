using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    //change openning char in private/protected method to lower. 
    public class GarageManager
    {
        private List<VehicleInGarage> m_Vehicles;
        private List<Customer> m_Customers;
        VehicleCreator m_CurrentVehicleCreation;
        Vehicle m_CurrentVehicle;
        Customer m_CurrentCustomer;

        public GarageManager()
        {
            m_Vehicles = new List<VehicleInGarage>();
            m_Customers = new List<Customer>();
        }

        //to implement
        public void insertCar(int i_LicenseNumber)
        {

        }
        
        //to implement
        public List<string> GetLicenseNumberByVehicleStatus(eVehicleStatus  i_VehicleStatus)
        {
            return null;
        }

        //to implement
        public void getLicenseNumberByVehicleStatus(eVehicleStatus i_VehicleStatus)
        {

        }

        //to implement
        public void getLicenseNumber(eVehicleStatus i_VehicleStatus)
        {

        }

        //to implement
        public void UpdateVehicleStatus(int i_LicenseNumber, eVehicleStatus i_VehicleStatus)
        {

        }
        
        //to implement
        public void InflameTires(int i_LicenseNumber)
        {

        }
        
        //to implement
        public void RefuelVehicle()
        {

        }
        
        //to implement
        public void ChargeVehicle()
        {

        }
        
        //to implement
        public string GetVehicleInformation(int i_LicenseNumber)
        {
            return null;
        }

        private Vehicle SearchVehicleByLicenseNumber(int i_LicenseNumber)
        {
            Vehicle vehicle = null;
            foreach (VehicleInGarage vehicleInGarage in m_Vehicles)
            {
                if(vehicleInGarage.LicenseNumber == i_LicenseNumber)
                {
                    vehicle = vehicleInGarage.Vehicle;
                }
            }
            return vehicle;
        }

        //to implement
        private void InsertNewVehicleIntoGarage(eEngineBased i_EngineBased, eVehicleType i_eVehicleType, string i_LicenceNumber, string i_ModelName)
        {
            m_CurrentVehicleCreation = new VehicleCreator(i_EngineBased, i_eVehicleType, i_LicenceNumber, i_ModelName);
            
        }

        private Vehicle CreateNewCar(int i_numOfDoors, eColor i_Color)
        {
            Vehicle vehicle = m_CurrentVehicleCreation.SetCarMaterials(i_Color, i_numOfDoors);
            return vehicle;
        }

        private Vehicle CreateNewTruck(int i_MaxCapcity, bool i_isHavingDangerousMetrials)
        {
            Vehicle vehicle = m_CurrentVehicleCreation.SetTruckMaterials(i_MaxCapcity, i_isHavingDangerousMetrials);
            return vehicle;
        }

        private Vehicle CreateNewMotorcycle(eLicenseType i_LicenseType, int i_EngineVolume)
        {
            Vehicle vehicle = m_CurrentVehicleCreation.SetMotorcycleMaterials(i_EngineVolume, i_LicenseType);
            return vehicle;
        }
        
        //to implement
        private void AddNewCustomer()
        {

        }
        
        //to implement
        private Customer SearchCustomerByName(string i_CustomerName)
        {
            return null;
        }
        
        //to implement
        private List<string> GetVehicleLicenseNumberByStatus(eVehicleStatus i_VehicleStatus)
        {
            List<string> sortedVehicls = new List<string>();

            return null;
        }

    }
   
}
