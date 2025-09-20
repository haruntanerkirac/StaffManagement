using System.Linq.Expressions;

namespace StaffManagement.Domain.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> AsQueryable();

    IQueryable<TEntity> GetAll();

    IQueryable<TEntity> GetAllWithTracking();

    IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);

    IQueryable<TEntity> WhereWithTracking(Expression<Func<TEntity, bool>> expression);

    TEntity First(Expression<Func<TEntity, bool>> expression, bool isTrackingActive = true);

    TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression, bool isTrackingActive = true);

    Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default(CancellationToken), bool isTrackingActive = true);

    Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default(CancellationToken), bool isTrackingActive = true);

    Task<TEntity> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default(CancellationToken));

    Task<TEntity> GetByExpressionWithTrackingAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default(CancellationToken));

    Task<TEntity> GetFirstAsync(CancellationToken cancellationToken = default(CancellationToken));

    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default(CancellationToken));

    bool Any(Expression<Func<TEntity, bool>> expression);

    TEntity GetByExpression(Expression<Func<TEntity, bool>> expression);

    TEntity GetByExpressionWithTracking(Expression<Func<TEntity, bool>> expression);

    TEntity GetFirst();

    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

    void Add(TEntity entity);

    Task AddRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));

    void AddRange(ICollection<TEntity> entities);

    void Update(TEntity entity);

    void UpdateRange(ICollection<TEntity> entities);

    Task DeleteByIdAsync(string id);

    Task DeleteByExpressionAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default(CancellationToken));

    void Delete(TEntity entity);

    void DeleteRange(ICollection<TEntity> entities);

    IQueryable<KeyValuePair<bool, int>> CountBy(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default(CancellationToken));

    int Count();

    int Count(Expression<Func<TEntity, bool>> expression);

    Task<int> CountAsync(CancellationToken cancellationToken = default(CancellationToken));

    Task<int> CountAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default(CancellationToken));

    //int ExecuteUpdate(Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> setPropertyCalls);

    //Task<int> ExecuteUpdateAsync(Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> setPropertyCalls, CancellationToken cancellationToken = default(CancellationToken));

    int ExecuteDelete();

    Task<int> ExecuteDeleteAsync(CancellationToken cancellationToken = default(CancellationToken));

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
