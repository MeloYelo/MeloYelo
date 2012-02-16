using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Raven.Client.Embedded;

namespace WeddingAddress.Controllers
{
	public class CustomControllerFactory : DefaultControllerFactory
	{
		protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
		{
			if(controllerType == null) return base.GetControllerInstance(requestContext, controllerType);
			var docStore = HttpContext.Current.Application["DocumentStore"] as EmbeddableDocumentStore;
			if(docStore == null)
			{
				docStore = new EmbeddableDocumentStore { DataDirectory = "Data", UseEmbeddedHttpServer = true };
				docStore.Conventions.IdentityPartsSeparator = "-";
				docStore.Initialize();
				requestContext.HttpContext.Application["DocumentStore"] = docStore;
			}
			return Activator.CreateInstance(controllerType, docStore) as IController;
		}
	}
}