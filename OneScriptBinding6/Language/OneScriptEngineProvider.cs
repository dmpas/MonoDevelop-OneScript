using System;
using System.IO;

namespace OneScript.MonoBinding
{
	public interface IEngineProvider
	{
		Stream GetStandaloneExeStream();
		object CreateEngine();
	}
}
