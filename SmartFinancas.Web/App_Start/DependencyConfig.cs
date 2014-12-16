using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace SmartFinancas.Web
{
    public class DependencyConfig
    {
        private static IContainer _container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            #region Registra todas as controllers deste assembly

            builder.RegisterControllers(typeof(MvcApplication).Assembly).InstancePerRequest();

            #endregion

            #region Registra módulos da aplicação em composite root

            builder.RegisterAssemblyModules(Assembly.Load("SmartFinancas.Web.Framework"));

            #endregion

            // Container contendo componentes registrados
            _container = builder.Build();

            // Configura o resolvedor de dependência do MVC para usar Autofac
            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));
        }
    }
}