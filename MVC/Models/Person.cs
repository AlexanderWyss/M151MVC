using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }
        public Person() { }
        public Person(int personid, string name, string vorname)
        {
            PersonId = personid;
            Name = name;
            Vorname = vorname;
        }
    }
}