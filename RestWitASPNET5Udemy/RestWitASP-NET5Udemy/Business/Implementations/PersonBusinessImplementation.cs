using RestWitASP_NET5Udemy.Business.Interfaces;
using RestWitASP_NET5Udemy.Model;
using RestWitASP_NET5Udemy.Repository.Generic;
using System.Collections.Generic;

namespace RestWitASP_NET5Udemy.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        IRepository<Person> _repository;
        public PersonBusinessImplementation(IRepository<Person> repository)
        {
            _repository = repository;
        }
        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }
    }
}
