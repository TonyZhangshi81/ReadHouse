using Common.Logging;
using RHF.Core.Data;
using RHF.Core.Logging;
using System;
using System.Transactions;

namespace RHF.Core.BusinessLogic
{
	/// <summary>
	/// 
	/// </summary>
	public abstract class LogicBase<T> : ILogic
		where T : LogicParameterBase, new()
	{
		/// <summary>
		/// 
		/// </summary>
		private static readonly ILog Log = LogManager.GetLogger(typeof(T));

		/// <summary>
		/// 
		/// </summary>
		private LogicExecuteHelper _helper;

		/// <summary>
		/// 
		/// </summary>
		private LogicExecuteHelper Helper
		{
			get
			{
				return this._helper ?? (this._helper = new LogicExecuteHelper());
			}
		}

		/// <summary>
		/// 
		/// </summary>
		protected IDbSession DbContext
		{
			get
			{
				return this.Helper.DbContext;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="param"></param>
		/// <returns></returns>
		public virtual void Execute(LogicParameterBase param)
		{
			LogUtil.LogBeginLogic(param.InstantiationId);

			var p = (T)param;
			try
			{
				p.IsSuccess = this.Execute(p);
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message, ex);
				throw;
			}
			finally
			{
				LogUtil.LogEndLogic(param.InstantiationId);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="param"></param>
		/// <returns></returns>
		protected abstract bool Execute(T param);

		/// <summary>
		/// 
		/// </summary>
		void IDisposable.Dispose()
		{
		}
	}
}