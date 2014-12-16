using System.Collections.Generic;

namespace SmartFinancas.Domain.Core.Infrastructure
{
    public interface IRepository<T> : IReadOnlyRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Adiciona um único objeto ao banco de dados
        /// </summary>
        /// <remarks>Sincrono</remarks>
        /// <param name="entity">O objeto a ser adicionado</param>
        /// <returns>O objeto resultante com a chave primária após inserção</returns>
        T Add(T entity);

        /// <summary>
        /// Adiciona uma coleção de objetos ao banco de dados
        /// </summary>
        /// <remarks>Sincrono</remarks>
        /// <param name="entities">Um lista do tipo IEnumerable de objetos a serem adicionados</param>
        /// <returns>A lista do tipo IEnumerable de objetos inseridos com a chave primária após inserção</returns>
        IEnumerable<T> AddAll(IEnumerable<T> entities);

        /// <summary>
        /// Atualiza um único objeto
        /// </summary>
        /// <remarks>Sincrono</remarks>
        /// <param name="entity">O objeto a ser atualizado</param>
        /// <returns>O objeto resultante da atualização</returns>
        T Update(T entity);

        /// <summary>
        /// Atualiza um único objeto baseado na chave primária
        /// </summary>
        /// <remarks>Sincrono</remarks>
        /// <param name="entity">O objeto a ser atualizado</param>
        /// <param name="key">A chave primária do objeto a ser atualizado</param>
        /// <returns>O objeto resultante da atualização</returns>
        T Update(T entity, int key);

        /// <summary>
        /// Exclui um objeto do banco de dados
        /// </summary>
        /// <remarks>Sincrono</remarks>
        /// <param name="entity">O objeto a ser excluído</param>
        void Delete(T entity);

        /// <summary>
        /// Obtém o total de objetos no banco de dados
        /// </summary>
        /// <remarks>Sincrono</remarks>
        /// <returns>O total de objetos</returns>
        int Count();
    }
}