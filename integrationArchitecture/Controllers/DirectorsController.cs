using integrationArchitecture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
//
namespace integrationArchitecture.Controllers
{
    public class DirectorsController : Controller
    {
        // GET: DirectorsController
        public async Task<ActionResult> Index()
        {
            string apiUrl = "https://localhost:7220/api/director";

            List<Directors> directors = new List<Directors>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var result = await response.Content.ReadAsStringAsync();
                directors = JsonConvert.DeserializeObject<List<Directors>>(result);
            }

            return View(directors);
        }

        // GET: DirectorsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DirectorsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DirectorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Directors directors)
        {
            string apiUrl = "https://localhost:7220/api/director";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(directors), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(directors);
        }

        // GET: DirectorsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DirectorsController/Edit/5
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

        // GET: DirectorsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DirectorsController/Delete/5
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
