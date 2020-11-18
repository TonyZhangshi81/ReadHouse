using RHF.Business.BLL.Parameters;
using RHF.Business.BLL.Properties;
using RHF.Business.Common.IDAL;
using RHF.Core.BusinessLogic;
using System.Linq;

namespace RHF.Business.BLL.Implementations
{
	/// <summary>
	/// 
	/// </summary>
	[Logic("Login")]
	public class LoginBC : LogicBase<LoginBcp>
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="bcp"></param>
		/// <returns></returns>
		protected override bool Execute(LoginBcp bcp)
		{
			var tMember = this.DbContext.GetRepository<ITMemberRepository>();
			bcp.IsLogin = tMember.Entities.Any(d => d.Email.Equals(bcp.EMail) && d.Password.Equals(bcp.Password));

			if (!bcp.IsLogin)
			{
				bcp.Messages.Add(Resource.MSG00001, Core.Constants.Messages.MessageLevel.Info);
			}

			return true;
		}
	}
}
