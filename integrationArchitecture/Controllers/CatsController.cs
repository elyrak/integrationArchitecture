﻿using integrationArchitecture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
//
namespace integrationArchitecture.Controllers
{
    public class CatsController : Controller
    {
        // GET: CatsController
      HttpClient client = new HttpClient();

        public async Task<IActionResult> Index()
        {
            string url = "https://catfact.ninja/fact";
            var response = await client.GetStringAsync(url);
            var cats = JsonConvert.DeserializeObject<Cat>(response);

            return View(cats);
        }


        // GET: CatsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CatsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CatsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CatsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CatsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CatsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
