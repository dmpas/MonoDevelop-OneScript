using System;
using Mono.Addins;
using Mono.Addins.Description;

[assembly:Addin ("OneScriptBinding", 
	Namespace = "OneScript",
	Version = "0.1.0",
	Category = "Language bindings")]

[assembly:AddinName ("OneScript Language Binding")]
[assembly:AddinDescription ("OneScript Language Binding")]

[assembly:AddinDependency ("::MonoDevelop.Core", MonoDevelop.BuildInfo.Version)]
[assembly:AddinDependency ("::MonoDevelop.Ide", MonoDevelop.BuildInfo.Version)]
[assembly:AddinDependency ("::MonoDevelop.SourceEditor2", MonoDevelop.BuildInfo.Version)]
