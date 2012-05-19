using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeEditor.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Upload()
		{
			if (Request.Files.Count > 0)
			{
				foreach (string file in Request.Files)
				{
					HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
					if (hpf.ContentLength == 0)
						continue;
					//hpf.SaveAs(savedFileName);
				}
			}
			else
			{
				var filename = Request.Headers.Get("X-File-Name");
				if (!string.IsNullOrEmpty(filename))
				{
					var file = new MemoryStream();
					Request.InputStream.CopyTo(file);
				}
			}
			//return Json(new {error = HttpUtility.HtmlEncode("deshalb")}, "text/html");
			return Json(new {success = true}, "text/html");
		}
    }
}
