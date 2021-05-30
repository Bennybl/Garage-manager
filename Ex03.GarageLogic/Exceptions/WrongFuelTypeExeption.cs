using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleNotInGarageException : Exception
    {

        public VehicleNotInGarageException(string i_message) :
            base(i_message);
        {
        }
    }
}
