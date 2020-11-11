using System;
using System.Collections.Specialized;

namespace RHF.Core.Logging
{
	/// <summary>
	/// 
	/// </summary>
	public class NLogLoggerFactoryAdapter : Common.Logging.Factory.AbstractCachingLoggerFactoryAdapter
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		public NLogLoggerFactoryAdapter(NameValueCollection properties)
			: base(true)
		{
			string configType = properties["configType"];
			string configFile = properties["configFile"];

			switch (configType.ToUpper())
			{
				case "FILE":
					NLog.LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(configFile);
					break;
			}
		}

		/// <summary>
		/// 获取指定名称的日志实例
		/// </summary>
		/// <param name="name"></param>
		protected override Common.Logging.ILog CreateLogger(string name)
		{
			return new NLogger(name);
		}

		/// <summary>
		/// 获取指定类型的日志实例
		/// </summary>
		/// <param name="name"></param>
		/// <param name="type"></param>
		protected virtual Common.Logging.ILog CreateLogger(string name, Type type)
		{
			return new NLogger(name, type);
		}
	}
}
