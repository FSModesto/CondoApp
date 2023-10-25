using System.Linq.Expressions;

namespace Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Recupera pelo ID (sem includes)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> Get(Guid id);

        Task<IEnumerable<TEntity>> GetAll();

        /// <summary>
        /// Retorna uma entidade baseado em um filtro. Pode conter includes
        /// </summary>
        /// <param name="where"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        Task<TEntity> Find(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, object> includes = null);

        /// <summary>
        /// Retorna várias entidades baseado em um filtro. Pode conter includes.
        /// </summary>
        /// <param name="where"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> Query(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, object> includes = null);

        /// <summary>
        /// Retorna um boleano indicando se a entidade existe baseado em um filtro.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        Task<bool> Exists(Expression<Func<TEntity, bool>> where);

        /// <summary>
        /// Retorna a quantidade de itens
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        Task<int> Count(Expression<Func<TEntity, bool>> where = null);

        /// <summary>
        /// Cria uma entidade
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> Create(TEntity entity);

        /// <summary>
        /// Atualiza uma entidade
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> Update(TEntity entity);
    }
}
