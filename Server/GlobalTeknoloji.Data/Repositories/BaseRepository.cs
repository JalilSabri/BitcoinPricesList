using GlobalTeknoloji.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GlobalTeknoloji.Data.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    internal readonly GTDbContext _gtdbContext;

    internal DbSet<TEntity> dbSet;

    public BaseRepository(GTDbContext gtdbContext)
    {
        this._gtdbContext = gtdbContext;
        dbSet = this._gtdbContext.Set<TEntity>();
    }

    public TEntity GetById(object Id)
    {
        return dbSet.Find(Id);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return dbSet.AsEnumerable();
    }

    public TEntity GetFirst(Expression<Func<TEntity, bool>>? where)
    {
        return dbSet.Where(where).FirstOrDefault();
    }

    public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>>? where = null)
    {
        IQueryable<TEntity> query = dbSet;

        if (where != null)
        {
            query = query.Where(where);
        }

        return query.ToList();
    }

    public IEnumerable<TEntity> GetWithExpressions(Expression<Func<TEntity, bool>>? where , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy , params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = dbSet;

        if (where != null)
        {
            query = query.Where(where);
        }

        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }

        if (orderBy != null)
        {
            return orderBy(query).ToList();
        }
        else
        {
            return query.ToList();
        }
    }

    Func<int, string, bool> checkExpression = (int i, string str) => { return int.Parse(str) == i; };

    public async Task<TEntity> GetByIdAsync(object Id)
    {
        return await dbSet.FindAsync(Id);
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await dbSet.ToListAsync();
    }

    public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>>? where)
    {
        return await dbSet.Where(where).FirstOrDefaultAsync();
    }

    public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? where)
    {
        IQueryable<TEntity> query = dbSet;

        if (where != null)
        {
            query = query.Where(where);
        }

        return await query.ToListAsync();
    }

    public void Add(TEntity entity)
    {
        _gtdbContext.Add(entity);
    }

    public void Add(List<TEntity> entities)
    {
        _gtdbContext.AddRange(entities);
    }

    public void Update(TEntity entity)
    {
        if (entity == null) throw new ArgumentException("Entity is null");
        _gtdbContext.Attach(entity);
        _gtdbContext.Entry(entity).State = EntityState.Modified;

        #region .:| Manual Modifing -> Concurrency Issue |:.

        //demodbContext.Entry(entity).Members.Select(ent =>
        //{
        //    var entityName = ent.Metadata.Name;
        //    string entityFullName = ent.Metadata.ClrType.FullName;
        //    if (ent is Microsoft.EntityFrameworkCore.ChangeTracking.ReferenceEntry)
        //    {
        //        demodbContext.Attach(((Microsoft.EntityFrameworkCore.ChangeTracking.ReferenceEntry)ent).TargetEntry.Entity);
        //        ((Microsoft.EntityFrameworkCore.ChangeTracking.ReferenceEntry)ent).TargetEntry.State = EntityState.Modified;
        //    }
        //    return ent;
        //}).ToList();

        #endregion
    }

    public void Delete(object id)
    {
        var entity = GetById(id);
        if (entity == null) throw new Exception("Entity is not found");
        Delete(entity);
    }

    public void Delete(TEntity entity)
    {
        if (_gtdbContext.Entry(entity).State == EntityState.Detached)
            dbSet.Attach(entity);
        dbSet.Remove(entity);
    }

    public void Delete(Expression<Func<TEntity, bool>>? where)
    {
        IEnumerable<TEntity> lstEntities = GetList(where);
        foreach (TEntity ent in lstEntities)
            dbSet.Remove(ent);
    }

    public void Delete(Expression<Func<TEntity, bool>>? where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = dbSet;

        if (where != null)
        {
            query = query.Where(where);
        }

        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }

        var lstEntities = query.ToList();
        foreach (TEntity ent in lstEntities)
            dbSet.Remove(ent);
    }

    public void Commit()
    {
        _gtdbContext.SaveChanges();
    }

    public Task<int> CommitAsync()
    {
        return _gtdbContext.SaveChangesAsync();
    }

    
}
