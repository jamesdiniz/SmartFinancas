using System.Collections.Generic;

namespace SmartFinancas.Domain.Core.Infrastructure
{
    public interface IRepository<T> : IReadOnlyRepository<T>, IReadOnlyRepositoryAsync<T> where T : BaseEntity
    {
        /// <summary>
        /// Adiciona um único objeto ao banco de dados
        /// </summary>
        /// <param name="entity">O objeto a ser adicionado</param>
        void Add(T entity);

        /// <summary>
        /// Adiciona uma coleção de objetos ao banco de dados
        /// </summary>
        /// <param name="entities">Um lista do tipo IEnumerable de objetos a serem adicionados</param>
        void AddAll(IEnumerable<T> entities);

        /// <summary>
        /// Atualiza um único objeto
        /// </summary>
        /// <param name="entity">O objeto a ser atualizado</param>
        void Update(T entity);

        /// <summary>
        /// Atualiza um único objeto baseado na chave primária
        /// </summary>
        /// <param name="entity">O objeto a ser atualizado</param>
        /// <param name="key">A chave primária do objeto a ser atualizado</param>
        void Update(T entity, int key);

        /// <summary>
        /// Exclui um objeto do banco de dados
        /// </summary>
        /// <param name="entity">O objeto a ser excluído</param>
        void Delete(T entity);
    }
}