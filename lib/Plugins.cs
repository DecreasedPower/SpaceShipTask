using System;
using System.Collections.Generic;

namespace ds.test.impl
{
    // class with fields 
    public static class Plugins
    {
        // counter of all created plugins
        private static int? pluginsCount = null;
        // property for counter 
        public static int? PluginsCount
        {
            get
            {
                return pluginsCount;
            }
            set
            {
                if (pluginsCount == null)
                    pluginsCount = 1;
                else
                    pluginsCount++;
            }
        }
        // list of plugins names. When plugin was created, its name comes here
        public static List<string> GetPluginNames= new List<string>();
        // list of created plugins
        public static List<IPlugin> pluginsList = new List<IPlugin>();
        // method for searching in the list for plugin by its name
        // if there is a plugin with specified name method will return it
        // if no method will throw an exception
        public static IPlugin GetPlugin(string pluginName) 
        {
            IPlugin result = null;
            foreach (IPlugin plugin in pluginsList)
            {
                if (plugin.PluginName == pluginName)
                    result = plugin;
            }
            if (result != null)
                return result;
            else
                throw new Exception("There is no plugin with such name");
        }
    }
}