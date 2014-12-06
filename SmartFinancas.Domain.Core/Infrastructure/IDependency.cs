
namespace SmartFinancas.Domain.Core.Infrastructure
{
    public interface IDependency
    {
        void Initialize(IDependencyRegistrar registrar);
    }
}