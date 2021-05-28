using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class VehicleCreator
    {


        internal static Vehicle CreateVehicle(eEngineBased i_EngineBased, eVehicleType i_eVehicleType, string  i_LicenceNumber, string i_ModelName)
        {
            Vehicle vehicle = null;
            switch (i_EngineBased)
            {
                case eEngineBased.FuelBased:

                    switch (i_eVehicleType)
                    {
                        case eVehicleType.Car:
                            vehicle = new Car(i_EngineBased, 4, eColor.Black, i_LicenceNumber, i_ModelName);
                            break;

                        case eVehicleType.Motorcycle:
                            vehicle = new Motorcycle(i_EngineBased,i_LicenseType, int i_EngineVolume, i_LicenceNumber, i_ModelName)
                    }

                        
                            
                

                

            return retVehicle;
        }
    }
}
