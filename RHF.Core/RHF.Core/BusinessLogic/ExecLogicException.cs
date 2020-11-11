using System;
using System.Runtime.Serialization;

namespace RHF.Core.BusinessLogic
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class ExecLogicException : Exception
	{
		/// <summary>
		/// 
		/// </summary>
		public ExecLogicException()
			: base()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		public ExecLogicException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		public ExecLogicException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		/// <param name="ex"></param>
		public ExecLogicException(string message, Exception ex)
			: base(message, ex)
		{
		}
	}
}
