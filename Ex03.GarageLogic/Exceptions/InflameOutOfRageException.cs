using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class InflameOutOfRageException : Exception
    {
        public InflameOutOfRageException(float i_MaxAirPressure) :
            base(string.Format("In flame out of rage exception! Max air pressure: {0}", i_MaxAirPressure))
        { 
        }
    }
}