using RestWitASP_NET5Udemy.Model;
using RestWitASP_NET5Udemy.Model.Context;
using RestWitASP_NET5Udemy.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWitASP_NET5Udemy.Repository.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        MySQLContext _context;
        public BookRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }
        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return book;
        }

        public void Delete(long id)
        {
            var _book = FindByID(id);
            if (_book == null)
            {
                return;
            }
            try
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book FindByID(long id)
        {
            return _context.Books.SingleOrDefault(book => book.Id.Equals(id));
        }

        public Book Update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
