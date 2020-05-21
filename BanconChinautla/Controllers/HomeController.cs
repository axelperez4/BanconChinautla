using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BanconChinautla.Models;
using BanconChinautla.Repository;
using Microsoft.AspNetCore.Authorization;

namespace BanconChinautla.Controllers
{
    [Authorize(AuthenticationSchemes = "Identity.Application")]
    public class HomeController : Controller
    {
        private readonly IBancoRepository _repo;

        //public HomeController(IBancoRepository repo)
        //{
        //    _repo = repo;
        //}
        [Authorize(AuthenticationSchemes = "Identity.Application")]
        public IActionResult Index()
        {
            var vm = new CuentaVM();
            return View(vm);
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
    }
}
