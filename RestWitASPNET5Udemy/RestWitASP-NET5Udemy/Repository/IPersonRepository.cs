using RestWitASP_NET5Udemy.Model;
using RestWitASP_NET5Udemy.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWitASP_NET5Udemy.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        List<Person> FindByName(string firstName, string lastName);
    }
}
