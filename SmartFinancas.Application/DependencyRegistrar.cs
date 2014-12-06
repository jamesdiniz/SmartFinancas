using System.ComponentModel.Composition;
using SmartFinancas.Domain.Core.Infrastructure;

namespace SmartFinancas.Application
{
    [Export(typeof(IDependency))]
    public class DependencyRegistrar : IDependency
    {
        public void Initialize(IDependencyRegistrar registrar)
        {
            //registrar.RegisterType<TFrom, TTo>();
        }
    }
}