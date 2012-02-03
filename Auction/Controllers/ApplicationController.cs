using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Raven.Client.Embedded;
using Raven.Client;
using Auction.Models;

namespace Auction.Controllers
{
	public class ApplicationController : Controller
	{
		public IDocumentSession DocumentSession;
		public EmbeddableDocumentStore DocumentStore;
		public User CurrentUser;
		public ApplicationController(EmbeddableDocumentStore docStore)
		{
			this.DocumentStore = docStore;
			this.DocumentSession = docStore.OpenSession();
		}

		protected override void OnAuthorization(AuthorizationContext filterContext)
		{
			base.OnAuthorization(filterContext);
			CurrentUser = GetCurrentUser();
		}

		private User GetCurrentUser()
		{
			User user = null;
			if(User.Identity.IsAuthenticated)
			{
				user = Session["CurrentUser"] as User;
				if(user == null)
				{
					user = DocumentSession.Query<User>().SingleOrDefault(u => u.Id == User.Identity.Name);
					Session["CurrentUser"] = user;
				}
			}
			return user;
		}
	}
}
