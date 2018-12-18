using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateDemo.Models.Person
{
    public class CarService : DBService
    {
        public void UpdateNewCar(Car car)
        {
            Update(car);
        }
        // Add all your query methods here like fetch data, delete data.
    }
}