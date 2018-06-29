using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcGroup.Models
{
	public class Item
	{
		public int Id { get; set; }
		[StringLength(20)]
		public string Task { get; set; }
		[StringLength(200)]
		public string Description { get; set; }

		public bool IsFinished { get; set; }
		[Required]
		public int UserId { get; set; }
		[Required]
		public virtual User User { get; set; }
		[Required]
		public DateTime Date { get; set; }
		public Item() { }
	}
}