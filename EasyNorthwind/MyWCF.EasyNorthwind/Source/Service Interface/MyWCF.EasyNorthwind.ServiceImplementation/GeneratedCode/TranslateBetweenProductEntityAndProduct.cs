﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using MyWCF.EasyNorthwind.BusinessEntities;
using MyWCF.EasyNorthwind.DataContracts;

namespace MyWCF.EasyNorthwind.ServiceImplementation
{
    public static class TranslateBetweenProductEntityAndProduct
    {
        public static MyWCF.EasyNorthwind.BusinessEntities.ProductEntity TranslateProductToProductEntity(MyWCF.EasyNorthwind.DataContracts.Product from)
        {
            MyWCF.EasyNorthwind.BusinessEntities.ProductEntity to = new MyWCF.EasyNorthwind.BusinessEntities.ProductEntity();
            to.ProductID = from.ProductID;
            to.ProductName = from.ProductName;
            to.QuantityPerUnit = from.QuantityPerUnit;
            to.UnitPrice = from.UnitPrice;
            to.Discontinued = from.Discontinued;
            return to;
        }

        public static MyWCF.EasyNorthwind.DataContracts.Product TranslateProductEntityToProduct(MyWCF.EasyNorthwind.BusinessEntities.ProductEntity from)
        {
            MyWCF.EasyNorthwind.DataContracts.Product to = new MyWCF.EasyNorthwind.DataContracts.Product();
            to.ProductID = from.ProductID;
            to.ProductName = from.ProductName;
            to.QuantityPerUnit = from.QuantityPerUnit;
            to.UnitPrice = from.UnitPrice;
            to.Discontinued = from.Discontinued;
            return to;
        }
    }
}
