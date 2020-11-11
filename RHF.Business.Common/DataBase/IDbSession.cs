using System.Data.Common;

namespace RHF.Business.Common.DataBase
{
	/// <summary>
	/// 添加接口，起约束作用
	/// </summary>
	public partial interface IDbSession
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		int SaveChanges();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="strSql"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		int ExcuteSql(string strSql, DbParameter[] parameters);
	}
}
