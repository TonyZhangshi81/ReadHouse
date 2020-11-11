using Common.Logging;
using RHF.Core.Composition.MetaData;
using RHF.Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Common;
using System.Linq;

namespace RHF.Business.Common.DataBase
{
	/// <summary>
	/// 
	/// </summary>
	[Export(typeof(IDbSession))]
	public partial class DbSession : IDbSession
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(DbSession));

		/// <summary>
		/// 
		/// </summary>
		[Import(typeof(IEFContextFactory))]
		private EFContextFactory EFContextFactory { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ImportMany(RequiredCreationPolicy = CreationPolicy.NonShared)]
		public IEnumerable<Lazy<IRepositoryMetaType, ITableNameMetaData>> EntityRepositories
		{
			get;
			set;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="tableName"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public virtual T GetRepository<T>(string tableName)
		{
			try
			{
				var repositories = this.EntityRepositories.Where(_ => _.Metadata.TableName.Equals(tableName));
				if (repositories.Count() == 0)
				{
					throw new NotImplementedException();
				}
				var type = repositories.First().Value.GetType();
				Log.Info(type.Name + "被实例化");

				return (T)Activator.CreateInstance(type);
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message, ex);
				throw ex;
			}
		}

		/// <summary>
		/// 代表当前应用程序跟数据库的回话内所有的实体变化，更新会数据库(UintWork单元工作模式)
		/// </summary>
		/// <returns></returns>
		public int SaveChanges()
		{
			try
			{
				// 调用EF上下文的SaveChanges的方法
				return EFContextFactory.CurrentDbContext.SaveChanges();
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message, ex);
				throw ex;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="strSql"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		public int ExcuteSql(string strSql, DbParameter[] parameters)
		{
			//return EFContextFactory.GetCurrentDbContext().ExecuteFunction(strSql, parameters);
			throw new NotImplementedException();
		}
	}
}
