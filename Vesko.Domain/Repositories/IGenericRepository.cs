using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using VeskoWeb.Domain.Models;

namespace VeskoWeb.Domain.Repositories
{
    public interface IGenericRepository<T> where T : Entity 
    {
        T Add(T obj);
        T GetById(int id);
        IEnumerable<T> GetAll();
        T Update(T obj);
        bool Remove(int id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        T Inactivate(int Id);
        T Activate(int Id);
        int SaveChanges();
        void Inactivate(T obj);
        void Activate(T obj);
    }
}
