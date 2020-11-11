using RHF.Business.Models.RHF;
using System;
using System.Web.Mvc;

namespace ReadHouseOnline.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	public class HomeController : Controller
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public ActionResult Index()
		{
			var member = new T_Member();
			return View(member);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="member"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult Index(T_Member member)
		{
			/*
			if (String.IsNullOrEmpty(member.Email))
			{
				ModelState.AddModelError("Email", "用户名不能为空");
			}
			if (String.IsNullOrEmpty(member.Password))
			{
				ModelState.AddModelError("Password", "密码不能为空");
			}
			if ("password".Equals(member.Password))
			{
				ModelState.AddModelError("Password", "密码不能为password");
			}
			 * */

			if (ModelState.IsValid)
			{
				if ("my@test.com".Equals(member.Email) && "111".Equals(member.Password))
				{
					return Redirect(Url.Action("Index", "Main"));
				}
			}

			return View(member);
		}
	}
}
