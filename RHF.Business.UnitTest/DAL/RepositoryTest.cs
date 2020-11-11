using Microsoft.VisualStudio.TestTools.UnitTesting;
using RHF.Business.Common.IDAL;
using RHF.Business.Models.RHF;
using RHF.Core.TestSupport;
using System.Linq;

namespace RHF.Business.UnitTest
{
	/// <summary>
	/// 
	/// </summary>
	[TestClass]
	public class RepositoryTest : TestBase
	{
		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void Test0001()
		{
			PrepareData();

			var mBookCategory = Helper.DbContext.GetRepository<IMBookCategoryRepository>();
			Assert.AreEqual(3, mBookCategory.Entities.Count());

			var tMember = Helper.DbContext.GetRepository<ITMemberRepository>();
			Assert.AreEqual(2, tMember.Entities.Count());

			var tBook = Helper.DbContext.GetRepository<ITBookRepository>();
			Assert.AreEqual(3, tBook.Entities.Count());

			var rBookCategory = Helper.DbContext.GetRepository<IRBookCategoryRepository>();

			Assert.AreEqual(5, rBookCategory.Entities.Count());
		}

		/// <summary>
		/// 
		/// </summary>
		private void PrepareData()
		{
			var mBookCategory = Helper.DbContext.GetRepository<IMBookCategoryRepository>();
			mBookCategory.AddEntitie(new M_BookCategory() { ID = 1, TypeName = "test01" });
			mBookCategory.AddEntitie(new M_BookCategory() { ID = 2, TypeName = "test02" });
			mBookCategory.AddEntitie(new M_BookCategory() { ID = 3, TypeName = "test03" });

			var tMember = Helper.DbContext.GetRepository<ITMemberRepository>();
			tMember.AddEntitie(new T_Member() { ID = 10001, Email = "user01@163.com", NickName = "u01", Password = "111", RoleType = 1, UserName = "User001" });
			tMember.AddEntitie(new T_Member() { ID = 10002, Email = "user02@163.com", NickName = "u02", Password = "222", RoleType = 1, UserName = "User002" });

			var tBook = Helper.DbContext.GetRepository<ITBookRepository>();
			var book01 = new T_Book() { MemberID = 10001, Description = "demo01", Name = "book01", CreateDateTime = System.DateTime.Now };
			tBook.AddEntitie(book01);

			var rBookCategory = Helper.DbContext.GetRepository<IRBookCategoryRepository>();
			rBookCategory.AddEntitie(new R_BookCategory() { BookID = book01.ID, BookCategoryID = 1 });
			rBookCategory.AddEntitie(new R_BookCategory() { BookID = book01.ID, BookCategoryID = 2 });

			var book02 = new T_Book() { MemberID = 10001, Description = "demo02", Name = "book02", CreateDateTime = System.DateTime.Now };
			tBook.AddEntitie(book02);
			rBookCategory.AddEntitie(new R_BookCategory() { BookID = book02.ID, BookCategoryID = 2 });
			rBookCategory.AddEntitie(new R_BookCategory() { BookID = book02.ID, BookCategoryID = 3 });

			var book03 = new T_Book() { MemberID = 10002, Description = "demo03", Name = "book03", CreateDateTime = System.DateTime.Now };
			tBook.AddEntitie(book03);
			rBookCategory.AddEntitie(new R_BookCategory() { BookID = book03.ID, BookCategoryID = 3 });

		}

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void Test0002()
		{
			PrepareData();

			var mBookCategory = Helper.DbContext.GetRepository<IMBookCategoryRepository>();
			mBookCategory.AddEntitie(new M_BookCategory() { ID = 4, TypeName = "test04" });

			Assert.AreEqual(4, mBookCategory.Entities.Count());

			var item = mBookCategory.LoadEntities(d => d.ID == 4).First();
			item.TypeName = "ttt04";
			mBookCategory.UpdateEntitie(item);

			var result = mBookCategory.LoadEntities(d => d.ID == 4).First();
			Assert.AreEqual("ttt04", result.TypeName);

			mBookCategory.DeleteEntities(b => b.ID == 4);

			var count = mBookCategory.LoadEntities(d => d.ID == 4).ToList().Count;
			Assert.AreEqual(0, count);
		}

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void Test0003()
		{
			var mBookCategory = Helper.DbContext.GetRepository<IMBookCategoryRepository>();
			mBookCategory.AddEntitie(new M_BookCategory() { ID = 1, TypeName = "test01" });
			mBookCategory.AddEntitie(new M_BookCategory() { ID = 2, TypeName = "test02" });
			mBookCategory.AddEntitie(new M_BookCategory() { ID = 3, TypeName = "test02" });
			mBookCategory.AddEntitie(new M_BookCategory() { ID = 4, TypeName = "test02" });
			mBookCategory.AddEntitie(new M_BookCategory() { ID = 5, TypeName = "test02" });
			mBookCategory.AddEntitie(new M_BookCategory() { ID = 6, TypeName = "test02" });
			mBookCategory.AddEntitie(new M_BookCategory() { ID = 7, TypeName = "test02" });
			mBookCategory.AddEntitie(new M_BookCategory() { ID = 8, TypeName = "test02" });

			var list = mBookCategory.LoadPagerEntities(3, 3, out int total, d => d.TypeName.Equals("test02"), true, d => d.ID);

			Assert.AreEqual(7, total);
			Assert.AreEqual(1, list.Count());
			Assert.AreEqual(8, list.ElementAt(0).ID);

			list = mBookCategory.LoadPagerEntities(5, 2, out total, d => d.TypeName.Equals("test02"), false, d => d.ID);
			Assert.AreEqual(7, total);
			Assert.AreEqual(2, list.Count());
			Assert.AreEqual(3, list.ElementAt(0).ID);
			Assert.AreEqual(2, list.ElementAt(1).ID);
		}
	}
}
