
namespace SmartFinancas.Domain.Core.Infrastructure
{
    public interface IEntityKey<out TKey>
    {
        /// <summary>
        /// Identificador da entidade
        /// </summary>
        TKey Id { get; }
    }
}
