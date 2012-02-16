using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeddingAddress.Models;
using Raven.Client.Embedded;

namespace WeddingAddress.Controllers
{
	public class AddressesController : ApplicationController
	{
		public AddressesController(EmbeddableDocumentStore docStore) : base(docStore) { }
		//
		// GET: /Addresses/

		public ViewResult Index()
		{
			return View(DocumentSession.Query<Address>().ToList());
		}

		//
		// GET: /Addresses/Details/5

		public ViewResult Details(string id)
		{
			Address address = DocumentSession.Query<Address>().Single(x => x.Id == id);
			return View(address);
		}

		//
		// GET: /Addresses/Create

		public ActionResult Create()
		{
			return View();
		}

		//
		// POST: /Addresses/Create

		[HttpPost]
		public ActionResult Create(Address address)
		{
			if(ModelState.IsValid)
			{
				DocumentSession.Store(address);
				DocumentSession.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(address);
		}

		//
		// GET: /Addresses/Edit/5

		public ActionResult Edit(string id)
		{
			Address address = DocumentSession.Query<Address>().Single(x => x.Id == id);
			return View(address);
		}

		//
		// POST: /Addresses/Edit/5

		[HttpPost]
		public ActionResult Edit(Address address)
		{
			if(ModelState.IsValid)
			{
				DocumentSession.Query<
				context.Entry(address).State = EntityState.Modified;
				context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(address);
		}

		//
		// GET: /Addresses/Delete/5

		public ActionResult Delete(string id)
		{
			Address address = context.Addresses.Single(x => x.Id == id);
			return View(address);
		}

		//
		// POST: /Addresses/Delete/5

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(string id)
		{
			Address address = context.Addresses.Single(x => x.Id == id);
			context.Addresses.Remove(address);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}