using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using DevExtreme_NETCore_Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DevExtreme_NETCore_Demo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(SampleData.Companies.Skip(2).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Company company)
        {
            if (ModelState.IsValid)
            {
                
                return View(company);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        public ActionResult GetCompanies(DataSourceLoadOptions loadOptions)
        {
            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(SampleData.Companies, loadOptions)), "application/json");
        }

    }
}
