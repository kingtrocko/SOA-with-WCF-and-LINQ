
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using WCF = global::System.ServiceModel;

namespace MyWCF.EasyNorthwind.MessageContracts
{
	/// <summary>
	/// Service Contract Class - GetProductReponse
	/// </summary>
	[WCF::MessageContract(IsWrapped = false)] 
	public partial class GetProductReponse
	{
		private MyWCF.EasyNorthwind.DataContracts.Product product;
	 		
		[WCF::MessageBodyMember(Namespace = "http://EasyNorthwind.Model/2014/ProductService", Name = "Product")]
		public MyWCF.EasyNorthwind.DataContracts.Product Product
		{
			get { return product; }
			set { product = value; }
		}
	}
}
