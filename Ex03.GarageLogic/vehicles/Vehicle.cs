﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Vehicle
    {
        protected string m_LicenceNumber;
        protected float m_energyLeft;
        protected Tire[] m_VehicleTire;
        protected string m_ModelName;
        protected const float k_MaxEnergy=0;
    }
}
