using Data.Warehouse.PostgreSQL.OSCRM.DAL;
using Microsoft.EntityFrameworkCore;

namespace OSCRM.Web.Api.Storages
{
    public partial class StorageRepository : IStorageRepository
    {
        private readonly OSCRMDbContext _context;

        public StorageRepository(OSCRMDbContext _context)
        {
            this._context = _context;
        }

        public async ValueTask<T> InsertAsync<T>(T @object)
        {
            this._context.Entry(@object!).State = EntityState.Added;
            await this._context.SaveChangesAsync();

            return @object;
        }

        public IQueryable<T> SelectAll<T>() where T : class => this._context.Set<T>();

        public async ValueTask<T?> SelectAsync<T>(params object[] @objectIds) where T : class =>
            await this._context.FindAsync<T>(objectIds);
        
        public T? Select<T>(params object[] @objectIds) where T : class =>
            this._context.Find<T>(objectIds);

        public async ValueTask<T> UpdateAsync<T>(T @object)
        {
            this._context.Entry(@object!).State = EntityState.Modified;
            await this._context.SaveChangesAsync();

            return @object;
        }

        public async ValueTask<T> DeleteAsync<T>(T @object)
        {
            this._context.Entry(@object!).State = EntityState.Deleted;
            await this._context.SaveChangesAsync();

            return @object;
        }
    }
}
