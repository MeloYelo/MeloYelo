using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Models
{
	public class Room
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public DateTime CreateDateTime { get; set; }
		public string CreateUserId { get; set; }
	}

	public class User
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public DateTime CreateDateTime { get; set; }
	}

	public class Message
	{
		public string Id { get; set; }
		public string RoomId { get; set; }
		public string Text { get; set; }
		public DateTime CreateDateTime { get; set; }
		public string CreateUserId { get; set; }
	}

	public class RoomUser
	{
		public string Id { get; set; }
		public string RoomId { get; set; }
		public string UserId { get; set; }
		public string UserName { get; set; }
		public DateTime LastActivity { get; set; }
	}
}