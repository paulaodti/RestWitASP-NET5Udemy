using RestWitASP_NET5Udemy.Model;
using RestWitASP_NET5Udemy.Model.Context;
using RestWitASP_NET5Udemy.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace RestWitASP_NET5Udemy.Repository
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(MySQLContext context) : base(context) { }
        public List<Person> FindByName(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
                return null;
            var personList = _context.Persons;
            var auxList = new List<Person>();
            
            if (!string.IsNullOrEmpty(firstName))
                auxList = personList.Where(p => p.FirstName.ToUpper().Contains(firstName.ToUpper())).ToList();
            
            if (!string.IsNullOrEmpty(lastName))
                if (auxList.Count > 0)
                    auxList = auxList.Where(p => p.LastName.ToUpper().Contains(lastName.ToUpper())).ToList();
                else
                    auxList = personList.Where(p => p.FirstName.ToUpper().Contains(lastName.ToUpper())).ToList();
            
            return auxList;
        }
    }
}
