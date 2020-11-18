using RHF.Business.BLL.Parameters;
using RHF.Business.Models.RHF;
using RHF.Core.BusinessLogic;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
		private LogicExecuteHelper _LogicHelper;

		/// <summary>
		/// 
		/// </summary>
		protected LogicExecuteHelper LogicHelper
		{
			get
			{
				if (_LogicHelper == null)
				{
					_LogicHelper = new LogicExecuteHelper();
				}
				return _LogicHelper;
			}
		}

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
			if (ModelState.IsValid)
			{
				var logic = LogicHelper.CreateLogic("Login");
				var bcp = (LoginBcp)LogicHelper.LogicFactory.CreateParameter("Login");

				bcp.EMail = member.Email;
				bcp.Password = member.Password;
				logic.Execute(bcp);

				if (bcp.IsLogin)
				{
					var authTicket = new FormsAuthenticationTicket(1, member.Email, DateTime.Now, DateTime.Now.AddMinutes(10), true, "/");

					string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

					var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
					{
						HttpOnly = true
					};
					Response.Cookies.Add(authCookie);

					return Redirect(Url.Action("Index", "Main"));
				}
				else
				{
					return JavaScript(@"RHF.Login.showMessage('" + bcp.Messages.ElementAt(0).Message + "');");
				}
			}

			return View(member);
		}
	}
}
