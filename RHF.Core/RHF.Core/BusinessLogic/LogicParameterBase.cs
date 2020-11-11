
using RHF.Core.Messages;
namespace RHF.Core.BusinessLogic
{
	/// <summary>
	/// 
	/// </summary>
	public abstract class LogicParameterBase : ILogicParameterBase
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual bool IsSuccess { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string InstantiationId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public LogicParameterBase()
		{
			this.IsSuccess = true;
			((ILogicParameterBase)this).TransferInfo = new LogicParameterInnerTransfer();
		}

		/// <summary>
		/// 
		/// </summary>
		public abstract void InitParameter();

		/// <summary>
		/// 
		/// </summary>
		LogicParameterInnerTransfer ILogicParameterBase.TransferInfo
		{
			get;
			set;
		}

		/// <summary>
		/// 
		/// </summary>
		public MessageCollection Messages
		{
			get
			{
				return ((ILogicParameterBase)this).TransferInfo.Messages;
			}
		}
	}
}
