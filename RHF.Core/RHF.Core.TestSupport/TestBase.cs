using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Transactions;

namespace RHF.Core.TestSupport
{
	/// <summary>
	/// 
	/// </summary>
	public abstract class TestBase : IDisposable
	{
		private readonly IsolationLevel _isolationLevel = IsolationLevel.Unspecified;
		private readonly TransactionScopeOption _scopeOption = TransactionScopeOption.Required;
		private TransactionScope _transactionScope;

		/// <summary>
		/// 
		/// </summary>
		private TestHelper _THelper;

		/// <summary>
		/// 
		/// </summary>
		protected TestHelper Helper
		{
			get
			{
				if (_THelper == null)
				{
					_THelper = new TestHelper();
				}
				return _THelper;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[TestInitialize]
		public void AutoRollbackBefore()
		{
			if (SetAutoRollback)
			{
				var options = new TransactionOptions
				{
					IsolationLevel = _isolationLevel,
					Timeout = new TimeSpan(0, 1, 0)
				};
				_transactionScope = new TransactionScope(_scopeOption, options);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[TestCleanup]
		public void AutoRollbackAfter()
		{
			if (SetAutoRollback)
			{
				if (_transactionScope == null)
				{
					throw new InvalidOperationException("un init TransactionScope");
				}

				_transactionScope.Dispose();
				_transactionScope = null;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		protected virtual bool SetAutoRollback
		{
			get
			{
				return true;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual void Dispose()
		{
			if (_THelper != null)
			{
				_THelper.Dispose();
				_THelper = null;
			}
		}
	}
}
