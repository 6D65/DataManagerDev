using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestMonkeys.DataManager;
using System.Threading.Tasks;

namespace SampleTestProject
{
    [TestClass]
    public class TestClass
    {
        #region Fields
        DataManagerClient _dm;
        #endregion Fields

        [TestMethod]
        public void FirstTestMethod()
        {
            //_dm.Documents
        }

        [TestInitialize]
        public void Initialize()
        {
            _dm = new DataManagerClient();
        }
    }
}
