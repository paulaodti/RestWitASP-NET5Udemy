using RestWitASP_NET5Udemy.Business.Interfaces;
using RestWitASP_NET5Udemy.Model;
using RestWitASP_NET5Udemy.Repository.Generic;
using System.Collections.Generic;

namespace RestWitASP_NET5Udemy.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        IRepository<Book> _repository; 

        public BookBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Book> FindAll()
        {
           return _repository.FindAll();
        }

        public Book FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }

        List<Book> IBookBusiness.FindAll()
        {
            return _repository.FindAll();
        }
    }
}
