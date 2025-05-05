using FlaschenpostTestDAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaschenpostTestDAL.Abstructions
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        protected DbContext db;
        protected readonly DbSet<TEntity> _dbSet;
        public BaseRepository(DbContext db)
        {
            this.db = db;
            _dbSet = this.db.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            var entity = _dbSet.FindAsync(id).Result;
            if (entity != null)
            {
                this.db.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public List<TEntity> GetAll()
        {
            return  _dbSet.ToListAsync().Result;
        }

        public TEntity Add(TEntity entity)
        {
            var item = _dbSet.AddAsync(entity).Result.Entity;
            return item;
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(TEntity entity)
        {
             _dbSet.Remove(entity);
        }

        public bool Save()
        {
            var affected = db.SaveChanges();
            if (affected > 0)
            {
                return true;
            }
            else
                return false;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        //public int GetNextId(Func<TEntity, int> keySelector)
        //{
        //    var dbSet = db.Set<TEntity>();
        //    if (dbSet.Any())
        //    {
        //        return dbSet.Max(keySelector) + 1;
        //    }
        //    else
        //    {
        //        return 1;
        //    }
        //}
    }
}
