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
	public static class MessageUtil
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="text"></param>
		/// <param name="level"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		public static MessageItem Get(string text, MessageLevel level, params object[] args)
		{
			IMessage message = new Message();

			return message.Get(text, level, args);
		}
	}
}
