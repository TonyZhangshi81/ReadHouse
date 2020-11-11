using System;
using System.Linq;

namespace RHF.Core.DataAccess
{
	/// <summary>
	/// 基仓储实现的方法
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	public interface IRepository<TEntity> where TEntity : class
	{
		/// <summary>
		/// 添加
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		TEntity AddEntities(TEntity entity);

		/// <summary>
		/// 修改
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		bool UpdateEntities(TEntity entity);


		/// <summary>
		/// 修改
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		bool DeleteEntities(TEntity entity);


		/// <summary>
		/// 查询
		/// </summary>
		/// <param name="wherelambda"></param>
		/// <returns></returns>
		IQueryable<TEntity> LoadEntities(Func<TEntity, bool> wherelambda);

		/// <summary>
		/// 分页
		/// </summary>
		/// <typeparam name="S"></typeparam>
		/// <param name="pageSize"></param>
		/// <param name="pageIndex"></param>
		/// <param name="total"></param>
		/// <param name="whereLambda"></param>
		/// <param name="isAsc"></param>
		/// <param name="orderByLambda"></param>
		/// <returns></returns>
		IQueryable<TEntity> LoadPagerEntities<S>(int pageSize, int pageIndex, out int total, Func<TEntity, bool> whereLambda, bool isAsc, Func<TEntity, S> orderByLambda);
	}
}
