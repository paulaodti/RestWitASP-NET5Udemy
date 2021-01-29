using RestWitASP_NET5Udemy.Data.VO;
using RestWitASP_NET5Udemy.Hypermedia.Ultils;
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
        List<PersonVO> FindByName(string firstName, string lastName);

        PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
    }
}
