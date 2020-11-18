using RHF.Core.Composition;
using RHF.Core.Data;
using System.ComponentModel.Composition;

namespace RHF.Core.BusinessLogic
{
	/// <summary>
	/// 
	/// </summary>
	public class LogicExecuteHelper
	{
		/// <summary>
		/// 
		/// </summary>
		private readonly Composer _composer;

		/// <summary>
		/// 
		/// </summary>
		public IDbSession DbContext
		{
			get
			{
				return this._dbContext;
			}
		}

		private bool _composed = false;
		/// <summary>
		/// 
		/// </summary>
		private void ComposeThis()
		{
			if (this._composed)
			{
				return;
			}

			this._composer.ComposeParts(this);
			this._composed = true;
		}

		/// <summary>
		/// 
		/// </summary>
		[Import(typeof(IDbSession))]
		private IDbSession _dbContext { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Import(typeof(ILogicFactory))]
		public LogicFactory LogicFactory { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public LogicExecuteHelper()
		{
			this._composer = ComposerFactory.GetComposer(this.GetType().Assembly);
			this.ComposeThis();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="logicId"></param>
		/// <returns></returns>
		public virtual ILogic CreateLogic(string logicId)
		{
			return LogicFactory.CreateLogic(logicId);
		}
	}
}
