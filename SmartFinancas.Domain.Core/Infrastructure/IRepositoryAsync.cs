using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartFinancas.Domain.Core.Infrastructure
{
    public interface IRepositoryAsync<T> : IReadOnlyRepositoryAsync<T> where T : BaseEntity
    {
        /// <summary>
        /// Adiciona um único objeto ao banco de dados
        /// </summary>
        /// <remarks>Assincrono</remarks>
        /// <param name="entity">O objeto a ser adicionado</param>
        /// <returns>O objeto resultante com a chave primária após inserção</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Adiciona uma coleção de objetos ao banco de dados
        /// </summary>
        /// <remarks>Assincrono</remarks>
        /// <param name="entities">Um lista do tipo IEnumerable de objetos a serem adicionados</param>
        /// <returns>A lista do tipo IEnumerable de objetos inseridos com a chave primária após inserção</returns>
        Task<IEnumerable<T>> AddAllAsync(IEnumerable<T> entities);

        /// <summary>
        /// Atualiza um único objeto
        /// </summary>
        /// <remarks>Assincrono</remarks>
        /// <param name="entity">O objeto a ser atualizado</param>
        /// <returns>O objeto resultante da atualização</returns>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        /// Atualiza um único objeto baseado na chave primária
        /// </summary>
        /// <remarks>Assincrono</remarks>
        /// <param name="entity">O objeto a ser atualizado</param>
        /// <param name="key">A chave primária do objeto a ser atualizado</param>
        /// <returns>O objeto resultante da atualização</returns>
        Task<T> UpdateAsync(T entity, int key);

        /// <summary>
        /// Exclui um objeto do banco de dados
        /// </summary>
        /// <remarks>Assincrono</remarks>
        /// <param name="entity">O objeto a ser excluído</param>
        Task<int> DeleteAsync(T entity);

        /// <summary>
        /// Obtém o total de objetos no banco de dados
        /// </summary>
        /// <remarks>Assincrono</remarks>
        /// <returns>O total de objetos</returns>
        Task<int> CountAsync();
    }
}