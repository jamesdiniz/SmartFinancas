
namespace SmartFinancas.Domain.Core.Infrastructure
{
    public interface IDependencyRegistrar
    {
        void RegisterType<TFrom, TTo>() where TTo : TFrom;
    }
}
