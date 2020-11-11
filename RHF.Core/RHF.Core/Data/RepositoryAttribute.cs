using RHF.Core.Composition.MetaData;
using System;
using System.ComponentModel.Composition;

namespace RHF.Core.Data
{
	/// <summary>
	/// 
	/// </summary>
	[MetadataAttribute, AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class RepositoryAttribute : ExportAttribute, IRepositoryMetaData
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="repository"></param>
		public RepositoryAttribute(Type repository)
			: base(typeof(IRepositoryMetaType))
		{
			Repository = repository;
		}

		/// <summary>
		/// 
		/// </summary>
		public Type Repository
		{
			get;
			private set;
		}
	}
}
