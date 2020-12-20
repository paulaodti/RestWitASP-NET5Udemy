using RestWitASP_NET5Udemy.Data.Converter.Contract;
using RestWitASP_NET5Udemy.Data.VO;
using RestWitASP_NET5Udemy.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWitASP_NET5Udemy.Data.Converter.Implementations
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public PersonVO Parse(Person origin)
        {
            if (origin == null)
                return null;
            return new PersonVO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Gender = origin.Gender,
                Address = origin.Address
            };
        }

        public List<PersonVO> Parse(List<Person> origins)
        {
            if (origins == null || origins.Count == 0)
                return null;
            return origins.Select(item => Parse(item)).ToList();
        }

        public Person Parse(PersonVO origin)
        {
            if (origin == null)
                return null;
            return new Person
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Gender = origin.Gender,
                Address = origin.Address
            };
        }

        public List<Person> Parse(List<PersonVO> origins)
        {
            if (origins == null || origins.Count == 0)
                return null;
            return origins.Select(item => Parse(item)).ToList();
        }
    }
}
