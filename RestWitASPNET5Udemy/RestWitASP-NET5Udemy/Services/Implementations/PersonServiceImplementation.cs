using RestWitASP_NET5Udemy.Model;
using RestWitASP_NET5Udemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWitASP_NET5Udemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private MySQLContext _context;
        public PersonServiceImplementation(MySQLContext context)
        {
            _context = context;
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindByID(long id)
        {
            return _context.Persons.SingleOrDefault(person => person.Id.Equals(id));
        }
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }

        public void Delete(long id)
        {
            var _person = FindByID(id);
            if (_person == null)
            {
                return;
            }
            try
            {
                _context.Persons.Remove(_person);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Person Update(Person person)
        {
            var _person = FindByID(person.Id);
            if (_person == null)
            {
                return new Person();
            }
            try
            {
                _context.Entry(_person).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }
    }
}
