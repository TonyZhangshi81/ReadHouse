using System.ComponentModel.Composition;
using System.Runtime.Remoting.Messaging;

namespace RHF.Core.Data
{
	/// <summary>
	/// 
	/// </summary>
	[Export(typeof(IEFContextFactory))]
	public partial class EFContextFactory : IEFContextFactory
	{
		/// <summary>
		/// 
		/// </summary>
		private readonly EFDbContext _context;

		/// <summary>
		/// 
		/// </summary>
		[ImportingConstructor]
		public EFContextFactory()
		{
			// 当第二次执行的时候直接取出线程嘈里面的对象
			// CallContext:是线程内部唯一的独用的数据槽(一块内存空间)
			// 数据存储在线程栈中
			// 线程内共享一个单例
			var dbcontext = CallContext.GetData("DbContext") as EFDbContext;

			// 判断线程里面是否有数据(线程的数据槽里面没有次上下文)
			if (dbcontext == null)
			{
				_context = new EFDbContext(true);
				// 存储指定对象
				CallContext.SetData("DbContext", _context);
			}
			_context = CallContext.GetData("DbContext") as EFDbContext;
		}

		/// <summary>
		/// 帮我们返回当前线程内的数据库上下文，如果当前线程内没有上下文，那么创建一个上下文，并保证
		/// 上下文是实例在线程内部唯一 
		/// 在EF4.0以前使用ObjectsContext对象
		/// </summary>
		/// <returns></returns>
		public EFDbContext CurrentDbContext
		{
			get
			{
				return CallContext.GetData("DbContext") as EFDbContext;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static EFDbContext GetCurrentDbContext()
		{
			var factory = new EFContextFactory();
			return factory._context;
		}
	}
}
