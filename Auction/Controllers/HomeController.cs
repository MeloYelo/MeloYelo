using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Raven.Client.Embedded;

namespace Auction.Controllers
{
	public class HomeController : ApplicationController
	{
		public HomeController(EmbeddableDocumentStore docStore) : base(docStore) { }

		public ActionResult Index()
		{
			ViewBag.Message = "Welcome to ASP.NET MVC!";

			return View();
		}

		public ActionResult About()
		{
			return View();
		}
	}
}
