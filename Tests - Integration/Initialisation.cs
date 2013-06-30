using System;
using Stephen.Webb.HR.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stephen.Webb.HR.ServiceLocator;

namespace Integration_tests
{
    /// <summary>
    /// Initialise the structuremap and the database
    /// </summary>
    [TestClass]
    public class Initialisation
    {
        [AssemblyInitialize]
        public static void MyTestInitialize(TestContext testContext)
        {
            StructureMapBootstrap.Initialise();

            if (testContext.FullyQualifiedTestClassName.StartsWith("Integration_tests"))
            {
                var delarueSystemContext2 = new DelarueSystemContext();

                delarueSystemContext2.Database.ExecuteSqlCommand("DELETE FROM EMPLOYEES");

                delarueSystemContext2.Employees.Add(new Employee { Name = "DeleteMe", EmployeeCode = 1001, StartDate = Convert.ToDateTime("15/Jul/2010") });

                delarueSystemContext2.Employees.Add(new Employee { Name = "Quad", EmployeeCode = 101, StartDate = Convert.ToDateTime("16/Jul/2012") });
                delarueSystemContext2.Employees.Add(new Employee { Name = "Quad", EmployeeCode = 102, StartDate = Convert.ToDateTime("17/Jul/2012") });
                delarueSystemContext2.Employees.Add(new Employee { Name = "Quad", EmployeeCode = 103, StartDate = Convert.ToDateTime("18/Jul/2012") });
                delarueSystemContext2.Employees.Add(new Employee { Name = "Quad", EmployeeCode = 104, StartDate = Convert.ToDateTime("19/Jul/2012") });

                delarueSystemContext2.Employees.Add(new Employee { Name = "George", EmployeeCode = 10, StartDate = Convert.ToDateTime("12/Feb/2013") });
                delarueSystemContext2.Employees.Add(new Employee { Name = "Twinkle", EmployeeCode = 200, StartDate = Convert.ToDateTime("17/Jan/2013") });

                delarueSystemContext2.SaveChanges();
            }
        }
    }
}
