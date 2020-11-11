using System.Data.Common;

namespace RHF.Core.Data
{
	/// <summary>
	/// 添加接口，起约束作用
	/// </summary>
	public partial interface IDbSession
	{
		T GetRepository<T>();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="validateOnSaveEnabled"></param>
		/// <returns></returns>
		int Commit(bool validateOnSaveEnabled = true);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="strSql"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		int ExcuteSql(string strSql, DbParameter[] parameters);
	}
}
