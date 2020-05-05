using KanbanApi.Base;
using KanbanApi.MyContext;
using KanbanApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.Repository
{
    public class GeneralRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : myContext
    {
        private readonly myContext _myContext;

        //Constructor
        public GeneralRepository(myContext myContexts)
        {
            this._myContext = myContexts;
        }

        //REPO GET ALL
        public async Task<List<TEntity>> Get()
        {
            return await _myContext.Set<TEntity>().ToListAsync();
        }

        //REPO GET BY ID

        public async Task<TEntity> Get(int id)
        {
            return await _myContext.Set<TEntity>().FindAsync(id);
        }

        //REPO POST
        public async Task<TEntity> Post(TEntity entity)
        {
            //entity.CreateDate = DateTimeOffset.Now;
            //entity.IsDelete = false;
            await _myContext.Set<TEntity>().AddAsync(entity);
            await _myContext.SaveChangesAsync();
            return entity;
        }

        //REPO PUT

        public async Task<TEntity> Put(TEntity entity)
        {
            _myContext.Entry(entity).State = EntityState.Modified;
            await _myContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await Get(id);
            if (entity == null)
            {
                return entity;
            }
            //entity.DeleteDate = DateTimeOffset.Now;
            //entity.IsDelete = true;
            _myContext.Entry(entity).State = EntityState.Modified;
            await _myContext.SaveChangesAsync();
            return entity;
        }
    }
}
