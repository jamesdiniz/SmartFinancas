using System.Threading.Tasks;

namespace SmartFinancas.Domain.Core.Infrastructure
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Repositório genérico de uma classe derivada <see cref="BaseEntity" />
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IGenericRepository<T> Repository<T>() where T : BaseEntity;
        
        /// <summary>
        /// Persiste todas as mudanças no bando de dados
        /// <remarks>Sincrono</remarks>
        /// </summary>
        int SaveChanges();

        /// <summary>
        /// Persiste todas as mudanças no bando de dados
        /// <remarks>Assincrono</remarks>
        /// </summary>
        Task<int> SaveChangesAsync();
    }
}