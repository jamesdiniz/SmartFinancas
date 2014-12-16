using Autofac;
using SmartFinancas.Domain.Core.Infrastructure;
using SmartFinancas.Infrastructure.Data.EntityFramework;

namespace SmartFinancas.Web.Framework
{
    public class DependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //data layer
            builder.Register<IDbContext>(c => new SmartDbContext("name=SmartDbContext")).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            //service layer
            
            //application layer
            
            base.Load(builder);
        }
    }
}