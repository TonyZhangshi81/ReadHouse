using System.Web.Mvc;
using System.Web.Security;

namespace ReadHouseOnline.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	[Authorize]
	public class MainController : Controller
	{
		//
		// GET: /Main/

		public ActionResult Index()
		{
			return View();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public ActionResult LogOut()
		{
			// 通過Forms驗證來刪除Cookie
			FormsAuthentication.SignOut();

			return Redirect(Url.Action("Index", "Main"));
		}
	}
}
