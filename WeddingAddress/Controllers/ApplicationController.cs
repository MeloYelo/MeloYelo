using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Raven.Client.Embedded;
using Raven.Client;

namespace WeddingAddress.Controllers
{
	public class ApplicationController : Controller
	{
		public IDocumentSession DocumentSession;
		public EmbeddableDocumentStore DocumentStore;
		public ApplicationController(EmbeddableDocumentStore docStore)
		{
			this.DocumentStore = docStore;
			this.DocumentSession = docStore.OpenSession();
		}
	}
}
