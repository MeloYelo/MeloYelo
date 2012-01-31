using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Raven.Client.Embedded;

namespace Chat.Controllers
{
	public class HomeController : ApplicationController
	{
		public HomeController(EmbeddableDocumentStore docStore) : base(docStore) { }
		public ActionResult Index()
		{
			return View();
		}

	}
}
