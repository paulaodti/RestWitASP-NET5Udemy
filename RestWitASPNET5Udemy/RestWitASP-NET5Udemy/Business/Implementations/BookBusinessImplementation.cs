using RestWitASP_NET5Udemy.Business.Interfaces;
using RestWitASP_NET5Udemy.Data.Converter.Implementations;
using RestWitASP_NET5Udemy.Data.VO;
using RestWitASP_NET5Udemy.Model;
using RestWitASP_NET5Udemy.Repository.Generic;
using System.Collections.Generic;

namespace RestWitASP_NET5Udemy.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _repository;
        private readonly BookConverter _converter;

        public BookBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public BookVO Create(BookVO book)
        {
            return _converter.Parse(_repository.Create(_converter.Parse(book)));
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<BookVO> FindAll()
        {
           return _converter.Parse(_repository.FindAll());
        }

        public BookVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public BookVO Update(BookVO book)
        {
            return _converter.Parse(_repository.Update(_converter.Parse(book)));
        }
    }
}
