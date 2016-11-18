using System;
using MonoDevelop.Ide.TypeSystem;
using MonoDevelop.Ide.Editor;

namespace OneScript.MonoBinding
{
	public class OneScriptFoldingParser : IFoldingParser
	{

		private ParsedDocument IdiotParse(string fileName, string content)
		{
			var result = new DefaultParsedDocument(fileName);
			int beginLine = 0;
			string foldTitle = "";

			var lines = content.Split('\n');
			for (int linenum = 0; linenum < lines.Length; ++linenum)
			{
				var line = lines[linenum];
				var t_line = line.Trim();

				int i;

				i = line.IndexOf("Процедура", StringComparison.InvariantCultureIgnoreCase);
				if (i != -1 && beginLine == 0)
				{
					beginLine = linenum;
					foldTitle = t_line;
				}

				i = line.IndexOf("КонецПроцедуры", StringComparison.InvariantCultureIgnoreCase);
				if (i != -1 && beginLine != 0)
				{
					var begin = new DocumentLocation(beginLine + 1, 1);
					var end = new DocumentLocation(linenum + 1, line.Length);
					result.Add(new FoldingRegion(foldTitle, new DocumentRegion(begin, end)));
					beginLine = 0;
				}
			}

			return result;
		}

		public ParsedDocument Parse(string fileName, string content)
		{
			return IdiotParse(fileName, content);
		}
	}
}
