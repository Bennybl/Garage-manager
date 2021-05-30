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

        public bool InsertVehicle(string i_LicenseNumber)
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
        public void UpdateVehicleStatus(string i_LicenseNumber, eVehicleStatus i_VehicleStatus)
        {
            VehicleInGarage vehicleInGarage = SearchVehicleByLicenseNumber(i_LicenseNumber);
            if(vehicleInGarage != null)
            {
                vehicleInGarage.UpdateVehicleStatus(i_VehicleStatus);
            }

        }
        
        //**
        public void InflameTires(string i_LicenseNumber)
        {
            VehicleInGarage vehicleInGarage = SearchVehicleByLicenseNumber(i_LicenseNumber);
            if (vehicleInGarage != null)
            {
                vehicleInGarage.Vehicle.InflameTireToMax();
            }

        }

        //to implement
        public void RefuelVehicle(float i_ammountToRefeul, eFuelType i_FuelType, string i_LicenseNumber)
        {
            VehicleInGarage vehicleInGarage = SearchVehicleByLicenseNumber(i_LicenseNumber);
            if (vehicleInGarage != null)
            {
                vehicleInGarage.Vehicle.EnergyRefill(i_ammountToRefeul, i_FuelType);
            }
        }
        
        //to implement
        public void ChargeVehicle(float i_ammountToCharge, string i_LicenseNumber)
        {
            VehicleInGarage vehicleInGarage = SearchVehicleByLicenseNumber(i_LicenseNumber);
            if (vehicleInGarage != null)
            {
                vehicleInGarage.Vehicle.EnergyRefill(i_ammountToCharge, eFuelType.electricty);
            }
        }
        
        //to implement
        public string GetVehicleInformation(string i_LicenseNumber)
        {
            return null;
        }

        private VehicleInGarage SearchVehicleByLicenseNumber(string i_LicenseNumber)
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

        private Vehicle CreateNewVehicle(Dictionary<string, Object> i_VehicleMetrials)
        {
            VehicleCreator vehicleCreatorObject = new VehicleCreator(i_VehicleMetrials);
            Vehicle vehicle = vehicleCreatorObject.Vehicle;
            return vehicle;
            
        }

        private  Customer AddNewCustomer(string i_CustomerName, string i_CustomerPhone)
        {
            Customer customer = new Customer(i_CustomerName, i_CustomerPhone);
            return customer;
        }
        
        public void InsertNewVehicleIntoGarage(Dictionary<string, Object> i_VehicleMetrials, string i_CustomerName, string i_CustomerPhone)
        {
            Vehicle vehicle = CreateNewVehicle(i_VehicleMetrials);
            Customer customer = AddNewCustomer(i_CustomerName, i_CustomerPhone);
            m_VehiclesInGarage.Add(new VehicleInGarage(vehicle.LicenseNumber, customer, vehicle));
        }
    }
   
}
