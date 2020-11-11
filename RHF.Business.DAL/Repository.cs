

using RHF.Business.Common.DataAccess;
using RHF.Business.Common.IDAL;
using RHF.Business.Models.RHF;
using RHF.Core.Data;

namespace RHF.Business.DAL.Repository
{

	/// <summary>
	/// M_BookCategory表
	/// </summary>
	[Repository(typeof(IMBookCategoryRepository))]
	internal partial class MBookCategoryRepository : RepositoryBase<M_BookCategory>, IMBookCategoryRepository, IRepositoryMetaType
	{
	}


	/// <summary>
	/// R_BookCategory表
	/// </summary>
	[Repository(typeof(IRBookCategoryRepository))]
	internal partial class RBookCategoryRepository : RepositoryBase<R_BookCategory>, IRBookCategoryRepository, IRepositoryMetaType
	{
	}


	/// <summary>
	/// T_Book表
	/// </summary>
	[Repository(typeof(ITBookRepository))]
	internal partial class TBookRepository : RepositoryBase<T_Book>, ITBookRepository, IRepositoryMetaType
	{
	}


	/// <summary>
	/// T_LoginLog表
	/// </summary>
	[Repository(typeof(ITLoginLogRepository))]
	internal partial class TLoginLogRepository : RepositoryBase<T_LoginLog>, ITLoginLogRepository, IRepositoryMetaType
	{
	}


	/// <summary>
	/// T_Member表
	/// </summary>
	[Repository(typeof(ITMemberRepository))]
	internal partial class TMemberRepository : RepositoryBase<T_Member>, ITMemberRepository, IRepositoryMetaType
	{
	}

}