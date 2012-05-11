using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecipeEditor.Models;

namespace RecipeEditor.Controllers
{
    public class RecipeController : Controller
    {
        //
        // GET: /Recipe/

        public ActionResult Index()
        {
        	var model = new RecipeModel() {Title = "Streuselkuchen"};
            return View(model);
        }

    }
}
