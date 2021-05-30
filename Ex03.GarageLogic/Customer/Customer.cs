
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal struct Customer
    {
        private string m_CustomerName;
        private string m_CustomerPhone;
        
        internal Customer(string i_CustomerName, string i_CustomerPhone)
        {
            m_CustomerPhone = i_CustomerPhone;
            m_CustomerName = i_CustomerName;
          
        }

        internal string CustomerName
        {
            get { return m_CustomerName; }
        }

        internal string CustomerPhone
        {
            get { return m_CustomerPhone; }
        }
    }

}
