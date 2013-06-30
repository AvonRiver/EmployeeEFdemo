﻿using System;
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
    public class RetrieveBasedOnStartDate
    {
        [TestMethod]
        public void Should_return_two()
        {
            var employeeRepository = MockRepository.GenerateStub<IGenericRepository<Employee>>();

            var mockEmployees = new List<Employee>
                                    {
                                        new Employee
                                            {
                                                ID = 2,
                                                EmployeeCode = 456,
                                                Name = "Jill",
                                                StartDate = Convert.ToDateTime("18/Dec/2011")
                                            },
                                        new Employee
                                            {
                                                ID = 3,
                                                EmployeeCode = 789,
                                                Name = "Sue",
                                                StartDate = Convert.ToDateTime("24/Dec/2011")
                                            }
                                    };

            employeeRepository.Stub(x => x.Get())
                              .IgnoreArguments()
                              .Return(mockEmployees);

            IEmployeeManagement employeeManagement = new EmployeeManagement(employeeRepository);

            List<EmployeeExternal> employeeExternalList = employeeManagement.RetrieveAfterStartDate(Convert.ToDateTime("18/Dec/2011"));

            Assert.AreEqual(2, employeeExternalList.Count);
        }

        [TestMethod]
        public void None_after_date_should_return_zero()
        {
            var employeeRepository = MockRepository.GenerateStub<IGenericRepository<Employee>>();

            var mockEmployees = new List<Employee>();

            employeeRepository.Stub(x => x.Get())
                              .IgnoreArguments()
                              .Return(mockEmployees);

            IEmployeeManagement employeeManagement = new EmployeeManagement(employeeRepository);

            List<EmployeeExternal> employeeExternalList = employeeManagement.RetrieveAfterStartDate(Convert.ToDateTime("18/Dec/2020"));

            Assert.AreEqual(0, employeeExternalList.Count);
        }
    }
}
