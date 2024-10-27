using BookStoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using Microsoft.Extensions.Configuration;
using BookStoreWebApp.Service;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IEmailService _emailService;


        [ViewData]
        public string CustomProp { get; set; }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //_emailService = emailService;
        }


        public  IActionResult Index()
        {
            //********************** SENDING EMAILS **********************
            /*
            UserEmailOptions options = new UserEmailOptions
            {
                ToEmails = new List<string>() { "test@gmail.com" },
                PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string,string>("{{UserName}}", "Sam")
                }
            };

            await _emailService.SendTestEmail(options);
            */

            //********************** Example of ViewBag **********************
            // ViewBag woeks on the dynamic principle.
            /*
            ViewBag.Sanskar = 123;
            dynamic data = new ExpandoObject(); // ExpandoObject is used whenever we need to pass anonymous data from the controller to View();
            data.Id = 1;
            data.Name = "Sanskar";
            ViewBag.Data = data;
            ViewBag.Type = new BookModel() { Id = 5, Author = "Sanskarrrw" };
            */
            //********************** Example of ViewData **********************
            // ViewData is used to pass data from action method to view and we can display this data on View()
            // ViewData works on the Key-Value Pair Principle.
            // The type od Binding is loosely Binding, similar to the ViewBag
            // ViewData["PropertyName"] = Data | ViewData["Key"]=Value;
            //ViewData["Prop1"] = "Sanskar Raval";
            //ViewData["Book"] = new BookModel() { Id = 5, Author = "SanskarLiza" };

            //********************** ViewData Attribute  **********************
            //CustomProp = "Custom Value"; 


            return View();
        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
