using System;
using System.Web.Mvc;

namespace RecipeEditor.JsTests.Controllers
{
    public class JasmineController : Controller
    {
        public ViewResult Run()
        {
            return View("SpecRunner");
        }
    }
}
