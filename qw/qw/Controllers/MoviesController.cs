using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using qw.Models;

namespace qw.Controllers
{
    public class MoviesController : Controller
    {
        //
        // GET: /Movies/

        public ActionResult Index()
        {
            return View();
        }

    }
}
