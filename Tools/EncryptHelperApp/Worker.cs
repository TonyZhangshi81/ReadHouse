using RHF.Core.Util;
using System.Text;

namespace EncryptHelperApp
{
	public class Worker
	{
		/// <summary>
		/// 
		/// </summary>
		private string ConnnectString
		{
			get;
			set;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="connStr"></param>
		public Worker(string connStr)
		{
			this.ConnnectString = connStr;
		}

		/// <summary>
		/// 
		/// </summary>
		public void ToWrite()
		{
			string enString = EncryptHelper.DESEncrypt(this.ConnnectString);
			System.IO.File.WriteAllText(@"ConnnectString.txt", enString, Encoding.Default);
		}
	}
}
