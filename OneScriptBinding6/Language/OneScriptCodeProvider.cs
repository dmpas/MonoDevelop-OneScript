using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using System.Reflection;
using System.CodeDom.Compiler;
using System.Linq;

namespace OneScript.MonoBinding
{
	public class CodeProvider : System.CodeDom.Compiler.CodeDomProvider 
	{
		public const string LanguageName = "OneScript";
		
		public string Language {
			get {
				return LanguageName;
			}
		}
		
		public string ProjectStockIcon {
			get { 
				return "md-project";
			}
		}
		
        public bool IsSourceCodeFile (MonoDevelop.Core.FilePath fileName)
		{
			return Path.GetExtension(fileName) == ".os";
		}
		
		public string SingleLineCommentTag { get { return "//"; } }
		public string BlockCommentStartTag { get { return "/*"; } }
		public string BlockCommentEndTag { get { return "*/"; } }
	
        public MonoDevelop.Core.FilePath GetFileName (MonoDevelop.Core.FilePath baseName)
		{
			return baseName + ".os";
		}

		public override CompilerResults CompileAssemblyFromFile(CompilerParameters options, params string[] fileNames)
		{
			return OneScriptCompilerService.CompileAssemblyFromFile(options, fileNames);
		}

		public override CompilerResults CompileAssemblyFromSource(CompilerParameters options, params string[] sources)
		{
			throw new NotImplementedException();
		}

		[Obsolete]
		public override ICodeGenerator CreateGenerator()
		{
			return new OneScriptCodeGenerator();
		}

		[Obsolete]
		public override ICodeCompiler CreateCompiler()
		{
			throw new Exception("Should not be used!");
		}
	}
}
