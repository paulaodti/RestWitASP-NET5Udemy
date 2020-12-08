using RestWitASP_NET5Udemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWitASP_NET5Udemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
        }

        public List<Person> FindAll()
        {
            var persons = new List<Person>();
            for (int i = 0; i<=8; i++)
            {
                persons.Add(MockPerson(i));
            };
            return persons;
        }

        public Person FindByID(long id)
        {
            return MockPerson(Convert.ToInt32(id));
        }

        public Person Update(Person person)
        {
            return person;
        }

        public Person MockPerson(int i)
        {
            return new Person
            {
                Id = i,
                FirstName = "Paulo Henrique " + i,
                Address = "Rua Monte Castelo Branco, Cambui, Minas Gerais",
                Gender = "Male",
                LastName = "Andrade Teixeira"
            };
        }
    }
}
