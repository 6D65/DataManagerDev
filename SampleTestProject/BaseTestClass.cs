using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMonkeys.DataManager;

namespace SampleTestProject
{
    [TestClass]
    public class BaseTestClass
    {
        public DataManagerClient _dm;

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
