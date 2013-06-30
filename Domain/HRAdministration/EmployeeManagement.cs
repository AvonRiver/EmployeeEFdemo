using System;
using System.Collections.Generic;
using System.Linq;
using Stephen.Webb.HR.DataTransferObjects;
using Stephen.Webb.HR.DataAccess;
using Stephen.Webb.HR.Repository;

namespace Stephen.Webb.HR.Domain
{
    public interface IEmployeeManagement
    {
        void AddEmployee(EmployeeExternal employeeExternal);
        List<EmployeeExternal> GetEmployees();
        EmployeeExternal RetrieveByEmployeeCode(int employeeCode);
        List<EmployeeExternal> RetrieveByName(string firstName);
        List<EmployeeExternal> RetrieveAfterStartDate(DateTime startDate);
        void DeleteEmployee(int employeeID);
    }

    /// <summary>
    /// Provides functionality for the management of employees
    /// </summary>
    public class EmployeeManagement : IEmployeeManagement
    {
        readonly IGenericRepository<Employee> employeeRepository;

        public EmployeeManagement(IGenericRepository<Employee> employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        /// <summary>
        /// 1.	Get a list of all employees in the database
        /// </summary>
        /// <returns></returns>
        public List<EmployeeExternal> GetEmployees()
        {
            var employees = employeeRepository.Get();

            var employeeExternals = from employee in employees
                                    select new EmployeeExternal
                                    {
                                        ID = employee.ID,
                                        EmployeeCode = employee.EmployeeCode,
                                        Name = employee.Name,
                                        StartDate = employee.StartDate
                                    };

            return employeeExternals.ToList();
        }

        /// <summary>
        /// 2.	Retrieve a single employee based on Name
        /// </summary>
        /// <param name="firstName"></param>
        /// <returns></returns>
        public List<EmployeeExternal> RetrieveByName(string firstName)
        {
            var employees = employeeRepository.Get(d => d.Name == firstName);

            var employeeExternals = from employee in employees
                                    select new EmployeeExternal
                                    {
                                        ID = employee.ID,
                                        EmployeeCode = employee.EmployeeCode,
                                        Name = employee.Name,
                                        StartDate = employee.StartDate
                                    };

            return employeeExternals.ToList();
        }

        /// <summary>
        /// 3. Retrieve a single employee based on EmployeeCode
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns></returns>
        public EmployeeExternal RetrieveByEmployeeCode(int employeeCode)
        {
            EmployeeExternal employeeExternal = null;

            Employee employee = employeeRepository.Get(d => d.EmployeeCode == employeeCode).SingleOrDefault();

            if(employee != null)
            {
                employeeExternal = new EmployeeExternal
                {
                    ID = employee.ID,
                    EmployeeCode = employee.EmployeeCode,
                    Name = employee.Name,
                    StartDate = employee.StartDate
                };
            }

            return employeeExternal;
        }

        /// <summary>
        /// 4.	Retrieve all employees that started AFTER a certain date.
        /// Note: if passed in date is 18th December 2012, then only return Emploees starting on 19th and later.
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns></returns>
        public List<EmployeeExternal> RetrieveAfterStartDate(DateTime startDate)
        {
            var employees = employeeRepository.Get(d => d.StartDate > startDate);

            var employeeExternals = from employee in employees
                              select new EmployeeExternal
                              {
                                  ID = employee.ID,
                                  EmployeeCode = employee.EmployeeCode,
                                  Name = employee.Name,
                                  StartDate = employee.StartDate
                              };

            return employeeExternals.ToList();
        }

        /// <summary>
        /// 5.	Add a new employee
        /// </summary>
        /// <param name="employeeExternal"></param>
        public void AddEmployee(EmployeeExternal employeeExternal)
        {
            var employee = new Employee
            {
                EmployeeCode = employeeExternal.EmployeeCode,
                Name = employeeExternal.Name,
                StartDate = employeeExternal.StartDate
            };

            employeeRepository.Insert(employee); 
        }

        /// <summary>
        /// 6.	Delete an employee.
        /// </summary>
        /// <param name="employeeID"></param>
        public void DeleteEmployee(int employeeID)
        {
            employeeRepository.Delete(employeeID); 
        }
    }
}
