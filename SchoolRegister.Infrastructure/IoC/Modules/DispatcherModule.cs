using System.Reflection;
using Autofac;
using SchoolRegister.Infrastructure.Dispatchers;

namespace SchoolRegister.Infrastructure.IoC.Modules
{
    public class DispatcherModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Dispatcher>()
                .As<IDispatcher>()
                .InstancePerLifetimeScope();
        }
    }
}