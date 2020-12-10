using RestWitASP_NET5Udemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWitASP_NET5Udemy.Repository
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
