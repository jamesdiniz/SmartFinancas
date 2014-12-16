
namespace SmartFinancas.Domain.Core.Infrastructure
{
    public interface IGenericRepository<T> : IRepository<T>, IRepositoryAsync<T> 
        where T : BaseEntity
    {
        
    }
}