using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcGroup.Models
{
	public class GroupContext : DbContext
	{
		public GroupContext() : base() {}


		public DbSet<User> Users { get; set; }
		public DbSet<Item> Items { get; set; }
	}
}