using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class CustomerManager
    {
        private List<Customer> m_Customers;

        internal CustomerManager()
        {
            m_Customers = new List<Customer>();
        }

        internal void CreateNewCustomer(string i_CustomerName, string i_CustomerPhone, VehicleInGarage i_CustomerVehicle)
        {
            m_Customers.Add(new Customer(i_CustomerName, i_CustomerPhone, i_CustomerVehicle));
        }

        internal void UpdateNewVehicleToCustomer(string i_CustomerPhone, VehicleInGarage i_CustomerVehicle)
        {
            foreach (Customer customer in m_Customers)
            {
                if(customer.CustomerPhone == i_CustomerPhone)
                {
                    customer.UpdateCustomrVehicle(i_CustomerVehicle);
                }
            }
        }

        
    }
}
