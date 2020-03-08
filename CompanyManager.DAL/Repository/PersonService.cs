using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManager.DAL.Entities;
using System.Data.Entity;

namespace CompanyManager.DAL.Repository
{
    public class PersonService
    {
        //CRUD functions on Person Table
        
        public IEnumerable<Person> GetPersons()
        {
            var context = new PersonContext();
            return context.Persons.ToList();
        }

        //public Person GetPersonByID(int personId)
        //{
        //    //return _context.Persons.Find(personId);
        //}

        public void InsertPerson(Person person)
        {
            try
            {
                using(var context = new PersonContext())
                {
                    context.Persons.Attach(person);
                    context.Entry(person).State = EntityState.Added;
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }          
        }

        public void DeletePerson(int personId)
        {
            try
            {
                using (var context = new PersonContext())
                {
                    Person person = context.Persons.Find(personId);
                    context.Persons.Remove(person);

                    context.Persons.Attach(person);
                    context.Entry(person).State = EntityState.Deleted;
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        public void UpdatePerson(Person person)
        {
            try
            {
                using (var context = new PersonContext())
                {
                    context.Persons.Attach(person);
                    context.Entry(person).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }
    }
}
