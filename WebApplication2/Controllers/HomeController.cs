using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        EmployeeList elist = new EmployeeList();
        private readonly ILogger<HomeController> _logger;


        public IActionResult create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult create(Employee employee)
        {
            elist.populate(employee);
            return View();
        }

        public IActionResult show()
        {
            var t = elist.getemp().ToList();
            return View(t);
        }

        public IActionResult edit(string name)
        {
            Employee t = elist.getemp().Single(sssss => sssss.Name == name);
            return View(t);
        }






    }
}
