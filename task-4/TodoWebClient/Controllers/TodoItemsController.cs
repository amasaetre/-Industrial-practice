using Microsoft.AspNetCore.Mvc;
using TodoWebClient.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TodoWebClient.Controllers
{
    public class TodoItemsController : Controller
    {
        private readonly HttpClient _client;

        public TodoItemsController(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://localhost:44371/api/");
            
        }

        public async Task<IActionResult> Index()
        {
            var todoItems = await _client.GetFromJsonAsync<List<TodoItem>>("TodoItems");
            return View(todoItems);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TodoItem todoItem)
        {
            var response = await _client.PostAsJsonAsync("TodoItems", todoItem);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(todoItem);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var todoItem = await _client.GetFromJsonAsync<TodoItem>($"TodoItems/{id}");
            return View(todoItem);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TodoItem todoItem)
        {
            var response = await _client.PutAsJsonAsync($"TodoItems/{todoItem.Id}", todoItem);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(todoItem);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var todoItem = await _client.GetFromJsonAsync<TodoItem>($"TodoItems/{id}");
            return View(todoItem);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _client.DeleteAsync($"TodoItems/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
