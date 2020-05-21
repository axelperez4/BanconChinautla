using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanconChinautla.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BanconChinautla.Controllers
{

    [Authorize(AuthenticationSchemes = "Identity.Application")]
    public class CuentasController : Controller
    {

        //private readonly IBancoRepository _repo;

        //public HomeController(IBancoRepository repo)
        //{
        //    _repo = repo;
        //}

        // GET: Cuentas
        public ActionResult Index()
        {
            var vm = new CuentaVM();
            return View(vm);

            //ajksndksad
        }

        // GET: Cuentas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cuentas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cuentas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CuentaVM collection)
        {
            try
            {
                if (ModelState.IsValid)
                {

                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cuentas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cuentas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cuentas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cuentas/Delete/5
        //[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}