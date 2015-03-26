using ApiClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestMonkeys.DataManager;

namespace SampleTestProject
{
    [TestClass]
    public class BaseTestClass
    {
        public DataManagerClient _dm;

        public Api TestApi { get { return new Api("http://localhost:8000"); } }

        [TestInitialize]
        public void Initialize()
        {
            Debug.WriteLine("Initializing");
            _dm = new DataManagerClient();
            //DataManagerClient.Instance();
        }

        [TestCleanup]
        public void Cleanup()
        {
            Debug.WriteLine("Cleaning up.");
        }
    }
}
