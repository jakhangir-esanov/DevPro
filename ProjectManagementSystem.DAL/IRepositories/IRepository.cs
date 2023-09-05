using ProjectManagementSystem.Domain.Commons;
using System.Linq.Expressions;

namespace ProjectManagementSystem.DAL.IRepositories;

public interface IRepository<T> where T : Auditable
{
    Task InsertAsync(T entity);
    void Update(T entity);
    void Drop(T entity);
    Task<T> GetAsync(Expression<Func<T, bool>> expression = null!, string[] includes = null!);
    IQueryable<T> GetAllAsync(Expression<Func<T, bool>> expression = null!, bool isNoTracking = true, string[] includes = null!);
    Task SaveAsync();
}
