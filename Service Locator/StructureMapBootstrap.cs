using Stephen.Webb.HR.Application;
using Stephen.Webb.HR.DataAccess;
using Stephen.Webb.HR.Domain;
using Stephen.Webb.HR.EventLogger;
using Stephen.Webb.HR.Repository;
using StructureMap;

namespace Stephen.Webb.HR.ServiceLocator
{
    public static class StructureMapBootstrap
    {
        public static void Initialise()
        {
            ObjectFactory.Initialize(x =>
            {
                x.ForRequestedType<IHRApplication>()
                    .TheDefault.Is.OfConcreteType<HRApplication>();

                x.ForRequestedType<IEmployeeManagement>()
                    .TheDefault.Is.OfConcreteType<EmployeeManagement>();

                x.ForRequestedType<DelarueSystemContext>()
                    .TheDefault.Is.OfConcreteType<DelarueSystemContext>();

                x.ForRequestedType<IEventLogger>()
                    .TheDefault.Is.OfConcreteType<EventLogger.EventLogger>();
             
                x.ForRequestedType<IGenericRepository<Employee>>()
                    .TheDefault.Is.OfConcreteType<GenericRepository<Employee>>();

            });
        }
    }
}

