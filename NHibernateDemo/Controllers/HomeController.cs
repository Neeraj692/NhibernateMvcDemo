using NHibernateDemo.Models.Person;
using NHibernateDemo.Sigletone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NHibernateDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Register(String name, String carModel1, Int32 year1, String carModel2, Int32 year2)
        {
            // Get the model services
            CarService carService = getCarService();
            PersonService personService = getPersonService();

            // Create a new person and also save the object in data base
            Person person = new Person();
            person.Name = name;
            personService.UpdateNewPerson(person);

            IList<Car> cars = new List<Car>();

            // Create a new Car and link it with the person and save into database
            Car car1 = new Car();
            car1.Person = person;
            car1.ModelName = carModel1;
            car1.Year = year1;
            carService.UpdateNewCar(car1);
            cars.Add(car1);

            Car car2 = new Car();
            car2.Person = person;
            car2.ModelName = carModel2;
            car2.Year = year2;
            carService.UpdateNewCar(car2);
            cars.Add(car2);

            person.CarsOwned = cars;

            return RedirectToAction("Index", "Home");
        }


        private CarService getCarService()
        {
            CarService carService = new CarService();
            carService.SetSession(ApplicationCore.Instance.SessionFactory.OpenSession());

            return carService;
        }

        private PersonService getPersonService()
        {
            PersonService personService = new PersonService();
            personService.SetSession(ApplicationCore.Instance.SessionFactory.OpenSession());

            return personService;
        }
    }
}