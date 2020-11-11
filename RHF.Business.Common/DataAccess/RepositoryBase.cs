using Common.Logging;
using RHF.Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace RHF.Business.Common.DataAccess
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	public abstract class RepositoryBase<TEntity> where TEntity : class
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(TEntity));

		/// <summary>
		/// 获取的实当前线程内部的上下文实例，而且保证了线程内上下文实例唯一
		/// </summary>
		private readonly EFDbContext db = EFContextFactory.GetCurrentDbContext();

		/// <summary>
		/// 
		/// </summary>
		[Import(typeof(IDbSession))]
		private IDbSession DBContext { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DbSet<TEntity> Entities
		{
			get { return db.Set<TEntity>(); }
		}

		/// <summary>
		/// 添加
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public int AddEntitie(TEntity entity)
		{
			try
			{
				db.Entry(entity).State = EntityState.Added;
				return DBContext.Commit();
			}
			catch(Exception ex)
			{
				Log.Error(ex.Message, ex);
				throw ex;
			}
		}

		/// <summary>
		/// 修改
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public int UpdateEntitie(TEntity entity)
		{
			try
			{
				db.Set<TEntity>().Attach(entity);
				db.Entry(entity).State = EntityState.Modified;
				return DBContext.Commit();
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message, ex);
				throw ex;
			}
		}

		#region DeleteEntitie

		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public int DeleteEntitie(TEntity entity)
		{
			try
			{
				db.Set<TEntity>().Attach(entity);
				db.Entry(entity).State = EntityState.Deleted;
				return DBContext.Commit();
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message, ex);
				throw ex;
			}
		}

		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="entities"></param>
		/// <returns></returns>
		public int DeleteEntities(IEnumerable<TEntity> entities)
		{
			try
			{
				foreach (var entity in entities)
				{
					DeleteEntitie(entity);
				}
				return DBContext.Commit();
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message, ex);
				throw ex;
			}
		}

		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="express"></param>
		/// <returns></returns>
		public int DeleteEntities(Expression<Func<TEntity, bool>> express)
		{
			try
			{
				Func<TEntity, bool> lamada = express.Compile();
				var lstEntity = db.Set<TEntity>().Where(lamada);
				DeleteEntities(lstEntity);
				return DBContext.Commit();
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message, ex);
				throw ex;
			}
		}

		#endregion

		/// <summary>
		/// 查询
		/// </summary>
		/// <param name="express"></param>
		/// <returns></returns>
		public IQueryable<TEntity> LoadEntities(Expression<Func<TEntity, bool>> express)
		{
			try
			{
				Func<TEntity, bool> lamada = express.Compile();
				return db.Set<TEntity>().Where(lamada).AsQueryable();
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message, ex);
				throw ex;
			}
		}

		/// <summary>
		/// 分页
		/// </summary>
		/// <typeparam name="S"></typeparam>
		/// <param name="pageSize"></param>
		/// <param name="pageIndex"></param>
		/// <param name="total"></param>
		/// <param name="whereExpress"></param>
		/// <param name="isAsc"></param>
		/// <param name="orderByLambda"></param>
		/// <returns></returns>
		public IQueryable<TEntity> LoadPagerEntities<S>(int pageSize, int pageIndex, out int total,
			Expression<Func<TEntity, bool>> whereExpress, bool isAsc, Func<TEntity, S> orderByLambda)
		{
			try
			{
				var tempData = db.Set<TEntity>().Where(whereExpress);

				total = tempData.Count();

				// 排序获取当前页的数据
				if (isAsc)
				{
					tempData = tempData.OrderBy(orderByLambda).
								  Skip(pageSize * (pageIndex - 1)).
								  Take(pageSize).AsQueryable();
				}
				else
				{
					tempData = tempData.OrderByDescending(orderByLambda).
								 Skip(pageSize * (pageIndex - 1)).
								 Take(pageSize).AsQueryable();
				}
				return tempData.AsQueryable();
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message, ex);
				throw ex;
			}
		}
	}
}
