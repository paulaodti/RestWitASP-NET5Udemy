using RestWitASP_NET5Udemy.Model;
using System.Collections.Generic;

namespace RestWitASP_NET5Udemy.Repository.Interfaces
{
    public interface IBookRepository
    {
        Book Create(Book book);
        Book FindByID(long id);
        List<Book> FindAll();
        Book Update(Book book);
        void Delete(long id);
    }
}
