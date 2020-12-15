using RestWitASP_NET5Udemy.Model;
using System.Collections.Generic;

namespace RestWitASP_NET5Udemy.Repository.Interfaces
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person FindByID(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
