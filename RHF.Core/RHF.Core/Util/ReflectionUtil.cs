using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace RHF.Core.Util
{
	/// <summary>
	/// 
	/// </summary>
	public static class ReflectionUtil
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="assembly"></param>
		/// <returns></returns>
		public static IEnumerable<Assembly> GetReferencedAssemblies(Assembly assembly)
		{
			yield return assembly;

			foreach (var an in assembly.GetReferencedAssemblies())
			{
				var target = GetAssembly(an);
				if (target != null)
				{
					foreach (var asm in GetReferencedAssemblies(target))
					{
						yield return asm;
					}
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="assemblyName"></param>
		/// <returns></returns>
		public static Assembly GetAssembly(AssemblyName assemblyName)
		{
			if (!assemblyName.FullName.StartsWith("RHF."))
			{
				return null;
			}

			var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(asm => asm.GetName().Name.Equals(assemblyName.Name));
			if (assembly != null)
			{
				return assembly;
			}

			var basePath = AppDomain.CurrentDomain.BaseDirectory;
			var dllName = assemblyName.Name + ".dll";
			if (!File.Exists(Path.Combine(basePath, dllName)))
			{
				basePath = Path.Combine(basePath, "bin");
			}
			var dllPath = Path.Combine(basePath, dllName);
			return File.Exists(dllPath) ? AppDomain.CurrentDomain.Load(assemblyName) : null;
		}
	}
}
