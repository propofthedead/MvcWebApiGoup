using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGroup.Models
{
	public class Item
	{
		public int Id { get; set; }
		public string Task { get; set; }
		public string Description { get; set; }
		public bool IsFinished { get; set; }
		public int UserId { get; set; }
		public virtual User User { get; set; }
		public DateTime Date { get; set; }
		public Item() { }
	}
}