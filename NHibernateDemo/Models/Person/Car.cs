using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateDemo.Models.Person
{
    public class Car
    {
        public virtual long Id { get; set; }

        public virtual String ModelName { get; set; }
        public virtual Int32 Year { get; set; }
        public virtual Person Person { get; set; }
 
    }
}