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

         public IActionResult Editemployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Editemployee(employeeDetails employeeDetails)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var employeesList = employees.Getemployees().ToList();
                    int flag = 0;
                    foreach (var employeeListObject in employeesList)
                    {
                        if (employeeListObject.employeeName == employeeDetails.employeeName)
                        {
                            employeeListObject.employeeGenre = employeeDetails.employeeGenre;
                            flag = 0;
                            break;

                        }
                        else
                        {
                            flag = 1;
                        }
                    }
                    if (flag == 1)
                    {
                        ViewBag.Message = "employee not Found";
                    }
                    else
                    {
                        return RedirectToAction("Viewemployees", "employee");
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.Message;
                }
            }
            return View();
        }

        public IActionResult Deleteemployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Deleteemployee(employeeDetails employeeDetails)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var employeesList = employees.Getemployees().ToList();
                    int flag = 0;
                    foreach (var employeeListObject in employeesList)
                    {
                        if (employeeListObject.employeeName == employeeDetails.employeeName)
                        {
                            int index = employeesList.FindIndex(employees => employees.employeeName == employeeListObject.employeeName);
                            employees.Getemployees().Remove(employeesList[index]);
                            flag = 0;
                            break;
                        }
                        else
                        {
                            flag = 1;
                        }
                    }
                    if (flag == 1)
                    {
                        ViewBag.Message = "employee not Found";
                    }
                    else
                    {
                        return RedirectToAction("Viewemployees", "employee");
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.Message;
                }
            }
            return View();
        }




    }
}
