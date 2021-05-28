using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class VehicleInGarage
    {
        private int m_LicenseNumber;
        private Customer m_VehicleOwener;
        private eVehicleStatus m_VehicleStatus;

        internal VehicleInGarage(int i_LicenseNumber, Customer i_VehicleOwener)
        {
            m_LicenseNumber = i_LicenseNumber;
            m_VehicleOwener = i_VehicleOwener;
            m_VehicleStatus = eVehicleStatus.InRepair;
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
