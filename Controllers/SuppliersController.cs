using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InventoryApp.Models;
using Newtonsoft.Json;
using System.Text;

namespace InventoryApp.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string ApiBaseUrl = "http://localhost:5198/api/suppliers";

        public SuppliersController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        // GET: Suppliers
        public async Task<IActionResult> Index()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, ApiBaseUrl);
            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var suppliers = JsonConvert.DeserializeObject<IEnumerable<Supplier>>(jsonString);
                return View(suppliers);
            }

            return View("Error");
        }

        // GET: Suppliers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync($"{ApiBaseUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var supplier = JsonConvert.DeserializeObject<Supplier>(await response.Content.ReadAsStringAsync());
                return View(supplier);
            }

            return NotFound();
        }

        // GET: Suppliers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient();
                var content = new StringContent(JsonConvert.SerializeObject(supplier), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(ApiBaseUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync($"{ApiBaseUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                Supplier supplier = JsonConvert.DeserializeObject<Supplier>(await response.Content.ReadAsStringAsync());
                return View(supplier);
            }

            return NotFound();
        }

        // POST: Suppliers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplierId, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone")] Supplier supplier)
        {
            if (id != supplier.SupplierId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient();
                var content = new StringContent(JsonConvert.SerializeObject(supplier), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync($"{ApiBaseUrl}/{id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "An error occurred on update. Please try again.");
                }
            }
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync($"{ApiBaseUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                Supplier supplier = JsonConvert.DeserializeObject<Supplier>(await response.Content.ReadAsStringAsync());
                return View(supplier);
            }

            return NotFound();
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.DeleteAsync($"{ApiBaseUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "An error occurred on delete. Please try again.");
                // Depending on how you want to handle this, you might want to redirect to another page
                // or return to the Delete view with the error message.
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
