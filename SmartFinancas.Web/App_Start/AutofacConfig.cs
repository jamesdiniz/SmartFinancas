using System;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using SmartFinancas.Application;
using SmartFinancas.Domain.Core.Infrastructure;

namespace SmartFinancas.Web
{
    public class AutofacConfig
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();

            // Registra dependências
            RegisterTypes(builder);

            // Configura o resolvedor de dependência do MVC para usar Autofac
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }

        private static void RegisterTypes(ContainerBuilder builder)
        {
            #region Registra todas as controllers para o assembly
            
            builder.RegisterControllers(typeof(MvcApplication).Assembly).InstancePerRequest();
            
            #endregion

            #region Model binder providers
            //builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            //builder.RegisterModelBinderProvider();
            #endregion

            #region Registar dependências da aplicação neste assembly

            //builder.RegisterType<ContaAppService>().AsSelf().InstancePerRequest();
            builder.RegisterType<ContaAppService>().AsSelf().As<IContaAppService>().InstancePerRequest();
            //builder.RegisterType<ContaAppService>().As<IContaAppService>().InstancePerRequest();
            
            #endregion

            #region Registra dependências de outros assemblies via mef
            RegisterDependencies(builder, ".\\bin", "SmartFinancas.*.dll");
            #endregion
        }

        private static void RegisterDependencies(ContainerBuilder builder, string path, string pattern)
        {
            var dirCatalog = new DirectoryCatalog(path, pattern);
            var importDefinition = BuildImportDefinition();

            try
            {
                using (var aggregateCatalog = new AggregateCatalog())
                {
                    aggregateCatalog.Catalogs.Add(dirCatalog);

                    using (var componsitionContainer = new CompositionContainer(aggregateCatalog))
                    {
                        var exports = componsitionContainer.GetExports(importDefinition);
                        var modules = exports.Select(export => export.Value as IDependency).Where(m => m != null);
                        var registrar = new DependencyRegistrar(builder);

                        foreach (var module in modules)
                            module.Initialize(registrar);
                    }
                }
            }
            catch (ReflectionTypeLoadException typeLoadException)
            {
                var sb = new StringBuilder();
                foreach (var ex in typeLoadException.LoaderExceptions)
                    sb.AppendFormat("{0}\n", ex.Message);

                throw new TypeLoadException(builder.ToString(), typeLoadException);
            }
        }

        private static ImportDefinition BuildImportDefinition()
        {
            return new ImportDefinition(def => true, typeof(IDependency).FullName, ImportCardinality.ZeroOrMore, false, false);
        }
    }

    internal class DependencyRegistrar : IDependencyRegistrar
    {
        private readonly ContainerBuilder _builder;

        public DependencyRegistrar(ContainerBuilder builder)
        {
            _builder = builder;
        }

        public void RegisterType<TFrom, TTo>() where TTo : TFrom
        {
            _builder.RegisterType<TTo>().As<TFrom>().InstancePerRequest();
        }
    }
}