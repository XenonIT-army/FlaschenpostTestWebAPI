using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaschenpostTestDAL.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetByIdAsync(int id);
        List<TEntity> GetAllAsync();
        TEntity AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        bool Save();
        //public int GetNextId(Func<TEntity, int> keySelector);
    }
}
