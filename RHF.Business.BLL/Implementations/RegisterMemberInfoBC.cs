using RHF.Business.BLL.Parameters;
using RHF.Business.Common.IDAL;
using RHF.Core.BusinessLogic;
using System.Linq;

namespace RHF.Business.BLL.Implementations
{
	/// <summary>
	/// 
	/// </summary>
	[Logic("RegisterMemberInfo")]
	internal class RegisterMemberInfoBC : LogicBase<RegisterMemberInfoBcp>
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="param"></param>
		/// <returns></returns>
		protected override bool Execute(RegisterMemberInfoBcp param)
		{
			var tMember = DbContext.GetRepository<ITMemberRepository>();
			if (tMember.LoadEntities(d => d.ID == param.MemberInfo.ID).Any())
			{
				tMember.UpdateEntitie(param.MemberInfo);
			}
			else
			{
				tMember.AddEntitie(param.MemberInfo);
			}

			DbContext.Commit();

			return true;
		}
	}
}
