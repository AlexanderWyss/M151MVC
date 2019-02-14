using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Models;

namespace MVC.Data
{
    public class PersonRepository
    {
        private static List<Person> persons = new List<Person>();

        static PersonRepository()
        {
            persons.Add(new Person(1, "Huber", "Peter"));
            persons.Add(new Person(2, "Meier", "Fritz"));
            persons.Add(new Person(3, "Brunner", "Tina"));
            persons.Add(new Person(4, "Müller", "Martina"));
        }

        public List<Person> FindAll()
        {
            return persons;
        }

        public Person FindById(int id)
        {
            return persons.Where(p => p.PersonId == id).FirstOrDefault();
        }

        public void Delete(int personid)
        {
            var person = FindById(personid);
            persons.Remove(person);
        }

        public void Save(Person p)
        {
            if (p.PersonId == 0)
            {
                //neue Person einfügen
                p.PersonId = persons.Max(prs => prs.PersonId) + 1;
                persons.Add(p);
            }
            else
            {
                //bestehende Person aktualisieren
                var person = FindById(p.PersonId);
                person.Vorname = p.Vorname;
                person.Name = p.Name;
            }
        }
    }
}