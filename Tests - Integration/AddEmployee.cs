using System;
using Stephen.Webb.HR.DataTransferObjects;
using Stephen.Webb.HR.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace Integration_tests
{
    [TestClass]
    public class AddEmployee
    {
        [TestMethod]
        public void Should_insert_new_employee()
        {
            var employee = new EmployeeExternal
            {
                EmployeeCode = 562,
                Name = "Insert 562",
                StartDate = Convert.ToDateTime("18/Jan/2011")
            };

            var application = ObjectFactory.GetInstance<IHRApplication>();

            application.AddEmployee(employee);

            EmployeeExternal employeeRetrieved = application.RetrieveByEmployeeCode(562);

            Assert.IsNotNull(employeeRetrieved);

            Assert.AreEqual("Insert 562", employeeRetrieved.Name);
        }
    }
}
