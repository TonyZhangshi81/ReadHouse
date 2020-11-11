using RHF.Business.Models.RHF;
using RHF.Core.BusinessLogic;

namespace RHF.Business.BLL.Parameters
{
	/// <summary>
	/// 
	/// </summary>
	[LogicParameter("RegisterMemberInfo")]
	public class RegisterMemberInfoBcp : LogicParameterBase
	{
		/// <summary>
		/// 
		/// </summary>
		public T_Member MemberInfo { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public override void InitParameter()
		{
			
		}
	}
}
