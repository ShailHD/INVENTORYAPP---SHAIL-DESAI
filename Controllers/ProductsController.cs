using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InventoryApp.Models;
using Newtonsoft.Json;

namespace InventoryApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string BaseUrl = "http://localhost:5198/api/products";

        public ProductsController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync(BaseUrl);

            if (response.IsSuccessStatusCode)
            {
                var products = JsonConvert.DeserializeObject<List<Product>>(
                    await response.Content.ReadAsStringAsync());
                return View(products);
            }
            else
            {
                // Log the error or handle it as necessary
                return View("Error");
            }
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"{BaseUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var product = JsonConvert.DeserializeObject<Product>(
                    await response.Content.ReadAsStringAsync());
                return View(product);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var client = _clientFactory.CreateClient();
            var response = await client.PostAsJsonAsync(BaseUrl, product);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(product);
            }
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"{BaseUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var product = JsonConvert.DeserializeObject<Product>(
                    await response.Content.ReadAsStringAsync());
                return View(product);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var client = _clientFactory.CreateClient();
            var response = await client.PutAsJsonAsync($"{BaseUrl}/{id}", product);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(product);
            }
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"{BaseUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var product = JsonConvert.DeserializeObject<Product>(
                    await response.Content.ReadAsStringAsync());
                return View(product);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync($"{BaseUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
