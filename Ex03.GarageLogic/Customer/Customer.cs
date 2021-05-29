﻿
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal struct Customer
    {
        private string m_CustomerPhone;
        private string m_CustomerName;

        internal Customer(string i_CustomerName, string i_CustomerPhone)
        {
            m_CustomerPhone = i_CustomerPhone;
            m_CustomerName = i_CustomerName;
            m_CustomerVehicles = new List<VehicleInGarage>();

        }

        internal void UpdateCustomrVehicle(VehicleInGarage i_CustomerVehicle)
        {
            m_CustomerVehicles.Add(i_CustomerVehicle);
        }

        internal string CustomerName
        {
            get { return m_CustomerName; }
        }

        internal string CustomerPhone
        {
            get { return m_CustomerPhone; }
        }

        internal List<VehicleInGarage> CustomerVehicles
        {
            get { return m_CustomerVehicles; }
    
        }
    }

}
