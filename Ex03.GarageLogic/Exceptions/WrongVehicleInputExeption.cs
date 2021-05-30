using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class WrongVehicleInputExeption : Exception
    {

        public WrongVehicleInputExeption(string i_message) :
            base(i_message)

        {

        }
    }
}




    