using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    ////change openning char in private/protected method to lower. 
    
    public class GarageManager
    {
        private List<VehicleInGarage> m_VehiclesInGarage;
        private List<Customer> m_Customers;

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
                UpdateVehicleStatus(i_LicenseNumber, eVehicleStatus.InRepair);
                isVehicleInGarage = false;
            }
            
            return isVehicleInGarage;
        }
               
        public List<string> GetLicenseNumberByVehicleStatus(eVehicleStatus i_VehicleStatus)
        {
            List<string> licenseNumberList;
            if(i_VehicleStatus != eVehicleStatus.None)
            {
                licenseNumberList = getLicenseNumberByVehicleStatus(i_VehicleStatus);
            }
            else
            {
                licenseNumberList = getLicenseNumber();
            }

            return licenseNumberList;
        }

        private List<string> getLicenseNumberByVehicleStatus(eVehicleStatus i_VehicleStatus)
        {
            List<string> licenseNumberList = new List<string>();
            foreach(VehicleInGarage vehicleInGarage in m_VehiclesInGarage)
            {
                if(vehicleInGarage.VehicleStatus == i_VehicleStatus)
                {
                    licenseNumberList.Add(vehicleInGarage.LicenseNumber);
                }
            }

            return licenseNumberList;
        }
 
        private List<string> getLicenseNumber()
        {
            List<string> licenseNumberList = new List<string>();
            foreach (VehicleInGarage vehicleInGarage in m_VehiclesInGarage)
            {
                    licenseNumberList.Add(vehicleInGarage.LicenseNumber);
            }

            return licenseNumberList;
        }

        public void UpdateVehicleStatus(string i_LicenseNumber, eVehicleStatus i_VehicleStatus)
        {
            VehicleInGarage vehicleInGarage = SearchVehicleByLicenseNumber(i_LicenseNumber);
            if(vehicleInGarage != null)
            {
                vehicleInGarage.UpdateVehicleStatus(i_VehicleStatus);
            }
        }
                
        public void InflameTires(string i_LicenseNumber)
        {
            VehicleInGarage vehicleInGarage = SearchVehicleByLicenseNumber(i_LicenseNumber);
            if (vehicleInGarage != null)
            {
                vehicleInGarage.Vehicle.InflameTireToMax();
            }
        }
        
        public void RefuelVehicle(float i_ammountToRefeul, eFuelType i_FuelType, string i_LicenseNumber)
        {
            VehicleInGarage vehicleInGarage = SearchVehicleByLicenseNumber(i_LicenseNumber);
            if (vehicleInGarage != null)
            {
                vehicleInGarage.Vehicle.EnergyRefill(i_ammountToRefeul, i_FuelType);
            }
        }
                
        public void ChargeVehicle(float i_ammountToCharge, string i_LicenseNumber)
        {
            VehicleInGarage vehicleInGarage = SearchVehicleByLicenseNumber(i_LicenseNumber);
            if (vehicleInGarage != null)
            {
                vehicleInGarage.Vehicle.EnergyRefill(i_ammountToCharge, eFuelType.electricty);
            }
        }
        
        public string GetVehicleInformation(string i_LicenseNumber)
        {
            string vehicleInfo = string.Empty;
            VehicleInGarage vehicleInGarage = SearchVehicleByLicenseNumber(i_LicenseNumber);
            if(vehicleInGarage != null)
            {
                vehicleInfo = vehicleInGarage.ToString();
            }

            return vehicleInfo;
        }

        private VehicleInGarage SearchVehicleByLicenseNumber(string i_LicenseNumber)
        {
            VehicleInGarage vehicleInGarage = null;
            foreach (VehicleInGarage vInGarage in m_VehiclesInGarage)
            {
                if(vInGarage.LicenseNumber == i_LicenseNumber)
                {
                    vehicleInGarage = vInGarage;
                }
            }

            if (vehicleInGarage == null)
            {
                throw new VehicleNotInGarageException();
            }

            return vehicleInGarage;
        }

        private Vehicle CreateNewVehicle(Dictionary<string, object> i_VehicleMetrials)
        {
            VehicleCreator vehicleCreatorObject = new VehicleCreator(i_VehicleMetrials);
            Vehicle vehicle = vehicleCreatorObject.Vehicle;
            return vehicle;  
        }

        private Customer AddNewCustomer(string i_CustomerName, string i_CustomerPhone)
        {
            Customer customer = new Customer(i_CustomerName, i_CustomerPhone);
            return customer;
        }
        
        public void InsertNewVehicleIntoGarage(Dictionary<string, object> i_VehicleMetrials, string i_CustomerName, string i_CustomerPhone)
        {
            Vehicle vehicle = CreateNewVehicle(i_VehicleMetrials);
            Customer customer = AddNewCustomer(i_CustomerName, i_CustomerPhone);
            m_VehiclesInGarage.Add(new VehicleInGarage(vehicle.LicenseNumber, customer, vehicle));
        }
    } 
}
