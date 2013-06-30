using System;
using System.Collections.Generic;
using Stephen.Webb.HR.Application;
using Stephen.Webb.HR.DataTransferObjects;
using Stephen.Webb.HR.ServiceLocator;
using StructureMap;

namespace Stephen.Webb.HR.WCF
{
    public class WCF_HR_Administration : IWCF_HR_Administration
    {
        public WCF_HR_Administration()
        {
            StructureMapBootstrap.Initialise();
        }

        public EmployeeExternal RetrieveByEmployeeCode(int employeeCode)
        {
            var application = ObjectFactory.GetInstance<IHRApplication>();

            return application.RetrieveByEmployeeCode(200);
        }

        public void AddEmployee(EmployeeExternal employeeExternal)
        {
            var application = ObjectFactory.GetInstance<IHRApplication>();

            application.AddEmployee(employeeExternal);
        }

        public List<EmployeeExternal> GetEmployees()
        {
            var application = ObjectFactory.GetInstance<IHRApplication>();

            return application.GetEmployees();
        }

        public List<EmployeeExternal> RetrieveByName(string firstName)
        {
            var application = ObjectFactory.GetInstance<IHRApplication>();

            return application.RetrieveByName(firstName);
        }

        public List<EmployeeExternal> RetrieveAfterStartDate(DateTime startDate)
        {
            var application = ObjectFactory.GetInstance<IHRApplication>();

            return application.RetrieveAfterStartDate(startDate);
        }

        public void DeleteEmployee(int employeeCode)
        {
            var application = ObjectFactory.GetInstance<IHRApplication>();

            application.DeleteEmployee(employeeCode);
        }
    }
}
