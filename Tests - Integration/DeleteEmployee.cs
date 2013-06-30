using Stephen.Webb.HR.DataTransferObjects;
using Stephen.Webb.HR.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace Integration_tests
{
    [TestClass]
    public class DeleteEmployee
    {
        [TestMethod]
        public void Existing_should_be_deleted()
        {
            var application = ObjectFactory.GetInstance<IHRApplication>();

            EmployeeExternal employeeExternal = application.RetrieveByEmployeeCode(1001);

            application.DeleteEmployee(employeeExternal.ID);

            EmployeeExternal employeeExternalRetrieve = application.RetrieveByEmployeeCode(1001);

            Assert.IsNull(employeeExternalRetrieve);
        }
    }
}
