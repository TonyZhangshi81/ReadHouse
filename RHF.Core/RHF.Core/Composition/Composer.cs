using RHF.Core.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;

namespace RHF.Core.Composition
{
	/// <summary>
	/// 基于MEF框架的依赖管理对象
	/// </summary>
	public class Composer : IDisposable
	{
		private readonly CompositionContainer _container;

		/// <summary>
		/// 指定一个程序集，并获取此程序集中所有组件定义，通过组合容器实现组件组合
		/// </summary>
		public Composer(Assembly assembly)
		{
			// 创建组件目录（包含4中Catalog）
			var catalog = new AggregateCatalog();
			var cache = new List<Assembly>();

			// 遍历此程序集引用的所有程序集的assembly对象，并获取其中所有组件定义
			foreach (var asm in ReflectionUtil.GetReferencedAssemblies(assembly))
			{
				foreach (var a in this.GetPriorAssemblyNames(assembly))
				{
					// 为防止相同程序集重复加载组件目录
					if (!cache.Contains(a))
					{
						// 加载组件目录
						catalog.Catalogs.Add(new AssemblyCatalog(a));
						cache.Add(a);
					}
				}

				// 为防止相同程序集重复加载组件目录
				if (!cache.Contains(asm))
				{
					// 加载组件目录
					catalog.Catalogs.Add(new AssemblyCatalog(asm));
					cache.Add(asm);
				}
			}

			// 创建组合容器
			this._container = new CompositionContainer(catalog, true);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="assembly"></param>
		/// <returns></returns>
		private IEnumerable<Assembly> GetPriorAssemblyNames(Assembly assembly)
		{
			foreach (var name in assembly.GetCustomAttributes(false).OfType<ComposerAttribute>().Select(attr => attr.Name))
			{
				var asm = ReflectionUtil.GetAssembly(name);
				if (asm != null)
				{
					yield return asm;
					foreach (var a in this.GetPriorAssemblyNames(asm))
					{
						yield return a;
					}
				}
			}
		}

		/// <summary>
		/// 执行组合
		/// </summary>
		/// <param name="target"></param>
		public void ComposeParts(object target)
		{
			// 对指定对象创建一个可组合部件
			var part = AttributedModelServices.CreatePart(target);
			// 此部件中是否有导入对象
			if (part.ImportDefinitions.Any())
			{
				// 对导入导出组件的重新组合
				this._container.SatisfyImportsOnce(part);
			}
		}

		~Composer()
		{
			(this as IDisposable).Dispose();
		}

		/// <summary>
		/// 
		/// </summary>
		void IDisposable.Dispose()
		{
			if (this._container != null)
			{
				this._container.Dispose();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="contractName"></param>
		/// <returns></returns>
		public IEnumerable<Lazy<T>> GetExports<T>(string contractName)
		{
			return this._container.GetExports<T>(contractName);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="contractName"></param>
		/// <returns></returns>
		public IEnumerable<Lazy<T>> GetExports<T>()
		{
			return this._container.GetExports<T>();
		}
	}
}
