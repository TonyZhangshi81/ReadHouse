using RHF.Core.Composition.MetaData;
using System;
using System.ComponentModel.Composition;

namespace RHF.Core.BusinessLogic
{
	/// <summary>
	/// 
	/// </summary>
	[MetadataAttribute, AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class LogicParameterAttribute : ExportAttribute, ILogicParameterMetaData
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="logicParameterId"></param>
		public LogicParameterAttribute(string logicParameterId)
			: base(typeof(ILogicParameterBase))
		{
			this.LogicParameterId = logicParameterId;
		}

		/// <summary>
		/// 
		/// </summary>
		public string LogicParameterId
		{
			get;
			private set;
		}
	}
}
