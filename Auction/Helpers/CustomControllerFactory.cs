using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Raven.Client.Embedded;

namespace Auction.Controllers
{
	public class CustomControllerFactory : DefaultControllerFactory
	{
		protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
		{
			if(controllerType == null) return base.GetControllerInstance(requestContext, controllerType);
			var docStore = HttpContext.Current.Application["DocumentStore"] as EmbeddableDocumentStore;
			return Activator.CreateInstance(controllerType, docStore) as IController;
		}
	}
}