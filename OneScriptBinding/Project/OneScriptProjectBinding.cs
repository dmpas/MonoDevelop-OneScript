using System;
using System.Xml;
using System.IO;
using MonoDevelop.Projects;

namespace OneScript.MonoBinding
{
    public class OneScriptProjectBinding : IProjectBinding
    {

        public string Name {
            get { return "OneScript"; }
        }
               public Project CreateProject (ProjectCreateInformation info, XmlElement project_options)
        {
            return new OneScriptProject("Default");
        }

        public Project CreateSingleFileProject (string source_file)
        {
            return new OneScriptProject("Default");
        }

        public bool CanCreateSingleFileProject (string source_file)
        {
            return Path.GetExtension(source_file) == "os";
        }
    }
}

