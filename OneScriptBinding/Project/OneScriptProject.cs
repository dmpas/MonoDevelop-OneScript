using System;
using MonoDevelop.Projects;


namespace OneScript.MonoBinding
{
    public class OneScriptProject : Project
    {
        private const string ProjectTypeName = "OneScript";

        public OneScriptProject()
        {
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
    }
}

