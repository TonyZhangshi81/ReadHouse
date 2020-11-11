using RHF.Core.Data;

namespace RHF.Business.Common.DataBase
{
	/// <summary>
	/// 
	/// </summary>
	public interface IEFContextFactory
	{
		/// <summary>
		/// 
		/// </summary>
		EFDbContext CurrentDbContext { get; }
	}
}
