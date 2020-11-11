using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace RHF.Core.Composition
{
	/// <summary>
	/// 创建并获取依赖管理对象的类
	/// </summary>
	public static class ComposerFactory
	{
		/// <summary>
		/// 依赖管理对象集合（每个指定程序集的依赖管理关系）
		/// </summary>
		/// <remarks>关于程序集加载Assembly类的说明 <see cref="http://www.cnblogs.com/heyuquan/archive/2012/03/31/2427535.html"/></remarks>
		private static readonly ConcurrentDictionary<Assembly, Composer> ComposerCache;

		/// <summary>
		/// 类实例化
		/// </summary>
		static ComposerFactory()
		{
			// 依赖管理对象集合实例化
			ComposerCache = new ConcurrentDictionary<Assembly, Composer>();
		}

		/// <summary>
		/// 对指定程序集的依赖管理对象装入集合
		/// </summary>
		/// <param name="assembly"></param>
		/// <returns></returns>
		public static Composer GetComposer(Assembly assembly)
		{
			// 此集合众是否存在指定的程序集
			if (ComposerCache.ContainsKey(assembly))
			{
				Composer composer;
				// 在集合中取得此指定程序集的依赖管理对象并返回
				if (ComposerCache.TryGetValue(assembly, out composer))
				{
					return composer;
				}
			}
			// 在集合中添加此指定程序集的依赖管理对象并返回
			return ComposerCache.GetOrAdd(assembly, new Composer(assembly));
		}

		private static readonly object Sync = new object();

		/// <summary>
		/// 
		/// </summary>
		internal static void Reset()
		{
			lock (Sync)
			{
				foreach (var keyValue in ComposerCache)
				{
					var value = keyValue.Value as IDisposable;
					if (value != null)
					{
						value.Dispose();
					}
				}
				ComposerCache.Clear();
			}
		}
	}
}
