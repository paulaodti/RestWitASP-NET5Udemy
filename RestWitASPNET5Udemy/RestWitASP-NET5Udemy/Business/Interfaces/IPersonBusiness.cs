using RestWitASP_NET5Udemy.Data.VO;
using System.Collections.Generic;

namespace RestWitASP_NET5Udemy.Business.Interfaces
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO PersonVO);
        PersonVO FindByID(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO PersonVO);
        void Delete(long id);
    }
}
