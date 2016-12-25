using System;
using System.Linq;
using MonoDevelop.Core;
using MonoDevelop.Projects;

namespace OneScript.MonoBinding
{
	public class OneScriptProject : MonoDevelop.Projects.DotNetProject
	{
		public OneScriptProject()
		{
		}

		protected override BuildResult OnCompileSources(ProjectItemCollection items, DotNetProjectConfiguration configuration, ConfigurationSelector configSelector, MonoDevelop.Core.ProgressMonitor monitor)
		{
			monitor.Log.WriteLine("Starting...");
			var fileNames = items.OfType<ProjectFile>().Select((ProjectFile arg) => arg.FilePath.ToString()).ToArray();
			var options = new System.CodeDom.Compiler.CompilerParameters();
			options.OutputAssembly = configuration.CompiledOutputName.ToString();
			var compileResult = OneScriptCompilerService.CompileAssemblyFromFile(options, fileNames);

			monitor.Log.WriteLine("Done!");

			return new BuildResult(compileResult, null);
		}


		protected override DotNetCompilerParameters OnCreateCompilationParameters(DotNetProjectConfiguration config, ConfigurationKind kind)
		{
			var parameters = new OneScriptCompilerParameters();
			return parameters;
		}

		protected override ClrVersion[] OnGetSupportedClrVersions()
		{
			return new ClrVersion[] { ClrVersion.Net_4_0, ClrVersion.Net_4_5 };
		}
	}
}

