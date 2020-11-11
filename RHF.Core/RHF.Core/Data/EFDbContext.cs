using RHF.Core.Util;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Data.Entity;

namespace RHF.Core.Data
{
	/// <summary>
	/// 
	/// </summary>
	[Export("EF", typeof(DbContext))]
	public class EFDbContext : DbContext
	{
		/// <summary>
		/// 取得解码后数据库连接字符串并创建数据库连接
		/// </summary>
		public EFDbContext()
			: base(GetEFConnctionString(false))
		{
		}

		/// <summary>
		/// 取得解码后数据库连接字符串并创建数据库连接
		/// </summary>
		/// <param name="isEncrypt"></param>
		public EFDbContext(bool isEncrypt)
			: base(GetEFConnctionString(isEncrypt))
		{
		}

		private static string EFConnctionString { get; set; }

		/// <summary>
		/// 对数据库连接字符串的加解密处理
		/// </summary>
		/// <param name="isEncrypt"></param>
		/// <returns>解码后的数据库连接字符串</returns>
		private static string GetEFConnctionString(bool isEncrypt)
		{
			if (!string.IsNullOrEmpty(EFConnctionString))
			{
				return EFConnctionString;
			}

			if (isEncrypt)
			{
				// DES解码处理
				EFConnctionString = string.Format(ConfigurationManager.AppSettings["EFConnectionMetadata"],
												EncryptHelper.DESDecrypt(ConfigurationManager.AppSettings["ConnectionString"]));
			}
			else
			{
				EFConnctionString = string.Format(ConfigurationManager.AppSettings["EFConnectionMetadata"],
												ConfigurationManager.AppSettings["ConnectionString"]);
			}
			return EFConnctionString;
		}
	}
}
