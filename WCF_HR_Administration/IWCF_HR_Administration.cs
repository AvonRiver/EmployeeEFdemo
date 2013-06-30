using System;
using System.Collections.Generic;
using System.ServiceModel;
using Stephen.Webb.HR.DataTransferObjects;

namespace Stephen.Webb.HR.WCF
{
    [ServiceContract]
    public interface IWCF_HR_Administration
    {
        [OperationContract]
        EmployeeExternal RetrieveByEmployeeCode(int employeeCode);

        [OperationContract]
        void AddEmployee(EmployeeExternal employeeExternal);

        [OperationContract]
        List<EmployeeExternal> GetEmployees();

        [OperationContract]
        List<EmployeeExternal> RetrieveByName(string firstName);

        [OperationContract]
        List<EmployeeExternal> RetrieveAfterStartDate(DateTime startDate);

        [OperationContract]
        void DeleteEmployee(int employeeID);
    }
}
