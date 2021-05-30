using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    //change openning char in private/protected method to lower. 
    //change refill in abstract
    //Exeptions
    
    public class GarageManager
    {
        private List<VehicleInGarage> m_VehiclesInGarage;
        private List<Customer> m_Customers;
        VehicleCreator m_CurrentVehicleCreation;
        Vehicle m_CurrentVehicle;
        Customer m_CurrentCustomer;

        
        public GarageManager()
        {
            m_VehiclesInGarage = new List<VehicleInGarage>();
            m_Customers = new List<Customer>();
        }

        
        public bool InsertVehicle(int i_LicenseNumber)
        {
            bool isVehicleInGarage = true;
            if(SearchVehicleByLicenseNumber(i_LicenseNumber) != null)
            {
                UpdateVehicleStatus(i_LicenseNumber , eVehicleStatus.InRepair);
                isVehicleInGarage = false;
            }
            
            return isVehicleInGarage;
        }
        
        //to implement
        public List<string> GetLicenseNumberByVehicleStatus(eVehicleStatus i_VehicleStatus)
        {
            return null;
        }

        //to implement
        private void getLicenseNumberByVehicleStatus(eVehicleStatus i_VehicleStatus)
        {

        }

        //**
        private void getLicenseNumber(eVehicleStatus i_VehicleStatus)
        {

        }

        //**
        public void UpdateVehicleStatus(int i_LicenseNumber, eVehicleStatus i_VehicleStatus)
        {
            VehicleInGarage vehicleInGarage = SearchVehicleByLicenseNumber(i_LicenseNumber);
            if(vehicleInGarage != null)
            {
                vehicleInGarage.UpdateVehicleStatus(i_VehicleStatus);
            }

        }
        
        //**
        public void InflameTires(int i_LicenseNumber)
        {
            VehicleInGarage vehicleInGarage = SearchVehicleByLicenseNumber(i_LicenseNumber);
            if (vehicleInGarage != null)
            {
                vehicleInGarage.Vehicle.InflameTireToMax();
            }

        }

        //to implement
        public void RefuelVehicle(float i_ammountToRefeul, eFuelType i_FuelType, int i_LicenseNumber)
        {
            VehicleInGarage vehicleInGarage = SearchVehicleByLicenseNumber(i_LicenseNumber);
            if (vehicleInGarage != null)
            {
                vehicleInGarage.Vehicle.EnergyRefill(i_ammountToRefeul, i_FuelType);
            }
        }
        
        //to implement
        public void ChargeVehicle(float i_ammountToCharge, int i_LicenseNumber)
        {
            VehicleInGarage vehicleInGarage = SearchVehicleByLicenseNumber(i_LicenseNumber);
            if (vehicleInGarage != null)
            {
                vehicleInGarage.Vehicle.EnergyRefill(i_ammountToCharge, eFuelType.electricty);
            }
        }
        
        //to implement
        public string GetVehicleInformation(int i_LicenseNumber)
        {
            return null;
        }

        private VehicleInGarage SearchVehicleByLicenseNumber(int i_LicenseNumber)
        {
            VehicleInGarage vehicleInGarage = null;
            foreach (VehicleInGarage vInGarage in m_VehiclesInGarage)
            {
                if(vehicleInGarage.LicenseNumber == i_LicenseNumber)
                {
                    vehicleInGarage = vInGarage;
                }
            }
            return vehicleInGarage;
        }

        //to implement
        private void InsertNewVehicleIntoGarage(Dictionary<string, Object> i_VehicleMetrials)
        {
            VehicleCreator vehicleCreatorObject = new VehicleCreator(i_VehicleMetrials);
            Vehicle vehicle = vehicleCreatorObject.Vehicle;
            
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
        
    }
   
}
