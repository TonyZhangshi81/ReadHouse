using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHF.Core.BusinessLogic
{
	public interface ILogic : IDisposable
	{
		void Execute(LogicParameterBase param);
	}
}
