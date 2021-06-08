using Dapper.Contrib.Extensions;
using HasanFurkanFidan.UdemyCourse.SHARED.DataAccess.Spesification;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HasanFurkanFidan.UdemyCourse.SHARED.DataAccess.Dapper
{
    public class DpGenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity:class,new()
    {
        private readonly IDbConnection _connection;
        public DpGenericRepository(IDbConnection dbConnection)
        {
            _connection = dbConnection;
        }
        public async Task AddAsync(TEntity entity)
        {
            await _connection.InsertAsync(entity);
        }

        public async Task AddRangeAsync(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                await _connection.InsertAsync(entity);
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await _connection.DeleteAsync(entity);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();

        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _connection.GetAsync<TEntity>(id);
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetListWithSpecQuery(ISpesification<TEntity> spesification)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetWithSpecQuery(ISpesification<TEntity> spesification)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _connection.UpdateAsync(entity);
        }
    }
}
