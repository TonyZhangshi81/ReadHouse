using RHF.Core.Composition.MetaData;
using System;
using System.ComponentModel.Composition;

namespace RHF.Core.BusinessLogic
{
	/// <summary>
	/// 
	/// </summary>
	[MetadataAttribute, AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class LogicAttribute : ExportAttribute, ILogicMetaData
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="logicId"></param>
		public LogicAttribute(string logicId)
			: base(typeof(ILogic))
		{
			this.LogicId = logicId;
		}

		/// <summary>
		/// 
		/// </summary>
		public string LogicId
		{
			get;
			private set;
		}
	}
}
