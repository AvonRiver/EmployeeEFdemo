using Stephen.Webb.HR.Application;
using Stephen.Webb.HR.DataAccess;
using Stephen.Webb.HR.Domain;
using Stephen.Webb.HR.EventLogger;
using Stephen.Webb.HR.Repository;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Stephen.Webb.HR.ServiceLocator
{
    public static class StructureMapBootstrap
    {
        public static void Initialise()
        {
            ObjectFactory.Initialize(x => x.AddRegistry(new ApplicationRegistry()));
        }
    }

    public class ApplicationRegistry : Registry
    {
        public ApplicationRegistry()
        {
            For<IHRApplication>().Use<HRApplication>();
            For<IEmployeeManagement>().Use<EmployeeManagement>();
            For<DelarueSystemContext>().Use<DelarueSystemContext>();
            For<IEventLogger>().Use<EventLogger.EventLogger>();
            For<IGenericRepository<Employee>>().Use<GenericRepository<Employee>>();
        }
    }
}
