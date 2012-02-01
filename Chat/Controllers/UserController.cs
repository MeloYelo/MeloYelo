using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Raven.Client.Embedded;
using Chat.ViewModels;
using Chat.Models;
using Chat.Helpers;
using System.Web.Security;

namespace Chat.Controllers
{
	public class UserController : ApplicationController
	{
		public UserController(EmbeddableDocumentStore docStore) : base(docStore) { }

		[HttpGet]
		public ActionResult Create()
		{
			if(CurrentUser != null)
			{
				return RedirectToAction("Create", "Room");
			}

			return View(new UserCreateViewModel());
		}

		[HttpPost]
		public ActionResult Create(UserCreateViewModel model)
		{
			if(ModelState.IsValid)
			{
				model.Name = model.Name.Trim();

				if(model.Name.Length >= 3)
				{
					User user = new User();
					user.CreateDateTime = DateTime.Now;
					user.Name = model.Name;
					DocumentSession.Store(user);
					DocumentSession.SaveChanges();
					if(!user.Id.IsNullOrWhiteSpace())
					{
						CurrentUser = user;
						FormsAuthentication.SetAuthCookie(user.Id, true);
						return RedirectToAction("Create", "Room");
					}
				}
				else
				{
					ModelState.AddModelError("Name", "Name is not valid");
				}
			}
			return View(model);
		}

		[HttpGet]
		public ActionResult LogOff()
		{
			CurrentUser = null;
			Session.Clear();
			FormsAuthentication.SignOut();
			return Redirect("~/");
		}
	}
}
