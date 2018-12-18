using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateDemo.Models.Person
{
    public class Person
    {

        #region public members

        public virtual long Id { get; set; }
        public virtual String Name { get; set; }
        public virtual IList<Car> CarsOwned { get; set; }

        #endregion
    }
}