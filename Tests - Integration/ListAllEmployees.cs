using System.Collections.Generic;
using Stephen.Webb.HR.DataTransferObjects;
using Stephen.Webb.HR.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace Integration_tests
{
    [TestClass]
    public class ListAllEmployees
    {
        [TestMethod]
        public void Should_return_at_least_five()
        {
            var application = ObjectFactory.GetInstance<IHRApplication>();

            List<EmployeeExternal> employeeExternalList = application.GetEmployees();

            Assert.IsTrue(employeeExternalList.Count >= 5);
        }
    }
}
