
namespace RHF.Core.Data
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
