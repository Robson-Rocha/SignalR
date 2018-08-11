using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RobsonAraujo.Demos.SignalR.Web.Hubs;
using RobsonAraujo.Demos.SignalR.Web.Models;

namespace RobsonAraujo.Demos.SignalR.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult LongRunning([FromServices] IHubContext<ProgressHub, IProgressHubClientFunctions> progressHub)
        {
            string operationId = Guid.NewGuid().ToString();
            Task longRunningTask = new LongRunningOperation(progressHub).DoOperation(operationId);
            ViewData["operationId"] = operationId;
            return View();
        }
    }
}
