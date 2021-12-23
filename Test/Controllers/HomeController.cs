using Test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Test.Repository.IRepository;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRegRepository _reg;

        public HomeController(ILogger<HomeController> logger, IRegRepository reg)
        {
            _logger = logger;
            _reg = reg;
        }

        [Route("/Home/json")]
        public JsonResult Uploadjson()
        {
            
            string read = System.IO.File.ReadAllText("json/info.json"); ;
            RegestrationModel reg = JsonConvert.DeserializeObject<RegestrationModel>(read);
              int result = _reg.AddUser(reg);
                if(result>0)
                {
                    return Json(new { massege = "Success" });
                }
            
            return Json(new{massege = "Failed"});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
