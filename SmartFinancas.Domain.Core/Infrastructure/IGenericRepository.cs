
namespace SmartFinancas.Domain.Core.Infrastructure
{
    public interface IGenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        
    }
}