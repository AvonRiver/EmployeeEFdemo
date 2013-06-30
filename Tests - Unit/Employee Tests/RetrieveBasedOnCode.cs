using System.Collections.Generic;
using Stephen.Webb.HR.DataTransferObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Stephen.Webb.HR.DataAccess;
using Stephen.Webb.HR.Domain;
using Stephen.Webb.HR.Repository;

namespace Unit_tests
{
    [TestClass]
    public class RetrieveBasedOnCode
    {
        [TestMethod]
        public void Should_return_one()
        {
            var employeeRepository = MockRepository.GenerateStub<IGenericRepository<Employee>>();

            var mockEmployees = new List<Employee> {new Employee {ID = 1, EmployeeCode = 123}};

            employeeRepository.Stub(x => x.Get())
                              .IgnoreArguments()
                              .Return(mockEmployees);

            IEmployeeManagement employeeManagement = new EmployeeManagement(employeeRepository);

            EmployeeExternal employeeExternal = employeeManagement.RetrieveByEmployeeCode(123);

            Assert.AreEqual(123, employeeExternal.EmployeeCode);
        }

        [TestMethod]
        public void Should_return_none()
        {
            var employeeRepository = MockRepository.GenerateStub<IGenericRepository<Employee>>();

            var mockEmployees = new List<Employee>();

            employeeRepository.Stub(x => x.Get())
                              .IgnoreArguments()
                              .Return(mockEmployees);

            IEmployeeManagement employeeManagement = new EmployeeManagement(employeeRepository);

            EmployeeExternal employeeExternal = employeeManagement.RetrieveByEmployeeCode(888);

            Assert.IsNull(employeeExternal);
        }
    }
}
