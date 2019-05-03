using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using VeskoWeb.Domain.Models;
using VeskoWeb.Domain.Repositories;


namespace VeskoWeb.DataBase.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {

        private readonly DbContext _dbContext;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Activate(int Id)
        {
            var entity = _dbContext.Set<T>().Find(Id);
            entity.InactivateDate = null;
            entity.IsActive = true;
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return entity;
        }


        public T Add(T obj)
        {
            _dbContext.Add(obj);
            return obj;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var currentSet = _dbContext.Set<T>();
            IQueryable<T> query = currentSet;
            foreach (var inc in includes)
                query = query.Include(inc);
            return query.Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().FirstOrDefault(f => f.Id == id);
        }

        public T Inactivate(int Id)
        {
            var entity = _dbContext.Set<T>().Find(Id);
            entity.InactivateDate = DateTime.Now;
            entity.IsActive = false;
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return entity;
        }

        public bool Remove(int id)
        {
            _dbContext.Set<T>().Remove(GetById(id));
            var returno = _dbContext.SaveChanges();

            return returno == 1;
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public T Update(T obj)
        {
            var entity = GetById(obj.Id);
            if (entity == null)
                return entity;

            _dbContext.Entry(entity).State = EntityState.Modified;
            return obj;
        }

        public void Inactivate(T toUpdate) => _dbContext.Entry(toUpdate).State = EntityState.Modified;

        public void Activate(T toUpdate) => _dbContext.Entry(toUpdate).State = EntityState.Modified;
    }
}
