using ConsumeWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumeWebApi.Controllers
{
    public class ProductsController : Controller
    {
        private readonly HttpClient _client;
        Uri baseaddress = new Uri("https://localhost:7267/api");
        
        public ProductsController() 
        {
            _client = new HttpClient();
            _client.BaseAddress = baseaddress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<ProductViewModel> productlist = new List<ProductViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Products/GetProducts").Result;
            if(response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                productlist = JsonConvert.DeserializeObject<List<ProductViewModel>>(data);
            }
            return View(productlist);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Products/PostProducts", stringContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            catch (Exception)
            {
                return View();
                
            }
            return View();
        }

    }
}
