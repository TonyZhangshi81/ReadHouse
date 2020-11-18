using RHF.Core.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHF.Business.BLL.Parameters
{
	/// <summary>
	/// 
	/// </summary>
	[LogicParameter("Login")]
	public class LoginBcp : LogicParameterBase
	{
		/// <summary>
		/// 
		/// </summary>
		public bool IsLogin { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string EMail { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public override void InitParameter()
		{

		}
	}
}
