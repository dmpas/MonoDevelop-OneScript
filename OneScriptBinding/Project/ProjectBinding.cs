using System;
using System.Xml;
using System.IO;

namespace OneScript.MonoBinding
{
    public class ProjectBinding : MonoDevelop.Projects.IProjectBinding
    {

        public string Name {
            get { return "OneScript"; }
        }

        public MonoDevelop.Projects.Project CreateProject (MonoDevelop.Projects.ProjectCreateInformation info, XmlElement project_options)
        {
            return new OneScriptProject("Default");
        }

        public MonoDevelop.Projects.Project CreateSingleFileProject (string source_file)
        {
            return new OneScriptProject("Default");
        }

        public bool CanCreateSingleFileProject (string source_file)
        {
            return Path.GetExtension(source_file) == "os";
        }
    }
}

