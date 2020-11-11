
namespace RHF.Core.BusinessLogic
{
	/// <summary>
	/// 
	/// </summary>
	public interface ILogicParameterBase
	{
		/// <summary>
		/// 
		/// </summary>
		void InitParameter();

		/// <summary>
		/// 
		/// </summary>
		LogicParameterInnerTransfer TransferInfo
		{
			get;
			set;
		}

		/// <summary>
		/// 
		/// </summary>
		bool IsSuccess
		{
			get;
			set;
		}

		/// <summary>
		/// 
		/// </summary>
		string InstantiationId
		{
			get;
			set;
		}
	}
}
