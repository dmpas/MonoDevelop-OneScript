//  OneScriptLanguageBinding.cs
//
// 2015         Sergey "dmpas" Batanov (sergey.batanov@dmpas.ru)


using System;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Xml;

namespace OneScript.MonoBinding
{
    public class LanguageBinding : MonoDevelop.Projects.ILanguageBinding
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
	
	}
}
