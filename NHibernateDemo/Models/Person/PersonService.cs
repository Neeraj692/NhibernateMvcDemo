using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateDemo.Models.Person
{
    public class PersonService : DBService
    {
        public void UpdateNewPerson(Person person)
        {
            Update(person);
        }
        // Add all your query methods here like fetch data, delete data.
    }
}