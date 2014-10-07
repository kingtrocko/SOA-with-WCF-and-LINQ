using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthwindClient.ProductServiceRef;
using System.ServiceModel;

namespace NorthwindClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductServiceClient client = new ProductServiceClient();

            Product product = client.GetProduct(23);
            Console.WriteLine("product name is " +product.ProductName);
            Console.WriteLine("product price is " +product.UnitPrice.ToString());
            product.UnitPrice = (decimal)20.0;
            bool result = client.UpdateProduct(product); 
            Console.WriteLine("Update result is " + result.ToString());
            TestException(client, 0); // channel is still open after a FaultException
            TestException(client, 999); // channel is Faulted after a non handled fault exception
            Console.WriteLine("\n\nTest Faulted client ...");
            product = client.GetProduct(20); // can't use a client with a Faulted channel
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }

        static void TestException(ProductServiceClient client, int id)
        {
            Console.WriteLine("\n\nTest {0} Fault Exception for product {1}...", (id != 999) ? "handled" : "unhandled", id);
            try
            {
                Product product = client.GetProduct(id);
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine("The service operation timed out. " +ex.Message);
            }
            catch (FaultException<ProductFault> ex)
            {
                Console.WriteLine("ProductFault: " + ex.ToString());
            }
            catch (FaultException ex)
            {
                Console.WriteLine("Unknown Fault: " + ex.ToString());
            }
            catch (CommunicationException ex)
            {
                Console.WriteLine("There was a communication problem. " + ex.Message + ex.StackTrace);
            }
            Console.WriteLine("\n\nChannel Status after the exception: " + client.InnerChannel.State.ToString());
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }
    }
}
