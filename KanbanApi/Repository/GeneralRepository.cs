using KanbanApi.Base;
using KanbanApi.Context;
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
        where TContext : MyContext

    {
        private readonly MyContext _myContext;

        //Constructor
        public GeneralRepository(MyContext myContext)
        {
            this._myContext = myContext;
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

        //REPO DELETE
        public async Task<TEntity> Delete(int id)
        {
            var entity = await Get(id);
            if (entity == null)
            {
                return entity;
            }
            _myContext.Entry(entity).State = EntityState.Deleted;
            await _myContext.SaveChangesAsync();
            return entity;
        }


    }



}
