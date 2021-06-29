using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AjaxWebDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AjaxWebDemo.Controllers
{
    [Route("data")]
    [ApiController]
    public class DataController : Controller
    {
        private List<Person> list = new()
        {
            new() {Surname = "Vrhovnik", Name = "Bojan", Age = 30},
            new() {Surname = "Vrhovnik", Name = "Sandra", Age = 31},
            new() {Surname = "Zofic", Name = "Oliver", Age = 40}
        };
        
        [Route("bysurname/{surname?}")]
        public JsonResult GetData(string surname)
        {
            if (!string.IsNullOrEmpty(surname))
                list = list.Where(d => d.Surname.Contains(surname)).ToList();
            return new JsonResult(list);
        }
        
        [Route("add")]
        [HttpPost]
        public async Task<JsonResult> AddData()
        {
            var stream = new MemoryStream();
            await Request.Body.CopyToAsync(stream);
            stream.Position = 0;

            using (var reader = new StreamReader(stream))
            {
                var requestBody = await reader.ReadToEndAsync();

                if (requestBody.Length > 0)
                {
                    var person = JsonConvert.DeserializeObject<Person>(requestBody);
                    list.Add(person);
                }
            }
            
            return Json(list);
        }
    }
}