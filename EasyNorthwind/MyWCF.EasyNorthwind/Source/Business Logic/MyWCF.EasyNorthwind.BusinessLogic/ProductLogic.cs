using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyWCF.EasyNorthwind.BusinessEntities;
using MyWCF.EasyNorthwind.DataAccess;


namespace MyWCF.EasyNorthwind.BusinessLogic
{
    public class ProductLogic
    {
        ProductDAL productDAL = new ProductDAL();
        public ProductEntity GetProduct(int id)
        {
            return productDAL.GetProduct(id);
        }

    }
}
