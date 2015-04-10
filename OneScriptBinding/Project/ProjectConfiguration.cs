using System;

namespace OneScript.MonoBinding
{
    public class ProjectConfiguration : MonoDevelop.Projects.ProjectConfiguration
    {
        public ProjectConfiguration()
        {
        }

        public ProjectConfiguration(string name)
        {
            Name = name;
        }
    }
}

