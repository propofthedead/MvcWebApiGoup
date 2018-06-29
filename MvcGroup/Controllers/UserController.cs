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
    public class UserController : ApiController
    {
		private GroupContext db = new GroupContext();

		[HttpGet]
		[ActionName("List")]
		public JsonResponse List() {
			var Users = db.Users.ToArray();
			return new JsonResponse { Data = Users };
		}
		[HttpGet]
		[ActionName("Get")]
		public JsonResponse Get(int? id) {
			if (id == null)
				return new JsonResponse { Error = "null", Message = "failed" };
			var user = db.Users.Find(id);
			return new JsonResponse { Data = user };
		}
		[HttpPost]
		[ActionName("Add")]
		public JsonResponse Add(User user)
		{
			if (user == null)
				return new JsonResponse { Error = "null", Message = "failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = "not valid", Message = "Failed" };
			db.Users.Add(user);
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpPost]
		[ActionName("Edit")]
		public JsonResponse Edit(User user) {
			if (user == null)
				return new JsonResponse { Error = "null", Message = "failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = "not valid", Message = "Failed" };
			var u = db.Users.Find(user.Id);
			u.Name = user.Name;
			u.Password = user.Password;
			u.Username = user.Username;
			u.Email = user.Email;
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpPost]
		[ActionName("Delete")]
		public JsonResponse Delete(int? Id) {
			if (Id == null)
				return new JsonResponse { Error = "null", Message = "failed" };
			var user = db.Users.Find(Id);
			db.Users.Remove(user);
			db.SaveChanges();
			return new JsonResponse();
		}
	}
}
