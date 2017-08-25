using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Enroute.ViewModels;
using Enroute.Services;
using Microsoft.Extensions.Configuration;
using Enroute.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enroute.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailservice _mailService;
        private IConfigurationRoot _config;
        
        private IWorldRepository _repository;

        public AppController(IMailservice mailService, 
            IConfigurationRoot config, 
            IWorldRepository repository
            )
        {
            _mailService = mailService;
            _config = config;
            _repository = repository;
             
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Trips()
        {

            var data = _repository.GetAllTrips();
            return View(data);

        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                _mailService.SendMail(_config["MailSettings:ToAddress"], model.Email, "from the world", model.Message);
                ModelState.Clear(); 
                ViewBag.UserMessage = "Message Sent";

            }
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
