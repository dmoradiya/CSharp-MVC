﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFirstProject.Models;

namespace MyFirstProject.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            Debug.WriteLine("ACTION - Index Action");

            return RedirectToAction("Management");
        }

        public IActionResult Management()
        {
            Debug.WriteLine("ACTION - Management Action");
            ViewBag.People = People;
            return View();
        }

        public IActionResult Create(string firstName, string lastName)
        {
            Debug.WriteLine("ACTION - Create Action");

            CreatePerson(firstName, lastName);
            return RedirectToAction("Management");
        }

        public IActionResult Delete(string firstName)
        {
            Debug.WriteLine("ACTION - Delete Action");

            DeletePersonByFirstName(firstName);
            return RedirectToAction("Management");
        }

        public static List<Person> People = new List<Person>();

        // These methods are for data management. The body of the methods will be replaced with EF code tomorrow, but for now, we're just using a static list.
        public void CreatePerson(string firstName, string lastName)
        {
            Debug.WriteLine($"DATA - CreatePerson({firstName}, {lastName})");

            People.Add(new Person()
            {
                FirstName = firstName.Trim(),
                LastName = lastName.Trim()
            });
        }

        public void DeletePersonByFirstName(string firstName)
        {
            Debug.WriteLine($"DATA - DeletePersonByFirstName({firstName})");

            People.Remove(GetPersonByFirstName(firstName));
        }

        public Person GetPersonByFirstName(string firstName)
        {
            Debug.WriteLine($"DATA - GetPersonByFirstName({firstName})");

            // This assumes nobody's name is duplicated. If it is, it will return null.
            return People.Where(x => x.FirstName.Trim().ToUpper() == firstName.Trim().ToUpper()).SingleOrDefault();
        }
    }
}
