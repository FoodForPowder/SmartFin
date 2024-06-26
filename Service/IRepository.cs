using SmartFin.Entities;

namespace SmartFin.Service
{
    public interface IRepository<T> where T: IEntity{
        Task CreateAsync(T entity);

    Task DeleteAsync(Guid id);

    Task<IReadOnlyCollection<T>> GetAllAsync();


    Task<T> GetAsync(Guid id);


    Task UpdateAsync(T entity);

    }
}