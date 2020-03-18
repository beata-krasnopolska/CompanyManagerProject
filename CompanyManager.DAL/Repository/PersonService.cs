using CompanyManager.DAL.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CompanyManager.DAL.Repository
{
    public class PersonService
    {
        public IEnumerable<Person> GetPersons()
        {
            using (var context = new PersonContext())
            {
                return context.Persons.ToList();
            }             
        }

        public Person GetPersonByID(int personId)
        {
            using (var context = new PersonContext())
            {
                return context.Persons.FirstOrDefault(x => x.Id == personId);
            }
        }

        public void InsertPerson(Person person)
        {
            using(var context = new PersonContext())
            {
                 context.Persons.Add(person);
                 context.SaveChanges();
            }       
        }

        public void DeletePerson(int personId)
        {
            using (var context = new PersonContext())
            {
                 Person person = context.Persons.FirstOrDefault(x => x.Id == personId);
                 context.Persons.Remove(person);
                 context.SaveChanges();
            }            
        }

        public void UpdatePerson(Person person)
        {
            using (var context = new PersonContext())
            {
                 context.Persons.Attach(person);
                 context.Entry(person).State = EntityState.Modified;
                 context.SaveChanges();
            }
        }
    }
}
