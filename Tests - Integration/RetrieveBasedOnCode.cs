using Stephen.Webb.HR.DataTransferObjects;
using Stephen.Webb.HR.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace Integration_tests
{
    [TestClass]
    public class RetrieveBasedOnCode
    {
        [TestMethod]
        public void Existing_code_should_return_one()
        {
            var application = ObjectFactory.GetInstance<IHRApplication>();

            EmployeeExternal employeeExternal = application.RetrieveByEmployeeCode(200);

            Assert.AreEqual(200, employeeExternal.EmployeeCode);
        }

        [TestMethod]
        public void Non_existing_code_should_return_none()
        {
            var application = ObjectFactory.GetInstance<IHRApplication>();

            EmployeeExternal employeeExternal = application.RetrieveByEmployeeCode(876543);

            Assert.IsNull(employeeExternal);
        }
    }
}
