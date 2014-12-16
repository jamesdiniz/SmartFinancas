using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartFinancas.Domain.Core;
using SmartFinancas.Domain.Core.Infrastructure;
using SmartFinancas.Infrastructure.Data.EntityFramework.Repositories;

namespace SmartFinancas.Infrastructure.Data.EntityFramework
{
    public class UnitOfWork : Disposable, IUnitOfWork
    {
        #region Fields

        private readonly IDbContext _context;
        private Dictionary<string, object> _repositories;

        #endregion

        #region Constructors

        public UnitOfWork(IDbContext context)
        {
            _context = context;
        }

        #endregion

        #region IUnitOfWork Members

        /// <summary>
        /// Repositório genérico de uma classe derivada <see cref="BaseEntity" />
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
            if (_repositories == null)
                _repositories = new Dictionary<string, object>();

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<T>)_repositories[type];
        }

        /// <summary>
        /// Persiste todas as mudanças no bando de dados
        /// <remarks>Sincrono</remarks>
        /// </summary>
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        /// <summary>
        /// Persiste todas as mudanças no bando de dados
        /// <remarks>Assincrono</remarks>
        /// </summary>
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        
        #endregion

        #region Disposable

        /// <summary>
        /// Destroi o objeto
        /// </summary>
        protected override void DisposeCore()
        {
            if (_context != null)
                _context.Dispose();
        }

        #endregion
    }
}