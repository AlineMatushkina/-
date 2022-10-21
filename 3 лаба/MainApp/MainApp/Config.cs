using System.Collections.Generic;
using System.Configuration;
using System.Xml;

namespace MainApp
{
    public class PluginsPath : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            List<Plugin> Plugins = new List<Plugin>();
            foreach (XmlNode childNode in section.ChildNodes)
            {
                foreach (XmlAttribute attrib in childNode.Attributes)
                {
                    Plugins.Add(new Plugin() { Path = attrib.Value });
                }
            }
            return Plugins;
        }
    }

    public class Plugin
    {
        public string Path { get; set; }
    }
}
