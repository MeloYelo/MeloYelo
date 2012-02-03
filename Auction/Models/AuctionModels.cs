using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction.Models
{
	public class User : IModel
	{
		public string Id { get; set; }
		public string EmailAddress { get; set; }
		public string Name { get; set; }
		public bool IsDeleted { get; set; }
	}

	public class Auction : IModel
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public AuctionEvent AuctionEvent { get; set; }
		public AuctionEvent PreviewEvent { get; set; }
		public string DefaultImageId { get; set; }
		public DateTime CreateDateTime { get; set; }
	}

	public class AuctionEvent
	{
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
		public Location Location { get; set; }
	}

	public class Location : IModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public Address Address { get; set; }
		public bool IsSaved { get; set; }
	}

	public class Address
	{
		public string Line1 { get; set; }
		public string Line2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }
	}

	public class AuctionItem : IModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public AuctionItemCategory Category { get; set; }
		public DateTime CreateDateTime { get; set; }
	}

	public class AuctionItemCategory : IModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public bool IsHidden { get; set; }
	}

	public class AuctionImage:IModel
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string AuctionId { get; set; }
		public string AuctionItemId { get; set; }
		public bool IsDeleted { get; set; }
	}


}