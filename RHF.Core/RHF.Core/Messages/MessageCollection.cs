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
	public class MessageCollection : System.Collections.Generic.HashSet<MessageItem>
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		/// <param name="level"></param>
		/// <param name="args"></param>
		public void Add(string message, MessageLevel level, params object[] args)
		{
			this.Add(MessageUtil.Get(message, level, args));
		}
	}
}
