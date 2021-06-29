using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AjaxWebDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AjaxWebDemo.Controllers
{
    [Route("data")]
    [ApiController]
    public class DataController : Controller
    {
        [Route("bysurname/{surname?}")]
        public JsonResult GetData(string surname)
        {
            var list = StaticDataSource.Data;
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

            using var reader = new StreamReader(stream);
            var requestBody = await reader.ReadToEndAsync();
            
            if (requestBody.Length > 0)
            {
                var person = JsonConvert.DeserializeObject<Person>(requestBody);
                StaticDataSource.Data.Add(person);
            }

            return Json(StaticDataSource.Data);
        }
    }
}