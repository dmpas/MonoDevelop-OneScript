using System;
using System.Threading.Tasks;
using MonoDevelop.Core;
using MonoDevelop.Projects;

namespace OneScript.MonoBinding
{
	public class OneScriptProjectFactory : SolutionItemFactory
    {
        private const string ProjectTypeName = "OneScript";

		public OneScriptProjectFactory()
		{
		}

		public override Task<SolutionItem> CreateItem(string fileName, string typeGuid)
		{
			throw new NotImplementedException();
		}
	}
}

