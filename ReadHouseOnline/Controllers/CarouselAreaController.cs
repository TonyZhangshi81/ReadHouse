using RHF.Business.Models.RHF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReadHouseOnline.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	public class CarouselAreaController : Controller
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public ActionResult Index()
		{
			this.CarouselBooksInit();

			return PartialView("~/Views/Shared/User/CarouselArea.cshtml");
		}

		/// <summary>
		/// 
		/// </summary>
		private void CarouselBooksInit()
		{
			this.ViewData.Add("active", new List<T_Book>()
									{
										new T_Book(){ ID = 1,  Name = "001", Description = "~/Content/image/books/001.jpg" },
										new T_Book(){ ID = 1,  Name = "002", Description = "~/Content/image/books/002.jpg" },
										new T_Book(){ ID = 1,  Name = "003", Description = "~/Content/image/books/003.jpg" },
										new T_Book(){ ID = 1,  Name = "004", Description = "~/Content/image/books/004.jpg" },
										new T_Book(){ ID = 1,  Name = "005", Description = "~/Content/image/books/005.jpg" },
										new T_Book(){ ID = 1,  Name = "006", Description = "~/Content/image/books/006.jpg" },
										new T_Book(){ ID = 1,  Name = "007", Description = "~/Content/image/books/007.jpg" },
										new T_Book(){ ID = 1,  Name = "008", Description = "~/Content/image/books/008.jpg" },
										new T_Book(){ ID = 1,  Name = "009", Description = "~/Content/image/books/009.jpg" },
										new T_Book(){ ID = 1,  Name = "010", Description = "~/Content/image/books/010.jpg" },
									});

			this.ViewData.Add("carousel1", new List<T_Book>()
									{
										new T_Book(){ ID = 1,  Name = "001", Description = "~/Content/image/books/011.jpg" },
										new T_Book(){ ID = 1,  Name = "002", Description = "~/Content/image/books/012.jpg" },
										new T_Book(){ ID = 1,  Name = "003", Description = "~/Content/image/books/013.jpg" },
										new T_Book(){ ID = 1,  Name = "004", Description = "~/Content/image/books/014.jpg" },
										new T_Book(){ ID = 1,  Name = "005", Description = "~/Content/image/books/015.jpg" },
										new T_Book(){ ID = 1,  Name = "006", Description = "~/Content/image/books/008.jpg" },
										new T_Book(){ ID = 1,  Name = "007", Description = "~/Content/image/books/016.jpg" },
										new T_Book(){ ID = 1,  Name = "008", Description = "~/Content/image/books/017.jpg" },
										new T_Book(){ ID = 1,  Name = "009", Description = "~/Content/image/books/018.jpg" },
										new T_Book(){ ID = 1,  Name = "010", Description = "~/Content/image/books/019.jpg" },
									});

			this.ViewData.Add("carousel2", new List<T_Book>()
									{
										new T_Book(){ ID = 1,  Name = "001", Description = "~/Content/image/books/023.jpg" },
										new T_Book(){ ID = 1,  Name = "002", Description = "~/Content/image/books/022.jpg" },
										new T_Book(){ ID = 1,  Name = "003", Description = "~/Content/image/books/014.jpg" },
										new T_Book(){ ID = 1,  Name = "004", Description = "~/Content/image/books/016.jpg" },
										new T_Book(){ ID = 1,  Name = "005", Description = "~/Content/image/books/007.jpg" },
										new T_Book(){ ID = 1,  Name = "006", Description = "~/Content/image/books/008.jpg" },
										new T_Book(){ ID = 1,  Name = "007", Description = "~/Content/image/books/019.jpg" },
										new T_Book(){ ID = 1,  Name = "008", Description = "~/Content/image/books/005.jpg" },
										new T_Book(){ ID = 1,  Name = "009", Description = "~/Content/image/books/008.jpg" },
										new T_Book(){ ID = 1,  Name = "010", Description = "~/Content/image/books/006.jpg" },
									});
		}
	}
}
