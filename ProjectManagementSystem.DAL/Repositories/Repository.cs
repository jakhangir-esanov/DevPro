using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.DAL.Contexts;
using ProjectManagementSystem.DAL.IRepositories;
using ProjectManagementSystem.Domain.Commons;
using System.Linq.Expressions;

namespace ProjectManagementSystem.DAL.Repositories;

public class Repository<T> : IRepository<T> where T : Auditable
{
    private readonly AppDbContext appDbContext;
    private readonly DbSet<T> dbSet;
    public Repository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
        dbSet = appDbContext.Set<T>();
    }

    public async Task InsertAsync(T entity)
    {
        await dbSet.AddAsync(entity);
    }

    public void Drop(T entity)
    {
        dbSet.Remove(entity);
    }

    public void Update(T entity)
    {
        entity.UpdatedAt = DateTime.Now;
        dbSet.Entry(entity).State = EntityState.Modified;
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> expression = null!, string[] includes = null!)
    {
        IQueryable<T> query = dbSet.Where(expression).AsQueryable();

        if (includes is not null)
            foreach (var include in includes)
                query = query.Include(include);

        var result = await query.FirstOrDefaultAsync(expression);
        return result;
    }

    public IQueryable<T> GetAllAsync(Expression<Func<T, bool>> expression = null!, bool isNoTracking = true, string[] includes = null!)
    {
        IQueryable<T> query = expression is null ? dbSet.AsQueryable() : dbSet.Where(expression).AsQueryable();

        query = isNoTracking ? query.AsNoTracking() : query;

        if (includes is not null)
            foreach (var include in includes)
                query = query.Include(include);

        return query;
    }

    public async Task SaveAsync()
    {
        await appDbContext.SaveChangesAsync();
    }
}
