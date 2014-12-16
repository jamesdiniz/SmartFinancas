using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using SmartFinancas.Domain.Core;

namespace SmartFinancas.Infrastructure.Data.EntityFramework
{
    public interface IDbContext
    {
        IDbSet<T> Set<T>() where T : BaseEntity;
        int SaveChanges();
        Task<int> SaveChangesAsync();
        DbEntityEntry Entry(object entity);
        void Dispose();
    }
}