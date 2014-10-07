using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyWCF.EasyNorthwind.FaultContracts
{
    public partial class ProductFault
    {
        public ProductFault(string message)
        {
            this.faultMessage = message;
        }
    }
}
