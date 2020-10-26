
using DNBProject.DAL.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DNBProject.DAL.EF.Repository
{
    public class EFEntityRepositoryBase<TEntity,TContext> : IRepository<TEntity>
        where TEntity : class, new()
        where TContext:DbContext,new()
    {
       
        public void Delete(TEntity obj)
        {
            using (TContext context = new TContext())
            {
                var deletedEntry = context.Entry(obj);
                deletedEntry.State = EntityState.Deleted;
                context.SaveChanges();
                
            }

        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> condition = null)
        {
            TContext context = new TContext();
            
                return condition == null ? context.Set<TEntity>().AsEnumerable() : context.Set<TEntity>().Where(condition).AsEnumerable();
            

        }

        public List<TEntity> GetAllList(Expression<Func<TEntity, bool>> condition = null)
        {
            using (TContext context = new TContext())
            {
                return condition == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(condition).ToList();
            }
        }

        public TEntity GetByCondition(Expression<Func<TEntity, bool>> condition)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Where(condition).FirstOrDefault(); ;
            }
        }

        public void Insert(TEntity obj)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(obj);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
            }
        }

        public void Update(TEntity obj)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(obj);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
            }
        }

    }
}
