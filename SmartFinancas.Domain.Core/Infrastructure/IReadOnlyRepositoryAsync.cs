using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartFinancas.Domain.Core.Infrastructure
{
    public interface IReadOnlyRepositoryAsync<T> where T : BaseEntity
    {
        /// <summary>
        /// Retorna um único objeto com uma chave primária do id especificado
        /// </summary>
        /// <remarks>Assincrono</remarks>
        /// <param name="id">A chave primária do objeto para buscar</param>
        /// <returns>Um único objeto com a chave primária especificado ou nulo</returns>
        Task<T> GetAsync(int id);

        /// <summary>
        /// Obtem uma coleção de todos os objetos no banco de dados
        /// </summary>
        /// <remarks>Assincrono</remarks>
        /// <returns>Um ICollection de cada objeto no banco de dados</returns>
        Task<ICollection<T>> GetAllAsync();

        /// <summary>
        /// Retorna um único objeto que corresponda a expressão fornecida
        /// </summary>
        /// <remarks>Assincrono</remarks>
        /// <param name="match">Filtro de expressão Linq para encontrar um único resultado</param>
        /// <returns>Um único objeto que corresponda ao filtro de expressão</returns>
        Task<T> FindAsync(Expression<Func<T, bool>> match);

        /// <summary>
        /// Retorna uma coleção de objetos que corresponda a expressão fornecida
        /// </summary>
        /// <remarks>Assincrono</remarks>
        /// <param name="match">Filtro de expressão Linq para encontrar um ou mais resultados</param>
        /// <returns>Um ICollection que corresponda ao filtro de expressão</returns>
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);

        /// <summary>
        /// Verifica se existe algum objeto
        /// </summary>
        /// <remarks>Assincrono</remarks>
        /// <returns>Se existe algum objeto</returns>
        Task<bool> AnyAsync();

        /// <summary>
        /// Verifica se existe algum objeto que corresponda a expressão fornecida 
        /// </summary>
        /// <remarks>Assincrono</remarks>
        /// <param name="predicate">Filtro de expressão Linq</param>
        /// <returns>Se existe algum objeto</returns>
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Obtém o total de objetos no banco de dados
        /// </summary>
        /// <remarks>Assincrono</remarks>
        /// <returns>O total de objetos</returns>
        Task<int> CountAsync();
    }
}