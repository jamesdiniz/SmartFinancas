using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartFinancas.Domain.Core;
using SmartFinancas.Domain.Core.Infrastructure;

namespace SmartFinancas.Infrastructure.Data.EntityFramework.Repositories
{
    /// <summary>
    /// Implementa a interface generica IGenericRepository
    /// </summary>
    /// <typeparam name="T">Uma classe derivada da classe <see cref="BaseEntity" /></typeparam>
    
    public class GenericRepository<T> : IGenericRepository<T> 
        where T : BaseEntity
    {
        #region Fields

        private readonly IDbContext _context;
        private DbSet<T> _entities;
        
        #endregion

        #region Constructors

        public GenericRepository(IDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>() as DbSet<T>;
        }

        #endregion

        #region IGenericRepository<T> Members

        #region Read Methods

        /// <summary>
        /// Retorna um único objeto com uma chave primária do id especificado
        /// </summary>
        /// <remarks>Sincrono</remarks>
        /// <param name="id">A chave primária do objeto para buscar</param>
        /// <returns>Um único objeto com a chave primária especificado ou nulo</returns>
        public T Get(int id)
        {
            return Entities.Find(id);
        }

        /// <summary>
        /// Retorna um único objeto com uma chave primária do id especificado
        /// </summary>
        /// <remarks>Assincrono</remarks>
        /// <param name="id">A chave primária do objeto para buscar</param>
        /// <returns>Um único objeto com a chave primária especificado ou nulo</returns>
        public async Task<T> GetAsync(int id)
        {
            return await Entities.FindAsync(id);
        }

        /// <summary>
        /// Obtem uma coleção de todos os objetos no banco de dados
        /// </summary>
        /// <remarks>Sincrono</remarks>
        /// <returns>Um ICollection de cada objeto no banco de dados</returns>
        public ICollection<T> GetAll()
        {
            return Entities.ToList();
        }

        /// <summary>
        /// Obtem uma coleção de todos os objetos no banco de dados
        /// </summary>
        /// <remarks>Assincrono</remarks>
        /// <returns>Um ICollection de cada objeto no banco de dados</returns>
        public async Task<ICollection<T>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        /// <summary>
        /// Retorna um único objeto que corresponda a expressão fornecida
        /// </summary>
        /// <remarks>Sincrono</remarks>
        /// <param name="match">Filtro de expressão Linq para encontrar um único resultado</param>
        /// <returns>Um único objeto que corresponda ao filtro de expressão</returns>
        public T Find(Expression<Func<T, bool>> match)
        {
            return Entities.SingleOrDefault(match);
        }

        /// <summary>
        /// Retorna um único objeto que corresponda a expressão fornecida
        /// </summary>
        /// <remarks>Assincrono</remarks>
        /// <param name="match">Filtro de expressão Linq para encontrar um único resultado</param>
        /// <returns>Um único objeto que corresponda ao filtro de expressão</returns>
        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await Entities.SingleOrDefaultAsync(match);
        }

        /// <summary>
        /// Retorna uma coleção de objetos que corresponda a expressão fornecida
        /// </summary>
        /// <remarks>Sincrono</remarks>
        /// <param name="match">Filtro de expressão Linq para encontrar um ou mais resultados</param>
        /// <returns>Um ICollection que corresponda ao filtro de expressão</returns>
        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return Entities.Where(match).ToList();
        }

        /// <summary>
        /// Retorna uma coleção de objetos que corresponda a expressão fornecida
        /// </summary>
        /// <remarks>Assincrono</remarks>
        /// <param name="match">Filtro de expressão Linq para encontrar um ou mais resultados</param>
        /// <returns>Um ICollection que corresponda ao filtro de expressão</returns>
        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await Entities.Where(match).ToListAsync();
        }

        /// <summary>
        /// Verifica se existe algum objeto
        /// </summary>
        /// <remarks>Sincrono</remarks>
        /// <returns>Se existe algum objeto</returns>
        public bool Any()
        {
            return Entities.Any();
        }

        /// <summary>
        /// Verifica se existe algum objeto
        /// </summary>
        /// <remarks>Assincrono</remarks>
        /// <returns>Se existe algum objeto</returns>
        public async Task<bool> AnyAsync()
        {
            return await Entities.AnyAsync();
        }

        /// <summary>
        /// Verifica se existe algum objeto que corresponda a expressão fornecida 
        /// </summary>
        /// <remarks>Sincrono</remarks>
        /// <param name="predicate">Filtro de expressão Linq</param>
        /// <returns>Se existe algum objeto</returns>
        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return Entities.Any(predicate);
        }
        
        /// <summary>
        /// Verifica se existe algum objeto que corresponda a expressão fornecida 
        /// </summary>
        /// <remarks>Assincrono</remarks>
        /// <param name="predicate">Filtro de expressão Linq</param>
        /// <returns>Se existe algum objeto</returns>
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await Entities.AnyAsync(predicate);
        }

        #endregion

        #region Write Methods

        /// <summary>
        /// Adiciona um único objeto ao banco de dados
        /// </summary>
        /// <param name="entity">O objeto a ser adicionado</param>
        public void Add(T entity)
        {
            Entities.Add(entity);
        }

        /// <summary>
        /// Adiciona uma coleção de objetos ao banco de dados
        /// </summary>
        /// <param name="entities">Um lista do tipo IEnumerable de objetos a serem adicionados</param>
        public void AddAll(IEnumerable<T> entities)
        {
            if (entities == null) return;
            
            var addAll = entities as IList<T> ?? entities.ToList();
            Entities.AddRange(addAll);
        }

        /// <summary>
        /// Atualiza um único objeto
        /// </summary>
        /// <param name="entity">O objeto a ser atualizado</param>
        public void Update(T entity)
        {
            if (entity == null)
                return;

            _context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Atualiza um único objeto baseado na chave primária
        /// </summary>
        /// <param name="entity">O objeto a ser atualizado</param>
        /// <param name="key">A chave primária do objeto a ser atualizado</param>
        public void Update(T entity, int key)
        {
            if (entity == null)
                return;

            var existing = Get(key);
            if (existing == null)
                return;

            _context.Entry(existing).CurrentValues.SetValues(entity);
        }

        /// <summary>
        /// Exclui um objeto do banco de dados
        /// </summary>
        /// <param name="entity">O objeto a ser excluído</param>
        public void Delete(T entity)
        {
            Entities.Remove(entity);
            _context.SaveChanges();
        }

        #endregion

        #region Utilities Methods

        /// <summary>
        /// Obtém o total de objetos no banco de dados
        /// </summary>
        /// <remarks>Sincrono</remarks>
        /// <returns>O total de objetos</returns>
        public int Count()
        {
            return Entities.Count();
        }

        /// <summary>
        /// Obtém o total de objetos no banco de dados
        /// </summary>
        /// <remarks>Assincrono</remarks>
        /// <returns>O total de objetos</returns>
        public async Task<int> CountAsync()
        {
            return await Entities.CountAsync();
        }

        #endregion

        #endregion

        #region Private Methods

        /// <summary>
        /// Objeto do contexto do tipo T
        /// </summary>
        private DbSet<T> Entities
        {
            get { return _entities ?? (_entities = _context.Set<T>() as DbSet<T>); }
        } 
        
        #endregion
    }
}