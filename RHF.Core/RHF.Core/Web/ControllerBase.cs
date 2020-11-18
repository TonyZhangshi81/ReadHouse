using RHF.Core.BusinessLogic;

namespace RHF.Core.Web
{
	/// <summary>
	/// 
	/// </summary>
	public abstract class ControllerBase
	{
		/// <summary>
		/// 
		/// </summary>
		private LogicExecuteHelper _LogicHelper;

		/// <summary>
		/// 
		/// </summary>
		protected LogicExecuteHelper LogicHelper
		{
			get
			{
				if (_LogicHelper == null)
				{
					_LogicHelper = new LogicExecuteHelper();
				}
				return _LogicHelper;
			}
		}
	}
}
