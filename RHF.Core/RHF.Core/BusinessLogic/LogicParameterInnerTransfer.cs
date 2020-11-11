using RHF.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHF.Core.BusinessLogic
{
	public class LogicParameterInnerTransfer
	{
		/// <summary>
		/// 
		/// </summary>
		public MessageCollection Messages
		{
			get;
			set;
		}

		/// <summary>
		/// 
		/// </summary>
		public bool IsSuccessProceeding
		{
			get;
			set;
		}

		/// <summary>
		/// 
		/// </summary>
		public LogicParameterInnerTransfer()
		{
			this.Messages = new MessageCollection();
			this.IsSuccessProceeding = true;
		}
	}
}
