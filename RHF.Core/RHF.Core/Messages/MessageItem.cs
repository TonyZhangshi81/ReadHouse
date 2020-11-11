using RHF.Core.Constants.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHF.Core.Messages
{
	/// <summary>
	/// 
	/// </summary>
	public class MessageItem
	{
		/// <summary>
		/// 
		/// </summary>
		public string Message
		{
			get;
			internal set;
		}

		/// <summary>
		/// 
		/// </summary>
		public MessageLevel Level
		{
			get;
			internal set;
		}
	}
}
