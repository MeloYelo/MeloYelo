using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Chat.Models;

namespace Chat.ViewModels
{
	public class UserCreateViewModel
	{
		[Required(ErrorMessage = "* required")]
		public string Name { get; set; }
	}

	public class RoomCreateViewModel
	{
		[Required(ErrorMessage = "* required")]
		public string Name { get; set; }
	}

	public class RoomChatViewModel
	{
		public Room Room { get; set; }
		public User CurrentUser { get; set; }
	}

	public class RoomSubmitMessageViewModel
	{
		[Required]
		public string RoomId { get; set; }

		[Required]
		public string Text { get; set; }
	}
}