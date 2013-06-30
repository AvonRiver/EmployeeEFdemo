using System;
using System.Collections.Generic;
using Stephen.Webb.HR.DataAccess;
using Stephen.Webb.HR.DataTransferObjects;
using Stephen.Webb.HR.Domain;
using Stephen.Webb.HR.EventLogger;

namespace Stephen.Webb.HR.Application
{
    public interface IHRApplication
    {
        void AddEmployee(EmployeeExternal employeeExternal);
        List<EmployeeExternal> GetEmployees();
        EmployeeExternal RetrieveByEmployeeCode(int employeeCode);
        List<EmployeeExternal> RetrieveByName(string firstName);
        List<EmployeeExternal> RetrieveAfterStartDate(DateTime startDate);
        void DeleteEmployee(int employeeID);
    }

    /// <summary>
    /// This is the application layer.
    /// In a more complex application it represents Unit of Work items, wheer more than one
    /// domain object would be co-ordinated.
    /// 
    /// Could implement Aspect Oriented Programming (AOP) for cross cutting concerns such as security, retries and logging
    /// </summary>
    public class HRApplication : IHRApplication
    {
        private readonly IEmployeeManagement employeeManagement;
        private readonly DelarueSystemContext delarueSystemContext;
        private readonly IEventLogger eventLogger;

        public HRApplication(IEmployeeManagement employeeManagement, DelarueSystemContext delarueSystemContext, IEventLogger eventLogger)
        {
            this.employeeManagement = employeeManagement;
            this.delarueSystemContext = delarueSystemContext;
            this.eventLogger = eventLogger;
        }

        public void AddEmployee(EmployeeExternal employeeExternal)
        {
            try
            {
                employeeManagement.AddEmployee(employeeExternal);

                delarueSystemContext.SaveChanges();
            }
            catch (Exception ex)
            {
                eventLogger.LogException(ex);
            }
        }

        public List<EmployeeExternal> GetEmployees()
        {
            var employees = new List<EmployeeExternal>();
            try
            {
                employees = employeeManagement.GetEmployees();
            }
            catch (Exception ex)
            {
                eventLogger.LogException(ex);
            }

            return employees;
        }

        public EmployeeExternal RetrieveByEmployeeCode(int employeeCode)
        {
            EmployeeExternal employeeExternal = null;
            try
            {
                employeeExternal = employeeManagement.RetrieveByEmployeeCode(employeeCode);
            }
            catch (Exception ex)
            {
                eventLogger.LogException(ex);
            }

            return employeeExternal;
        }

        public List<EmployeeExternal> RetrieveByName(string firstName)
        {
            var employees = new List<EmployeeExternal>();

            try
            {
                employees = employeeManagement.RetrieveByName(firstName);
            }
            catch (Exception ex)
            {
                eventLogger.LogException(ex);
            }

            return employees;
        }

        public List<EmployeeExternal> RetrieveAfterStartDate(DateTime startDate)
        {
            var employees = new List<EmployeeExternal>();

            try
            {
                employees = employeeManagement.RetrieveAfterStartDate(startDate);
            }
            catch (Exception ex)
            {
                eventLogger.LogException(ex);
            }

            return employees;
        }

        public void DeleteEmployee(int employeeID)
        {
            try
            {
                employeeManagement.DeleteEmployee(employeeID);

                delarueSystemContext.SaveChanges();
            }
            catch (Exception ex)
            {
                eventLogger.LogException(ex);
            }
        }
    }
}
