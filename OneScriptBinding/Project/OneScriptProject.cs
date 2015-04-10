using System;

namespace OneScript.MonoBinding
{
    public class OneScriptProject : MonoDevelop.Projects.Project
    {
        private const string ProjectTypeName = "OneScript";

        public OneScriptProject()
        {
        }

        public OneScriptProject(string DefaultConfiguration)
        {
            Configurations.Add(CreateConfiguration(DefaultConfiguration));
        }

        public override System.Collections.Generic.IEnumerable<string> GetProjectTypes()
        {
            var typeList = new System.Collections.Generic.List<string>();
            typeList.Add(ProjectTypeName);
            return typeList;
        }

        public override bool IsCompileable(string file_name)
        {
            return false;
        }

        public override MonoDevelop.Projects.SolutionItemConfiguration CreateConfiguration( string name )
        {
            return new ProjectConfiguration( name );
        }
    }
}

