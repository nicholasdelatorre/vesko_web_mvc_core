using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using VeskoWeb.DataBase.Context;
using VeskoWeb.DataBase.Repositories;
using VeskoWeb.Domain.Models;
using VeskoWeb.Domain.Repositories;
using VeskoWeb.Domain.Services;

namespace VeskoWeb.Application.GenericService
{
    public abstract class GenericService<T> : IGenericService<T> where T : Entity
    {
        protected IGenericRepository<T> repository;
        private readonly DbContext _context;
        protected AppDbContext ctx => _context as AppDbContext;

        public GenericService(DbContext context)
        {
            repository = new GenericRepository<T>(context);
            _context = context;
        }

        public T Activate(int Id)
        {
            try
            {
                var obj = repository.Activate(Id);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Add(T obj)
        {
            try
            {
                repository.Add(obj);
                repository.SaveChanges();
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return repository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T GetById(int id)
        {
            try
            {
                return repository.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Inactivate(int Id)
        {
            try
            {
                var obj = repository.Inactivate(Id);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Remove(int id)
        {
            try
            {
                var obj = repository.Remove(id);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Update(T obj)
        {
            try
            {
                var current = repository.GetById(obj.Id);
                current.MergeFrom(obj);
                repository.Update(current);
                repository.SaveChanges();
                return current;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public abstract IEnumerable<T> FindBy(T filter);
    }
}
