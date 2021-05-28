using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private List<VehicleInGarage> m_Vehicles;
        private List<Customer> m_Customers;


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
        public void GetLicenseNumber()
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
        private void InsertNewCar()
        {

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
