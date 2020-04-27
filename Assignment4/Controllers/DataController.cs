using Assignment4.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
//using GHI.ModelDto;
using Assignment4.Models;
using System.Threading.Tasks;

namespace GHI.Controllers
{
    [Produces("application/json")]
    [Route("api/data")]
    public class DataController : Controller
    {
        public ApplicationDbContext dbContext;

        public DataController(ApplicationDbContext context)
        {
            dbContext = context;
        }

    }
}