using RHF.Core.Composition.MetaData;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace RHF.Core.BusinessLogic
{
	/// <summary>
	/// 
	/// </summary>
	[PartCreationPolicy(CreationPolicy.NonShared)]
	[Export(typeof(ILogicFactory))]
	public class LogicFactory : ILogicFactory
	{
		/// <summary>
		/// 
		/// </summary>
		private static readonly ConcurrentDictionary<string, Type> LogicTypeCache = new ConcurrentDictionary<string, Type>();
		/// <summary>
		/// 
		/// </summary>
		private static readonly ConcurrentDictionary<string, Type> ParameterTypeCache = new ConcurrentDictionary<string, Type>();

		/// <summary>
		/// 
		/// </summary>
		[ImportMany(RequiredCreationPolicy = CreationPolicy.NonShared)]
		public IEnumerable<Lazy<ILogic, ILogicMetaData>> Logics
		{
			get;
			set;
		}

		/// <summary>
		/// 
		/// </summary>
		[ImportMany(RequiredCreationPolicy = CreationPolicy.NonShared)]
		public IEnumerable<Lazy<ILogicParameterBase, ILogicParameterMetaData>> LogicParameters
		{
			get;
			set;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="logicId"></param>
		/// <returns></returns>
		public virtual ILogic CreateLogic(string logicId)
		{
			var type = LogicTypeCache.GetOrAdd(
				logicId,
				(id) =>
				{
					var logics = this.Logics.Where(_ => _.Metadata.LogicId.Contains(logicId));
					if (logics.Count() == 0)
					{
						throw new NotImplementedException();
					}
					return logics.First().Value.GetType();
				});

			return (ILogic)Activator.CreateInstance(type);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="logicParameterId"></param>
		/// <returns></returns>
		public virtual ILogicParameterBase CreateParameter(string logicParameterId)
		{
			var type = ParameterTypeCache.GetOrAdd(
				logicParameterId,
				(id) =>
				{
					var parameters = this.LogicParameters.Where(_ => _.Metadata.LogicParameterId.Contains(logicParameterId));
					if (parameters.Count() == 0)
					{
						throw new NotImplementedException();
					}
					return parameters.First().Value.GetType();
				});

			var parameter = (ILogicParameterBase)Activator.CreateInstance(type);
			parameter.InstantiationId = logicParameterId;
			return parameter;
		}
	}
}
