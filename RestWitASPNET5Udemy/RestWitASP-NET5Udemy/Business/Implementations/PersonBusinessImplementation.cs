using RestWitASP_NET5Udemy.Business.Interfaces;
using RestWitASP_NET5Udemy.Model;
using RestWitASP_NET5Udemy.Repository.Interfaces;
using System.Collections.Generic;

namespace RestWitASP_NET5Udemy.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        IPersonRepository _personRepository;
        public PersonBusinessImplementation(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public Person Create(Person person)
        {
            return _personRepository.Create(person);
        }

        public void Delete(long id)
        {
            _personRepository.Delete(id);
        }

        public List<Person> FindAll()
        {
            return _personRepository.FindAll();
        }

        public Person FindByID(long id)
        {
            return _personRepository.FindByID(id);
        }

        public Person Update(Person person)
        {
            return _personRepository.Update(person);
        }
    }
}
