using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Raven.Client.Embedded;
using Chat.ViewModels;
using Chat.Helpers;
using Chat.Models;

namespace Chat.Controllers
{
	[Authorize]
	public class RoomController : ApplicationController
	{
		public RoomController(EmbeddableDocumentStore docStore) : base(docStore) { }

		[HttpGet]
		public ActionResult Create()
		{
			return View(new RoomCreateViewModel());
		}

		[HttpPost]
		public ActionResult Create(RoomCreateViewModel model)
		{
			if(ModelState.IsValid)
			{
				var room = new Room();
				room.Name = model.Name.Trim();
				room.CreateDateTime = DateTime.Now;
				room.CreateUserId = CurrentUser.Id;
				DocumentSession.Store(room);
				DocumentSession.SaveChanges();
				if(!room.Id.IsNullOrWhiteSpace())
				{
					return RedirectToAction("Chat", new { roomId = room.Id });
				}
			}

			return View(model);
		}

		[HttpGet]
		public ActionResult Chat(string roomId)
		{
			var room = DocumentSession.Query<Room>().SingleOrDefault(r => r.Id == roomId);
			if(room == null)
			{
				return RedirectToAction("Create");
			}
			var model = new RoomChatViewModel();
			model.CurrentUser = CurrentUser;
			model.Room = room;
			return View(model);
		}

		public ActionResult ListUsers(string roomId)
		{
			var room = DocumentSession.Query<Room>().SingleOrDefault(r => r.Id == roomId);
			if(room == null)
			{
				return RedirectToAction("Create");
			}
			var model = new RoomChatViewModel();
			model.CurrentUser = CurrentUser;
			model.Room = room;
			return View(model);
		}

		public ActionResult SubmitMessage(RoomSubmitMessageViewModel model)
		{
			if(!ModelState.IsValid)
			{
				return Json(new { Success = false, Message = "Not valid" });
			}
			var room = DocumentSession.Query<Room>().SingleOrDefault(m => m.Id == model.RoomId);
			if(room == null)
			{
				return Json(new { Success = false, Message = "Not valid room id" });
			}

			var roomUser = DocumentSession.Query<RoomUser>().SingleOrDefault(r => r.UserId == CurrentUser.Id && r.RoomId == room.Id);
			if(roomUser == null)
			{
				roomUser = new RoomUser() { Id = room.Id + "-" + CurrentUser.Id, LastActivity = DateTime.Now, RoomId = room.Id, UserId = CurrentUser.Id, UserName = CurrentUser.Name };
				DocumentSession.Store(roomUser);
			}
			else
			{
				roomUser.LastActivity = DateTime.Now;
			}

			Message message = new Message()
			{
				CreateDateTime = DateTime.Now,
				CreateUserId = CurrentUser.Id,
				RoomId = room.Id,
				Text = model.Text
			};
			DocumentSession.Store(message);
			DocumentSession.SaveChanges();
			return Json(new { Success = true });
		}
	}
}
