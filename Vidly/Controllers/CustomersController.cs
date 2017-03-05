using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customer
        List<Customer> customerList = new List<Customer>
        {
            new Customer { Id = 1, Name = "Morgan Norell" },
            new Customer { Id = 2, Name ="Therese Sallander" },
            new Customer { Id = 3, Name = "Isac Norell" },
            new Customer { Id = 4, Name = "Emma Norell"  },
            new Customer { Id = 5, Name = "Elise Jägrup Sallander" }
        };

        public ActionResult Index()
        {           
            var ViewModel = new CustomerViewModel
            {
                Customers = customerList
            };

            return View(ViewModel);
        }

        [Route("Customers/Detail/{Id}")]
        public ActionResult Details(int id)
        {
            Movie customer = new Movie();

            foreach (var c in customerList)
            {
                if (c.Id == id)
                    customer.Name = c.Name;       
            }

            return View(customer);          
        }
    }
}