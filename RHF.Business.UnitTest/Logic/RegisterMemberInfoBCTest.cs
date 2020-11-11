using Microsoft.VisualStudio.TestTools.UnitTesting;
using RHF.Business.BLL.Parameters;
using RHF.Business.Common.IDAL;
using RHF.Business.Models.RHF;
using RHF.Core.TestSupport;
using System.Linq;

namespace RHF.Business.UnitTest.Logic
{
	/// <summary>
	/// 
	/// </summary>
	[TestClass]
	public class RegisterMemberInfoBCTest : TestBase
	{
		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void Test0001()
		{
			var tMember = Helper.DbContext.GetRepository<ITMemberRepository>();
			tMember.DeleteEntities(m => m.ID == 10001);

			var logic = Helper.LogicFactory.CreateLogic("RegisterMemberInfo");
			var bcp = (RegisterMemberInfoBcp)Helper.LogicFactory.CreateParameter("RegisterMemberInfo");


			bcp.MemberInfo = new T_Member() { ID = 10001, Email = "user01@163.com", NickName = "u01", Password = "111", RoleType = 1, UserName = "User001" };
			logic.Execute(bcp);

			Assert.IsTrue(bcp.IsSuccess);

			var expected = Helper.DbContext.GetRepository<ITMemberRepository>();
			var list = expected.LoadEntities(d => d.ID == 10001);
			Assert.IsTrue(list.Any());
			Assert.AreEqual(1, list.Count());
			Assert.AreEqual(bcp.MemberInfo.Email, list.ElementAt(0).Email);
			Assert.AreEqual(bcp.MemberInfo.NickName, list.ElementAt(0).NickName);
			Assert.AreEqual(bcp.MemberInfo.Password, list.ElementAt(0).Password);
			Assert.AreEqual(bcp.MemberInfo.RoleType, list.ElementAt(0).RoleType);
			Assert.AreEqual(bcp.MemberInfo.UserName, list.ElementAt(0).UserName);
		}

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void Test0002()
		{
			PrepareData();

			var logic = Helper.LogicFactory.CreateLogic("RegisterMemberInfo");
			var bcp = (RegisterMemberInfoBcp)Helper.LogicFactory.CreateParameter("RegisterMemberInfo");

			var tMember = Helper.DbContext.GetRepository<ITMemberRepository>().LoadEntities(d => d.ID == 10002).First();
			tMember.Email = "user03@163.com";
			bcp.MemberInfo = tMember;
			logic.Execute(bcp);

			Assert.IsTrue(bcp.IsSuccess);

			var list = Helper.DbContext.GetRepository<ITMemberRepository>().LoadEntities(d => d.ID == 10002);
			Assert.IsTrue(list.Any());
			Assert.AreEqual(1, list.Count());
			Assert.AreEqual(bcp.MemberInfo.Email, list.ElementAt(0).Email);
			Assert.AreEqual(bcp.MemberInfo.NickName, list.ElementAt(0).NickName);
			Assert.AreEqual(bcp.MemberInfo.Password, list.ElementAt(0).Password);
			Assert.AreEqual(bcp.MemberInfo.RoleType, list.ElementAt(0).RoleType);
			Assert.AreEqual(bcp.MemberInfo.UserName, list.ElementAt(0).UserName);
		}

		/// <summary>
		/// 
		/// </summary>
		private void PrepareData()
		{
			var tMember = Helper.DbContext.GetRepository<ITMemberRepository>();
			tMember.AddEntitie(new T_Member() { ID = 10001, Email = "user01@163.com", NickName = "u01", Password = "111", RoleType = 1, UserName = "User001" });
			tMember.AddEntitie(new T_Member() { ID = 10002, Email = "user02@163.com", NickName = "u02", Password = "222", RoleType = 1, UserName = "User002" });

			Helper.DbContext.Commit();
		}
	}
}
