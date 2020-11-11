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
	public class Message : IMessage
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		/// <param name="level"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		public MessageItem Get(string message, MessageLevel level, params object[] args)
		{
			return new MessageItem() {
				Message = message,
				Level = level
			};
		}
	}
}
