
namespace RHF.Core.BusinessLogic
{
	/// <summary>
	/// 
	/// </summary>
	public interface ILogicFactory
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="logicId"></param>
		/// <returns></returns>
		ILogic CreateLogic(string logicId);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="logicParameterId"></param>
		/// <returns></returns>
		ILogicParameterBase CreateParameter(string logicParameterId);
	}
}
