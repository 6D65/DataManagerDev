using ApiSchema.v1;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSampleService.v1
{
    public class ProductsApi : NancyModule
    {
        public ProductsApi() : this("/api/v1") { }

        public ProductsApi(string apiVersion)
            : base(apiVersion)
        {
            Get["/products/{productId}"] = parameters => 
            {
                return Response.AsJson(new Product { Id = parameters.productId, Name = "ProductName", PublishedDate = DateTime.Now });
            };

            Get["/products"] = parameters => 
            {
                List<Product> products = new List<Product>();
                for (int i = 0; i < 20; i++ )
                {
                    var p = new Product { Id = i, PublishedDate = DateTime.Now, Name = "ProductName" };
                    products.Add(p);
                }

                return Response.AsJson(products);
            };
        }
    }
}
