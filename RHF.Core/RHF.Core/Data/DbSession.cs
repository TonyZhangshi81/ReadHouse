using Common.Logging;
using RHF.Core.Composition;
using RHF.Core.Composition.MetaData;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Common;
using System.Linq;

namespace RHF.Core.Data
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
		public IEnumerable<Lazy<IRepositoryMetaType, IRepositoryMetaData>> EntityRepositories
		{
			get;
			set;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public virtual T GetRepository<T>()
		{
			try
			{
				var repositories = this.EntityRepositories.Where(_ => _.Metadata.Repository.Name.Equals(typeof(T).Name));
				if (repositories.Count() == 0)
				{
					throw new NotImplementedException();
				}
				Log.Info(typeof(T) + "被实例化");

				return (T)repositories.First().Value;
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
		public int Commit(bool validateOnSaveEnabled = true)
		{
			bool isReturn = EFContextFactory.CurrentDbContext.Configuration.ValidateOnSaveEnabled != validateOnSaveEnabled;
			try
			{
				EFContextFactory.CurrentDbContext.Configuration.ValidateOnSaveEnabled = validateOnSaveEnabled;
				// 调用EF上下文的SaveChanges的方法
				return EFContextFactory.CurrentDbContext.SaveChanges();
			}
			catch (Exception ex)
			{
				Log.Error(ex);
				throw ex;
			}
			finally
			{
				if (isReturn)
				{
					EFContextFactory.CurrentDbContext.Configuration.ValidateOnSaveEnabled = !validateOnSaveEnabled;
				}
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
