using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;

namespace OneScript.MonoBinding
{
	public class OneScriptCompilerService
	{
		public OneScriptCompilerService()
		{
		}

		public static CompilerResults CompileAssemblyFromFile(CompilerParameters options, params string[] fileNames)
		{
			var result = new CompilerResults(new TempFileCollection());
			var engine = new ScriptEngine.HostedScript.HostedScriptEngine();
			engine.Initialize();
			var compilerService = engine.GetCompilerService();
			// TODO: Применить options

			var modules = new List<ScriptEngine.Environment.ScriptModuleHandle>();
			var compiled = true;

			foreach (var fileName in fileNames)
			{
				var codeSource = engine.Loader.FromFile(fileName);
				try
				{
					var module = compilerService.CreateModule(codeSource);
					modules.Add(module);
				}
				catch (Exception exc)
				{
					var error = new CompilerError(fileName, 1, 1, "", exc.Message);
					result.Errors.Add(error);
					compiled = false;
				}
			}

			if (!compiled)
			{
				return result;
			}

			var exePath = options.OutputAssembly;
			using (var output = new FileStream(exePath, FileMode.Create))
			{
				using (var exeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("OneScript.MonoBinding.StandaloneRunner.exe"))
				{
					exeStream.CopyTo(output);
				}
				var offset = (int)output.Length;

				var embeddedContext = engine.GetUserAddedScripts();
				using (var modulesDataWriter = new BinaryWriter(output))
				{
					modulesDataWriter.Write(embeddedContext.Count() + 1);
					var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
					var persistor = new ScriptEngine.Compiler.ModulePersistor(formatter);
					persistor.Save(new ScriptEngine.UserAddedScript()
					{
						Type = ScriptEngine.UserAddedScriptType.Module,
						Symbol = "$entry",
						Module = modules[0] // TODO: Внятно определять точку входа
					}, output);

					foreach (var item in embeddedContext)
					{
						persistor.Save(item, output);
					}

					// Magic "OSMD"
					var signature = new byte[4] { 0x4f, 0x53, 0x4d, 0x44 };
					output.Write(signature, 0, signature.Length);

					modulesDataWriter.Write(offset);
				}
			}

			result.PathToAssembly = exePath;
			result.Output.Add("Compile complete!");

			return result;
		}
	}
}
