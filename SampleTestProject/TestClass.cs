using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestMonkeys.DataManager;
using System.Threading.Tasks;
using Refit;
using ApiClient.v1;

namespace SampleTestProject
{
    [TestClass]
    public class TestClass : BaseTestClass
    {
        [TestMethod]
        public async Task FirstTestMethod()
        {
            var mockApi = RestService.For<IMockApi>("http://localhost:8000");

            var product = await mockApi.GetAllProducts();

            Task.WaitAll();
        }
    }
}
