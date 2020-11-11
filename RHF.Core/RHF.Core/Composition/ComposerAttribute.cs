using System;
using System.Reflection;

namespace RHF.Core.Composition
{
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
	public sealed class ComposerAttribute : Attribute
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		public ComposerAttribute(string name)
		{
			this.Name = new AssemblyName(name);
		}

		/// <summary>
		/// 
		/// </summary>
		public AssemblyName Name
		{
			get;
			private set;
		}
	}
}
