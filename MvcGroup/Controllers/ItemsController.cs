using MvcGroup.Models;
using MvcGroup.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcGroup.Controllers
{
    public class ItemsController : ApiController
    {
		private GroupContext db = new GroupContext();

		[HttpGet]
		[ActionName("List")]
		public JsonResponse List() {
			var items = db.Items.ToArray();
			return new JsonResponse { Data = items };
		}

		[HttpPost]
		[ActionName("Add")]
		public JsonResponse Add(Item item) {
			if (item == null)
				return new JsonResponse { Error = "null", Message = "failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = "non valid", Message = "failed" };
			db.Items.Add(item);
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpPost]
		[ActionName("Edit")]
		public JsonResponse Edit(Item item) {
			if (item == null)
				return new JsonResponse { Error = "null", Message = "failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = "non valid", Message = "failed" };
			var i = db.Items.Find(item.Id);
			i.User = item.User;
			i.UserId = item.UserId;
			i.Task = item.Task;
			i.Description = item.Description;
			i.Date = item.Date;
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpPost]
		[ActionName("Delete")]
		public JsonResponse Delete(int? id) {
			if (id == null)
				return new JsonResponse { Error = "null", Message = "failed" };
			var item = db.Items.Find(id);
			db.Items.Remove(item);
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpPost]
		[ActionName("Finished")]
		public JsonResponse Finished(int? id) {
			if (id == null)
				return new JsonResponse { Error = "null", Message = "failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = "non valid", Message = "failed" };
			var item = db.Items.Find(id);
			item.IsFinished = true;
			db.SaveChanges();
			return new JsonResponse();
		}
    }
}
