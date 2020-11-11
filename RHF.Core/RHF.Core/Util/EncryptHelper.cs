using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RHF.Core.Util
{
	/// <summary>
	/// 
	/// </summary>
	public class EncryptHelper
	{
		/// <summary>
		/// 提供8个字符作为DES密钥（程序自动截取前8个字符） 
		/// </summary>
		private static string key = "1234567890";

		/// <summary>
		/// DES对称加密解密的密钥
		/// </summary>
		public static string Key
		{
			get
			{
				return key;
			}
			set
			{
				key = value;
			}
		}

		/// <summary>
		/// MD5 加密（不可逆加密）
		/// </summary>
		/// <param name="pass">要加密的原始字串</param>
		/// <returns>密文</returns>
		public static string MD5Encrypt(string pass)
		{
			var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
			var bytResult = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass));
			md5.Clear();

			var strResult = BitConverter.ToString(bytResult).Replace("-", "");
			return strResult;
		}

		/// <summary>
		/// SHA1 加密（不可逆加密）
		/// </summary>
		/// <param name="pass">要加密的原始字串</param>
		/// <returns>密文</returns>
		public static string SHA1Encrypt(string pass)
		{
			var sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
			var bytResult = sha1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass));
			sha1.Clear();

			var strResult = BitConverter.ToString(bytResult).Replace("-", string.Empty);
			return strResult;
		}

		/// <summary>
		/// DES加密字符串
		/// </summary>
		/// <param name="encryptString">待加密的字符串</param>
		/// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
		public static string DESEncrypt(string encryptString)
		{
			try
			{
				var rgbKey = Encoding.UTF8.GetBytes(key.Substring(0, 8));
				var rgbIV = rgbKey;
				var inputByteArray = Encoding.UTF8.GetBytes(encryptString);
				var dCSP = new DESCryptoServiceProvider();
				var mStream = new MemoryStream();
				var cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
				cStream.Write(inputByteArray, 0, inputByteArray.Length);
				cStream.FlushFinalBlock();
				cStream.Close();
				return Convert.ToBase64String(mStream.ToArray());
			}
			catch
			{
				return encryptString;
			}
		}

		/// <summary>
		/// DES解密字符串
		/// </summary>
		/// <param name="decryptString">待解密的字符串</param>
		/// <returns>解密成功返回解密后的字符串，失败返源串</returns>
		public static string DESDecrypt(string decryptString)
		{
			try
			{
				var rgbKey = Encoding.UTF8.GetBytes(key.Substring(0, 8));
				var rgbIV = rgbKey;
				var inputByteArray = Convert.FromBase64String(decryptString);
				var DCSP = new DESCryptoServiceProvider();
				var mStream = new MemoryStream();
				var cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
				cStream.Write(inputByteArray, 0, inputByteArray.Length);
				cStream.FlushFinalBlock();
				cStream.Close();
				return Encoding.UTF8.GetString(mStream.ToArray());
			}
			catch
			{
				return decryptString;
			}
		}

		/// <summary>
		/// 将普通字符串编码为BASE64字串
		/// </summary>
		/// <param name="str">源字符串</param>
		/// <returns>BASE64字串</returns>
		public static string Base64Encode(string str)
		{
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
		}

		/// <summary>
		/// 解码BASE64字串
		/// </summary>
		/// <param name="base64Str">Base64字串</param>
		/// <returns>源码</returns>
		public static string Base64Decode(string base64Str)
		{
			return Encoding.UTF8.GetString(Convert.FromBase64String(base64Str));
		}
	}
}
