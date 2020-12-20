using RestWitASP_NET5Udemy.Data.VO;
using System.Collections.Generic;

namespace RestWitASP_NET5Udemy.Business.Interfaces
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO FindByID(long id);
        List<BookVO> FindAll();
        BookVO Update(BookVO book);
        void Delete(long id);
    }
}
