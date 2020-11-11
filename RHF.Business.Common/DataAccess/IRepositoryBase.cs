using RHF.Business.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace RHF.Business.Common.DataAccess
{
	/// <summary>
	/// 基仓储实现的方法
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	public interface IRepositoryBase<TEntity> where TEntity : class
	{
		/// <summary>
		/// 
		/// </summary>
		DbSet<TEntity> Entities { get; }

		/// <summary>
		/// 添加
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		int AddEntitie(TEntity entity);

		/// <summary>
		/// 修改
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		int UpdateEntitie(TEntity entity);

		#region DeleteEntities

		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		int DeleteEntitie(TEntity entity);

		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="entities"></param>
		/// <returns></returns>
		int DeleteEntities(IEnumerable<TEntity> entities);

		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="express"></param>
		/// <returns></returns>
		int DeleteEntities(Expression<Func<TEntity, bool>> express);

		#endregion

		/// <summary>
		/// 查询
		/// </summary>
		/// <param name="express"></param>
		/// <returns></returns>
		IQueryable<TEntity> LoadEntities(Expression<Func<TEntity, bool>> express);

		/// <summary>
		/// 分页
		/// </summary>
		/// <typeparam name="S"></typeparam>
		/// <param name="pageSize"></param>
		/// <param name="pageIndex"></param>
		/// <param name="total"></param>
		/// <param name="whereExpress"></param>
		/// <param name="isAsc"></param>
		/// <param name="orderByExpress"></param>
		/// <returns></returns>
		IQueryable<TEntity> LoadPagerEntities<S>(int pageSize, int pageIndex, out int total, Expression<Func<TEntity, bool>> whereExpress, bool isAsc, Func<TEntity, S> orderByExpress);
	}
}
