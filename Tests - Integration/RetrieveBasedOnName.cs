using System.Collections.Generic;
using Stephen.Webb.HR.DataTransferObjects;
using Stephen.Webb.HR.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace Integration_tests
{
    [TestClass]
    public class RetrieveBasedOnName
    {
        [TestMethod]
        public void Existing_name_should_return_one()
        {
            var application = ObjectFactory.GetInstance<IHRApplication>();

            List<EmployeeExternal> employeeExternalList = application.RetrieveByName("George");

            Assert.AreEqual("George", employeeExternalList[0].Name);
        }

        [TestMethod]
        public void Non_existing_name_should_return_none()
        {
            var application = ObjectFactory.GetInstance<IHRApplication>();

            List<EmployeeExternal> employeeExternalList = application.RetrieveByName("UNKNOWN");

            Assert.AreEqual(0, employeeExternalList.Count);
        }

        [TestMethod]
        public void Four_identical_names_should_return_four()
        {
            var application = ObjectFactory.GetInstance<IHRApplication>();

            List<EmployeeExternal> employeeExternalList = application.RetrieveByName("Quad");

            Assert.AreEqual(4, employeeExternalList.Count);
        }
    }
}
