using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment4.Infrastructure.GHIListHandler;
using Assignment4.Models;
using Assignment4.DataAccess;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using System.Net.Http;



namespace MVCTemplate.Controllers
{

    public class HomeController : Controller
    {
        public ApplicationDbContext dbContext;
        //private readonly AppSettings _appSettings;
        public const string SessionKeyName = "HospitalData";

        public HomeController(ApplicationDbContext context /*IOptions<AppSettings>*/ /*appSettings*/)
        {
            dbContext = context;
            //_appSettings = appSettings.Value;
        }

        //public IActionResult HelloIndex()
        //{
        //    ViewBag.Hello = _appSettings.Hello;
        //    return View();
        //}
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About_us()
        {
            return View();
        }
        public IActionResult Summary()
        {


            return View();

        }

        public IActionResult Form()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Form(Hospital hospital)
        {
            var details = dbContext.HospitalInfo.Where(c => c.city == hospital.city);

            return View("Hospitals", details);
        }

        public IActionResult Chart()
        {
            return View();
        }
        //public IActionResult Chart(string symbol)
        //{
        //    //Set ViewBag variable first
        //    ViewBag.dbSuccessChart = 0;
        //    List<Hospital> hosp = new List<Hospital>();
        //    if (symbol != null)
        //    {
        //        GHIHandler webHandler = new GHIHandler();
        //        hosp = webHandler.GetChart(symbol);
        //        hosp = hosp.OrderBy(c => c.city).ToList(); //Make sure the data is in ascending order of date.
        //    }

        //    Hospital hosplist = GetHospitalModel(hosp);

        //    return View(hosplist);
        //}

        //public Hospital GetHospitalModel(List<Hospital> hospitals)
        //{
        //    List<Hospital> hospital = dbContext.HospitalInfo.ToList();



        //}

        public IActionResult Hospitals()
        {

            //Set ViewBag variable first
            ViewBag.dbSucessComp = 0;
            GHIHandler webHandler = new GHIHandler();
            List<Hospital> hos_centers = webHandler.GetFloridadata();

            String recdata = JsonConvert.SerializeObject(hos_centers);


            HttpContext.Session.SetString(SessionKeyName, recdata);

            return View(hos_centers);
        }




        public IActionResult savedata()
        {
            string hospitalsData = HttpContext.Session.GetString(SessionKeyName);
            List<Hospital> hospitals = null;
            if (hospitalsData != "")
            {
                hospitals = JsonConvert.DeserializeObject<List<Hospital>>(hospitalsData);
            }

            foreach (Hospital hospital in hospitals)
            {
                //   Database will give PK constraint violation error when trying to insert record with existing PK.
                //  So add company only if it doesnt exist, check existence using symbol (PK)
                // if (dbContext.Companies.Where(c => c.symbol.Equals(company.symbol)).Count() == 0)
                // {
                dbContext.HospitalInfo.Add(hospital);
                // }
                // }
                dbContext.SaveChanges();
                ViewBag.dbSuccessComp = 1;

            }
            return View("Hospitals", hospitals);
        }


        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }



    }
}