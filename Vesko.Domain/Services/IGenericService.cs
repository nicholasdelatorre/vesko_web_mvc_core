using System;
using System.Collections.Generic;
using System.Text;
using VeskoWeb.Domain.Models;

namespace VeskoWeb.Domain.Services
{
    public interface IGenericService<T> where T : Entity
    {
        T Add(T obj);
        T GetById(int id);
        IEnumerable<T> GetAll();
        T Update(T obj);
        bool Remove(int id);
        IEnumerable<T> FindBy(T filter);
        T Inactivate(int Id);
        T Activate(int Id);
    }
}
