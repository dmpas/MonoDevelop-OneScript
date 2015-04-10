using System;
using MonoDevelop.Projects;

namespace OneScript.MonoBinding
{
    public class OneScriptProjectConfiguration : ProjectConfiguration
    {
        public OneScriptProjectConfiguration()
        {
        }

        public OneScriptProjectConfiguration(string name)
        {
            Name = name;
        }
    }
}

