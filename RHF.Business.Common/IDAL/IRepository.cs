
using RHF.Business.Common.DataAccess;
using RHF.Business.Models.RHF;

namespace RHF.Business.Common.IDAL
{

	/// <summary>
	/// M_BookCategory表
	/// </summary>
	public partial interface IMBookCategoryRepository : IRepositoryBase<M_BookCategory>
	{
	}

	/// <summary>
	/// R_BookCategory表
	/// </summary>
	public partial interface IRBookCategoryRepository : IRepositoryBase<R_BookCategory>
	{
	}

	/// <summary>
	/// T_Book表
	/// </summary>
	public partial interface ITBookRepository : IRepositoryBase<T_Book>
	{
	}

	/// <summary>
	/// T_LoginLog表
	/// </summary>
	public partial interface ITLoginLogRepository : IRepositoryBase<T_LoginLog>
	{
	}

	/// <summary>
	/// T_Member表
	/// </summary>
	public partial interface ITMemberRepository : IRepositoryBase<T_Member>
	{
	}
}