using RestWitASP_NET5Udemy.Business.Interfaces;
using RestWitASP_NET5Udemy.Data.Converter.Implementations;
using RestWitASP_NET5Udemy.Data.VO;
using RestWitASP_NET5Udemy.Model;
using RestWitASP_NET5Udemy.Repository.Generic;
using System.Collections.Generic;

namespace RestWitASP_NET5Udemy.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IRepository<Person> _repository;
        private readonly PersonConverter _converter;
        public PersonBusinessImplementation(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }
        public PersonVO Create(PersonVO person)
        {
            return _converter.Parse(_repository.Create(_converter.Parse(person)));
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PersonVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public PersonVO Update(PersonVO person)
        {
            return _converter.Parse(_repository.Update(_converter.Parse(person)));
        }
    }
}
