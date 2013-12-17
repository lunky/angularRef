using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using Shared;

namespace angularRef.Controllers
{
	public class HomeController : Controller
	{
		private readonly IKidService _kidService;

		public HomeController(IKidService kidService)
		{
			_kidService = kidService;
		}

		public ActionResult Index()
		{
			ViewBag.Message = "";

			return View();
		}
		public ActionResult Collection()
		{
			ViewBag.Message = "Demonstrates somthing I did with angular";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public EmptyResult SaveKids(IEnumerable<KidDto> kids)
		{
			_kidService.SaveOrUpdateKids(kids);
			System.Diagnostics.Debug.WriteLine("kids");
			var result = new EmptyResult();
			return result;
		}

		public JsonResult Demo()
		{
			var kids = _kidService.GetKids();
			return Json(kids, JsonRequestBehavior.AllowGet);
		}
	}
}
