using ds.test.impl;
using System;
using System.Drawing;

namespace SpaceShipTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //here are created 6 objects. One for every plugin
            PlusPlugin plusPlugin = new PlusPlugin("PlusPlugin","1.0",
                Image.FromFile("image.png"),"PlusPlugin description");

            MinusPlugin minusPlugin = new MinusPlugin("MinusPlugin", "1.0",
                Image.FromFile("image.png"), "MinusPlugin description");

            DividePlugin dividePlugin = new DividePlugin("DividePlugin", "1.0",
                Image.FromFile("image.png"), "DividePlugin description");

            MultiplyPlugin multiplyPlugin = new MultiplyPlugin("MultiplyPlugin", "1.0",
                Image.FromFile("image.png"), "MultiplyPlugin description");

            PowPlugin powPlugin = new PowPlugin("PowPlugin", "1.0",
                Image.FromFile("image.png"), "PowPlugin description");

            RemainderPlugin remainderPlugin = new RemainderPlugin("RemainderPlugin", "1.0",
                Image.FromFile("image.png"), "RemainderPlugin description");

            // array for checking if Run() implementations in different plugins works properly
            int[] resultArray = new int[6];
            resultArray[0] = plusPlugin.Run(5,5);
            resultArray[1] = minusPlugin.Run(5, 5);
            resultArray[2] = dividePlugin.Run(5, 5);
            resultArray[3] = multiplyPlugin.Run(5, 5);
            resultArray[4] = powPlugin.Run(5, 5);
            resultArray[5] = remainderPlugin.Run(5, 5);
            // displaying of results
            foreach (int i in resultArray)
                Console.WriteLine(i);

            // checking if function for searching for a plugin in the list works correctly
            Console.WriteLine(Plugins.GetPlugin("PowPlugin").Description);
            // checking if counter contains all of the created plugins
            Console.WriteLine(Plugins.PluginsCount);
            // checking if all of the objects are in the list
            foreach (IPlugin plugin in Plugins.pluginsList)
                Console.WriteLine(plugin.Description);
            //checking if all of the plugin names are in the list
            foreach (string str in Plugins.GetPluginNames)
                Console.WriteLine(str);
        }
        // base class in which specified common fields for all future plugins
        private abstract class BasePlugin : IPlugin
        {
            // constructor which assignes specified data in fields and interact with static fields in Plugins class:
            // incrementes counter, puts the name and the object in the lists
            public BasePlugin(string pluginName, string version, Image image,
                string description)
            {
                PluginName = pluginName;
                Version = version;
                Image = image;
                Description = description;
                Plugins.PluginsCount++;
                Plugins.pluginsList.Add(this);
                Plugins.GetPluginNames.Add(this.PluginName);
            }
            public string PluginName { get; set; }
            public string Version { get; set; }
            public Image Image { get; set; }
            public string Description { get; set; }
            // method is available for override that lets create plugins with own implementation
            public abstract int Run(int input1, int input2);
        }
        // here are described 6 plugins with different Run() implementations
        // all of them use constructor from base class
        private class PlusPlugin : BasePlugin, IPlugin
        {
            public PlusPlugin(string pluginName, string version, Image image,
                string description) : base(pluginName, version, image, description)
            {

            }
            public override int Run(int input1, int input2)
            {
                return input1 + input2;
            }
        }
        private class MinusPlugin : BasePlugin, IPlugin
        {
            public MinusPlugin(string pluginName, string version, Image image,
                string description) : base(pluginName, version, image, description)
            {
            }
            public override int Run(int input1, int input2)
            {
                return input1 - input2;
            }
        }
        private class DividePlugin : BasePlugin, IPlugin
        {
            public DividePlugin(string pluginName, string version, Image image,
                string description) : base(pluginName, version, image, description)
            {
            }
            public override int Run(int input1, int input2)
            {
                return input1 / input2;
            }
        }
        private class MultiplyPlugin : BasePlugin, IPlugin
        {
            public MultiplyPlugin(string pluginName, string version, Image image,
                string description) : base(pluginName, version, image, description)
            {
            }
            public override int Run(int input1, int input2)
            {
                return input1 * input2;
            }
        }
        private class PowPlugin : BasePlugin, IPlugin
        {
            public PowPlugin(string pluginName, string version, Image image,
                string description) : base(pluginName, version, image, description)
            {
            }
            public override int Run(int input1, int input2)
            {
                return Convert.ToInt32(Math.Pow(input1,input2));
            }
        }
        private class RemainderPlugin : BasePlugin, IPlugin
        {
            public RemainderPlugin(string pluginName, string version, Image image,
                string description) : base(pluginName, version, image, description)
            {
            }
            public override int Run(int input1, int input2)
            {
                return input1 % input2;
            }
        }
    }
}