using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Stephen.Webb.HR.DataAccess;
using Stephen.Webb.HR.Domain;
using Stephen.Webb.HR.Repository;

namespace Unit_tests
{
    [TestClass]
    public class DeleteEmployee
    {
        [TestMethod]
        public void Existing_should_be_deleted()
        {
            var employeeRepository = MockRepository.GenerateStub<IGenericRepository<Employee>>();

            IEmployeeManagement employeeManagement = new EmployeeManagement(employeeRepository);

            employeeManagement.DeleteEmployee(6); 
        }
    }
}
