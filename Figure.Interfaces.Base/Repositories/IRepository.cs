using Figure.Interfaces.Base.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Figure.Interfaces.Base.Repositories
{
    public interface IRepository<T> where T : IEntity, new()
    {
        bool AutoSaveChanges { get; set; }


        T Add(T entity);
        Task<T> AddAsync(T entity, CancellationToken Cancel = default);

        
        T Get(int id);
        Task<T> GetAsync(int id, CancellationToken Cancel = default);


        T Update(T entity);
        Task<T> UpdateAsync(T entity, CancellationToken Cancel = default);


        T Delete(int id);
        Task<T> DeleteAsync(int id, CancellationToken Cancel = default);


        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken Cancel = default);
    }
}
