using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class VehicleInGarage
    {
        private string m_LicenseNumber;
        private Customer m_VehicleOwener;
        private eVehicleStatus m_VehicleStatus;
        private Vehicle m_Vehicle;

        internal VehicleInGarage(string i_LicenseNumber, Customer i_VehicleOwener, Vehicle i_Vehicle)
        {
            m_LicenseNumber = i_LicenseNumber;
            m_VehicleOwener = i_VehicleOwener;
            m_VehicleStatus = eVehicleStatus.InRepair;
            m_Vehicle = i_Vehicle;
        }

        internal string LicenseNumber
        {
            get { return m_LicenseNumber; }
        }

        internal Vehicle Vehicle
        {
            get { return m_Vehicle; }
        }

        internal eVehicleStatus VehicleStatus
        {
            get { return m_VehicleStatus; }
        }

        internal void UpdateVehicleStatus(eVehicleStatus i_VehicleStatus)
        {
            m_VehicleStatus = i_VehicleStatus;
        }

        public override string ToString()
        {
            return String.Format("License number: {0} Vehicle owener: {1} Vehicle status: {2}", m_LicenseNumber, m_VehicleOwener, m_VehicleStatus);
        }
    }
}
