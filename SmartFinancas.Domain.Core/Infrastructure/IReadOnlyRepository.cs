using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SmartFinancas.Domain.Core.Infrastructure
{
    public interface IReadOnlyRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Retorna um único objeto com uma chave primária do id especificado
        /// </summary>
        /// <remarks>Sincrono</remarks>
        /// <param name="id">A chave primária do objeto para buscar</param>
        /// <returns>Um único objeto com a chave primária especificado ou nulo</returns>
        T Get(int id);

        /// <summary>
        /// Obtem uma coleção de todos os objetos no banco de dados
        /// </summary>
        /// <remarks>Sincrono</remarks>
        /// <returns>Um ICollection de cada objeto no banco de dados</returns>
        ICollection<T> GetAll();

        /// <summary>
        /// Retorna um único objeto que corresponda a expressão fornecida
        /// </summary>
        /// <remarks>Sincrono</remarks>
        /// <param name="match">Filtro de expressão Linq para encontrar um único resultado</param>
        /// <returns>Um único objeto que corresponda ao filtro de expressão</returns>
        T Find(Expression<Func<T, bool>> match);

        /// <summary>
        /// Retorna uma coleção de objetos que corresponda a expressão fornecida
        /// </summary>
        /// <remarks>Sincrono</remarks>
        /// <param name="match">Filtro de expressão Linq para encontrar um ou mais resultados</param>
        /// <returns>Um ICollection que corresponda ao filtro de expressão</returns>
        ICollection<T> FindAll(Expression<Func<T, bool>> match);

        /// <summary>
        /// Verifica se existe algum objeto
        /// </summary>
        /// <remarks>Sincrono</remarks>
        /// <returns>Se existe algum objeto</returns>
        bool Any();

        /// <summary>
        /// Verifica se existe algum objeto que corresponda a expressão fornecida 
        /// </summary>
        /// <remarks>Sincrono</remarks>
        /// <param name="predicate">Filtro de expressão Linq</param>
        /// <returns>Se existe algum objeto</returns>
        bool Any(Expression<Func<T, bool>> predicate);
    }
}