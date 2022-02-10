using Figure.Data.Entity.Entities.Base;
using Figure.Database.Context;
using Figure.Interfaces.Base.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Figure.Services.Repository.Base
{
    public class DbRepository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly FigureDb _db;
        private readonly DbSet<T> _Set;


        public DbRepository(FigureDb db)
        {
            _db = db;
            _Set = db.Set<T>();
        }

        public bool AutoSaveChanges { get; set; } = true;


        public virtual IQueryable<T> Items => _Set;


        public T Add(T entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            _db.Entry(entity).State = EntityState.Added;
            
            if (AutoSaveChanges) SaveChanges();
            return entity;
        }

        public async Task<T> AddAsync(T entity, CancellationToken Cancel = default)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            _db.Entry(entity).State = EntityState.Added;

            if (AutoSaveChanges) await SaveChangesAsync(Cancel).ConfigureAwait(false);
            return entity;
        }

        public T Delete(int id)
        {
            if (!_db.Set<T>().Any(e => e.Id == id)) throw new ArgumentException($"Entity with id={id} is not found/exist");

            var item = _Set.Local.FirstOrDefault(e => e.Id == id);
            if (item is null)
                item = _Set.FirstOrDefault(e => e.Id == id);

            _db.Entry(item).State = EntityState.Deleted;
            if (AutoSaveChanges) SaveChanges();

            return item;
        }

        public async Task<T> DeleteAsync(int id, CancellationToken Cancel = default)
        {
            if (! await _db.Set<T>().AnyAsync(e => e.Id == id, Cancel).ConfigureAwait(false)) throw new ArgumentException($"Entity with id={id} is not found/exist");

            var item = _Set.Local.FirstOrDefault(e => e.Id == id);
            if (item is null)
                item = await _Set.FirstOrDefaultAsync(e => e.Id == id, Cancel).ConfigureAwait(false);

            _db.Entry(item).State = EntityState.Deleted;
            if (AutoSaveChanges) await SaveChangesAsync(Cancel).ConfigureAwait(false);

            return item;
        }

        public T Get(int id)
        {
            switch (Items)
            {
                case DbSet<T> set:
                    return set.Find(new object[] { id });
                case { } items:
                    return items.FirstOrDefault(item => item.Id == id);
                default:
                    throw new InvalidOperationException("Ошибка в определении источника данных");
            }
        }

        public async Task<T> GetAsync(int id, CancellationToken Cancel = default)
        {
            switch (Items)
            {
                case DbSet<T> set:
                    return await set.FindAsync(new object[] { id }, Cancel).ConfigureAwait(false);
                case { } items:
                    return await items.FirstOrDefaultAsync(item => item.Id == id, Cancel).ConfigureAwait(false);
                default:
                    throw new InvalidOperationException("Ошибка в определении источника данных");
            }
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(CancellationToken Cancel = default)
        {
            return await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }

        public T Update(T entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            _db.Entry(entity).State = EntityState.Modified;

            if (AutoSaveChanges) SaveChanges();

            return entity;
        }

        public async Task<T> UpdateAsync(T entity, CancellationToken Cancel = default)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            _db.Entry(entity).State = EntityState.Modified;
            
            if (AutoSaveChanges)
                await SaveChangesAsync(Cancel).ConfigureAwait(false);

            return entity;
        }
    }
}
