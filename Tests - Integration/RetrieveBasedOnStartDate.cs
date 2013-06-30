using System;
using System.Collections.Generic;
using Stephen.Webb.HR.DataTransferObjects;
using Stephen.Webb.HR.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace Integration_tests
{
    [TestClass]
    public class RetrieveBasedOnStartDate
    {
        [TestMethod]
        public void Three_records_with_greater_date_should_return_three()
        {
            var application = ObjectFactory.GetInstance<IHRApplication>();

            List<EmployeeExternal> employeeExternalList = application.RetrieveAfterStartDate(Convert.ToDateTime("18/Jul/2012"));

            Assert.AreEqual(3, employeeExternalList.Count);
        }
    }
}
