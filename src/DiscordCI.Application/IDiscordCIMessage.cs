using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordCI.Application
{
	public interface IDiscordCIMessage
	{
		string Message { get; }
	}
}
