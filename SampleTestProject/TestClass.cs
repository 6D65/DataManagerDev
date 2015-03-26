using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestMonkeys.DataManager;
using System.Threading.Tasks;
using ApiClient;
using System.Runtime.CompilerServices;


namespace SampleTestProject
{
    [TestClass]
    public class TestClass : BaseTestClass
    {
        [TestMethod]
        public async Task FirstTestMethod()
        {
            var products = await TestApi.v1.Products.GetAllProducts();

            Assert.AreEqual(20, products.Count, "The Get Products command should return 20 items.");
            //Task.WaitAll();
        }

        //[TestMethod, ExpectedException(typeof(Refit.ApiException))]
        [TestMethod]
        public async Task ApiClientTest()
        {
            var companies = await TestApi.v1.Companies.GetCompany(1);
        }
    }
}