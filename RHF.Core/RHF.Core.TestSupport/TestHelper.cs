using RHF.Core.BusinessLogic;
using RHF.Core.Composition;
using RHF.Core.Data;
using System;
using System.ComponentModel.Composition;

namespace RHF.Core.TestSupport
{
	/// <summary>
	/// 
	/// </summary>
	public class TestHelper : IDisposable
	{
		/// <summary>
		/// 
		/// </summary>
		private readonly Composer _composer;

		/// <summary>
		/// 
		/// </summary>
		[Import(typeof(IDbSession))]
		public IDbSession DbContext { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Import(typeof(ILogicFactory))]
		public LogicFactory LogicFactory { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public TestHelper()
		{
			this._composer = ComposerFactory.GetComposer(this.GetType().Assembly);
			this._composer.ComposeParts(this);
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual void Dispose()
		{
			ComposerFactory.Reset();
		}
	}
}
