﻿using ApiSchema.v1;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient.ApiVersions.v1
{
    public interface IProductsApi
    {
        [Get("/api/v1/products/{productId}")]
        Task<Product> GetProduct(int productId);

        [Get("/api/v1/products")]
        Task<List<Product>> GetAllProducts();
    }
}
