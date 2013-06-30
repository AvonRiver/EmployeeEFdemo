using System;
using Stephen.Webb.HR.DataTransferObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Stephen.Webb.HR.DataAccess;
using Stephen.Webb.HR.Domain;
using Stephen.Webb.HR.Repository;

namespace Unit_tests
{
    [TestClass]
    public class AddEmployee
    {
        [TestMethod]
        public void Should_insert()
        {
            var employeeRepository = MockRepository.GenerateStub<IGenericRepository<Employee>>();

            var employee = new EmployeeExternal
            {
                ID = 6,
                EmployeeCode = 562,
                Name = "TEST",
                StartDate = Convert.ToDateTime("18/Jan/2009")
            };

            IEmployeeManagement employeeManagement = new EmployeeManagement(employeeRepository);

            employeeManagement.AddEmployee(employee);
        }
    }
}
