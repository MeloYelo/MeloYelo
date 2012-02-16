using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WeddingAddress.Models
{
	public class Address
	{
		public string Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Line1 { get; set; }
		public string Line2 { get; set; }

		[Required]
		public string City { get; set; }

		[Required]
		public string State { get; set; }

		[Required]
		public string Zip { get; set; }
		public string Message { get; set; }
		public DateTime InsertDateTime { get; set; }
		public string IPAddress { get; set; }
	}
}