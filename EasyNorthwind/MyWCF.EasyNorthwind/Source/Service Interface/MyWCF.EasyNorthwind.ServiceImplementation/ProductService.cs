using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyWCF.EasyNorthwind.BusinessEntities;
using MyWCF.EasyNorthwind.DataContracts;
using MyWCF.EasyNorthwind.MessageContracts;
using MyWCF.EasyNorthwind.BusinessLogic;
using MyWCF.EasyNorthwind.FaultContracts;
using System.ServiceModel;

namespace MyWCF.EasyNorthwind.ServiceImplementation
{
    public partial class ProductService
    {
        ProductLogic productLogic = new ProductLogic();
        public override GetProductReponse GetProduct(GetProductRequest request)
        {
            // call business entity layer to retrieve a product
            ProductEntity productEntity =
            productLogic.GetProduct(request.ProductID);
            // throw a Fault if no product found
            if (productEntity == null)
                throw new FaultException<ProductFault>(new ProductFault("No product found with id " + request.ProductID), "Product Fault");
            // translate it to a Product Data Contract object
            Product product;
            product = TranslateBetweenProductEntityAndProduct.
            TranslateProductEntityToProduct(productEntity);
            // create a response message
            GetProductReponse response = new GetProductReponse();
            response.Product = product;
            // return the response message
            return response;
        }

    }
}
