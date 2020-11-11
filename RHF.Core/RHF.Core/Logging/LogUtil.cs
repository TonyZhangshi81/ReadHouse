using Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHF.Core.Logging
{
	/// <summary>
	/// 
	/// </summary>
	internal static class LogUtil
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="log"></param>
		/// <param name="createContext"></param>
		public static void Loginfo(ILog log, Func<string> createContext)
		{
			var context = string.Empty;

			if (log.IsInfoEnabled)
			{
				if (string.IsNullOrEmpty(context))
				{
					context = createContext();
				}
				log.Info(context);
			}
		}

		private static readonly ILog LogicLogging = LogManager.GetLogger("Logic");

		private const string LogicBeginLogContext = "BC开始执行";
		private const string LogicEndLogContext = "BC执行完毕";

		/// <summary>
		/// 
		/// </summary>
		/// <param name="logicId"></param>
		public static void LogBeginLogic(string logicId)
		{
			Loginfo(LogicLogging, () => string.Format("{0} {1}", logicId, LogicBeginLogContext));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="logicId"></param>
		public static void LogEndLogic(string logicId)
		{
			Loginfo(LogicLogging, () => string.Format("{0} {1}", logicId, LogicEndLogContext));
		}
	}
}
