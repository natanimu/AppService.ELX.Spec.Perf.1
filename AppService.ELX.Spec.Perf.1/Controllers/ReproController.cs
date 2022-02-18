using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppService.ELX.Spec.Perf._1.Controllers
{
    public class ReproController : Controller
    {
        static Lazy<HttpClient> client = new Lazy<HttpClient>();
        public async Task<String> Index()
        {
            HttpClient c = client.Value;
            HttpResponseMessage response = await c.GetAsync("https://juzhudelay.azurewebsites.net/Delay?seconds=20");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return "Done";
        }
    }
}
