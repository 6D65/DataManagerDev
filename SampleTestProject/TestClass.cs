using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestMonkeys.DataManager;
using System.Threading.Tasks;
using Refit;
using ApiClient;
using ApiClient.ApiVersions.v1;

namespace SampleTestProject
{
    [TestClass]
    public class TestClass : BaseTestClass
    {
        [TestMethod]
        public async Task FirstTestMethod()
        {
            Api api = new Api("http://localhost:8000");

            var products = await api.v1.Products.GetAllProducts();

            //Task.WaitAll();
        }

        [TestMethod]
        public async Task ApiClientTest()
        { 
        }
    }
}
