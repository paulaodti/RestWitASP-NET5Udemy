using RestWitASP_NET5Udemy.Data.Converter.Contract;
using RestWitASP_NET5Udemy.Data.VO;
using RestWitASP_NET5Udemy.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWitASP_NET5Udemy.Data.Converter.Implementations
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public BookVO Parse(Book origin)
        {
            if (origin == null)
                return null;
            return new BookVO
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price
            };
        }

        public List<BookVO> Parse(List<Book> origins)
        {
            if (origins == null || origins.Count == 0)
                return null;
            return origins.Select(item => Parse(item)).ToList();
        }

        public Book Parse(BookVO origin)
        {
            if (origin == null)
                return null;
            return new Book
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price
            };
        }

        public List<Book> Parse(List<BookVO> origins)
        {
            if (origins == null || origins.Count == 0)
                return null;
            return origins.Select(item => Parse(item)).ToList();
        }
    }
}
