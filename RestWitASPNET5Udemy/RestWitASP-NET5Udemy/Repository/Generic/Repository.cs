using Microsoft.EntityFrameworkCore;
using RestWitASP_NET5Udemy.Model.Base;
using RestWitASP_NET5Udemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWitASP_NET5Udemy.Repository.Generic
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        protected MySQLContext _context;

        private DbSet<T> _dataset;

        public Repository (MySQLContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }
        public T Create(T item)
        {
            try
            {
                _context.Add(item);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return item;
        }

        public void Delete(long id)
        {
            var _item = FindByID(id);
            if (_item == null)
            {
                return;
            }
            try
            {
                _dataset.Remove(_item);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<T> FindAll()
        {
            return _dataset.ToList();
        }

        public T FindByID(long id)
        {
            return _dataset.SingleOrDefault(item => item.Id.Equals(id));
        }

        public List<T> FindWithPagedSearch(string query)
        {
            return _dataset.FromSqlRaw<T>(query).ToList();
        }

        public int GetCount(string query)
        {
            var result = "";
            using (var connection = _context.Database.GetDbConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    result = command.ExecuteScalar().ToString();
                }
            }
            return int.Parse(result);
        }

        public T Update(T item)
        {
            var _item = FindByID(item.Id);
            if (_item == null)
                return _item;
            try
            {
                _context.Entry(_item).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return item;
        }
    }
}
