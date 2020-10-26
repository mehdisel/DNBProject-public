using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DNBProject.DAL.EF.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll(Expression<Func<T,bool>> condition=null);
        List<T> GetAllList(Expression<Func<T,bool>> condition=null);
        T GetByCondition(Expression<Func<T, bool>> condition);
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
    }
}
