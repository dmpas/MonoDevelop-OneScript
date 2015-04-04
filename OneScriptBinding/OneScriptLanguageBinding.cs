//  OneScriptLanguageBinding.cs
//
// 2015         Sergey "dmpas" Batanov (sergey.batanov@dmpas.ru)


using System;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Xml;

using MonoDevelop.Projects;
using MonoDevelop.Core;

namespace OneScript.MonoBinding
{
    public class OneScriptLanguageBinding : ILanguageBinding
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
		
		public bool IsSourceCodeFile (FilePath fileName)
		{
			return Path.GetExtension(fileName) == ".os";
		}
		
		public string SingleLineCommentTag { get { return "//"; } }
		public string BlockCommentStartTag { get { return "/*"; } }
		public string BlockCommentEndTag { get { return "*/"; } }
	
		public FilePath GetFileName (FilePath baseName)
		{
			return baseName + ".os";
		}   
	
	}
}
