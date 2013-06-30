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
    public class RetrieveBasedOnName
    {
        [TestMethod]
        public void Exists_should_return_one()
        {
            var employeeRepository = MockRepository.GenerateStub<IGenericRepository<Employee>>();

            var mockEmployees = new List<Employee> {new Employee {ID = 1, EmployeeCode = 123, Name = "Stephen"}};

            employeeRepository.Stub(x => x.Get())
                              .IgnoreArguments()
                              .Return(mockEmployees);

            IEmployeeManagement employeeManagement = new EmployeeManagement(employeeRepository);

            List<EmployeeExternal> employeeExternalList = employeeManagement.RetrieveByName("Stephen");

            Assert.IsTrue(employeeExternalList[0].Name == "Stephen");
        }

        [TestMethod]
        public void Does_not_exists_should_return_none()
        {
            var employeeRepository = MockRepository.GenerateStub<IGenericRepository<Employee>>();

            var mockEmployees = new List<Employee>();

            employeeRepository.Stub(x => x.Get())
                              .IgnoreArguments()
                              .Return(mockEmployees);

            IEmployeeManagement employeeManagement = new EmployeeManagement(employeeRepository);

            List<EmployeeExternal> employeeExternalList = employeeManagement.RetrieveByName("XXXX");

            Assert.AreEqual(0, employeeExternalList.Count);
        }

        [TestMethod]
        public void Three_exists_should_return_three()
        {
            var employeeRepository = MockRepository.GenerateStub<IGenericRepository<Employee>>();

            var mockEmployees = new List<Employee>
                                    {
                                        new Employee {ID = 1, EmployeeCode = 123, Name = "Fred"},
                                        new Employee {ID = 2, EmployeeCode = 456, Name = "Fred"},
                                        new Employee {ID = 3, EmployeeCode = 789, Name = "Fred"}
                                    };

            employeeRepository.Stub(x => x.Get())
                              .IgnoreArguments()
                              .Return(mockEmployees);

            IEmployeeManagement employeeManagement = new EmployeeManagement(employeeRepository);

            List<EmployeeExternal> employeeExternalList = employeeManagement.RetrieveByName("Fred");

            Assert.AreEqual(3, employeeExternalList.Count);
        }
    }
}
