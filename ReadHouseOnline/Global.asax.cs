using RHF.Core.Composition;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace ReadHouseOnline
{
	// メモ: IIS6 または IIS7 のクラシック モードの詳細については、
	// http://go.microsoft.com/?LinkId=9394801 を参照してください
	public class MvcApplication : System.Web.HttpApplication
	{
		/// <summary>
		/// 
		/// </summary>
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			ViewEngines.Engines.Clear();
			ViewEngines.Engines.Add(
									new RazorViewEngine
									{
										PartialViewLocationFormats = new[]
										{
											"~/Views/{1}/{0}.cshtml",
											"~/Views/Shared/{0}.cshtml",
											"~/Views/Shared/User/{1}.cshtml"
										}
									});

			WebApiConfig.Register(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);

			var path = this.Server.MapPath("~/bin");
			var catalog = new AggregateCatalog();
			ComposerFactory.GetCatalog(path).ToList().ForEach(catalog.Catalogs.Add);
			var container = new CompositionContainer(catalog, true);

			//ContainerHolder.Init(container);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{
			// 獲取Cookie
			HttpCookie authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
			if (authCookie == null || authCookie.Value == "")
			{
				return;
			}

			FormsAuthenticationTicket authTicket;
			try
			{
				// 解析Cookie
				authTicket = FormsAuthentication.Decrypt(authCookie.Value);
			}
			catch
			{
				return;
			}

			// 解析權限
			string[] roles = authTicket.UserData.Split(';');

			if (Context.User != null)
			{
				// 把權限賦值給當前用戶
				Context.User = new GenericPrincipal(Context.User.Identity, roles);
			}
		}
	}
}