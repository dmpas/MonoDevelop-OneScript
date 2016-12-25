using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using ScriptEngine.Compiler;

namespace OneScript.MonoBinding
{
	public class OneScriptCodeGenerator : ICodeGenerator
	{
		public OneScriptCodeGenerator()
		{
		}

		public string CreateEscapedIdentifier(string value)
		{
			return value;
		}

		public string CreateValidIdentifier(string value)
		{
			return value;
		}

		public void GenerateCodeFromCompileUnit(CodeCompileUnit e, TextWriter w, CodeGeneratorOptions o)
		{
			throw new NotImplementedException();
		}

		public void GenerateCodeFromExpression(CodeExpression e, TextWriter w, CodeGeneratorOptions o)
		{
			throw new NotImplementedException();
		}

		public void GenerateCodeFromNamespace(CodeNamespace e, TextWriter w, CodeGeneratorOptions o)
		{
			throw new NotImplementedException();
		}

		public void GenerateCodeFromStatement(CodeStatement e, TextWriter w, CodeGeneratorOptions o)
		{
			throw new NotImplementedException();
		}

		public void GenerateCodeFromType(CodeTypeDeclaration e, TextWriter w, CodeGeneratorOptions o)
		{
			throw new NotImplementedException();
		}

		public string GetTypeOutput(CodeTypeReference type)
		{
			throw new NotImplementedException();
		}

		public bool IsValidIdentifier(string value)
		{
			// TODO: OneScript.IsValidIdentifier 
			return true;
		}

		public bool Supports(GeneratorSupport supports)
		{
			return false;
		}

		public void ValidateIdentifier(string value)
		{
			throw new NotImplementedException();
		}
	}
}
