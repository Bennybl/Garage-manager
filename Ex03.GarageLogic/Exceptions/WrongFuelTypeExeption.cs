using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class WrongFuelTypeExeption : Exception
    {

        public WrongFuelTypeExeption(eFuelType i_FuelType):
            base(String.Format("Wrong fuel type exeption! the right fuel type is: {0}" , i_FuelType.ToString()))
        {
        }
    }
}
